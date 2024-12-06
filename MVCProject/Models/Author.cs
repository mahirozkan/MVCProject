namespace MVCProject.Models
{
    public class Author
    {
        public int Id { get; set; }  // Yazarın benzersiz kimlik numarası
        public string FirstName { get; set; } = string.Empty;  // Yazarın adı
        public string LastName { get; set; } = string.Empty;  // Yazarın soyadı
        public DateTime DateOfBirth { get; set; }  // Yazarın doğum tarihi
        public string FullName => FirstName + " " + LastName;  // Yazarın tam adı (Ad + Soyad birleştirilmiş hali)

    }
}
