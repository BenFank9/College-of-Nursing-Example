using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IS_413_Assignment_3.Models
{
    public class NewMovie
    {
        //Categories are required
        [Required]
        public string Category { get; set; }

        //Titles are required
        [Required]
        public string Title { get; set; }

        //Years are required and movies can not have come out in the future so cap the years at 2021
        [Required]
        [Range(1000, 2021, ErrorMessage ="Must enter a number between 1000 to 2021")]
        public int Year { get; set; }

        //Director Names are required
        [Required(ErrorMessage = "Director Names are required")]
        public string Director { get; set; }

        //Ratings are required 
        [Required(ErrorMessage ="Ratings are required")]
        public string Rating { get; set; }

        //edited, lent to , and notes are all optional but notes does have a 25 character limit
        public bool? Edited { get; set; }

        public string LentTo { get; set; }

        [StringLength(25, ErrorMessage ="Notes must be 25 characters or less")]
        public string Notes { get; set; }
    }
}
