using ConsoleApp.Context;
using ConsoleApp.Entities;

namespace ConsoleApp.Repository;

internal class AddressRepository : Repo<AddressEntity>
{
    public AddressRepository(DataContext context) : base(context)
    {

    }
}
