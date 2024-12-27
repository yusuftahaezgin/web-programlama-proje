﻿// <auto-generated />
using System;
using BerberOtomasyonu.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BerberOtomasyonu.Migrations
{
    [DbContext(typeof(Veriler))]
    [Migration("20241226171842_Gunceleme8")]
    partial class Gunceleme8
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("BerberHizmet", b =>
                {
                    b.Property<int>("BerberlerBerberID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HizmetlerHizmetID")
                        .HasColumnType("INTEGER");

                    b.HasKey("BerberlerBerberID", "HizmetlerHizmetID");

                    b.HasIndex("HizmetlerHizmetID");

                    b.ToTable("BerberHizmet");
                });

            modelBuilder.Entity("BerberOtomasyonu.Entity.Admin", b =>
                {
                    b.Property<int>("AdminID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AdSoyad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefon")
                        .HasColumnType("TEXT");

                    b.HasKey("AdminID");

                    b.ToTable("Adminler");
                });

            modelBuilder.Entity("BerberOtomasyonu.Entity.Berber", b =>
                {
                    b.Property<int>("BerberID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AdSoyad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("CalismaBaslangic")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("CalismaBitis")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<int>("HizmetID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Telefon")
                        .HasColumnType("TEXT");

                    b.HasKey("BerberID");

                    b.ToTable("Berberler");
                });

            modelBuilder.Entity("BerberOtomasyonu.Entity.Hizmet", b =>
                {
                    b.Property<int>("HizmetID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Aciklama")
                        .HasColumnType("TEXT");

                    b.Property<int>("BerberID")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Fiyat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("HizmetAdi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("HizmetID");

                    b.ToTable("Hizmetler");
                });

            modelBuilder.Entity("BerberOtomasyonu.Entity.Musteri", b =>
                {
                    b.Property<int>("MusteriID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AdSoyad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("KayitTarihi")
                        .HasColumnType("TEXT");

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefon")
                        .HasColumnType("TEXT");

                    b.HasKey("MusteriID");

                    b.ToTable("Musteriler");
                });

            modelBuilder.Entity("BerberOtomasyonu.Entity.Randevu", b =>
                {
                    b.Property<int>("RandevuID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BerberID")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Durum")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HizmetID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MusteriID")
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan>("RandevuSaati")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RandevuTarihi")
                        .HasColumnType("TEXT");

                    b.HasKey("RandevuID");

                    b.HasIndex("BerberID");

                    b.HasIndex("HizmetID");

                    b.ToTable("Randevular");
                });

            modelBuilder.Entity("BerberHizmet", b =>
                {
                    b.HasOne("BerberOtomasyonu.Entity.Berber", null)
                        .WithMany()
                        .HasForeignKey("BerberlerBerberID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BerberOtomasyonu.Entity.Hizmet", null)
                        .WithMany()
                        .HasForeignKey("HizmetlerHizmetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BerberOtomasyonu.Entity.Randevu", b =>
                {
                    b.HasOne("BerberOtomasyonu.Entity.Berber", "Berber")
                        .WithMany()
                        .HasForeignKey("BerberID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BerberOtomasyonu.Entity.Hizmet", "Hizmet")
                        .WithMany()
                        .HasForeignKey("HizmetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Berber");

                    b.Navigation("Hizmet");
                });
#pragma warning restore 612, 618
        }
    }
}
