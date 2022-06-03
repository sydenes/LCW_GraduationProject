using System.ComponentModel.DataAnnotations;

namespace Lcw_GraduationProject.UI.Models.User
{
    public class VM_Create_User
    {
        [Display(Name = "FirstName", Prompt = "Name")]
        [DataType(DataType.Text, ErrorMessage = "{0} exception")]
        [StringLength(100, ErrorMessage = "min10-max100 character", MinimumLength = 10)]
        [Required(ErrorMessage = "{0} is Required")]
        public string FirstName { get; set; }

        [Display(Name = "LastName", Prompt = "Surname")]
        [DataType(DataType.Text, ErrorMessage = "{0} exception")]
        [StringLength(100, ErrorMessage = "min10-max100 character", MinimumLength = 10)]
        [Required(ErrorMessage = "{0} is Required")]
        public string LastName { get; set; }

        [Display(Name = "Mail", Prompt = "Mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "{0} exception")]
        [StringLength(100, ErrorMessage = "min10-max100 character", MinimumLength = 10)]
        [Required(ErrorMessage = "{0} is Required")]
        public string Mail { get; set; }

        [Display(Name = "Password", Prompt = "Password")]
        [DataType(DataType.Password, ErrorMessage = "{0} exception")]
        [StringLength(20, ErrorMessage = "min8-max20 character", MinimumLength = 8)]
        [Required(ErrorMessage = "{0} is Required")]
        public string Password { get; set; }
    }
}
