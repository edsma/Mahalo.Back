using Mahalo.Back.Data;
using Mahalo.Back.Helpers;
using Mahalo.Back.UnitsOfWork.Interfaces;
using Mahalo.Shared.DTOs;
using Mahalo.Shared.Entities;
using Mahalo.Shared.Response;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.Metrics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Mahalo.Back.Controllers;

[ApiController]
[Route("/api/accounts")]
public class AccountsController : ControllerBase
{
    private readonly IUsersUnitOfWork _usersUnitOfWork;
    private readonly IConfiguration _configuration;
    private readonly IMailHelper _mailHelper;
    private readonly DataContext _context;
    private readonly IFileStorage _fileStorage;

    public AccountsController(IUsersUnitOfWork usersUnitOfWork, IConfiguration configuration,
        IMailHelper mailHelper, DataContext context,
        IFileStorage fileStorage)
    {
        _usersUnitOfWork = usersUnitOfWork;
        _configuration = configuration;
        _mailHelper = mailHelper;
        _context = context;
        _fileStorage = fileStorage;
    }

    [HttpPost("CreateUser")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO model)
    {
        City country = await _context.Cities.FindAsync(model.CityId)?? new City();
        User user = new User { 
            Email = model.Email,
            FirstName = model.FirstName,
            IsActive = true,
            LastName = model.LastName,
            UserName = model.UserName,
            City = country
        };
        var result = await _usersUnitOfWork.AddUserAsync(user, model.Password);
        if (result.Succeeded)
        {
            await _usersUnitOfWork.AddUserToRoleAsync(user, user.UserType.ToString());
            var response = await SendConfirmationEmailAsync(user, model.Language);
            if (response.WasSuccess)
            {
                return NoContent();
            }

            return BadRequest(response.Message);
        }

        return BadRequest(result.Errors.FirstOrDefault());
    }

    [HttpPost("Login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginDTO model)
    {
        var result = await _usersUnitOfWork.LoginAsync(model);
        if (result.Succeeded)
        {
            var user = await _usersUnitOfWork.GetUserAsync(model.Email);
            return Ok(BuildToken(user));
        }

        if (result.IsLockedOut)
        {
            return BadRequest("ERR007");
        }

        if (result.IsNotAllowed)
        {
            return BadRequest("ERR008");
        }

        return BadRequest("ERR006");
    }

    private TokenDTO BuildToken(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.Email!),
            new(ClaimTypes.Role, user.UserType.ToString()),
            new("FirstName", user.FirstName),
            new("LastName", user.LastName),
            new("Photo", user.Photo ?? string.Empty)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwtKey"]!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expiration = DateTime.UtcNow.AddDays(30);
        var token = new JwtSecurityToken(
            issuer: null,
            audience: null,
            claims: claims,
            expires: expiration,
            signingCredentials: credentials);

        return new TokenDTO
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = expiration
        };
    }

    private async Task<ActionResponse<string>> SendConfirmationEmailAsync(User user, string language)
    {
        var myToken = await _usersUnitOfWork.GenerateEmailConfirmationTokenAsync(user);
        var tokenLink = Url.Action("ConfirmEmail", "accounts", new
        {
            userid = user.Id,
            token = myToken
        }, HttpContext.Request.Scheme, _configuration["Url_Frontend"]);
        var algo = _configuration["Url_Frontend"];

        if (language.ToLower() == "es")
        {
            return _mailHelper.SendMail(user.FullName, user.Email!, _configuration["Mail:SubjectConfirmationEs"]!, string.Format(_configuration["Mail:BodyConfirmationEs"]!, tokenLink), language);
        }
        return _mailHelper.SendMail(user.FullName, user.Email!, _configuration["Mail:SubjectConfirmationEn"]!, string.Format(_configuration["Mail:BodyConfirmationEn"]!, tokenLink), language);
    }

    [HttpGet("ConfirmEmail")]
    public async Task<IActionResult> ConfirmEmailAsync(string userId, string token)
    {
        token = token.Replace(" ", "+");
        var user = await _usersUnitOfWork.GetUserAsync(new Guid(userId));
        if (user == null)
        {
            return NotFound();
        }

        var newtoken = await _usersUnitOfWork.GenerateEmailConfirmationTokenAsync(user);
        var result = await _usersUnitOfWork.ConfirmEmailAsync(user, newtoken);
        if (!result.Succeeded)
        {
            return BadRequest(result.Errors.FirstOrDefault());
        }

        return NoContent();
    }

