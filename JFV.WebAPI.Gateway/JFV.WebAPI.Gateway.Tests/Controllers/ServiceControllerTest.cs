using JFV.Gateway.Web.Controllers;
using JFV.WebAPI.Gateway.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace JFV.WebAPI.Gateway.Tests.Controllers
{
    [TestClass]
    public class ServiceControllerTest
    {
        [TestMethod]
        public void GetReturnsNotFound()
        {
            var mockRepository = new Mock<IServiceManager>();
            var controller = new ServiceController(mockRepository.Object);

            Task<IHttpActionResult> actionResult = controller.FindByNameAsync("parameters");

            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void GetReturnsServiceWithSameId()
        {
            var mockRepository = new Mock<IServiceManager>();
            mockRepository
                .Setup(x => x.FindByIdAsync("testId"))
                .Returns(Task.FromResult(new Service { Id = "testId" }));

            var controller = new ServiceController(mockRepository.Object);

            Task<IHttpActionResult> actionResult = controller.FindByIdAsync("testId");
            var contentResult = actionResult.Result as OkNegotiatedContentResult<Service>;

            Assert.IsNotNull(actionResult.Result);
            Assert.IsNotNull(contentResult.Content);
            Assert.IsInstanceOfType(actionResult.Result, typeof(OkNegotiatedContentResult<Service>));
            Assert.AreEqual("testId", contentResult.Content.Id);
        }

        [TestMethod]
        public void GetReturnsServiceUsingServiceName()
        {
            var mockRepository = new Mock<IServiceManager>();
            mockRepository.Setup(x => x.FindByNameAsync("treatment"))
                .Returns(Task.FromResult(new Service { Name = "treatment" }));

            var controller = new ServiceController(mockRepository.Object);

            Task<IHttpActionResult> actionResult = controller.FindByNameAsync("treatment");
            var contentResult = actionResult.Result as OkNegotiatedContentResult<Service>;

            Assert.IsNotNull(actionResult.Result);
            Assert.IsNotNull(contentResult.Content);
            Assert.IsInstanceOfType(actionResult.Result, typeof(OkNegotiatedContentResult<Service>));
            Assert.AreEqual("treatment", contentResult.Content.Name);
        }
    }
}
