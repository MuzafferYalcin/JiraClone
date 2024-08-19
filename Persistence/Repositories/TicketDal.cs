using Application.Repositories;
using Domain.Entity;
using Persistence.Context;
using Persistence.Repositories.Base;

namespace Persistence.Repositories
{
    public sealed class TicketDal : RepositoryBase<Ticket>, ITicketDal
    {
        public TicketDal(JiraDbContext context) : base(context)
        {
        }
    }
}