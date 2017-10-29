using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication8.Models
{
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$",
        ErrorMessage = "Please enter valid email.")]
        public string Email { get; set; }



        [Required(ErrorMessage = "Username is required.")]
        [RegularExpression(@"^([a-zA-Z][\w.]+|[0-9][0-9_.]*[a-zA-Z]+[\w.]*)$",
         ErrorMessage = "Invalid type.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression(@"^([a-zA-Z]+[\d]+|[\d]+[a-zA-Z]+)[^\s]*$",
        ErrorMessage = "Invalid type.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Please confirm your password.")]
        [DataType(DataType.Password)]
        public string Confirm { get; set; }

        

    }
}