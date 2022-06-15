using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lcw_GraduationProject.Application.ViewModels.Offers
{
    public class VM_Get_OfferDetail
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public string UserName { get; set; } //TODO: Tabloda isim+soyisim kolonu açılıp o alan basılacak
        public float Price { get; set; }
        public int Status { get; set; }
    }
}
