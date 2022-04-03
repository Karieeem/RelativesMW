using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RelativesData.Core.Models
{
    [Table("Users")]
    public class User
    {

        [Range(1, int.MaxValue, ErrorMessage = "SapNumber must be between {1} and {2}.")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SapNumber { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }


    }
}
