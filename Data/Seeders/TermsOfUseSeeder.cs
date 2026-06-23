using ModernWMC.Data.Concrete.EntityFramework;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Data.Seeders
{
    public static class TermsOfUseSeeder
    {
        public static void Seed(StokFlowAppContext context)
        {
            if (!context.TermsOfUses.Any())
            {
                context.TermsOfUses.Add(new TermsOfUse
                {
                    Title = "İstifadə Şərtləri",
                    SubText = "Platformamızdan istifadə etməzdən əvvəl bu şərtləri diqqətlə oxuyun.",
                    Content = @"
                        <div class='toc'>
                            <h4><i class='bi bi-list-ul me-2'></i>Mündəricə</h4>
                            <ul>
                                <li><a href='#section1'>1. Qəbul və Razılıq</a></li>
                                <li><a href='#section2'>2. İstifadəçi Öhdəlikləri</a></li>
                                <li><a href='#section3'>3. Məlumatların Mülkiyyəti</a></li>
                                <li><a href='#section4'>4. Məsuliyyətin Məhdudlaşdırılması</a></li>
                                <li><a href='#section5'>5. Xidmətin Dayandırılması</a></li>
                                <li><a href='#section6'>6. Əlaqə Məlumatları</a></li>
                            </ul>
                        </div>

                        <div class='privacy-section' id='section1'>
                            <h3><i class='bi bi-1-circle me-2'></i>Qəbul və Razılıq</h3>
                            <p>
                                WMS Pro platformasına daxil olaraq və ya istifadə edərək bu İstifadə Şərtlərini tam olaraq qəbul etmiş
                                hesab olunursunuz. Əgər bu şərtlərlə razı deyilsinizsə, platformadan istifadə etməyin.
                            </p>
                            <div class='privacy-highlight'>
                                <strong><i class='bi bi-info-circle me-2'></i>Qeyd:</strong> Bu şərtlər hər zaman yenilənə bilər. Dəyişikliklər haqqında istifadəçilərə e-poçt vasitəsilə məlumat veriləcəkdir.
                            </div>
                        </div>

                        <div class='privacy-section' id='section2'>
                            <h3><i class='bi bi-2-circle me-2'></i>İstifadəçi Öhdəlikləri</h3>
                            <p>
                                Platformadan istifadə edərkən aşağıdakı öhdəlikləri yerinə yetirməlisiniz:
                            </p>
                            <ul class='list-group mt-3'>
                                <li class='list-group-item'>
                                    <strong><i class='bi bi-check-circle text-success me-2'></i>Doğru Məlumat:</strong>
                                    Qeydiyyat zamanı düzgün və aktual məlumatlar vermək
                                </li>
                                <li class='list-group-item'>
                                    <strong><i class='bi bi-lock text-success me-2'></i>Hesab Təhlükəsizliyi:</strong>
                                    Hesab məlumatlarınızı gizli saxlamaq və icazəsiz girişi dərhal bildirmək
                                </li>
                                <li class='list-group-item'>
                                    <strong><i class='bi bi-ban text-success me-2'></i>Qadağan Edilmiş Fəaliyyətlər:</strong>
                                    Platformaya zərər verə biləcək hər hansı fəaliyyətdən çəkinmək
                                </li>
                            </ul>
                        </div>

                        <div class='privacy-section' id='section3'>
                            <h3><i class='bi bi-3-circle me-2'></i>Məlumatların Mülkiyyəti</h3>
                            <p>
                                Platforma vasitəsilə daxil etdiyiniz bütün biznes məlumatları (anbar, məhsul, sifariş və s.)
                                sizin mülkiyyətinizdir. WMS Pro bu məlumatları yalnız sizə xidmət göstərmək məqsədilə emal edir.
                            </p>
                            <div class='privacy-highlight'>
                                <strong><i class='bi bi-shield-check me-2'></i>Zəmanət:</strong>
                                Məlumatlarınız heç bir halda üçüncü tərəflərə satılmır və ya paylaşılmır.
                            </div>
                        </div>

                        <div class='privacy-section' id='section4'>
                            <h3><i class='bi bi-4-circle me-2'></i>Məsuliyyətin Məhdudlaşdırılması</h3>
                            <p>
                                WMS Pro platforması olduğu kimi təqdim edilir. Biz aşağıdakı hallarda məsuliyyət daşımırıq:
                            </p>
                            <ul class='list-group mt-3'>
                                <li class='list-group-item'>
                                    <strong><i class='bi bi-exclamation-triangle text-warning me-2'></i>Texniki Nasazlıqlar:</strong>
                                    İnternet bağlantısı kəsilmələri və ya server texniki xidmətindən yaranan fasilələr
                                </li>
                                <li class='list-group-item'>
                                    <strong><i class='bi bi-exclamation-triangle text-warning me-2'></i>İstifadəçi Səhvləri:</strong>
                                    İstifadəçinin yanlış məlumat daxil etməsindən yaranan zərərlər
                                </li>
                                <li class='list-group-item'>
                                    <strong><i class='bi bi-exclamation-triangle text-warning me-2'></i>Force Majeure:</strong>
                                    Bizim nəzarətimizdən kənar hadisələrdən (təbii fəlakətlər, müharibə və s.) yaranan itkilər
                                </li>
                            </ul>
                        </div>

                        <div class='privacy-section' id='section5'>
                            <h3><i class='bi bi-5-circle me-2'></i>Xidmətin Dayandırılması</h3>
                            <p>
                                WMS Pro aşağıdakı hallarda hesabınızı müvəqqəti dayandıra və ya tamamilə silə bilər:
                            </p>
                            <div class='privacy-highlight'>
                                <strong><i class='bi bi-x-circle me-2'></i>Hesab Bloklanması:</strong>
                                Bu şərtlərin pozulması, abunə ödənişinin gecikdirilməsi və ya platforma qaydalarına zidd davranış aşkar edildikdə.
                            </div>
                        </div>

                        <div class='privacy-section' id='section6'>
                            <h3><i class='bi bi-6-circle me-2'></i>Əlaqə Məlumatları</h3>
                            <p>
                                İstifadə şərtlərinə dair hər hansı sual varsa, bizimlə əlaqə saxlayın:
                            </p>
                            <div class='alert alert-info mt-3' role='alert'>
                                <i class='bi bi-envelope me-2'></i>
                                <strong>E-poçt:</strong> legal@wmspro.az
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
