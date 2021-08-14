using Foobar.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;

namespace Foobar.Tests.Unit
{
    [TestFixture]
    public class FoobarControllerTests
    {
        [Test]
        public void Get_Success()
        {
            var controller = new FoobarsController(NullLogger<FoobarsController>.Instance);
            var getResult = controller.Get();

            var okResult = (OkObjectResult) getResult;
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(okResult.Value, Has.Length.EqualTo(2));
        }
    }
}