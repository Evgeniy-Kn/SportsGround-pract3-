using Microsoft.EntityFrameworkCore;
using NameFacilities.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NameFacilities.InfrastructureServices.Gateways.Database
{
    public class NameFacilityContext : DbContext
    {
        public DbSet<NameFacility> NameFacilities { get; set; }

        public NameFacilityContext(DbContextOptions options)
            : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<NameFacility>().HasData(
                new NameFacility()
                {
                    Id = 1,
                    Name = "универсальная спортивная площадка",
                    AdministrativeDistrict = "Северо-Восточный административный округ",
                    Area = "Бутырский район",
                    Address = "Олонецкий проезд, дом 6",
                    Email = "1095@edu.mos.ru",
                    NumberPhone = "(495) 470-91-55",
                    WebSite = "sch1095sv.mskobr.ru",
                    Lighting = "без дополнительного освещения",
                    TypeofSportsGround = "специальное покрытие"
                }
                );
            FillTestData(modelBuilder);
        }
        private void FillTestData(ModelBuilder modelBuilder)
        {
            /*var to1 = new TransportOrganization { 
                Id = 1L, 
                Name = @"ООО ""Трансавтолиз""", 
                TimeZone = "Europe/Moscow", 
                WebSite = "http://avtoline.ru" 
            };

            var to2 = new TransportOrganization { 
                Id = 2L, 
                Name = @"ГУП ""Мосгортранс""",
                TimeZone = "Europe/Moscow",
                WebSite = "http://mosgortrans.ru"
            };

            modelBuilder.Entity<TransportOrganization>().HasData(
               to1,
               to2
            );

            modelBuilder.Entity<NameFacility>().HasData(
                new
                {
                    Id = 1L,
                    Number = "591",
                    Name = @"Метро ""Войковская"" - Станция Ховрино",
                    Type = TransportType.Bus,
                    OrganizationId = to1.Id
                },
                new
                {
                    Id = 2L,
                    Number = "191",
                    Name = @"Метро ""Селигерская"" - Станция Ховрино",
                    Type = TransportType.Bus,
                    OrganizationId = to1.Id
                },
                new
                {
                    Id = 3L,
                    Number = "215к",
                    Name = @"Метро ""Селигерская"" - Станция Ховрино",
                    Type = TransportType.Bus,
                    OrganizationId = to2.Id
                },
                new
                {
                    Id = 4L,
                    Number = "59",
                    Name = @"Метро ""Сокол"" - Улица Генерала Глаголева",
                    Type = TransportType.Trolley,
                    OrganizationId = to2.Id
                }
            );*/
        }
    }
}
