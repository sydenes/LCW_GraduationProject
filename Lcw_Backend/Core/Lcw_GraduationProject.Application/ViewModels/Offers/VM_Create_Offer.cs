using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lcw_GraduationProject.Application.ViewModels.Offers
{
    public class VM_Create_Offer
    {
        public string ProductId { get; set; }
        public string UserId { get; set; }
        public float Price { get; set; }
        public int Status { get; set; }
    }
}
