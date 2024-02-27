using ConsoleApp.Entities;
using ConsoleApp.Repository;

namespace ConsoleApp.Services;

internal class ProductService
{
    private readonly ProductRepository _productRepository;
    private readonly CategoryService _categoryService;

    public ProductService(ProductRepository productRepository, CategoryService categoryService)
    {
        _productRepository = productRepository;
        _categoryService = categoryService;
    }

    public ProductEntity CreateProduct(string title, decimal price, string description, string categoryName)
    {
        var categoryEntity = _categoryService.CreateCategory(categoryName);

        var productEntity = new ProductEntity
        {
            Title = title,
            Price = price,
            Description = description,
            CategoryId = categoryEntity.Id
        };

        productEntity = _productRepository.Create(productEntity);
        return productEntity;
    }

    public ProductEntity GetproductById(int Id)
    {
        var productEntity = _productRepository.Get(x => x.Id == Id);
        return productEntity;
    }

    public IEnumerable<ProductEntity> Getproducts()
    {
        var products = _productRepository.GetAll();
        return products;
    }

    public ProductEntity UpdateProduct(ProductEntity productsEntity)
    {
        var updateproduct = _productRepository.Update(x => x.Id == productsEntity.Id, productsEntity);
        return updateproduct;
    }

    public void Deleteproduct(int Id)
    {
        _productRepository.Delete(x => x.Id == Id);

    }

}
