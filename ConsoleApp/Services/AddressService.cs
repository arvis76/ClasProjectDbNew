using ConsoleApp.Entities;
using ConsoleApp.Repository;

namespace ConsoleApp.Services;

internal class AddressService
{
    private readonly AddressRepository _addressRepository;

    public AddressService(AddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public AddressEntity CreateAddress(string streetName, string postalCode, string city  )
    {
        var addressEntity = _addressRepository.Get(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
        addressEntity ??= _addressRepository.Create(new AddressEntity { StreetName = streetName, PostalCode = postalCode, City = city });
        return addressEntity;
    }

    public AddressEntity GetAddress(string streetName, string postalCode, string city)
    {
        var addressEntity = _addressRepository.Get(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
        return addressEntity;
    }
    public AddressEntity GetCategoryById(int Id)
    {
        var addressEntity = _addressRepository.Get(x => x.Id == Id);
        return addressEntity;
    }

    public IEnumerable<AddressEntity> GetCategories()
    {
        var addresses = _addressRepository.GetAll();
        return addresses;
    }

    public AddressEntity UpdateaddressEntity(AddressEntity addressEntity)
    {
        var updateaddressEntity = _addressRepository.Update(x => x.Id == addressEntity.Id, addressEntity);
        return updateaddressEntity;
    }

    public void DeleteAddress(int Id)
    {
        _addressRepository.Delete(x => x.Id == Id);

    }


}
