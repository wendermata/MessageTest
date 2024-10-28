using MassTransit;
using MediatR;

 namespace MessagesTest
{
    [MessageUrn("accounting_gateway-financial_accounting-create_customer_omie")]
    public class CreateCustomerOmieContract : INotification
    {
        public Guid TrackerId { get; set; }
        public string? ExternalReference { get; set; }
        public string? Name { get; set; }
        public string? CompanyName { get; set; }
        public string? Email { get; set; }
        public string? TaxpayerNumber { get; set; }
        public AddressContract? Address { get; set; }
        public List<TagContract>? Tags { get; set; }
    }

    public record AddressContract(string? Street,
                           string? Number,
                           string? Complement,
                           string? State,
                           string? City,
                           string? Neighborhood,
                           string? Zipcode);

    public record TagContract(string? Tag);
}
