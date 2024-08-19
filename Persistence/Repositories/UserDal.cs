using Application.Repositories;
using Domain.Entity;
using Persistence.Context;
using Persistence.Repositories.Base;

namespace Persistence.Repositories
{
    public sealed class UserDal : RepositoryBase<User>, IUserDal
    {
        public UserDal(JiraDbContext context) : base(context)
        {
        }

    }
}