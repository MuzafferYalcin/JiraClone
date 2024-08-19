using Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.TicketQueries.GetAllWithUser;

public sealed class GetAllWithUserHandler : IRequestHandler<GetAllWithUserRequest, List<GetAllWithUserResponse>>
{
    private readonly ITicketDal _ticketDal;

    public GetAllWithUserHandler(ITicketDal ticketDal)
    {
        _ticketDal = ticketDal;
    }

    public async Task<List<GetAllWithUserResponse>> Handle(GetAllWithUserRequest request, CancellationToken cancellationToken)
    {
        var data = await _ticketDal.Table.Include(p => p.CreatedByUser).ToListAsync();
        List<GetAllWithUserResponse> result = data.Select(item => new GetAllWithUserResponse(
            item.Id,
            item.Title, 
            item.Description, 
            item.IsActive, 
            item.CreatedDate, 
            item.DeletedDate, 
            item.UpdatedDate, 
            item.CreatedBy, 
            item.DeletedBy, 
            item.UpdatedBy,
            item.CreatedByUser?.FirstName,
            item.CreatedByUser?.LastName,
            item.CreatedByUser?.Email
            )).ToList();
        return result;
    }
}