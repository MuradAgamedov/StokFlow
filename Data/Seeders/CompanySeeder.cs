using ModernWMC.Data.Concrete.EntityFramework;
using ModernWMC.Models.Concrete;
using System;
using System.Linq;

namespace ModernWMC.Data.Seeders
{
    public static class CompanySeeder
    {
        public static void Seed(StokFlowAppContext context)
        {
            if (!context.Companies.Any())
            {
                context.Companies.AddRange(
                    new Company
                    {
                        Name = "Delta Elektroniks MMC",
                        Voen = "1301234561",
                        ContactPerson = "Rəşad Əliyev",
                        Email = "info@delta.az",
                        Phone = "+994124445566",
                        Address = "Bakı, A.Əliyev küç. 45",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    },
                    new Company
                    {
                        Name = "LogiLink Aksesuar LTD",
                        Voen = "1409876541",
                        ContactPerson = "Tural Məmmədov",
                        Email = "service@logilink.az",
                        Phone = "+994125556677",
                        Address = "Bakı, Heydər Əliyev pr. 115",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    },
                    new Company
                    {
                        Name = "Bakı İnşaat Materialları MMC",
                        Voen = "2002345671",
                        ContactPerson = "Nigar Həsənova",
                        Email = "office@bakubuild.az",
                        Phone = "+994123334455",
                        Address = "Bakı, Dərnəgül şossesi 8B",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
