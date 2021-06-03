using ApplicationService.ApplicationException;
using AutoMapper;
using ExceptionsManagement.DomainExceptions.BaseDomainExceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Orchestration.Exceptions;
using Persistence.Exceptions;
using System;
using Utilities.BasedSetMappers;
using Utilities.BaseExceptions;
using WebApi.Exceptions;

namespace WebApi.Controllers.BaseControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {

        protected IServiceCollection _services;
        protected IMapper _mapper;
        protected IAutoMapperConfiguration _config;
        protected ILogger<BaseController> _logger;

       
        public BaseController(IAutoMapperConfiguration config, ILogger<BaseController> logger)
        {
            _services = new ServiceCollection();
            _config = config;
            _config.Configure(_services);

            var serviceProvider = _services.BuildServiceProvider();
            _mapper = serviceProvider.GetService<IMapper>();
            _logger = logger;
        }

        protected BaseException ManageException(Exception e)
        {
            BaseException exception=new BaseException(0);

            if (e.GetType().Equals(typeof(ApiException)))
            {
                exception = (ApiException)e;
            }

            if (e.GetType().Equals(typeof(OrchestrationException)))
            {
                exception = (OrchestrationException)e;
            }

            if (e.GetType().Equals(typeof(DapApplicationException)))
            {
                exception = (DapApplicationException)e;
            }

            if (e.GetType().Equals(typeof(DomainException)))
            {
                exception = (DomainException)e;
            }

            if (e.GetType().Equals(typeof(PersistenceException)))
            {
                exception = (PersistenceException)e;
            }

            //todo: to be checked later with commets in ExceptionCode enum
            _logger.LogError((EventId)exception._code, exception, exception._code.ToString());
            return exception;
        }

    }
}
