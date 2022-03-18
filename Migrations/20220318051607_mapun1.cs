using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mapun_api.Migrations
{
    public partial class mapun1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "mapun");

            migrationBuilder.CreateTable(
                name: "BRATES",
                schema: "mapun",
                columns: table => new
                {
                    BRATE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    TITLE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REMARKS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RATE = table.Column<long>(type: "bigint", nullable: true),
                    DATE_CREATED = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DATE_UPDATED = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRATES", x => x.BRATE_ID);
                });

            migrationBuilder.CreateTable(
                name: "ERATES",
                schema: "mapun",
                columns: table => new
                {
                    ERATE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    TITLE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REMARKS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RATE = table.Column<long>(type: "bigint", nullable: true),
                    DATE_CREATED = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DATE_UPDATED = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ERATES", x => x.ERATE_ID);
                });

            migrationBuilder.CreateTable(
                name: "MRATES",
                schema: "mapun",
                columns: table => new
                {
                    MRATE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    TITLE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REMARKS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RATE = table.Column<long>(type: "bigint", nullable: true),
                    DATE_CREATED = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DATE_UPDATED = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MRATES", x => x.MRATE_ID);
                });

            migrationBuilder.CreateTable(
                name: "PAYSTATUSES",
                schema: "mapun",
                columns: table => new
                {
                    PAYSTATUS_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    TITLE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REMARKS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ORDER = table.Column<int>(type: "int", nullable: true),
                    DATE_CREATED = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DATE_UPDATED = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAYSTATUSES", x => x.PAYSTATUS_ID);
                });

            migrationBuilder.CreateTable(
                name: "PSTATUSES",
                schema: "mapun",
                columns: table => new
                {
                    PSTATUS_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    TITLE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REMARKS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ORDER = table.Column<int>(type: "int", nullable: true),
                    DATE_CREATED = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DATE_UPDATED = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSTATUSES", x => x.PSTATUS_ID);
                });

            migrationBuilder.CreateTable(
                name: "ROLES",
                schema: "mapun",
                columns: table => new
                {
                    ROLE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    TITLE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATE_CREATED = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DATE_UPDATED = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLES", x => x.ROLE_ID);
                });

            migrationBuilder.CreateTable(
                name: "ZRATES",
                schema: "mapun",
                columns: table => new
                {
                    ZRATE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    TITLE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REMARKS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RATE = table.Column<long>(type: "bigint", nullable: true),
                    DATE_CREATED = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DATE_UPDATED = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZRATES", x => x.ZRATE_ID);
                });

            migrationBuilder.CreateTable(
                name: "PENHANCEMENTS",
                schema: "mapun",
                columns: table => new
                {
                    PENHANCEMENT_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    TITLE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REMARKS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ENHANCEMENT_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATE_CREATED = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DATE_UPDATED = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    ERATE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PENHANCEMENTS", x => x.PENHANCEMENT_ID);
                    table.ForeignKey(
                        name: "FK_PENHANCEMENTS_ERATES_ERATE_ID",
                        column: x => x.ERATE_ID,
                        principalSchema: "mapun",
                        principalTable: "ERATES",
                        principalColumn: "ERATE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                schema: "mapun",
                columns: table => new
                {
                    USER_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    FIRSTNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MIDDLENAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LASTNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USERNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATE_CREATED = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DATE_UPDATED = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    ROLE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.USER_ID);
                    table.ForeignKey(
                        name: "FK_USERS_ROLES_ROLE_ID",
                        column: x => x.ROLE_ID,
                        principalSchema: "mapun",
                        principalTable: "ROLES",
                        principalColumn: "ROLE_ID");
                });

            migrationBuilder.CreateTable(
                name: "ZONES",
                schema: "mapun",
                columns: table => new
                {
                    ZONE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    ZONE_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZONE_DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZONE_AREA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZONE_AREACODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZONE_LATITUDE = table.Column<long>(type: "bigint", nullable: true),
                    ZONE_LONGITUDE = table.Column<long>(type: "bigint", nullable: true),
                    DATE_CREATED = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DATE_UPDATED = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    ZRATE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZONES", x => x.ZONE_ID);
                    table.ForeignKey(
                        name: "FK_ZONES_ZRATES_ZONE_ID",
                        column: x => x.ZONE_ID,
                        principalSchema: "mapun",
                        principalTable: "ZRATES",
                        principalColumn: "ZRATE_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PROPERTIES",
                schema: "mapun",
                columns: table => new
                {
                    PROPERTY_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    PROPERTY_IDENTIFICATION_NUMBER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ARP_NO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TCT_CLOA_NO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OCT_NO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TD_NO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATE_FILLED = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LOT_NO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BLOCK_NO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BOUNDARY_NORTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BOUNDARY_SOUTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BOUNDARY_WEST = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BOUNDARY_EAST = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PROPERTY_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PROPERTY_LONGITUDE = table.Column<long>(type: "bigint", nullable: true),
                    PROPERTY_LATITUDE = table.Column<long>(type: "bigint", nullable: true),
                    OWNER_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OWNER_ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OWNER_TIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OWNER_TEL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ADMINISTRATOR_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ADMINISTRATOR_ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ADMINISTRATOR_TIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ADMINISTRATOR_TEL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PROPERTY_STREET = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PROPERTY_BARANGAY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PROPERTY_MUNICIPALITY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MEMORANDA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PROVINCE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATE_CREATED = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DATE_UPDATED = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    PSTATUS_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PEHANCEMENT_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BRATE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MRATE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ZONE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROPERTIES", x => x.PROPERTY_ID);
                    table.ForeignKey(
                        name: "FK_PROPERTIES_BRATES_BRATE_ID",
                        column: x => x.BRATE_ID,
                        principalSchema: "mapun",
                        principalTable: "BRATES",
                        principalColumn: "BRATE_ID");
                    table.ForeignKey(
                        name: "FK_PROPERTIES_MRATES_MRATE_ID",
                        column: x => x.MRATE_ID,
                        principalSchema: "mapun",
                        principalTable: "MRATES",
                        principalColumn: "MRATE_ID");
                    table.ForeignKey(
                        name: "FK_PROPERTIES_PENHANCEMENTS_PEHANCEMENT_ID",
                        column: x => x.PEHANCEMENT_ID,
                        principalSchema: "mapun",
                        principalTable: "PENHANCEMENTS",
                        principalColumn: "PENHANCEMENT_ID");
                    table.ForeignKey(
                        name: "FK_PROPERTIES_PSTATUSES_PSTATUS_ID",
                        column: x => x.PSTATUS_ID,
                        principalSchema: "mapun",
                        principalTable: "PSTATUSES",
                        principalColumn: "PSTATUS_ID");
                    table.ForeignKey(
                        name: "FK_PROPERTIES_ZONES_ZONE_ID",
                        column: x => x.ZONE_ID,
                        principalSchema: "mapun",
                        principalTable: "ZONES",
                        principalColumn: "ZONE_ID");
                });

            migrationBuilder.CreateTable(
                name: "ASSESSMENTS",
                schema: "mapun",
                columns: table => new
                {
                    ASSESSMENT_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    ARP_NO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TCT_CLOA_NO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OCT_NO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TD_NO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATE_FILLED = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SURVEY_NO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ASSESSED_BOUNDARY_NORTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ASSESSED_BOUNDARY_SOUTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ASSESSED_BOUNDARY_WEST = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ASSESSED_BOUNDARY_EAST = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MEMORANDA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATE_CREATED = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DATE_UPDATED = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    PROPERTY_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASSESSMENTS", x => x.ASSESSMENT_ID);
                    table.ForeignKey(
                        name: "FK_ASSESSMENTS_PROPERTIES_PROPERTY_ID",
                        column: x => x.PROPERTY_ID,
                        principalSchema: "mapun",
                        principalTable: "PROPERTIES",
                        principalColumn: "PROPERTY_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PAYMENTS",
                schema: "mapun",
                columns: table => new
                {
                    PAYMENT_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TRANSACTION_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TITLE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REMARKS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PAYER_NAME_PROXY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AMOUNT_DUE = table.Column<long>(type: "bigint", nullable: true),
                    DUE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DATE_CREATED = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DATE_UPDATED = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    PROPERTY_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PAYSTATUS_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAYMENTS", x => x.PAYMENT_ID);
                    table.ForeignKey(
                        name: "FK_PAYMENTS_PAYSTATUSES_PAYSTATUS_ID",
                        column: x => x.PAYSTATUS_ID,
                        principalSchema: "mapun",
                        principalTable: "PAYSTATUSES",
                        principalColumn: "PAYSTATUS_ID");
                    table.ForeignKey(
                        name: "FK_PAYMENTS_PROPERTIES_PROPERTY_ID",
                        column: x => x.PROPERTY_ID,
                        principalSchema: "mapun",
                        principalTable: "PROPERTIES",
                        principalColumn: "PROPERTY_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PLOGS",
                schema: "mapun",
                columns: table => new
                {
                    PLOG_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    TITLE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REMARKS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATE_CREATED = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DATE_UPDATED = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    USER_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PROPERTY_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLOGS", x => x.PLOG_ID);
                    table.ForeignKey(
                        name: "FK_PLOGS_PROPERTIES_PROPERTY_ID",
                        column: x => x.PROPERTY_ID,
                        principalSchema: "mapun",
                        principalTable: "PROPERTIES",
                        principalColumn: "PROPERTY_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PLOGS_USERS_USER_ID",
                        column: x => x.USER_ID,
                        principalSchema: "mapun",
                        principalTable: "USERS",
                        principalColumn: "USER_ID");
                });

            migrationBuilder.CreateTable(
                name: "PropertyUser",
                schema: "mapun",
                columns: table => new
                {
                    ASSESSORSUSER_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PROPERTIESPROPERTY_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyUser", x => new { x.ASSESSORSUSER_ID, x.PROPERTIESPROPERTY_ID });
                    table.ForeignKey(
                        name: "FK_PropertyUser_PROPERTIES_PROPERTIESPROPERTY_ID",
                        column: x => x.PROPERTIESPROPERTY_ID,
                        principalSchema: "mapun",
                        principalTable: "PROPERTIES",
                        principalColumn: "PROPERTY_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyUser_USERS_ASSESSORSUSER_ID",
                        column: x => x.ASSESSORSUSER_ID,
                        principalSchema: "mapun",
                        principalTable: "USERS",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ASSESSMENTS_PROPERTY_ID",
                schema: "mapun",
                table: "ASSESSMENTS",
                column: "PROPERTY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PAYMENTS_PAYSTATUS_ID",
                schema: "mapun",
                table: "PAYMENTS",
                column: "PAYSTATUS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PAYMENTS_PROPERTY_ID",
                schema: "mapun",
                table: "PAYMENTS",
                column: "PROPERTY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PENHANCEMENTS_ERATE_ID",
                schema: "mapun",
                table: "PENHANCEMENTS",
                column: "ERATE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PLOGS_PROPERTY_ID",
                schema: "mapun",
                table: "PLOGS",
                column: "PROPERTY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PLOGS_USER_ID",
                schema: "mapun",
                table: "PLOGS",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROPERTIES_BRATE_ID",
                schema: "mapun",
                table: "PROPERTIES",
                column: "BRATE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROPERTIES_MRATE_ID",
                schema: "mapun",
                table: "PROPERTIES",
                column: "MRATE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROPERTIES_PEHANCEMENT_ID",
                schema: "mapun",
                table: "PROPERTIES",
                column: "PEHANCEMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROPERTIES_PSTATUS_ID",
                schema: "mapun",
                table: "PROPERTIES",
                column: "PSTATUS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROPERTIES_ZONE_ID",
                schema: "mapun",
                table: "PROPERTIES",
                column: "ZONE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyUser_PROPERTIESPROPERTY_ID",
                schema: "mapun",
                table: "PropertyUser",
                column: "PROPERTIESPROPERTY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_ROLE_ID",
                schema: "mapun",
                table: "USERS",
                column: "ROLE_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ASSESSMENTS",
                schema: "mapun");

            migrationBuilder.DropTable(
                name: "PAYMENTS",
                schema: "mapun");

            migrationBuilder.DropTable(
                name: "PLOGS",
                schema: "mapun");

            migrationBuilder.DropTable(
                name: "PropertyUser",
                schema: "mapun");

            migrationBuilder.DropTable(
                name: "PAYSTATUSES",
                schema: "mapun");

            migrationBuilder.DropTable(
                name: "PROPERTIES",
                schema: "mapun");

            migrationBuilder.DropTable(
                name: "USERS",
                schema: "mapun");

            migrationBuilder.DropTable(
                name: "BRATES",
                schema: "mapun");

            migrationBuilder.DropTable(
                name: "MRATES",
                schema: "mapun");

            migrationBuilder.DropTable(
                name: "PENHANCEMENTS",
                schema: "mapun");

            migrationBuilder.DropTable(
                name: "PSTATUSES",
                schema: "mapun");

            migrationBuilder.DropTable(
                name: "ZONES",
                schema: "mapun");

            migrationBuilder.DropTable(
                name: "ROLES",
                schema: "mapun");

            migrationBuilder.DropTable(
                name: "ERATES",
                schema: "mapun");

            migrationBuilder.DropTable(
                name: "ZRATES",
                schema: "mapun");
        }
    }
}
