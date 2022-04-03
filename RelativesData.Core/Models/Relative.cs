using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RelativesData.Ef.Models
{
    [Table("Relatives")]
    public class Relative
    {
        public int RelativeId { get; set; }

        //[Required(ErrorMessage = "SapNumber  is required")]
        [Range(1, int.MaxValue, ErrorMessage = "SapNumber must be between {1} and {2}.")]

        public int SapNumber { get; set; }

        [Required(ErrorMessage = "FullName  is required")]
        [MaxLength(500)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Gender  is required")]
        [MaxLength(20)]
        public string Relationship { get; set; }

        [Required(ErrorMessage = "Gender  is required")]
        [MaxLength(10)]
        public string Gender { get; set; }

        [Required(ErrorMessage = "BirthDate  is required")]
        [MaxLength(20)]
        public string BirthDate { get; set; }

        [Required(ErrorMessage = "SourceDate  is required")]
        [MaxLength(20)]
        public string SourceDate { get; set; }

        [Required(ErrorMessage = "LastChange  is required")]
        [MaxLength(20)]
        public string LastChange { get; set; }

        [Range(0, 1, ErrorMessage = "SapNumber must be between {1} and {2}.")]
        [Required(ErrorMessage = "isEmployee  is required")]
        public int isEmployee { get; set; }




    }
}
