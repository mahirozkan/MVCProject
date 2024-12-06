using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models
{
    public class BookCreateViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Title")] // Görüntülenecek etiket adı
        [Required(ErrorMessage = "Title is required.")] // Zorunlu alan ve hata mesajı
        public string Title { get; set; } = "";
        public int AuthorId { get; set; }
        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Genre is required.")]
        public string Genre { get; set; } = "";
        [Display(Name = "Publish Date")]
        [Required(ErrorMessage = "Publish Date is required.")]
        public DateTime PublishDate { get; set; }
        [Display(Name = "ISBN")]
        [Required(ErrorMessage = "ISBN is required.")]
        public string ISBN { get; set; } = "";
        [Display(Name = "Available Copies")]
        [Required(ErrorMessage = "Available Copies is required.")]
        public int CopiesAvailable { get; set; }
    }
}
