using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestBridge.Controllers.BaseControllers
{
    public class BaseController : Controller
    {
        protected readonly IHttpClientFactory _HttpClientFactory;

        public BaseController(IHttpClientFactory httpClientFactory)
        {
            _HttpClientFactory = httpClientFactory;
        }
    }
}

