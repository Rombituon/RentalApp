using System.ComponentModel.DataAnnotations;

namespace RentalApp.Models
{
    public class Renter
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Nama diperlukan")]
        public string Name { get; set; }
        public string IcNo { get; set; }
        public string PhoneNo { get; set;}
    }
}
