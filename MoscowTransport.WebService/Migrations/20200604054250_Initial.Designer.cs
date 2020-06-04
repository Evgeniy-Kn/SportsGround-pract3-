﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NameFacilities.InfrastructureServices.Gateways.Database;

namespace MoscowTransport.WebService.Migrations
{
    [DbContext(typeof(NameFacilityContext))]
    [Migration("20200604054250_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("NameFacilities.DomainObjects.NameFacility", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("AdministrativeDistrict")
                        .HasColumnType("TEXT");

                    b.Property<string>("Area")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Lighting")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("NumberPhone")
                        .HasColumnType("TEXT");

                    b.Property<string>("TypeofSportsGround")
                        .HasColumnType("TEXT");

                    b.Property<string>("WebSite")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("NameFacilities");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Address = "Олонецкий проезд, дом 6",
                            AdministrativeDistrict = "Северо-Восточный административный округ",
                            Area = "Бутырский район",
                            Email = "1095@edu.mos.ru",
                            Lighting = "без дополнительного освещения",
                            Name = "универсальная спортивная площадка",
                            NumberPhone = "(495) 470-91-55",
                            TypeofSportsGround = "специальное покрытие",
                            WebSite = "sch1095sv.mskobr.ru"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}