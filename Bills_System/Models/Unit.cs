using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Bills.Models
{
    public class Unit
    {
        //Unit ( item id)-------okay
        public int Id { get; set; }
        [Required(ErrorMessage = "* Unit Name is Required")]
        [Remote(action: "uniquename", controller: "Unit", ErrorMessage = "* UNIT NAME has already existed before")]
        public string Name { get; set; }
        public string Notes { get; set; }


        public virtual List<Item> Items { get; set; }

    }
}
