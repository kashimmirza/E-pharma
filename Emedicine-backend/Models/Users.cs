using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Security.Principal;
using System.ComponentModel.DataAnnotations;
using System;

namespace Emedicine.Models
{
    public class Users
    {
        //public int ID { get; set; }
        //[StringLength(100, ErrorMessage = "First Name cannot be longer than 100 characters.")]
        //public string FirstName { get; set; } // Maps to FirstName column in the database
        //[StringLength(100, ErrorMessage = "Last Name cannot be longer than 100 characters.")]
        //public string LastName { get; set; } // Maps to LastName column in the database
        //[Required(ErrorMessage = "Password is required.")]
        //[StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long and no more than 100 characters.")]
        //public string Password { get; set; } // Maps to Password column in the database
        //[Required(ErrorMessage = "Email is required.")]
        //[EmailAddress(ErrorMessage = "Invalid email address format.")]
        //[StringLength(100, ErrorMessage = "Email cannot be longer than 100 characters.")]
        //public string Email { get; set; } // Maps to Email column in the database
        //[Range(0, double.MaxValue, ErrorMessage = "Fund must be a positive number.")]
        //public decimal? Fund { get; set; } // Maps to Fund column in the database (nullable)
        //[StringLength(100, ErrorMessage = "Type cannot be longer than 100 characters.")]
        //public string Type { get; set; } // Maps to Type column in the database

        //[Range(0, int.MaxValue, ErrorMessage = "Status must be a non-negative number.")]
        //public int? Status { get; set; }
        //public DateTime CreatedOn { get; set; }
        //[StringLength(11, ErrorMessage = "Phone number cannot be longer than 11 digits.")]
        //[RegularExpression("^[0-9]*$", ErrorMessage = "Phone number can only contain numeric values.")]
        //public string PhoneNumber { get; set; }
        //public ICollection<Orders> Orders { get; set; }

        public int ID { get; set; }
        
        public string FirstName { get; set; } // Maps to FirstName column in the database
        
        public string LastName { get; set; } // Maps to LastName column in the database
        
      
        public string Password { get; set; } // Maps to Password column in the database
        
        public string Email { get; set; } // Maps to Email column in the database
        
        public decimal? Fund { get; set; } // Maps to Fund column in the database (nullable)
        
        public string Type { get; set; } // Maps to Type column in the database

        
        public int? Status { get; set; }
        public DateTime CreatedOn { get; set; }
        
        public string PhoneNumber { get; set; }
        public ICollection<Orders> Orders { get; set; }





    }
}
