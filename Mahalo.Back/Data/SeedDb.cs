using Mahalo.Back.UnitsOfWork.Interfaces;
using Mahalo.Shared.Entities;
using Mahalo.Shared.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Mahalo.Back.Data;

public class SeedDb
{
    private readonly DataContext _context;
    private readonly IUsersUnitOfWork _usersUnitOfWork;
    private readonly IServiceProvider _serviceProvider;
    private readonly DateTime _creationDate = DateTime.Now;

    public SeedDb(DataContext context, IUsersUnitOfWork usersUnitOfWork, IServiceProvider serviceProvider)
    {
        _context = context;
        _serviceProvider = serviceProvider;
        _usersUnitOfWork = usersUnitOfWork;
    }

    public async Task SeedAsync()
    {
        await _context.Database.EnsureCreatedAsync();
        await CheckCountriesAsync();
        await CheckStatesAsync();
        await CheckCitiesAsync();

        await CheckDisordersAsync();
        await CheckDocumentTypesAsync();
        await CheckPsychologistAsync();

        await CheckNotificationsHistoryAsync();
        await CheckNotificationsSchedulingAsync();
        await CheckNotificationsSchedulingResourcesAsync();
        await CheckResourcesAsync();
        await CheckResourcesDisorderAsync();
        await CreateRoles();
        await CheckUsersAsync();
        await CheckTerapiesAsync();

        await CheckRolesAsync();
        await CheckUserAsync("Juan", "Zuluaga", "zulu@yopmail.com", "322 311 4620", UserType.Admin);
    }

