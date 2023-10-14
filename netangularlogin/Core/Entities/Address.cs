using System.ComponentModel.DataAnnotations;
using netangularlogin.Core.Entities;

namespace netangularlogin.Core.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }

        [Required]
        public string UserId { get; set; }
        public Users User { get; set; }
    }
}