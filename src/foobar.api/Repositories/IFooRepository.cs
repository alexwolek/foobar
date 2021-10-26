using System.Collections.Generic;
using Foobar.Api.Models;

namespace Foobar.Api.Repositories
{
    public interface IFooRepository
    {
        IEnumerable<Foo> GetFoobars();
        void AddFoo(Foo foo);
    }
}
