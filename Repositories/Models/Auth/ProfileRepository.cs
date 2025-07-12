using Entities.Models.Auth;
using Repositories.Config.Context;

namespace Repositories.Models.Auth;

public sealed class ProfileRepository : AbstractRepository<Profile>
{
    public ProfileRepository(RepositoryContext context) : base(context)
    {
    }
}