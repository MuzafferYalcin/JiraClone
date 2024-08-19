using MediatR;

namespace Application.Features.Commands.TicketCommands.CreateTicket
{
    public sealed record CreateTicketRequest(
        string Title,
        string Description,
        int createdBy
    ) : IRequest<CreateTicketResponse>;

    public sealed record CreateTicketResponse(
        string Message = "Talep Başarıyla Oluşturuldu"
    );
}

