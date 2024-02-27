namespace ConsoleApp.Services;

internal class MenuService
{
    private readonly ProductService _productService;
    private readonly CustomerService _customerService;

    public MenuService(ProductService productService, CustomerService customerService)
    {
        _productService = productService;
        _customerService = customerService;
    }

    public void MainMenu()
    {
        while (true)
        {

            Console.WriteLine("  1. Add Customer");
            Console.WriteLine();
            Console.WriteLine("  2. Viem Customer");
            Console.WriteLine();
            Console.WriteLine("  3. Update Customer");
            Console.WriteLine();
            Console.WriteLine("  4. Add Product");
            Console.WriteLine();
            Console.WriteLine("  5. View Product");
            Console.WriteLine();
            Console.WriteLine("  6. Update Product");
            Console.WriteLine();
            Console.WriteLine("  7. Delete Customer");
            Console.WriteLine();
            Console.WriteLine("  8. Delete Product");
            Console.WriteLine();
            Console.WriteLine("  0. Exit");
            Console.WriteLine();
            Console.Write("  Enter your option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddCustomer();
                    break;
                case "2":
                    ShowCustomer();
                    break;
                case "3":
                    UpdateCustomer();
                    break;
                case "4":
                    AddProduct();
                    break;
                case "5":
                    ShowProduct();
                    break;
                case "6":
                    UpdateProduct();
                    break;
                case "7":
                    DeleteCustomer();
                    break;
                case "8":
                    DeleteProduct();
                    break;

                case "0":
                    ShowExitApplicationOption();
                    break;
                default:
                    Console.WriteLine("This is not a option please try again");
                    Console.ReadKey();
                    break;
            }
        }

    }

    public void AddCustomer()
    {

        Console.Clear();
        Console.WriteLine("******Add Customer******");
        Console.WriteLine();
        Console.Write("  Firstname: ");
        var firstName = Console.ReadLine()!;
        Console.Write("  Lastname: ");
        var lastName = Console.ReadLine()!;
        Console.Write("  Email: ");
        var email = Console.ReadLine()!;
        Console.Write("  Streetname: ");
        var streetName = Console.ReadLine()!;
        Console.Write("  Postalcode: ");
        var postalCode = Console.ReadLine()!;
        Console.Write("  City: ");
        var city = Console.ReadLine()!;
        Console.Write("  Rolename: ");
        var roleName = Console.ReadLine()!;


        var result = _customerService.CreateCustomer(firstName, lastName, email, roleName, streetName, postalCode, city );

        if (result != null)
        {
            Console.Clear();
            Console.WriteLine("Customer was created");
        }
        else
        {
            Console.WriteLine("Customer already exist");
        }
        Console.ReadKey();


    }
    public void ShowCustomer()
    {
        var customers = _customerService.GetCustomers();
        foreach (var customer in customers)
        {
           Console.WriteLine($"{customer.FirstName} - {customer.LastName} - {customer.Email}");
            Console.WriteLine($"{customer.Role.RoleName}");
           Console.WriteLine($"{customer.Address.StreetName} - {customer.Address.PostalCode} - {customer.Address.City}");

        }

    }
    public void UpdateCustomer()
    {
        Console.Clear();
        Console.Write("Enter email on the customer that you want to update: ");
        var email = Console.ReadLine()!;
        var customer = _customerService.GetCustomerByEmail(email);

        if (customer != null)
        {
            Console.WriteLine($"{customer.FirstName} - {customer.LastName} - {customer.Email}");
            Console.WriteLine($"{customer.Role.RoleName}");
            Console.WriteLine($"{customer.Address.StreetName} - {customer.Address.PostalCode} - {customer.Address.City}");

            Console.Write("Please update your firtname: ");
            customer.FirstName = Console.ReadLine()!;
            Console.Write("Please update your Lastname: ");
            customer.LastName = Console.ReadLine()!;

            var newCustomer = _customerService.UpdateCustomer(customer);
            Console.WriteLine($"{newCustomer.FirstName} - {newCustomer.LastName} - {newCustomer.Email}");
            Console.WriteLine($"{newCustomer.Role.RoleName}");
            Console.WriteLine($"{newCustomer.Address.StreetName} - {newCustomer.Address.PostalCode} - {newCustomer.Address.City}");
        }
        else
        {
            Console.WriteLine("No product in the list");
        }
        Console.ReadKey();

    }
    public void DeleteCustomer()
    {
        Console.Clear();
        Console.Write("Enter email on the customer that you want to update: ");
        var email = Console.ReadLine()!;
        var customer = _customerService.GetCustomerByEmail(email);

       if (customer != null)
        {

            _customerService.DeleteCustomer(email);
            Console.WriteLine("Customer was deleted");


        }
        else
        {
            Console.WriteLine("No Customer was not found");
        }
        Console.ReadKey();

    }
    public void AddProduct()
    {
        Console.Clear();
        Console.WriteLine("******Add Product******");
        Console.WriteLine();
        Console.Write("  Add title of you product: ");
        var title = Console.ReadLine()!;
        Console.Write("  Add the decription of you product: ");
        var description = Console.ReadLine()!;
        Console.Write("  Add Category of you product: ");
        var categoryName = Console.ReadLine()!;
        Console.Write("  Add the price of you product: ");
        var price = decimal.Parse(Console.ReadLine()!);

        var result = _productService.CreateProduct(title, price, description, categoryName);

        if (result != null)
        {
            Console.Clear();
            Console.WriteLine("Product was created");
        }
    }
    public void ShowProduct()
    {

        var products = _productService.Getproducts();
        foreach (var product in products)
        {
            Console.WriteLine($"{product.Title} - {product.Description} - {product.Category.CategoryName} - {product.Price} SEK");
        }
        Console.ReadKey();
    }
    public void UpdateProduct()
    {
        Console.Clear();
        Console.Write("Enter id pf the product you want to update: ");
        var id = int.Parse(Console.ReadLine()!);
        var product = _productService.GetproductById(id);

        if (product != null)
        {
            Console.WriteLine($"{product.Title} - {product.Description} - {product.Category.CategoryName} - {product.Price} SEK");
            Console.WriteLine();

            Console.Write("Add New product: ");
            Console.WriteLine();
            Console.Write("  Add title of you product: ");
            product.Title = Console.ReadLine()!;
            Console.Write("  Add the decription of you product: ");
            product.Description = Console.ReadLine()!;
            Console.Write("  Add the price of you product: ");
            product.Price = decimal.Parse(Console.ReadLine()!);

            var updatedProduct = _productService.UpdateProduct(product);
            Console.WriteLine($"{product.Title} - {product.Description} - {product.Category.CategoryName} - {product.Price} SEK");
        }
        else
        {
            Console.WriteLine("No product in the list");
        }
        Console.ReadKey();

    }

    public void DeleteProduct()
    {
        Console.Clear();
        Console.Write("Enter id pf the product you want to delete: ");
        var id = int.Parse(Console.ReadLine()!);
        var product = _productService.GetproductById(id);

        if (product != null)
        {

            _productService.Deleteproduct(product.Id);
            Console.WriteLine("Product was deleted");


        }
        else
        {
            Console.WriteLine("No product was found");
        }
        Console.ReadKey();


    }
    public void ShowExitApplicationOption()
    {
        Console.Clear();
        Console.Write("Are you sure you want to exit? (y/n) :");
        var option = Console.ReadLine() ?? "";

        if (option.Equals("y", StringComparison.OrdinalIgnoreCase))
        {
            Environment.Exit(0);
        }

    }
}
