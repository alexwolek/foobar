using Foobar.Api.Controllers;
using Foobar.Api.Models;
using Foobar.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;
using System.Linq;

namespace Foobar.Tests.Unit
{
    [TestFixture]
    public class FoobarControllerTests
    {
        [Test]
        public void Get_Success()
        {
            // arrange
            var repository = new FooRepository(new[] { new Foo { Bar = "foobar" } });
            var controller = new FoobarsController(repository, NullLogger<FoobarsController>.Instance);

            // act
            var getResult = controller.Get();

            // assert
            var okResult = (OkObjectResult)getResult;
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(okResult.Value, Has.Exactly(1).Items);
        }

        [Test]
        public void AddFoobar_Success()
        {
            // arrange
            var repository = new FooRepository(new Foo[] { });
            var controller = new FoobarsController(repository, NullLogger<FoobarsController>.Instance);

            var fooToAdd = new Foo{Bar = "new foo"};

            // act
            var getResult = controller.AddFoobar(fooToAdd);

            // assert
            var okResult = (NoContentResult)getResult;
            Assert.That(okResult.StatusCode, Is.EqualTo(204));

            var itemsInRepo = repository.GetFoobars().ToArray();
            Assert.That(itemsInRepo, Has.Exactly(1).Items);
            Assert.That(itemsInRepo[0].Bar, Is.EqualTo("new foo"));
        }
    }
}
