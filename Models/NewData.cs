using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models
{
    public class NewData
    {
        // Set MovieId to be the key to be used for update and delete function in the controller.
        [Key]
        public int MovieId { get; set; }

        [Required(ErrorMessage="This field is required!")]
        public String Category { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        public String Title { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        public String Year { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        public String Director { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        public String Rating { get; set; }

        public Nullable<Boolean> Edited { get; set; }

        public String LentTo { get; set; }

        [StringLength(25)]
        public String Notes { get; set; }
    }
}
