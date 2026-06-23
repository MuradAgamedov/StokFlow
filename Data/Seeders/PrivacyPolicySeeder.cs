using ModernWMC.Data.Concrete.EntityFramework;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Data.Seeders
{
    public static class PrivacyPolicySeeder
    {
        public static void Seed(StokFlowAppContext context)
        {
            if (!context.PrivacyPolicies.Any())
            {
                context.PrivacyPolicies.Add(new PrivacyPolicy
                {
                    Title = "Gizlilik Siyasəti",
                    SubText = "Sizin məlumatlarınızın təhlükəsizliyi və konfidensiallığı bizim üçün ən yüksək prioritetdir.",
                    Content = @"
                        <div class='toc'>
                            <h4><i class='bi bi-list-ul me-2'></i>Mündəricə</h4>
                            <ul>
                                <li><a href='#section1'>1. Məlumatların Toplanması və İstifadəsi</a></li>
                                <li><a href='#section2'>2. Təhlükəsizlik Zəmanəti</a></li>
                                <li><a href='#section3'>3. Məlumatların Paylaşılmaması</a></li>
                                <li><a href='#section4'>4. İstifadəçi Hüquqları</a></li>
                                <li><a href='#section5'>5. Əlaqə Məlumatları</a></li>
                            </ul>
                        </div>

                        <div class='privacy-section' id='section1'>
                            <h3><i class='bi bi-1-circle me-2'></i>Məlumatların Toplanması və İstifadəsi</h3>
                            <p>
                                Sistemdən istifadə edərkən daxil etdiyiniz anbar, məhsul, satınalma və digər logistika məlumatları tamamilə konfidensial saxlanılır 
                                və yalnız sizin şirkətinizin ERP/WMS ehtiyaclarını qarşılamaq məqsədilə emal edilir.
                            </p>
                            <div class='privacy-highlight'>
                                <strong><i class='bi bi-info-circle me-2'></i>Məlumat Keçmiş:</strong> Biz yalnız fəaliyyətinizi optimize etmək üçün lazım olan minimum məlumatları toplayırıq.
                            </div>
                        </div>

                        <div class='privacy-section' id='section2'>
                            <h3><i class='bi bi-2-circle me-2'></i>Təhlükəsizlik Zəmanəti</h3>
                            <p>
                                Bütün verilənlər bazası bağlantıları və şifrələr müasir SSL/TLS şifrələmə protokolları ilə qorunur. İstifadəçi səviyyəsində 
                                səlahiyyətləndirmə sayəsində hər bir işçi yalnız administrator tərəfindən ona icazə verilən modullara və anbarlara giriş edə bilər.
                            </p>
                            <ul class='list-group mt-3'>
                                <li class='list-group-item'>
                                    <strong><i class='bi bi-shield-check text-success me-2'></i>End-to-End Şifrələmə:</strong> 
                                    Bütün əlaqələr SSL/TLS ilə qorunur
                                </li>
                                <li class='list-group-item'>
                                    <strong><i class='bi bi-key text-success me-2'></i>Güclü Şifrə Siyasəti:</strong> 
                                    Minimum 8 simvol, rəqəm və xüsusi simvollar tələb olunur
                                </li>
                                <li class='list-group-item'>
                                    <strong><i class='bi bi-eye-slash text-success me-2'></i>İkidən-Amilli Yoxlama:</strong> 
                                    Seçməli olaraq 2FA aktivləşdirmə
                                </li>
                            </ul>
                        </div>

                        <div class='privacy-section' id='section3'>
                            <h3><i class='bi bi-3-circle me-2'></i>Məlumatların Paylaşılmaması</h3>
                            <p>
                                WMS Pro heç bir halda topladığı B2B və ya şəxsi istifadəçi məlumatlarını üçüncü tərəflərə ötürmür, satmır və ya paylaşmır. 
                                Məlumatlarınız yalnız bizim serverlərimizdə saxlanılır.
                            </p>
                            <div class='privacy-highlight'>
                                <strong><i class='bi bi-check-circle me-2'></i>Əminlik:</strong> 
                                Məlumatlarınız yalnız siz, məcburi qanun istəyi olmadıqca, heç kə ilə bölüşülməyəcəkdir.
                            </div>
                        </div>

                        <div class='privacy-section' id='section4'>
                            <h3><i class='bi bi-4-circle me-2'></i>İstifadəçi Hüquqları</h3>
                            <p>Hər bir istifadəçi aşağıdakı hüquqlara malikdir:</p>
                            <ul class='list-group mt-3'>
                                <li class='list-group-item'>
                                    <strong><i class='bi bi-file-earmark text-primary me-2'></i>Məlumat Tələbləri:</strong> 
                                    Bizdə saxlanan bütün şəxsi məlumatlarınıza daxil olmaq hüququ
                                </li>
                                <li class='list-group-item'>
                                    <strong><i class='bi bi-arrow-clockwise text-primary me-2'></i>Düzəltmə Hüququ:</strong> 
                                    Qeyri-dəqiq məlumatları düzəltmək hüququ
                                </li>
                                <li class='list-group-item'>
                                    <strong><i class='bi bi-trash text-primary me-2'></i>Silmə Hüququ:</strong> 
                                    Müəyyən şərtlərdə məlumatlarınızın silinməsini tələb etmək hüququ
                                </li>
                            </ul>
                        </div>

                        <div class='privacy-section' id='section5'>
                            <h3><i class='bi bi-5-circle me-2'></i>Əlaqə Məlumatları</h3>
                            <p>
                                Gizlilik siyasətinə dair hər hansi bir sual və ya qayğı varsa, lütfən bizimlə əlaqə saxlayın:
                            </p>
                            <div class='alert alert-info mt-3' role='alert'>
                                <i class='bi bi-envelope me-2'></i>
                                <strong>E-poçt:</strong> privacy@wmspro.az
                            </div>
                        </div>
                    ",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                });

                context.SaveChanges();
            }
        }
    }
}
