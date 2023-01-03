using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerWebMVC.Models
{
    public class CustomModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Customer Name")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Please Enter Customer Address")]
        public string CustomerAddress { get; set; }

        [Required(ErrorMessage = "Please Enter Customer Age")]
        public int CustomAge { get; set; }

        [Required(ErrorMessage = "Please Enter Customer Phone")]
        public long CustomerPhone { get; set; }
    }
}
