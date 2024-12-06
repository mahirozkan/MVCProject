namespace MVCProject
{
    public class Program // Program s�n�f�, uygulaman�n ba�lang�� noktas�n� i�erir
    {
        // Main metodunda uygulama ba�lat�l�r
        public static void Main(string[] args)
        {
            // WebApplication builder'� olu�turur
            var builder = WebApplication.CreateBuilder(args);

            // MVC yap�s�n� kullanarak Controller ve View'lar� ekler
            builder.Services.AddControllersWithViews();

            // Uygulamay� in�a eder
            var app = builder.Build();

            // E�er ortam geli�tirme de�ilse, hata sayfas�n� y�nlendirir
            if (!app.Environment.IsDevelopment())
            {
                // Hata sayfas�n� "/Home/Error" olarak ayarlar
                app.UseExceptionHandler("/Home/Error");
                // HSTS (HTTP Strict Transport Security) kullanarak HTTPS zorunlulu�u getirir
                app.UseHsts();
            }
            // HTTPS y�nlendirmesini etkinle�tirir
            app.UseHttpsRedirection();
            // Statik dosyalar�n sunulmas�na izin verir (CSS, JS, vb.)
            app.UseStaticFiles();
            // Uygulaman�n route (y�nlendirme) yap�land�rmas�n� ba�lat�r
            app.UseRouting();
            // Kullan�c� do�rulama i�lemleri i�in Authorization middleware'ini ekler
            app.UseAuthorization();
            // Varsay�lan controller ve action rota desenini belirler
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            // Uygulaman�n �al��mas�n� ba�lat�r
            app.Run();
        }
    }
}
