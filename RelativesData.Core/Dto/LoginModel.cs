using RelativesData.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RelativesData.Core.Dto
{
    public class LoginModel
    {
        [Range(1, int.MaxValue, ErrorMessage = "SapNumber must be between {1} and {2}.")]
        public int SapNumber { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "secretKey is required")]

        public string secretKey { get; set; }

    }
}
