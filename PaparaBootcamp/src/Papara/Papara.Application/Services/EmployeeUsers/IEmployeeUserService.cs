using System.Threading.Tasks;
using Papara.Application.Services.EmployeeUsers.Models;

namespace Papara.Application.Services.EmployeeUsers;

public interface IEmployeeUserService
{
	Task CreateUserAndAssignToEmployeeAsync(EmployeeUserRequest request);
}
