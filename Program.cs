using ModernWMC.Data.Concrete.EntityFramework;
using ModernWMC.Data.Seeders;
using Microsoft.EntityFrameworkCore;
using ModernWMC.Data.Abstract;
using ModernWMC.Services.Abstract;
using ModernWMC.Services.Concrete;
using Microsoft.AspNetCore.Identity;
using ModernWMC.Models.Concrete;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<StokFlowAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<StokFlowAppContext>()
    .AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Admin/Login";
    options.AccessDeniedPath = "/Admin/Login";
});
builder.Services.AddRazorPages();
builder.Services.AddScoped<IHeroDal, EFHeroDal>();
builder.Services.AddScoped<IHeroService, HeroService>();
builder.Services.AddScoped<ISystemModulesStaticDal, EFSystemModulesStaticDal>();
builder.Services.AddScoped<ISystemModulesStaticService, SystemModulesStaticService>();
builder.Services.AddScoped<ISystemModulesDynamicDal, EFSystemModulesDynamicDal>();
builder.Services.AddScoped<ISystemModulesDynamicService, SystemModulesDynamicService>();
builder.Services.AddScoped<IStatisticsDal, EFStatisticsDal>();
builder.Services.AddScoped<IStatisticsService, StatisticsService>();
builder.Services.AddScoped<IAboutDal, EFAboutDal>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IPrivacyPolicyDal, EFPrivacyPolicyDal>();
builder.Services.AddScoped<IPrivacyPolicyService, PrivacyPolicyService>();
builder.Services.AddScoped<ITermsOfUseDal, EFTermsOfUseDal>();
builder.Services.AddScoped<ITermsOfUseService, TermsOfUseService>();
builder.Services.AddScoped<IFAQDal, EFFAQDal>();
builder.Services.AddScoped<IFAQService, FAQService>();
builder.Services.AddScoped<IPhoneDal, EFPhoneDal>();
builder.Services.AddScoped<IPhoneService, PhoneService>();
builder.Services.AddScoped<IEmailDal, EFEmailDal>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IAddressDal, EFAddressDal>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IMapDal, EFMapDal>();
builder.Services.AddScoped<IMapService, MapService>();
builder.Services.AddScoped<ICtaDal, EFCtaDal>();
builder.Services.AddScoped<ICtaService, CtaService>();
builder.Services.AddScoped<ICategoryDal, EFCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IWarehouseDal, EFWarehouseDal>();
builder.Services.AddScoped<IWarehouseService, WarehouseService>();
builder.Services.AddScoped<IInventoryDal, EFInventoryDal>();
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IPurchaseOrderDal, EFPurchaseOrderDal>();
builder.Services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();
builder.Services.AddScoped<ITransferDal, EFTransferDal>();
builder.Services.AddScoped<ITransferService, TransferService>();
builder.Services.AddScoped<ICompanyDal, EFCompanyDal>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IMeasureUnitDal, EFMeasureUnitDal>();
builder.Services.AddScoped<IMeasureUnitService, MeasureUnitService>();
builder.Services.AddScoped<IContactMessageDal, EFContactMessageDal>();
builder.Services.AddScoped<IContactMessageService, ContactMessageService>();
builder.Services.AddScoped<IFileService, FileService>();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<StokFlowAppContext>();

    DbSeeder.Seed(context);

    await IdentitySeeder.SeedAsync(
        scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>(),
        scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>());
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();



app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
app.MapRazorPages();

app.Run();
