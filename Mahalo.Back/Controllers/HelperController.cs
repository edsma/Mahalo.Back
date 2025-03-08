using Mahalo.Back.UnitsOfWork.Implementation;
using Mahalo.Back.UnitsOfWork.Interfaces;
using Mahalo.Shared.Constants;
using Mahalo.Shared.DTOs;
using Mahalo.Shared.Entities;
using Mahalo.Shared.Response;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Cmp;

namespace Mahalo.Back.Controllers
{
    [ApiController]
    [Route("/api/helpers")]
    public class HelperController : Controller
    {
        private readonly IUploadFilesUnitOfWork _uploadFilesUnitOfWork;
        private readonly IResourcesDisorderUnitOfWork _resourcesDisorderUnitOfWork;
        private readonly IGenericUnitOfWork<Resource> _UnitOfWork;
        private readonly IGenericUnitOfWork<ResourceDisorder> _UnitOfWorkResourceDisorder;

        private IUsersUnitOfWork _userUnitOfWork;
        public HelperController(IUploadFilesUnitOfWork uploadFilesUnitOfWork,
            IGenericUnitOfWork<Resource> unitOfWork, 
            IResourcesDisorderUnitOfWork resourcesDisorderUnitOfWork,
            IUsersUnitOfWork userUnitOfWork,
            IGenericUnitOfWork<ResourceDisorder> unitOfWorkResourceDisorder)
        {
            _uploadFilesUnitOfWork = uploadFilesUnitOfWork;
            _UnitOfWork = unitOfWork;
            _resourcesDisorderUnitOfWork = resourcesDisorderUnitOfWork;
            _userUnitOfWork = userUnitOfWork;
            _UnitOfWorkResourceDisorder = unitOfWorkResourceDisorder;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFile(ResourceDto resource)
        {
            User user = await _userUnitOfWork.GetUserAsync(User.Identity!.Name!);
            ActionResponse<Resource> resourceLocation = await _UnitOfWork.GetAsync(resource.ResourceId);

            var result = await _uploadFilesUnitOfWork.DeleteFileAync(resourceLocation.Result.Location);
            if (result)
            {
                resourceLocation.Result.ModifiedDate = DateTime.UtcNow;

                FilesDto resultFile = await _uploadFilesUnitOfWork.UploadFileLocal(resource.file);


                resourceLocation.Result.Location = resultFile.route;

                await _UnitOfWork.UpdateAsync(resourceLocation.Result);
            }
            return Ok("");
        }

        [HttpPost("UploadFile")]
        public async Task<IActionResult> UploadFile(ResourceDto resource)
        {
            Resource request = new Resource();
            User user = await _userUnitOfWork.GetUserAsync(User.Identity!.Name!);
            FilesDto result = await _uploadFilesUnitOfWork.UploadFileLocal(resource.file);
            if (result.resultProcess)
            {
                ActionResponse<ResourceDisorder> resourcrDisorderResult = await _resourcesDisorderUnitOfWork.GetAsync(resource.ResourceDisorderId);
                if (resourcrDisorderResult.MasSuccess)
                {
                    request = BuildResource(result,resource,user,resourcrDisorderResult.Result!);
                    await _UnitOfWork.AddAsync(request);
                }
                else
                {
                    ResourceDisorder requestResourceDisorder = new ResourceDisorder
                    {
                        IsActive = true,
                        Name = resource.ResourceDisorderName,
                    };
                    ActionResponse<ResourceDisorder> addResult = await _UnitOfWorkResourceDisorder.AddAsync(requestResourceDisorder);
                    if (addResult.WasSuccess)
                    {
                        request = BuildResource(result, resource, user, addResult.Result!);
                        await _UnitOfWork.AddAsync(request);
                    }
                }
            }

            return Ok(ConstantsApp.AppConstants.ResultOk);
        }

        private Resource BuildResource(FilesDto result, ResourceDto resource, User user, ResourceDisorder resourcrDisorderResult)
        {
            return new Resource
            {
                Name = result.name,
                CreationDate = DateTime.Now,
                Description = resource.FileDescription,
                IsActive = true,
                Location = result.route,
                Status = ConstantsApp.StatusForAcceptance.underReview,
                UserId = user.Id,
                ResourceDisorderId = resourcrDisorderResult.Id
            };
        }
    }
}
