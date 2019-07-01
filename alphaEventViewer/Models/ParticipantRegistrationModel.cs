using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace alphaEventViewer.Models
{
    public class ParticipantRegistrationModel
    {
        [DisplayName("Anrede")]
        public string Salutation { get; set; }

        [DisplayName("Titel")]
        public string Title { get; set; }

        [DisplayName("Vorname")]
        [Required(ErrorMessage = "Darf nicht leer sein.")]
        public string FirstName { get; set; }

        [DisplayName("Nachname")]
        [Required(ErrorMessage = "Darf nicht leer sein.")]
        public string LastName { get; set; }

        [DisplayName("E-Mail-Adresse")]
        [Required(ErrorMessage = "Darf nicht leer sein.")]
        [EmailAddress(ErrorMessage = "Muss eine valide E-Mail-Adresse sein.")]
        public string EMailAddress { get; set; }

        [DisplayName("Straße und Hausnummer")]
        [Required(ErrorMessage = "Darf nicht leer sein.")]
        public string Street { get; set; }

        [DisplayName("PLZ")]
        [Required(ErrorMessage = "Darf nicht leer sein.")]
        public string ZipCode { get; set; }

        [DisplayName("Stadt")]
        [Required(ErrorMessage = "Darf nicht leer sein.")]
        public string City { get; set; }

        [DisplayName("Land")]
        [Required(ErrorMessage = "Darf nicht leer sein.")]
        public string Country { get; set; }

        [DisplayName("Telefon")]
        public string Phone { get; set; }
    }
}
