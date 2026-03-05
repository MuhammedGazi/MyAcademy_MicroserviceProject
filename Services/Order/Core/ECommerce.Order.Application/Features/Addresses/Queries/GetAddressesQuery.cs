using ECommerce.Order.Application.Features.Addresses.Results;
using MediatR;

namespace ECommerce.Order.Application.Features.Addresses.Queries;

public record GetAddressesQuery : IRequest<List<GetAddressesQueryResult>>
{
}
