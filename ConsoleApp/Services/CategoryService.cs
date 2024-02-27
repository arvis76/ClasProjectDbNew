using ConsoleApp.Entities;
using ConsoleApp.Repository;

namespace ConsoleApp.Services;

internal class CategoryService
{

    private readonly CategoryRepository _categoryRepository;

    public CategoryService(CategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }


    public CategoryEntity CreateCategory(string categoryName)
    {
        var categoryEntity = _categoryRepository.Get(x => x.CategoryName == categoryName) ?? _categoryRepository.Create(new CategoryEntity { CategoryName = categoryName });
        return categoryEntity;
    }

    public CategoryEntity GetCategoryByGategoryName(string categoryName)
    {
        var categoryEntity = _categoryRepository.Get(x => x.CategoryName == categoryName);
        return categoryEntity;
    }
    public CategoryEntity GetCategoryById(int Id)
    {
        var categoryEntity = _categoryRepository.Get(x => x.Id == Id);
        return categoryEntity;
    }

    public IEnumerable<CategoryEntity> GetCategories()
    {
        var categories = _categoryRepository.GetAll();
        return categories;
    }

    public CategoryEntity UpdateCategory(CategoryEntity categoryEntity)
    {
        var updateCategory = _categoryRepository.Update(x => x.Id == categoryEntity.Id, categoryEntity);
        return updateCategory;
    }

    public void DeleteCategory(int Id)
    {
        _categoryRepository.Delete(x => x.Id == Id);

    }

}
