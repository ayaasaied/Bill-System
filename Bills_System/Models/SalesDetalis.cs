using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Bills.Models
{
    public class SalesDetalis
    {
        //Sales details( item id, sales id)--------okay
        
        public int Id { get; set; }
        public int Price { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "* Quantity Must be Greater than or equal Zero")]
        [Required(ErrorMessage = "* Quantity is Required")]
        [Remote(action: "TestQuantity", controller: "Sales", AdditionalFields = "Item_Id"
            , ErrorMessage = "* Quantity Must be less than stock")]
        public int quantity { get; set; }


        [ForeignKey("I")]
        [Required(ErrorMessage = "* Item NAME is Required")]

        public int Item_Id { get; set; }

        [ForeignKey("S")]
        
        public int Sales_Id { get; set; }

        public virtual Item I { get; set; }
        public virtual Sales S { get; set; }


    }
}
