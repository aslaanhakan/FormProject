using System.ComponentModel.DataAnnotations;

namespace FormProject.MVC.Models
{
    public class FormViewModel
    {
        public FormViewModel()
        {
            Forms= new List<FormViewModel>();
        }
        public int FormId { get; set; }
        public string FormName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "Ad boş bırakılamaz")]
        public string FieldFirstName { get; set; }
        [Required(ErrorMessage = "Soyad boş bırakılamaz")]
        public string FieldLastName { get; set; }
        public int Age { get; set; }
        public List<FormViewModel> Forms { get; set; }

    }
}
