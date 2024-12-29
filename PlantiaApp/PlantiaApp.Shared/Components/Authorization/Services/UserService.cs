using Microsoft.Maui.Platform;
using PlantiaApp.Shared.Components.Authorization.Interfaces;
using PlantiaApp.Shared.Components.Authorization.Records;
using PlantiaApp.Shared.Core.Contexts;

using PlantiaApp.Shared.Core.Entities;


namespace PlantiaApp.Shared.Components.Authorization.Services
{
    public class UserSQLiteService : IUserService
    {
        private SQLiteContexts Context { get; set; }
        public UserSQLiteService(SQLiteContexts context)
        {
            Context = context;
            Context.Init().Wait();
        }

        public async Task<UserRegisteredOutput?> InsertAsync(SignUpInput item)
        {
            try
            {
                await Context!.Init();

                var user = new User()
                {
                    Username = item.Username,
                    // TODO: converter para Hash
                    PasswordHash = item.Password
                };

                var rows = await Context!.Database!.InsertAsync(user);
                if (rows < 1)
                {
                    throw new Exception("Falha ao inserir usuário no banco de dados");
                }

                return new UserRegisteredOutput() { Id = user.Id, Username = user!.Username! };
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Ocorreu um erro a inserir um usuário no banco de dados.");
            }
            return null;
        }


        public async Task<List<UserRegisteredOutput>> AllAsync()
        {
            await Context!.Init();
            var users = await Context!.Database!.Table<User>().ToListAsync();
            List<UserRegisteredOutput> output = [];
            if (users.Count() < 1)
            {
                return output;
            }

            foreach (var user in users) {
                output.Add(
                    new UserRegisteredOutput() {
                        Id = user.Id, Username = user.Username!
                    }
                );
            }
            return output;
        }
        
        public async Task<UserRegisteredOutput?> GetAsync(Guid Id)
        {
            await Context.Init();
            var user = await Context!.Database!.Table<User>().FirstAsync(x => x.Id == Id);
            if (user == null)
            {
                return null;
            }
            return new UserRegisteredOutput() {
                Id = user.Id,
                Username = user!.Username!,
                // PasswordHash = user!.PasswordHash!
            };
        }


        public async Task<UserRegisteredOutput?> UpdateAsync(UserUpdateInput item)
        {
            try
            {
                await Context!.Init();

                var user = new User()
                {
                    Id = item.Id,
                    Username = item.Username,
                    PasswordHash = item.Password
                };
                await Context!.Database!.UpdateAsync(user);
                return new UserRegisteredOutput() { Id = user.Id, Username = user!.Username! };
            }
            catch(Exception ex)
            {
                Console.WriteLine("Ocorreu um erro ao atualizar o usuário");
            }
            return null;
        }

        public async Task<UserRegisteredOutput?> ArquiveAsync(Guid Id)
        {
            await Context!.Init();
            var user = await Context!.Database!.Table<User>().Where(u => u.Id == Id).FirstAsync();
            if (user == null)
            {
                return null;
            }
            user.Arquived = true;
            await Context!.Database!.UpdateAsync(user);
            return new UserRegisteredOutput() { Id = user.Id, Username = user!.Username! };
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            await Context!.Init();
            var user = new User() { Id = Id };
            return await Context!.Database!.DeleteAsync(user) > 0;
        }
    }
}
