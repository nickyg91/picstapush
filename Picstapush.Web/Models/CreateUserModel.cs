using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Picstapush.Web.Validators;

namespace Picstapush.Web.Models
{
    public class CreateUserModel
    {
        [Required, MinLength(6, ErrorMessage = "Username must be at least 10 characters long")]
        public string Username { get; set; }
        [Required, EmailAddress(ErrorMessage = "Value must be a valid email address.")]
        public string Email { get; set; }
        [Required, RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[*.!@$%^&(){}[\\]]:;<>,.?\/~_+-=|).{8,32}$"), MinLength(8), MaxLength(32)]
        public string Password { get; set; }
        [Required, PropertyHasSameValue("Password", ErrorMessage = "Confirm password must be equal to Password.")]
        public string ConfirmPassword { get; set; }
    }
}
