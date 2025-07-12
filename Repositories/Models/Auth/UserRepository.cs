using Entities.Models.Auth;
using Repositories.Config.Context;

namespace Repositories.Models.Auth;

public sealed class UserRepository : AbstractRepository<User>
{
    public UserRepository(RepositoryContext context) : base(context)
    {
    }
}