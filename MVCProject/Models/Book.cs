namespace MVCProject.Models
{
    public class Book
    {
        public int Id { get; set; }  // Kitabın benzersiz kimlik numarası
        public string Title { get; set; }  // Kitabın adı
        public int AuthorId { get; set; }  // Kitabın yazarı ile ilişkilendirilmiş yazar kimlik numarası
        public Author Author { get; set; }  // Kitabın yazarıyla birebir ilişki (navigasyon özelliği)
        public string Genre { get; set; }  // Kitabın türü
        public DateTime PublishDate { get; set; }  // Kitabın yayın tarihi
        public string ISBN { get; set; }   // Kitabın Uluslararası Standart Kitap Numarası (ISBN)
        public int CopiesAvailable { get; set; }  // Kitabın mevcut kopya sayısı
    }
}
