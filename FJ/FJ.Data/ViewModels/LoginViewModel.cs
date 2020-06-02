using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FJ.Data.ViewModels
{
    public class LoginIndexViewModel
    {
        [Required(ErrorMessage ="請輸入帳號")]
        [RegularExpression("^[A-Za-z0-9]+$",ErrorMessage ="只能輸入數字和英文")]
        public string Account { get; set; }
        [Required]
        [RegularExpression("^[A-Za-z0-9]+$")]
        public string Password { get; set; }
    }
}
