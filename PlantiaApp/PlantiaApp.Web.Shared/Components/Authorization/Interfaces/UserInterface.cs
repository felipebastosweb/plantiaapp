using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PlantiaApp.Shared.Components.Authorization.Records;

namespace PlantiaApp.Shared.Components.Authorization.Interfaces
{
    public interface IUser { }
    public interface IUserService
    {
        Task<UserRegisteredOutput?> InsertAsync(SignUpInput item);
        Task<List<UserRegisteredOutput>> AllAsync();
        Task<UserRegisteredOutput?> GetAsync(Guid Id);
        Task<UserRegisteredOutput?> UpdateAsync(UserUpdateInput item);
        Task<UserRegisteredOutput?> ArquiveAsync(Guid Id);
        Task<bool> DeleteAsync(Guid Id);
    }
}
