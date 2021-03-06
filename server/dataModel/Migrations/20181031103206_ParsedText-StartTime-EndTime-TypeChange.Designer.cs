﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dataModel;

namespace dataModel.Migrations
{
    [DbContext(typeof(MgDataContext))]
    [Migration("20181031103206_ParsedText-StartTime-EndTime-TypeChange")]
    partial class ParsedTextStartTimeEndTimeTypeChange
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("dataModel.Media", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<string>("Episode");

                    b.Property<string>("ExternalLink");

                    b.Property<string>("Image");

                    b.Property<string>("Keywords");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<string>("Season");

                    b.Property<string>("Status");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("Media");
                });

            modelBuilder.Entity("dataModel.MediaArtist", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("ExternalLink");

                    b.Property<string>("Image");

                    b.Property<string>("MediaId")
                        .IsRequired();

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name");

                    b.Property<string>("PersonName");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("MediaArtist");
                });

            modelBuilder.Entity("dataModel.MediaText", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<TimeSpan>("Created");

                    b.Property<string>("Language");

                    b.Property<string>("MediaId")
                        .IsRequired();

                    b.Property<TimeSpan>("Modified");

                    b.Property<string>("Status");

                    b.Property<string>("Text");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("MediaText");
                });

            modelBuilder.Entity("dataModel.ParsedText", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ArtistId");

                    b.Property<DateTime>("EndTime");

                    b.Property<string>("MediaTextId")
                        .IsRequired();

                    b.Property<DateTime>("StartTime");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("ParsedText");
                });
#pragma warning restore 612, 618
        }
    }
}