    [HttpPost("ResedToken")]
    public async Task<IActionResult> ResedTokenAsync([FromBody] EmailDTO model)
    {
        var user = await _usersUnitOfWork.GetUserAsync(model.Email);
        if (user == null)
        {
            return NotFound();
        }

        var response = await SendConfirmationEmailAsync(user, model.Language);
        if (response.WasSuccess)
        {
            return NoContent();
        }

        return BadRequest(response.Message);
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpPut]
    public async Task<IActionResult> PutAsync(User user)
    {
        try
        {
            var currentUser = await _usersUnitOfWork.GetUserAsync(User.Identity!.Name!);
            if (currentUser == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(user.Photo))
            {
                var photoUser = Convert.FromBase64String(user.Photo);
                //user.Photo = await _fileStorage.SaveFileAsync(photoUser, ".jpg", _container);
            }

            currentUser.DocumentType = user.DocumentType;
            currentUser.FirstName = user.FirstName;
            currentUser.LastName = user.LastName;
            currentUser.PhoneNumber = user.PhoneNumber;
            currentUser.Photo = !string.IsNullOrEmpty(user.Photo) && user.Photo != currentUser.Photo ? user.Photo : currentUser.Photo;
            currentUser.City = user.City;

            var result = await _usersUnitOfWork.UpdateUserAsync(currentUser);
            if (result.Succeeded)
            {
                return Ok(BuildToken(currentUser));
            }

            return BadRequest(result.Errors.FirstOrDefault());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _usersUnitOfWork.GetUserAsync(User.Identity!.Name!));
    }

    [HttpPost("changePassword")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> ChangePasswordAsync(ChangePasswordDTO model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        //var user = await _usersUnitOfWork.GetUserAsync(User.Identity!.Name!);
        var user = await _usersUnitOfWork.GetUserAsync(new Guid("d8debfb9-f0f9-4498-89c9-7db58cf5bb8a"));
        if (user == null)
        {
            return NotFound();
        }

        var result = await _usersUnitOfWork.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
        if (!result.Succeeded)
        {
            return BadRequest(result.Errors.FirstOrDefault()!.Description);
        }

        return NoContent();
    }

    [HttpPost("RecoverPassword")]
    public async Task<IActionResult> RecoverPasswordAsync([FromBody] EmailDTO model)
    {
        var user = await _usersUnitOfWork.GetUserAsync(model.Email);
        if (user == null)
        {
            return NotFound();
        }

        //var response = await SendRecoverEmailAsync(user, model.Language);
        if (true)
        {
            return NoContent();
        }

        return BadRequest("");
    }

    [HttpPost("ResetPassword")]
    public async Task<IActionResult> ResetPasswordAsync([FromBody] ResetPasswordDTO model)
    {
        var user = await _usersUnitOfWork.GetUserAsync(model.Email);
        if (user == null)
        {
            return NotFound();
        }

        var result = await _usersUnitOfWork.ResetPasswordAsync(user, model.Token, model.NewPassword);
        if (result.Succeeded)
        {
            return NoContent();
        }

        return BadRequest(result.Errors.FirstOrDefault()!.Description);
    }

    [HttpPost("SendRecoverEmailAsync")]
    public async Task<ActionResponse<string>> SendRecoverEmailAsync(CreateUserDTO user, string language)
    {
        User searchUser = new User
        {
            Email = user.Email,
            FirstName = user.FirstName,
            IsActive = true,
            LastName = user.LastName,
            UserName = user.UserName,
        };
        var myToken = await _usersUnitOfWork.GeneratePasswordResetTokenAsync(searchUser);
        var tokenLink = Url.Action("ResetPassword", "accounts", new
        {
            userid = searchUser.Id,
            token = myToken
        }, HttpContext.Request.Scheme, _configuration["Url_Frontend"]);

        if (language == "es")
        {
            return _mailHelper.SendMail(searchUser.FullName, user.Email!, _configuration["Mail:SubjectRecoveryEs"]!, string.Format(_configuration["Mail:BodyRecoveryEs"]!, tokenLink), language);
        }
        return _mailHelper.SendMail(searchUser.FullName, user.Email!, _configuration["Mail:SubjectRecoveryEn"]!, string.Format(_configuration["Mail:BodyRecoveryEn"]!, tokenLink), language);
    }
}