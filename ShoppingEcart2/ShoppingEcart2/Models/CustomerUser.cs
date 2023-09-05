//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShoppingEcart2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class CustomerUser
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Please enter Firstname ")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter Lastname ")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="Please enter username ")]
        [DisplayName("Username")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter Password ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        [Compare("Password")]
        [Required(ErrorMessage = "Please enter Confirm Password ")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Please enter Email ")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string LoginErrorMessage { get; set; }

    }
}
