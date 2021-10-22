using Foobar.Api.Controllers;
using Foobar.Api.Models;
using Foobar.Api.Repositories;
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
            var repository = new FooRepository();
            repository.AddFoo(new Foo{Bar = "foobar"});
            var controller = new FoobarsController(repository, NullLogger<FoobarsController>.Instance);
            var getResult = controller.Get();

            var okResult = (OkObjectResult) getResult;
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(okResult.Value, Has.Count.EqualTo(2));
        }
    }
}