﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mapun_api.Data;

namespace mapun_api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220318051607_mapun1")]
    partial class mapun1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("mapun")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PropertyUser", b =>
                {
                    b.Property<Guid>("ASSESSORSUSER_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PROPERTIESPROPERTY_ID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ASSESSORSUSER_ID", "PROPERTIESPROPERTY_ID");

                    b.HasIndex("PROPERTIESPROPERTY_ID");

                    b.ToTable("PropertyUser");
                });

            modelBuilder.Entity("mapun_api.Models.Entities.Assessment", b =>
                {
                    b.Property<Guid>("ASSESSMENT_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<string>("ARP_NO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ASSESSED_BOUNDARY_EAST")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ASSESSED_BOUNDARY_NORTH")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ASSESSED_BOUNDARY_SOUTH")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ASSESSED_BOUNDARY_WEST")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CREATED_BY")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DATE_CREATED")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DATE_FILLED")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DATE_UPDATED")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IS_ACTIVE")
                        .HasColumnType("bit");

                    b.Property<string>("MEMORANDA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OCT_NO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PROPERTY_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SURVEY_NO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TCT_CLOA_NO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TD_NO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UPDATED_BY")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ASSESSMENT_ID");

                    b.HasIndex("PROPERTY_ID");

                    b.ToTable("ASSESSMENTS");
                });

            modelBuilder.Entity("mapun_api.Models.Entities.BaseRate", b =>
                {
                    b.Property<Guid>("BRATE_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<Guid?>("CREATED_BY")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DATE_CREATED")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DATE_UPDATED")
                        .HasColumnType("datetime2");

                    b.Property<string>("DESCRIPTION")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IS_ACTIVE")
                        .HasColumnType("bit");

                    b.Property<long?>("RATE")
                        .HasColumnType("bigint");

                    b.Property<string>("REMARKS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TITLE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UPDATED_BY")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BRATE_ID");

                    b.ToTable("BRATES");
                });

            modelBuilder.Entity("mapun_api.Models.Entities.EnhancementRate", b =>
                {
                    b.Property<Guid>("ERATE_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<Guid?>("CREATED_BY")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DATE_CREATED")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DATE_UPDATED")
                        .HasColumnType("datetime2");

                    b.Property<string>("DESCRIPTION")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IS_ACTIVE")
                        .HasColumnType("bit");

                    b.Property<long?>("RATE")
                        .HasColumnType("bigint");

                    b.Property<string>("REMARKS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TITLE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UPDATED_BY")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ERATE_ID");

                    b.ToTable("ERATES");
                });

            modelBuilder.Entity("mapun_api.Models.Entities.MiscRate", b =>
                {
                    b.Property<Guid>("MRATE_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<Guid?>("CREATED_BY")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DATE_CREATED")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DATE_UPDATED")
                        .HasColumnType("datetime2");

                    b.Property<string>("DESCRIPTION")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IS_ACTIVE")
                        .HasColumnType("bit");

                    b.Property<long?>("RATE")
                        .HasColumnType("bigint");

                    b.Property<string>("REMARKS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TITLE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UPDATED_BY")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MRATE_ID");

                    b.ToTable("MRATES");
                });

            modelBuilder.Entity("mapun_api.Models.Entities.Payment", b =>
                {
                    b.Property<Guid>("PAYMENT_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long?>("AMOUNT_DUE")
                        .HasColumnType("bigint");

                    b.Property<Guid?>("CREATED_BY")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DATE_CREATED")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DATE_UPDATED")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DUE_DATE")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IS_ACTIVE")
                        .HasColumnType("bit");

                    b.Property<string>("PAYER_NAME_PROXY")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PAYSTATUS_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PROPERTY_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("REMARKS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TITLE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TRANSACTION_CODE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UPDATED_BY")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PAYMENT_ID");

                    b.HasIndex("PAYSTATUS_ID");

                    b.HasIndex("PROPERTY_ID");

                    b.ToTable("PAYMENTS");
                });

            modelBuilder.Entity("mapun_api.Models.Entities.PaymentStatus", b =>
                {
                    b.Property<Guid>("PAYSTATUS_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<Guid?>("CREATED_BY")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DATE_CREATED")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DATE_UPDATED")
                        .HasColumnType("datetime2");

                    b.Property<string>("DESCRIPTION")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IS_ACTIVE")
                        .HasColumnType("bit");

                    b.Property<int?>("ORDER")
                        .HasColumnType("int");

                    b.Property<string>("REMARKS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TITLE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UPDATED_BY")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PAYSTATUS_ID");

                    b.ToTable("PAYSTATUSES");
                });

            modelBuilder.Entity("mapun_api.Models.Entities.Property", b =>
                {
                    b.Property<Guid>("PROPERTY_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<string>("ADMINISTRATOR_ADDRESS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ADMINISTRATOR_NAME")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ADMINISTRATOR_TEL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ADMINISTRATOR_TIN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ARP_NO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BLOCK_NO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BOUNDARY_EAST")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BOUNDARY_NORTH")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BOUNDARY_SOUTH")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BOUNDARY_WEST")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("BRATE_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CREATED_BY")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DATE_CREATED")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DATE_FILLED")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DATE_UPDATED")
                        .HasColumnType("datetime2");

                    b.Property<string>("EMAIL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IS_ACTIVE")
                        .HasColumnType("bit");

                    b.Property<string>("LOT_NO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MEMORANDA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("MRATE_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OCT_NO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OWNER_ADDRESS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OWNER_NAME")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OWNER_TEL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OWNER_TIN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PEHANCEMENT_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PROPERTY_BARANGAY")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PROPERTY_IDENTIFICATION_NUMBER")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PROPERTY_LATITUDE")
                        .HasColumnType("bigint");

                    b.Property<long?>("PROPERTY_LONGITUDE")
                        .HasColumnType("bigint");

                    b.Property<string>("PROPERTY_MUNICIPALITY")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PROPERTY_NAME")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PROPERTY_STREET")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PROVINCE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PSTATUS_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TCT_CLOA_NO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TD_NO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UPDATED_BY")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ZONE_ID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PROPERTY_ID");

                    b.HasIndex("BRATE_ID");

                    b.HasIndex("MRATE_ID");

                    b.HasIndex("PEHANCEMENT_ID");

                    b.HasIndex("PSTATUS_ID");

                    b.HasIndex("ZONE_ID");

                    b.ToTable("PROPERTIES");
                });

            modelBuilder.Entity("mapun_api.Models.Entities.PropertyEnhancement", b =>
                {
                    b.Property<Guid>("PENHANCEMENT_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<Guid?>("CREATED_BY")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DATE_CREATED")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DATE_UPDATED")
                        .HasColumnType("datetime2");

                    b.Property<string>("DESCRIPTION")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ENHANCEMENT_TYPE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ERATE_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("IS_ACTIVE")
                        .HasColumnType("bit");

                    b.Property<string>("REMARKS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TITLE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UPDATED_BY")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PENHANCEMENT_ID");

                    b.HasIndex("ERATE_ID");

                    b.ToTable("PENHANCEMENTS");
                });

            modelBuilder.Entity("mapun_api.Models.Entities.PropertyLog", b =>
                {
                    b.Property<Guid>("PLOG_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<Guid?>("CREATED_BY")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DATE_CREATED")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DATE_UPDATED")
                        .HasColumnType("datetime2");

                    b.Property<string>("DESCRIPTION")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IS_ACTIVE")
                        .HasColumnType("bit");

                    b.Property<Guid?>("PROPERTY_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("REMARKS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TITLE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UPDATED_BY")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("USER_ID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PLOG_ID");

                    b.HasIndex("PROPERTY_ID");

                    b.HasIndex("USER_ID");

                    b.ToTable("PLOGS");
                });

            modelBuilder.Entity("mapun_api.Models.Entities.PropertyStatus", b =>
                {
                    b.Property<Guid>("PSTATUS_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<Guid?>("CREATED_BY")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DATE_CREATED")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DATE_UPDATED")
                        .HasColumnType("datetime2");

                    b.Property<string>("DESCRIPTION")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IS_ACTIVE")
                        .HasColumnType("bit");

                    b.Property<int?>("ORDER")
                        .HasColumnType("int");

                    b.Property<string>("REMARKS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TITLE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UPDATED_BY")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PSTATUS_ID");

                    b.ToTable("PSTATUSES");
                });

            modelBuilder.Entity("mapun_api.Models.Entities.User", b =>
                {
                    b.Property<Guid>("USER_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<Guid?>("CREATED_BY")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DATE_CREATED")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DATE_UPDATED")
                        .HasColumnType("datetime2");

                    b.Property<string>("EMAIL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FIRSTNAME")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IS_ACTIVE")
                        .HasColumnType("bit");

                    b.Property<string>("LASTNAME")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MIDDLENAME")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ROLE_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UPDATED_BY")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("USERNAME")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("USER_ID");

                    b.HasIndex("ROLE_ID");

                    b.ToTable("USERS");
                });

            modelBuilder.Entity("mapun_api.Models.Entities.Zone", b =>
                {
                    b.Property<Guid>("ZONE_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<Guid?>("CREATED_BY")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DATE_CREATED")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DATE_UPDATED")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IS_ACTIVE")
                        .HasColumnType("bit");

                    b.Property<Guid?>("UPDATED_BY")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ZONE_AREA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZONE_AREACODE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZONE_DESCRIPTION")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ZONE_LATITUDE")
                        .HasColumnType("bigint");

                    b.Property<long?>("ZONE_LONGITUDE")
                        .HasColumnType("bigint");

                    b.Property<string>("ZONE_NAME")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ZRATE_ID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ZONE_ID");

                    b.ToTable("ZONES");
                });

            modelBuilder.Entity("mapun_api.Models.Entities.ZoneRate", b =>
                {
                    b.Property<Guid>("ZRATE_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<Guid?>("CREATED_BY")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DATE_CREATED")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DATE_UPDATED")
                        .HasColumnType("datetime2");

                    b.Property<string>("DESCRIPTION")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IS_ACTIVE")
                        .HasColumnType("bit");

                    b.Property<long?>("RATE")
                        .HasColumnType("bigint");

                    b.Property<string>("REMARKS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TITLE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UPDATED_BY")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ZRATE_ID");

                    b.ToTable("ZRATES");
                });

            modelBuilder.Entity("mapun_api.Models.Entities.mapunRole", b =>
                {
                    b.Property<Guid>("ROLE_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<Guid?>("CREATED_BY")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DATE_CREATED")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DATE_UPDATED")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IS_ACTIVE")
                        .HasColumnType("bit");

                    b.Property<string>("TITLE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UPDATED_BY")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ROLE_ID");

                    b.ToTable("ROLES");
                });

            modelBuilder.Entity("PropertyUser", b =>
                {
                    b.HasOne("mapun_api.Models.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("ASSESSORSUSER_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mapun_api.Models.Entities.Property", null)
                        .WithMany()
                        .HasForeignKey("PROPERTIESPROPERTY_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("mapun_api.Models.Entities.Assessment", b =>
                {
                    b.HasOne("mapun_api.Models.Entities.Property", "PROPERTY")
                        .WithMany("ASSESSMENTS")
                        .HasForeignKey("PROPERTY_ID");

                    b.Navigation("PROPERTY");
                });

            modelBuilder.Entity("mapun_api.Models.Entities.Payment", b =>
                {
                    b.HasOne("mapun_api.Models.Entities.PaymentStatus", "PAYSTATUS")
                        .WithMany("PAYMENTS")
                        .HasForeignKey("PAYSTATUS_ID")
                        .OnDelete(DeleteBehavior.ClientNoAction);

                    b.HasOne("mapun_api.Models.Entities.Property", "PROPERTY")
                        .WithMany("PAYMENT_HISTORY")
                        .HasForeignKey("PROPERTY_ID");

                    b.Navigation("PAYSTATUS");

                    b.Navigation("PROPERTY");
                });

            modelBuilder.Entity("mapun_api.Models.Entities.Property", b =>
                {
                    b.HasOne("mapun_api.Models.Entities.BaseRate", "BRATE")
                        .WithMany("AFFECTED_PROPERTIES")
                        .HasForeignKey("BRATE_ID")
                        .OnDelete(DeleteBehavior.ClientNoAction);

                    b.HasOne("mapun_api.Models.Entities.MiscRate", "MRATE")
                        .WithMany("AFFECTED_PROPERTIES")
                        .HasForeignKey("MRATE_ID")
                        .OnDelete(DeleteBehavior.ClientNoAction);

                    b.HasOne("mapun_api.Models.Entities.PropertyEnhancement", "ENHANCEMENT")
                        .WithMany("PROPERTIES")
                        .HasForeignKey("PEHANCEMENT_ID")
                        .OnDelete(DeleteBehavior.ClientNoAction);

                    b.HasOne("mapun_api.Models.Entities.PropertyStatus", "PSTATUS")
                        .WithMany("PROPERTIES")
                        .HasForeignKey("PSTATUS_ID")
                        .OnDelete(DeleteBehavior.ClientNoAction);

                    b.HasOne("mapun_api.Models.Entities.Zone", "ZONE")
                        .WithMany("PROPERTIES")
                        .HasForeignKey("ZONE_ID")
                        .OnDelete(DeleteBehavior.ClientNoAction);

                    b.Navigation("BRATE");

                    b.Navigation("ENHANCEMENT");

                    b.Navigation("MRATE");

                    b.Navigation("PSTATUS");

                    b.Navigation("ZONE");
                });

            modelBuilder.Entity("mapun_api.Models.Entities.PropertyEnhancement", b =>
                {
                    b.HasOne("mapun_api.Models.Entities.EnhancementRate", "ERATE")
                        .WithMany("AFFECTED_TYPES")
                        .HasForeignKey("ERATE_ID");

                    b.Navigation("ERATE");
                });

            modelBuilder.Entity("mapun_api.Models.Entities.PropertyLog", b =>
                {
                    b.HasOne("mapun_api.Models.Entities.Property", "PROPERTY")
                        .WithMany("HISTORY")
                        .HasForeignKey("PROPERTY_ID");

                    b.HasOne("mapun_api.Models.Entities.User", "USER")
                        .WithMany("HISTORY")
                        .HasForeignKey("USER_ID")
                        .OnDelete(DeleteBehavior.ClientNoAction);

                    b.Navigation("PROPERTY");

                    b.Navigation("USER");
                });

            modelBuilder.Entity("mapun_api.Models.Entities.User", b =>
                {
                    b.HasOne("mapun_api.Models.Entities.mapunRole", "ROLE")
                        .WithMany("USERS")
                        .HasForeignKey("ROLE_ID")
                        .OnDelete(DeleteBehavior.ClientNoAction);

                    b.Navigation("ROLE");
                });

            modelBuilder.Entity("mapun_api.Models.Entities.Zone", b =>
                {
                    b.HasOne("mapun_api.Models.Entities.ZoneRate", "ZRATE")
                        .WithMany("AFFECTED_ZONES")
                        .HasForeignKey("ZONE_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ZRATE");
                });

            modelBuilder.Entity("mapun_api.Models.Entities.BaseRate", b =>
                {
                    b.Navigation("AFFECTED_PROPERTIES");
                });

            modelBuilder.Entity("mapun_api.Models.Entities.EnhancementRate", b =>
                {
                    b.Navigation("AFFECTED_TYPES");
                });

            modelBuilder.Entity("mapun_api.Models.Entities.MiscRate", b =>
                {
                    b.Navigation("AFFECTED_PROPERTIES");
                });

            modelBuilder.Entity("mapun_api.Models.Entities.PaymentStatus", b =>
                {
                    b.Navigation("PAYMENTS");
                });

            modelBuilder.Entity("mapun_api.Models.Entities.Property", b =>
                {
                    b.Navigation("ASSESSMENTS");

                    b.Navigation("HISTORY");

                    b.Navigation("PAYMENT_HISTORY");
                });

            modelBuilder.Entity("mapun_api.Models.Entities.PropertyEnhancement", b =>
                {
                    b.Navigation("PROPERTIES");
                });

            modelBuilder.Entity("mapun_api.Models.Entities.PropertyStatus", b =>
                {
                    b.Navigation("PROPERTIES");
                });

            modelBuilder.Entity("mapun_api.Models.Entities.User", b =>
                {
                    b.Navigation("HISTORY");
                });

            modelBuilder.Entity("mapun_api.Models.Entities.Zone", b =>
                {
                    b.Navigation("PROPERTIES");
                });

            modelBuilder.Entity("mapun_api.Models.Entities.ZoneRate", b =>
                {
                    b.Navigation("AFFECTED_ZONES");
                });

            modelBuilder.Entity("mapun_api.Models.Entities.mapunRole", b =>
                {
                    b.Navigation("USERS");
                });
#pragma warning restore 612, 618
        }
    }
}
