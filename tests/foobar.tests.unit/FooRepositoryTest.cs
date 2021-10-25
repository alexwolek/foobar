using Foobar.Api.Repositories;
using NUnit.Framework;
using System.Linq;

namespace Foobar.Tests.Unit
{
    [TestFixture]
    public class FooRepositoryTests
    {
        [Test]
        public void Ctor_Empty()
        {
            // arrange
            // act
            var repository = new FooRepository();

            // assert
            var items = repository.GetFoobars().ToArray();
            Assert.That(items, Has.Exactly(1).Items);
            Assert.That(items[0].Bar, Is.EqualTo("baz"));
        }
    }
}