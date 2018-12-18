using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Controllers;
using WebStore.Interfaces.Clients;

namespace WebStore.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        private HomeController _controller;

        [TestInitialize]
        public void SetupTest()
        {
            var mockService = new Mock<IValueService>();
            mockService.Setup(c => c.GetAsync()).ReturnsAsync(new List<string>
            {
                "1","2"
            });
            _controller = new HomeController(mockService.Object);
        }

        [TestMethod]
        public async Task Index_Method_Returns_View_with_Values()
        {
            var result = await _controller.Index();
            var viewResult = Xunit.Assert.IsType<ViewResult>(result);
            var model = Xunit.Assert.IsAssignableFrom<IEnumerable<string>>(viewResult.ViewData.Model);
            Xunit.Assert.Equal(2, model.Count());
        }

        [TestMethod]
        public void ContactUs_Returns_View()
        {
            var result = _controller.ContactUs();
            Xunit.Assert.IsType<ViewResult>(result);
        }

        [TestMethod]
        public void ErrorStatus_404_Redirects_to_NotFound()
        {
            var result = _controller.ErrorStatus("404");
            var redirectToActionResult =
            Xunit.Assert.IsType<RedirectToActionResult>(result);
            Xunit.Assert.Null(redirectToActionResult.ControllerName);
            Xunit.Assert.Equal("NotFound", redirectToActionResult.ActionName);
        }
    }
}
