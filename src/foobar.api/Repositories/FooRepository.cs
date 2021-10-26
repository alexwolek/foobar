using System.Collections.Generic;
using Foobar.Api.Models;

namespace Foobar.Api.Repositories
{
    public class FooRepository : IFooRepository
    {
        private readonly ICollection<Foo> _foobars;

        public FooRepository() : this(new Foo[] { new Foo { Bar = "baz" } })
        {

        }

        public FooRepository(IEnumerable<Foo> foobars)
        {
            _foobars = new List<Foo>(foobars);
        }

        public IEnumerable<Foo> GetFoobars()
        {
            return _foobars;
        }

        public void AddFoo(Foo foo)
        {
            _foobars.Add(foo);
        }
    }
}