    public async Task CreateRoles()
    {
        // Obtenemos el RoleManager
        var roleManager = _serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        string roleName = "ADMIN";
        bool roleExists = await roleManager.RoleExistsAsync(roleName);

        if (!roleExists)
        {
            // Creamos el rol si no existe
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }

    private async Task CheckCitiesAsync()
    {
        if (!_context.Cities.Any())
        {
            var citiesSQLScript = File.ReadAllText("Data\\Cities.sql");
            await _context.Database.ExecuteSqlRawAsync(citiesSQLScript);
        }
    }



    private async Task CheckCountriesAsync()
    {
        if (!_context.Countries.Any())
        {
            var countriesSQLScript = File.ReadAllText("Data\\Countries.sql");
            await _context.Database.ExecuteSqlRawAsync(countriesSQLScript);
        }
    }

    private async Task CheckDisordersAsync()
    {
        if (!_context.Disorders.Any())
        {
            var DisordersSQLScript = File.ReadAllText("Data\\Disorders.sql");
            await _context.Database.ExecuteSqlRawAsync(DisordersSQLScript);
        }
    }

    private async Task CheckDocumentTypesAsync()
    {
        if (!_context.DocumentTypes.Any())
        {
            var documentTypesSQLScript = File.ReadAllText("Data\\DocumentTypes.sql");
            await _context.Database.ExecuteSqlRawAsync(documentTypesSQLScript);
        }
    }

    private async Task CheckPsychologistAsync()
    {
        if (!_context.Psychologists.Any())
        {
            var PsychologistSQLScript = File.ReadAllText("Data\\Psychologists.sql");
            await _context.Database.ExecuteSqlRawAsync(PsychologistSQLScript);
        }
    }

    private async Task CheckStatesAsync()
    {
        if (!_context.States.Any())
        {
            var statesSQLScript = File.ReadAllText("Data\\States.sql");
            await _context.Database.ExecuteSqlRawAsync(statesSQLScript);
        }
    }

    private async Task CheckNotificationsHistoryAsync()
    {
        if (!_context.NotificationsHistory.Any())
        {
            _context.NotificationsHistory.Add(new NotificationHistory { CreationDate = _creationDate!, IsActive = true, Resource = new Resource { Name = "Anxiety resource", Location = "C://Downloads", CreationDate = _creationDate, ModifiedDate = _creationDate, Status = "Published", IsActive = true } });
            _context.NotificationsHistory.Add(new NotificationHistory { CreationDate = _creationDate!, IsActive = true, Resource = new Resource { Name = "Depression resource", Location = "C://Documents", CreationDate = _creationDate, ModifiedDate = _creationDate, Status = "Under review", IsActive = true } });
        }

        await _context.SaveChangesAsync();
    }

    private async Task CheckNotificationsSchedulingAsync()
    {
        if (!_context.NotificationsScheduling.Any())
        {
            _context.NotificationsScheduling.Add(new NotificationScheduling { Name = "Notificacion scheduling 1", SchedulingDays = _creationDate!, IsActive = true, });
            _context.NotificationsScheduling.Add(new NotificationScheduling { Name = "Notificacion scheduling 2", SchedulingDays = _creationDate!, IsActive = true, });
        }

        await _context.SaveChangesAsync();
    }

    private async Task CheckNotificationsSchedulingResourcesAsync()
    {
        if (!_context.NotificationsSchedulingResources.Any())
        {
            _context.NotificationsSchedulingResources.Add(new NotificationSchedulingResource { SchedulingDays = _creationDate!, IsActive = true, Resource = new Resource { Name = "Anxiety resource", Location = "C://Downloads", CreationDate = _creationDate, ModifiedDate = _creationDate, Status = "Published", IsActive = true } });
            _context.NotificationsSchedulingResources.Add(new NotificationSchedulingResource { SchedulingDays = _creationDate!, IsActive = true, Resource = new Resource { Name = "Anxiety resource", Location = "C://Downloads", CreationDate = _creationDate, ModifiedDate = _creationDate, Status = "Published", IsActive = true } });
        }

        await _context.SaveChangesAsync();
    }

    private async Task CheckResourcesAsync()
    {
        if (!_context.Resources.Any())
        {
            _context.Resources.Add(new Resource { Name = "Schizophrenia resource", Location = "C://Downloads", CreationDate = _creationDate, ModifiedDate = _creationDate, Status = "Published", IsActive = true });
            _context.Resources.Add(new Resource { Name = "Social anxiety resource", Location = "C://Downloads", CreationDate = _creationDate, ModifiedDate = _creationDate, Status = "Published", IsActive = true });
        }

        await _context.SaveChangesAsync();
    }

    private async Task CheckResourcesDisorderAsync()
    {
        if (!_context.ResourcesDisorder.Any())
        {
            var firstDisorder = _context.Disorders.First();
            var firstResource = _context.Resources.First();
            firstDisorder.ResourcesDisorder = new List<ResourceDisorder> { };
            firstDisorder.ResourcesDisorder.Add(new ResourceDisorder { Name = "Resource Disorder Anxiety", CreationDate = _creationDate, IsActive = true, Resource = firstResource });
            _context.Disorders.Update(firstDisorder);
        }

        await _context.SaveChangesAsync();
    }

    private async Task CheckTerapiesAsync()
    {
        if (!_context.Terapies.Any())
        {
            var firstCity = _context.Cities.First();
            var firstPsychologist = _context.Psychologists.First();
            var Terapy1 = new Terapy { Name = "Terapy 1", HourTerapy = _creationDate, IsActive = true, City = firstCity, Psychologist = firstPsychologist };
            var Terapy2 = new Terapy { Name = "Terapy 2", HourTerapy = _creationDate, IsActive = true, City = firstCity, Psychologist = firstPsychologist };
            _context.Terapies.Add(Terapy1);
            _context.Terapies.Add(Terapy2);
        }

        await _context.SaveChangesAsync();
    }

    private async Task CheckUsersAsync()
    {
        if (!_context.Users.Any())
        {
            //_context.Users.Add(new User { Name = "Homer Simpson", Email = "homer@yopmail.com", Password = "123456", CreationDate = _creationDate, IsActive = true });
            //_context.Users.Add(new User { Name = "Lisa Simpson", Email = "lisa@yopmail.com", Password = "123456", CreationDate = _creationDate, IsActive = true });
            //_context.Users.Add(new User { Name = "Maggie Simpson", Email = "maggie@yopmail.com", Password = "123456", CreationDate = _creationDate, IsActive = true });
            //_context.Users.Add(new User { FirstName = "Maggie", LastName = "Simpson", Email = "maggie@yopmail.com", UserType = UserType.Admin, CreationDate = _creationDate, IsActive = true });
            await CheckUserAsync("Catherine", "Delgado", "yeiyicadepa@hotmail.com", "3113167415", UserType.Admin);
        }

        await _context.SaveChangesAsync();
    }

    private async Task CheckRolesAsync()
    {
        await _usersUnitOfWork.CheckRoleAsync(UserType.Admin.ToString());
        await _usersUnitOfWork.CheckRoleAsync(UserType.User.ToString());
    }

    private async Task<User> CheckUserAsync(string firstName, string lastName, string email, string phone, UserType userType)
    {
        var user = await _usersUnitOfWork.GetUserAsync(email);
        if (user == null)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(x => x.Name == "Colombia");
            user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                UserName = email,
                PhoneNumber = phone,
                UserType = userType,
            };

            await _usersUnitOfWork.AddUserAsync(user, "123456");
            await _usersUnitOfWork.AddUserToRoleAsync(user, userType.ToString());

            var token = await _usersUnitOfWork.GenerateEmailConfirmationTokenAsync(user);
            await _usersUnitOfWork.ConfirmEmailAsync(user, token);
        }

        return user;
    }
}