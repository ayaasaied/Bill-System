using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Bills.Models
{
    public class Client
    {
        [Display(Name="Number")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Client Name is Required")]
        [Remote(action: "UniqueName",
               controller: "Client",
               ErrorMessage = "Client Name has already existed before")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Phone Number is Required")]
        [MinLength(11, ErrorMessage = " must be just a 11 digit number")]
        [StringLength(11, ErrorMessage = " must be just a 11 digit number")]
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }


        public virtual List<Sales> Sales { get; set; }


    }
}