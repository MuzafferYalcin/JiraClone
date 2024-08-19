using Application.Repositories;
using Domain.Entity;
using MediatR;

namespace Application.Features.Commands.TicketCommands.CreateTicket;

public sealed class CreateTicketHandler : IRequestHandler<CreateTicketRequest, CreateTicketResponse>
{
    private readonly ITicketDal _ticketDal;

    public CreateTicketHandler(ITicketDal ticketDal)
    {
        _ticketDal = ticketDal;
    }

    public async Task<CreateTicketResponse> Handle(CreateTicketRequest request, CancellationToken cancellationToken)
    {
        Ticket ticket = new Ticket {
            Title = request.Title,
            Description = request.Description,
            CreatedBy = request.createdBy,
            CreatedDate = DateTimeOffset.UtcNow,
        };
        await _ticketDal.Add(ticket);
        await _ticketDal.SaveAsync();
        return new();
    }
}
