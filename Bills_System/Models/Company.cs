using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Bills.Models
{
    public class Company
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "* Company Name is Required")]
        [Remote(action: "uniquename", controller: "Company", ErrorMessage = "* This Company Is Already Exist")]
        public string Name { get; set; }
        public string Notes { get; set; }

        public virtual List<Item> Items { get; set; }

        public virtual List<Type> Types { get; set; }

    }
}
