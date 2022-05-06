using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Bills.Models
{
    public class Sales
    {
        //Sales( client Id )

        public int Id { get; set; }
        public float TotalBill { get; set; }

        private DateTime _Date = DateTime.MinValue;
        [Required(ErrorMessage = "* Date is Required")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date
        {
            get
            {
                return (_Date == DateTime.MinValue) ? DateTime.Now : _Date;
            }
            set
            {
                _Date = value;
            }
        }
        [Required(ErrorMessage = "* PAIED is Required")]
        [Range(0, int.MaxValue, ErrorMessage = "* PAIED Must be Greater than or equal Zero")]
        
        public float paied { get; set; }
        public int BillsNumber { get; set; }
        [Required(ErrorMessage = "* Percentage discount is Required")]
        [Range(0, int.MaxValue, ErrorMessage = "* Percentage discount Must be Greater than or equal Zero")]
        public float TpercentDiscount { get; set; }
        [Required(ErrorMessage = "* Value discount is Required")]
        [Range(0, int.MaxValue, ErrorMessage = "* Value discount Must be Greater than or equal Zero")]
        public float TvalueDiscount { get; set; }

        [ForeignKey("Client")]
        [Required(ErrorMessage = "* CLIENT NAME is Required")]
        public int? Client_Id { get; set; } 
        
        public virtual Client Client { get; set; }

        public virtual List<SalesDetalis> SalesDetalis { get; set; }
    }
}
