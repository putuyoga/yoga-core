using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using YogaCore.Controllers;
using YogaCore.ViewModels.Accounts;
using YogaCoreTest.Data;

namespace YogaCoreTest
{
    public class TestAccountController
    {
        private readonly Dictionary<string, string> _identityDict =
            new Dictionary<string, string>()
            {
                { "joni", "12345" },
                { "jono", "25345" }
            };

        public TestAccountController()
        { }

        [Fact]
        public async void SuccesLogin_WithValidCredential()
        {
            var manager = new TestPersonManager(_identityDict);
            var controller = new AccountController(manager);

            // Login with valid credential
            var loginVM = new LoginViewModel()
            {
                Email = _identityDict.FirstOrDefault().Key,
                Password = _identityDict.FirstOrDefault().Value
            };

            // Make sure the result is redirection to home index route
            var result = await controller.Login(loginVM) as RedirectToActionResult;
            Assert.Equal("Index", result.ActionName);
            Assert.Equal("Home", result.ControllerName);
        }

        [Fact]
        public async void FailedLogin_WithInvalidCredential()
        {
            var manager = new TestPersonManager(_identityDict);
            var controller = new AccountController(manager);

            // Login with false credential
            var loginVM = new LoginViewModel()
            {
                Email = "worong@email.com",
                Password = "wrongPass"
            };

            // Make sure there is some error recorded
            await controller.Login(loginVM);
            Assert.NotEqual(0, controller.ModelState.ErrorCount);
        }

        public async void RegisterNewValidIdentity_ShouldSuccess()
        {
            var manager = new TestPersonManager(_identityDict);
            var controller = new AccountController(manager);

            // Login with false credential
            var registerVM = new RegisterViewModel()
            {
                Email = "valid@person.com",
                Password = "12345678",
                ConfirmPassword = "12345678"
            };

            // Make sure there is some error recorded
            var result = await controller.Register(registerVM) as RedirectToActionResult;

            // error free
            Assert.True(controller.ModelState.IsValid);

            // redirected to appropiate place
            Assert.Equal("Index", result.ActionName);
            Assert.Equal("Home", result.ControllerName);
        }

        public async void RegisterWithExistEmail_ShouldFail()
        {
            var manager = new TestPersonManager(_identityDict);
            var controller = new AccountController(manager);

            // Login with false credential
            var registerVM = new RegisterViewModel()
            {
                Email = _identityDict.FirstOrDefault().Key,
                Password = "12345678",
                ConfirmPassword = "12345678"
            };

            // Make sure there is some error recorded
            await controller.Register(registerVM);

            // not error free
            Assert.True(!controller.ModelState.IsValid);
        }
    }
}
