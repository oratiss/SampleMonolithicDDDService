using ApplicationService.UserAccounting.Dtos;
using ApplicationService.UserAccounting.Roles;
using WebApi.Controllers.BaseControllers;
using WebApi.Dtos.UserAccounting;
using WebApi.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using Utilities.BasedSetMappers;
using Utilities.BaseExceptions;
using Utilities.SharedTools.ExceptionDictionaries;

namespace WebApi.Areas.UserAccounting.Controllers
{
    [Route("[area]/[controller]/[action]")]
    [ApiController]
    [Area("UserAccounting")]
    public class RoleController : BaseController
    {
        private readonly IApplicationRoleService _applicationRoleService;


        public RoleController(IApplicationRoleService applicationRoleService, IAutoMapperConfiguration config, ILogger<RoleController> logger) : base(config, logger)
        {
            _applicationRoleService = applicationRoleService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var applicationRoles = _applicationRoleService.GetAll();
                if (applicationRoles.Count().Equals(0) || applicationRoles == null)
                {
                    throw new ApiException(200005); //to be added to enum with (long) cast.
                }
                //return Ok();
                return Ok(applicationRoles.Select(_mapper.Map<ApiRoleDto>));
            }
            catch (BaseException e)
            {
                var exception = ManageException(e);
                return BadRequest(exception._code);
            }
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Create([FromBody] ApiRoleDto apiRoleDto)
        {
            try
            {
                var applicationRoleDto = _mapper.Map<ApplicationRoleDto>(apiRoleDto);
                var applicationRole = _applicationRoleService.Add(applicationRoleDto, true);
                if (applicationRole == null)
                {
                    throw new ApiException((long)ExceptionCodes.UserAccountingApiRoleCreatePost); //to be added to enum with (long) cast.
                }
                //return Ok();
                return Ok(applicationRole);
            }
            catch (BaseException e)
            {
                var exception = ManageException(e);
                return BadRequest(exception._code);
            }
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Delete([FromBody] ApiRoleDto apiRoleDto)
        {
            try
            {
                var applicationRoleDto = _mapper.Map<ApplicationRoleDto>(apiRoleDto);
                _applicationRoleService.Delete(applicationRoleDto, true);
                var check = _applicationRoleService.Get(apiRoleDto.Id);
                if (check != null)
                {
                    throw new ApiException((long)ExceptionCodes.UserAccountingApiRoleDeletePost);
                }

                return Ok();
            }
            catch (BaseException e)
            {
                var exception = ManageException(e);
                return BadRequest(exception._code);
            }
        }


        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult DeleteById([FromBody] int id)
        {
            try
            {
                _applicationRoleService.Delete(id, true);
                var check = _applicationRoleService.Get(id);
                if (check != null)
                {
                    throw new ApiException((long)ExceptionCodes.UserAccountingApiRoleDeleteByIdPost);
                }

                return Ok();
            }
            catch (BaseException e)
            {
                var exception = ManageException(e);
                return BadRequest(exception._code);
            }
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Edit([FromBody] ApiRoleDto apiRoleDto)
        {
            try
            {
                var applicationRoleDto = _mapper.Map<ApplicationRoleDto>(apiRoleDto);
                var applicationRole = _applicationRoleService.Update(applicationRoleDto, true);
                if (applicationRole == null)
                {
                    throw new ApiException((long)ExceptionCodes.UserAccountingApiRoleEditPost);
                }

                return Ok(applicationRole);
            }
            catch (BaseException e)
            {
                var exception = ManageException(e);
                return BadRequest(exception._code);
            }
        }
    }
}
