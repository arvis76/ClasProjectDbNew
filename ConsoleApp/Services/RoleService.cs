using ConsoleApp.Entities;
using ConsoleApp.Repository;

namespace ConsoleApp.Services;

internal class RoleService
{

    private readonly RoleRepository _roleRepository;

    public RoleService(RoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public RoleEntity CreateRole(string roleName)
    {
        var rolesEntity = _roleRepository.Get(x => x.RoleName == roleName) ?? _roleRepository.Create(new RoleEntity { RoleName = roleName });
        return rolesEntity;
    }

    public RoleEntity GetRoleByRoleName(string roleName)
    {
        var rolesEntity = _roleRepository.Get(x => x.RoleName == roleName);
        return rolesEntity;
    }
    public RoleEntity GetRoleById(int Id)
    {
        var rolesEntity = _roleRepository.Get(x => x.Id == Id);
        return rolesEntity;
    }

    public IEnumerable<RoleEntity> GetRoles()
    {
        var role = _roleRepository.GetAll();
        return role;
    }

    public RoleEntity UpdateRole(RoleEntity RolesEntity)
    {
        var updateRole = _roleRepository.Update(x => x.Id == RolesEntity.Id, RolesEntity);
        return updateRole;
    }

    public void DeleteRole(int Id)
    {
        _roleRepository.Delete(x => x.Id == Id);

    }
}
