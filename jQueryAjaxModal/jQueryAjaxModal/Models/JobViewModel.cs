using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace jQueryAjaxModal.Models
{
    public class JobViewModel
    {
        [Key]
        public short ID { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Tên công việc")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Mức lương")]
        public decimal Salary { get; set; }
        [Display(Name = "Ngày tạo")]
        [DataType(DataType.DateTime), Required(ErrorMessage = "This field is required.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public System.DateTime Datecreated { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Kích hoạt")]
        public bool Activated { get; set; }

    }
}