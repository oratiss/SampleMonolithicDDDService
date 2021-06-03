using System;
using Client;
using Xunit;

namespace CkeintConsoleTest
{
    public class ConsoleClientTests
    {
        [Fact]
        public async void IdentityServer_Should_Work_If_DicoveryDocument_Is_Ok()
        {
            var testClass = new ConsoleTestClass();
            var check = await testClass.DoCheckMEtadata();
            Assert.True(check);
        }

        [Fact]
        public async void IdentityServer_Token_Should_Give_Us_Access_Token_If_We_Provide_It_With_Client_Id_And_Secret()
        {
            var testClass = new ConsoleTestClass();
            var check = await testClass.DoCheckAccessToken();
            Assert.True(check);
        }    
        
        [Fact]
        public async void IdentityServer_Api_Calling_Should_Work_When_It_is_Provided_With_Bearer_Token()
        {
            var testClass = new ConsoleTestClass();
            var check = await testClass.DocheckCallingApi();
            Assert.True(check);
        }
    }
}
