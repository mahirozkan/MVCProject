using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Title")]  // Görüntülenecek etiket adı
        [Required(ErrorMessage = "Title is required.")]  // Zorunlu alan ve hata mesajı
        public string Title { get; set; }

        public int AuthorId { get; set; }
        [Display(Name = "AuthorName")]
        [Required(ErrorMessage = "AuthorName is required.")]
        public string AuthorName { get; set; }
        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Genre is required.")]
        public string Genre { get; set; }
        [Display(Name = "PublishDate")]
        [Required(ErrorMessage = "PublishDate is required.")]
        public DateTime PublishDate { get; set; }
        [Display(Name = "ISBN")]
        [Required(ErrorMessage = "ISBN is required.")]
        public string ISBN { get; set; }
        [Display(Name = "CopiesAvailable")]
        [Required(ErrorMessage = "CopiesAvailable is required.")]
        public int CopiesAvailable { get; set; }
    }
}
