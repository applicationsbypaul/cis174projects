using System.ComponentModel.DataAnnotations;

namespace cis174projects.Models
{
    public class Contact
    {
        // EF core will configure the databse to generate this value
        public int ContactId { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a phone number. XXX-XXX-XXXX")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number XXX-XXX-XXXX")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Please enter an address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter a note.")]
        public string Note { get; set; }

    }
}