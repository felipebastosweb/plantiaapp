using PlantiaApp.Shared.Core.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PlantiaApp.Shared.Core.Entities;
using PlantiaApp.Shared.Core.Records;
using System.Xml.Schema;


namespace PlantiaApp.Shared.Components.Authorization
{
    public class UserSQLiteService
    {
        private SQLiteContexts Context { get; set; }
        public UserSQLiteService(SQLiteContexts context)
        {
            Context = context;
        }
        
        public async Task<List<UserOutput>> AllAsync()
        {
            await Context.Init();
            var users = await Context!.Database!.Table<User>().ToListAsync();
            List<UserOutput> output = [];
            foreach (var user in users) {
                output.Add(
                    new UserOutput() {
                        Id = user.Id, Username = user.Username!, PasswordHash = user.PasswordHash!
                    }
                );
            }
            return output;
        }
        
        public async Task<UserOutput> GetAsync(Guid Id)
        {
            await Context.Init();
            var user = await Context!.Database!.Table<User>().FirstAsync(x => x.Id == Id);
            return new UserOutput() {
                Id = user.Id,
                Username = user!.Username!,
                PasswordHash = user!.PasswordHash!
            };
        }


        public async Task<int> SaveItemAsync(UserInput item)
        {
            await Context!.Init();
            if (item.Id != null)
                return await Context!.Database!.UpdateAsync(item);
            else
                return await Context!.Database!.InsertAsync(item);
        }
    }
}
