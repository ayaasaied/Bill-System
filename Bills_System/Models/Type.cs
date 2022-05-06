using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Bills.Models
{
    public class Type
    {
        //Type ( company id)-----okayyyyy(1 (company) - M (type))

        public int Id { get; set; }
        [Remote(action: "UniqueTypeName", controller: "Type", ErrorMessage = "* Type Name has already existed before")]
        [Required(ErrorMessage = "* Type Name is Required")]
        public string Name { get; set; }
        public string Notes { get; set; }


        [ForeignKey("Company")]
        [Required(ErrorMessage = "* Company Name is Required")]
        public int Campany_Id { get; set; }

        public virtual Company Company { get; set; }

        public virtual List<Item> Items { get; set; }

    }
}
