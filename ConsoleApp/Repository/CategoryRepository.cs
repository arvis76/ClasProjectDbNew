using ConsoleApp.Context;
using ConsoleApp.Entities;

namespace ConsoleApp.Repository;

internal class CategoryRepository : Repo<CategoryEntity>
{
    public CategoryRepository(DataContext context) : base(context)
    {


    }
}
