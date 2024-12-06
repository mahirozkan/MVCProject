using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models
{
    public class AuthorViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Name")]  // Görüntülenecek etiket adı
        [Required(ErrorMessage = "Name is required.")]  // Zorunlu alan ve hata mesajı
        public string FirstName { get; set; } = " ";
        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Surname is required.")]
        public string LastName { get; set; } = " ";
        [Display(Name = "Date Of Birth")]
        [Required(ErrorMessage = "Date Of Birth is required.")]
        public DateTime DateOfBirth { get; set; }

        public List<Book> Books { get; set; }
        public string FullName => FirstName + " " + LastName;
    }
}
