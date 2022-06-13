using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lcw_GraduationProject.Application.ViewModels.Products
{
    public class VM_Create_Product
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public string CategoryId { get; set; }
        public string UserId { get; set; }
    }
}
