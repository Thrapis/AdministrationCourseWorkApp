using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheRamShop.Models.Authentication
{
    public class RegisterModel
    {
        // Personal Information
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        // Address
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string StateOrProvince { get; set; }
        [Required]
        [DataType(DataType.PostalCode)]
        public string PostCode { get; set; }
        [Required]
        public string Country { get; set; }

        // Contact Information
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }
        [Required]
        public bool Newsletter { get; set; }

        // Password
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        // Additional
        [Required]
        public bool LegalAgreements { get; set; }
        [Required]
        public string Question { get; set; }
        [Required]
        public string QuestionAnswer { get; set; }
    }
}