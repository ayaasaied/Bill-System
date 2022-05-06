using System;
using System.ComponentModel.DataAnnotations;
using Bills.Services;

namespace Bills.ViewModels
{

    public class SalesReport
    {
        

        [Required(ErrorMessage = "* startDate is Required")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime startDate { get; set; }
        
        [Required(ErrorMessage = "* endDate is Required")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime endDate { get; set; }

    }
}
