using Domain.DTOs;
using Domain.Entity;
using MediatR;

namespace Application.Features.Queries.TicketQueries.GetAllWithUser;

public sealed record GetAllWithUserRequest() : IRequest<List<GetAllWithUserResponse>>;
public sealed record GetAllWithUserResponse(
    int Id,
    string Title,
    string Description,
    bool IsACtive,
    DateTimeOffset? CreatedDate,
    DateTimeOffset? DeletedDate,
    DateTimeOffset? UpdatedDate,
    int? CreatedBy,
    int? DeletedBy,
    int? UpdatedBy,
    string? CreatedUserName,
    string? CreatedUserLastName,
    string? CreatedUserEmail

);