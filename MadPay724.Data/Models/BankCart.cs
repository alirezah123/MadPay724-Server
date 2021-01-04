using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MadPay724.Data.Models
{
    public class BankCart : BaseEntity<string>
    {
        public BankCart()
        {
            Id = Guid.NewGuid().ToString();
            DateCreated = DateTime.Now;
            DateModified = DateTime.Now;
        }
        [Required]
        public string BankName { get; set; }
        
        public string Shaba { get; set; }
        [Required]
        [Range(16,16)]
        public string CartNumber { get; set; }
        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string ExpireDateMonth { get; set; }
        [Required]
        [StringLength(2,MinimumLength =2)]
        public string ExpireDateYear { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }



    }
}
