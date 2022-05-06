using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Bills.Models
{
    public class Item
    {
       // Item( type ID  ----okkkkkay    , unit ID -------okkkkkay , company ID -----!!!!!)
        public int Id { get; set; }
        [Required (ErrorMessage = "* ITEM NAME is Required")]
        [Remote(action: "TestItemName", controller: "Item"
            , ErrorMessage = "* ITEM NAME has already existed before")]
        public string Name { get; set; }
        public string Notes { get; set; }
        //beginning quantity
        [Range(0, int.MaxValue, ErrorMessage = "SELLING PRICE Must be Greater than or equal Zero")]
        [Required(ErrorMessage = "* Beginning Quantity is Required")]
        public int Stock { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "* SELLING PRICE Must be Greater than or equal Zero")]
        [Required(ErrorMessage = "* Selling Price is Required")]
        public int SellingPrice { get; set; }
        [Required(ErrorMessage = "* Buying Price is Required")]
        [Range(0, int.MaxValue, ErrorMessage = "SELLING PRICE Must be Greater than or equal Zero")]
        [Remote(action: "TestPrice", controller: "Item", AdditionalFields = "SellingPrice"
            , ErrorMessage = "* BUYING PRICE Must be less than or equal SELLING PRICE")]
        public int BuyingPrice { get; set; }
        public DateTime Created { get; set; }

        [ForeignKey("Type")]
        [Required(ErrorMessage = "* TYPE NAME is Required")]
        public int Type_Id { get; set; }
        public virtual Type Type { get; set; }


        [ForeignKey("Unit")]
        [Required(ErrorMessage = "* Unit NAME is Required")]
        public int Unit_Id { get; set; }
        public virtual Unit Unit { get; set; }

        [ForeignKey("company")]
        [Required(ErrorMessage = "* COMPANY NAME is Required")]
        public int Comp_Id { get; set; }
        public virtual Company company { get; set; }


        public virtual List<SalesDetalis> SalesDetalis { get; set; }



    }
}
