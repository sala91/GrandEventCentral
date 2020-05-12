using System.Collections.Generic;
using System.Threading.Tasks;
using GrandEventCentral.Shared.DTOs;

namespace GrandEventCentral.Client.Repository
{
    public interface IUsersRepository
    {
        Task AssignRole(EditRoleDTO editRole);
        Task<List<RoleDTO>> GetRoles();
        Task<PaginatedResponse<List<UserDTO>>> GetUsers(PaginationDTO paginationDTO);
        Task RemoveRole(EditRoleDTO editRole);
    }
}
