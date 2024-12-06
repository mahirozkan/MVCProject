namespace MVCProject
{
    public class Program // Program sýnýfý, uygulamanýn baþlangýç noktasýný içerir
    {
        // Main metodunda uygulama baþlatýlýr
        public static void Main(string[] args)
        {
            // WebApplication builder'ý oluþturur
            var builder = WebApplication.CreateBuilder(args);

            // MVC yapýsýný kullanarak Controller ve View'larý ekler
            builder.Services.AddControllersWithViews();

            // Uygulamayý inþa eder
            var app = builder.Build();

            // Eðer ortam geliþtirme deðilse, hata sayfasýný yönlendirir
            if (!app.Environment.IsDevelopment())
            {
                // Hata sayfasýný "/Home/Error" olarak ayarlar
                app.UseExceptionHandler("/Home/Error");
                // HSTS (HTTP Strict Transport Security) kullanarak HTTPS zorunluluðu getirir
                app.UseHsts();
            }
            // HTTPS yönlendirmesini etkinleþtirir
            app.UseHttpsRedirection();
            // Statik dosyalarýn sunulmasýna izin verir (CSS, JS, vb.)
            app.UseStaticFiles();
            // Uygulamanýn route (yönlendirme) yapýlandýrmasýný baþlatýr
            app.UseRouting();
            // Kullanýcý doðrulama iþlemleri için Authorization middleware'ini ekler
            app.UseAuthorization();
            // Varsayýlan controller ve action rota desenini belirler
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            // Uygulamanýn çalýþmasýný baþlatýr
            app.Run();
        }
    }
}
