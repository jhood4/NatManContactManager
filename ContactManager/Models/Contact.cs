using System;
using System.ComponentModel.DataAnnotations;
namespace ContactManager.Models
{
    public class Contact
    {
        public int ContactId { get; set; }

        [Required(ErrorMessage = "Please enter a first name.")] 
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter a Phone Number.")] 
        [DataType(DataType.PhoneNumber)]
        //[Range(1889, 2999, ErrorMessage = "Year must be after 1889.")] 
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter an Email.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string? Organization { get; set; }
        public DateTime DateAdded { get; set; }

        [Required(ErrorMessage = "Please enter a Category.")]
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        
        public string Slug =>
            FirstName?.Replace(' ', '-').ToLower() + '-' + LastName?.Replace(' ', '-').ToLower();
    }
}