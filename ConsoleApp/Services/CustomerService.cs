using ConsoleApp.Entities;
using ConsoleApp.Repository;

namespace ConsoleApp.Services;

internal class CustomerService
{
    private readonly CustomerRepository _customerRepository;
    private readonly AddressService _addressServices;
    private readonly RoleService _roleService;


    public CustomerService(CustomerRepository customerRepository, AddressService addressServices, RoleService roleService)
    {
        _customerRepository = customerRepository;
        _addressServices = addressServices;
        _roleService = roleService;
    }

    public CustomerEntity CreateCustomer(string firstName, string lastName, string email, string roleName, string streetName, string postalCode, string city)
    {
        var roleEntity = _roleService.CreateRole(roleName);
        var addressEntity = _addressServices.CreateAddress(streetName, postalCode, city);


        var customerEntity = new CustomerEntity
        {
            FirstName = firstName.Trim(),
            LastName = lastName.Trim(),
            Email = email.Trim(),
            RoleId = roleEntity.Id,
            AddressId = addressEntity.Id
            
    

        };
        customerEntity = _customerRepository.Create(customerEntity);
        return customerEntity;


    }

    public CustomerEntity GetCustomerByEmail(string email)
    {
        var customersEntity = _customerRepository.Get(x => x.Email == email);
        return customersEntity;
    }

    public IEnumerable<CustomerEntity> GetCustomers()
    {
        var customers = _customerRepository.GetAll();
        return customers;
    }

    public CustomerEntity UpdateCustomer(CustomerEntity customersEntity)
    {
        var updateCustomer = _customerRepository.Update(x => x.Id == customersEntity.Id, customersEntity);
        return updateCustomer;
    }

    public void DeleteCustomer(string email)
    {
        _customerRepository.Delete(x => x.Email == email);

    }

}
