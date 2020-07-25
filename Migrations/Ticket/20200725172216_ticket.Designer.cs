﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cis174projects.Models;

namespace cis174projects.Migrations.Ticket
{
    [DbContext(typeof(TicketContext))]
    [Migration("20200725172216_ticket")]
    partial class ticket
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("cis174projects.Models.Status", b =>
                {
                    b.Property<string>("StatusId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("StatusesP");

                    b.HasData(
                        new
                        {
                            StatusId = "todo",
                            Name = "To Do"
                        },
                        new
                        {
                            StatusId = "inprogress",
                            Name = "In Progress"
                        },
                        new
                        {
                            StatusId = "qa",
                            Name = "Quality Assurance"
                        },
                        new
                        {
                            StatusId = "done",
                            Name = "Done"
                        });
                });

            modelBuilder.Entity("cis174projects.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("TicketsP");
                });

            modelBuilder.Entity("cis174projects.Models.Ticket", b =>
                {
                    b.HasOne("cis174projects.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
