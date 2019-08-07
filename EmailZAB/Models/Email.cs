using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmailZAB.Models
{
    public class Email
    {
        public int EmailId { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9.+-]+@[a-zA-Z0-9-.]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email Format")]
        [Display(Name = "sender Email")]
        public String Sender { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9.+-]+@[a-zA-Z0-9-.]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email Format")]
        [Display(Name = "receiver Email")]
        public String Receiver { get; set; }

        [Required]  //we declare the Name mandatory by specifying [Required] attribute
        [MaxLength(50, ErrorMessage = "Subject can not exit 50 characters")]
        public String Subject { get; set; }

        public String HtmlMessage { get; set; }
    }
}
