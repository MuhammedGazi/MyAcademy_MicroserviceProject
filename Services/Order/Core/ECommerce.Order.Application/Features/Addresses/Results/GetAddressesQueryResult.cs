namespace ECommerce.Order.Application.Features.Addresses.Results;

public record GetAddressesQueryResult
{
    public int Id { get; init; }
    public string UserId { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string City { get; init; }
    public string District { get; init; }
    public string AddressLine { get; init; }
}
