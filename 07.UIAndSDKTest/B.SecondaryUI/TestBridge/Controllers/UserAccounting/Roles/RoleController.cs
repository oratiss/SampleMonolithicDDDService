using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestBridge.Controllers.BaseControllers;
using TestBridge.Models.UserAccounting.Roles;
using static TestBridge.Constants.ApiCallConstants;

namespace TestBridge.Controllers.UserAccounting.Roles
{
    public class RoleController : BaseController
    {

        public RoleController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }


        // GET: RoleController
        public async Task<IEnumerable<BridgeRoleViewModel>> Index()
        {
            try
            {
                var httpClinet = _HttpClientFactory.CreateClient();
                var apiResponse = await httpClinet.GetStringAsync(UserAccountingRoleIndexURL);
                var result = JsonConvert.DeserializeObject<IEnumerable<BridgeRoleViewModel>>(apiResponse);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // POST: RoleController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<BridgeRoleViewModel> Create(BridgeRoleViewModel bridgeRoleViewModel)
        {

            try
            {
                var httpClient = _HttpClientFactory.CreateClient();
                var stringbridgeRoleViewModel = await Task.Run(() => JsonConvert.SerializeObject(bridgeRoleViewModel));
                var httpContent = new StringContent(stringbridgeRoleViewModel, Encoding.UTF8, "application/json");
                var apiResponse = await httpClient.PostAsync(UserAccountingRoleCreateURL, httpContent);
                var responseContent = await apiResponse?.Content.ReadAsStringAsync();
                var result = await Task.Run(() => JsonConvert.DeserializeObject<BridgeRoleViewModel>(responseContent));
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: RoleController/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(BridgeRoleViewModel bridgeRoleViewModel)
        {

            try
            {
                var httpClient = _HttpClientFactory.CreateClient();
                var stringbridgeRoleViewModel = await Task.Run(() => JsonConvert.SerializeObject(bridgeRoleViewModel));
                var httpContent = new StringContent(stringbridgeRoleViewModel, Encoding.UTF8, "application/json");
                var apiResponse = await httpClient.PostAsync(UserAccountingRoleDeleteURL, httpContent);
                var responseCode = apiResponse.StatusCode;
                if (responseCode.Equals(System.Net.HttpStatusCode.OK))
                {
                    return Ok(responseCode);
                }
                else
                {
                    return BadRequest(responseCode);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteById(int id)
        {

            try
            {
                var httpClient = _HttpClientFactory.CreateClient();
                var stringbridgeRoleViewModel = await Task.Run(() => JsonConvert.SerializeObject(id));
                var httpContent = new StringContent(stringbridgeRoleViewModel, Encoding.UTF8, "application/json");
                var apiResponse = await httpClient.PostAsync(UserAccountingRoleDeleteByIdURL, httpContent);
                var responseCode = apiResponse.StatusCode;
                if (responseCode.Equals(System.Net.HttpStatusCode.OK))
                {
                    return Ok(responseCode);
                }
                else
                {
                    return BadRequest(responseCode);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<BridgeRoleViewModel>  Edit(BridgeRoleViewModel bridgeRoleViewModel)
        {

            try
            {
                var httpClient = _HttpClientFactory.CreateClient();
                var stringbridgeRoleViewModel = await Task.Run(() => JsonConvert.SerializeObject(bridgeRoleViewModel));
                var httpContent = new StringContent(stringbridgeRoleViewModel, Encoding.UTF8, "application/json");
                var apiResponse = await httpClient.PostAsync(UserAccountingRoleEditURL, httpContent);
                var responseContent = await apiResponse?.Content.ReadAsStringAsync();
                var result = await Task.Run(() => JsonConvert.DeserializeObject<BridgeRoleViewModel>(responseContent));
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




    }
}
