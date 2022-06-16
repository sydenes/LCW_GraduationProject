namespace Lcw_GraduationProject.UI.Models.Product
{
    public class VM_Create_Product
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public string CategoryId { get; set; }
        public string UserId { get; set; }
        public bool isOfferable { get; set; }
    }
}
