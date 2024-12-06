using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models
{
    public class AuthorCreateViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Name")] // View'da gösterilecek etiket adı
        [Required(ErrorMessage = "Name is required.")] // Zorunlu alan, hata mesajı ile
        public string FirstName { get; set; } = "";

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Surname is required.")]
        public string LastName { get; set; } = "";

        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Date of Birth is required.")]
        public DateTime? DateOfBirth { get; set; }
    }
}