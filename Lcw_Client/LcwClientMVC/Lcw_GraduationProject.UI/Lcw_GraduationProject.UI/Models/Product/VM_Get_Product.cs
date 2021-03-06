using System;

namespace Lcw_GraduationProject.UI.Models.Product
{
    public class VM_Get_Product
    {
        public Guid Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public bool isOfferable { get; set; }=true;
        public bool isSold { get; set; }=false;
    }
}
