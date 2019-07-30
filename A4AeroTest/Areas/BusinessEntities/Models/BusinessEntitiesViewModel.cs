using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace A4AeroTest.Areas.BusinessEntities.Models
{
    public class BusinessEntitiesViewModel
    {
        public int Id { get; set; }


        public string Code { get; set; }

        [EmailAddress(ErrorMessage = "not a valid Emial"),]
        public string Email { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Display(Name="Address")]
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        
        public string Mobile { get; set; }
        
        public string Phone { get; set; }
        public string ContactPerson { get; set; }
        public string ReferredBy { get; set; }
        public string Logo { get; set; }
        public int? Status { get; set; }

        [Required(ErrorMessage = "balnace is reuired")]
        public decimal Balance { get; set; }

        public string LoginUrl { get; set; }

        public string SecurityCode { get; set; }
        public string SMTPServer { get; set; }
        public int? SMTPPort { get; set; }
        public string SMTPUsername { get; set; }
        public string SMTPPassword { get; set; }
    }
}
