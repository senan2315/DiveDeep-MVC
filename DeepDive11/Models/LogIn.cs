using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DeepDive11.Models
{
    public class LogIn
    {
        [Required(ErrorMessage = "Email skal udfyldes")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Kodeord skal udfyldes")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
