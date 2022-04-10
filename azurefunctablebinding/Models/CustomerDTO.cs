using Microsoft.Azure.Cosmos.Table;

namespace azurefunctablebinding.Models
{
    public class CustomerDTO: TableEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
    }
}
