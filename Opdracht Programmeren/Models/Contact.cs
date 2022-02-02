using System.ComponentModel.DataAnnotations;

namespace Opdracht_Programmeren.Models
{
    public class Contact
    {
        [Required, Display(Name = "Voornaam")]
        public string? Firstname { get; set; }

        [Required, Display(Name = "Achternaam")]
        public string? LastName { get; set; }

        [Required, Display(Name = "E-Mail")]
        public string? Mail { get; set; }

        [Required, Display(Name = "Telefoonnummer")]
        public int PhoneNumber { get; set; }

        [Required, Display(Name = "Bericht")]
        public string? Text { get; set; }
    }
}
