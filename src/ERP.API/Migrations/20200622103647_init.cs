using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "erp");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyCompanyType",
                schema: "erp",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created = table.Column<DateTime>(nullable: false),
                    modified = table.Column<DateTime>(nullable: false),
                    created_by = table.Column<long>(nullable: false),
                    modified_by = table.Column<long>(nullable: false),
                    IsInactive = table.Column<bool>(nullable: false),
                    name = table.Column<string>(type: "varchar(max)", maxLength: 1000, nullable: false),
                    type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyCompanyType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyCountry",
                schema: "erp",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created = table.Column<DateTime>(nullable: false),
                    modified = table.Column<DateTime>(nullable: false),
                    created_by = table.Column<long>(nullable: false),
                    modified_by = table.Column<long>(nullable: false),
                    IsInactive = table.Column<bool>(nullable: false),
                    iso_3cc = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false),
                    iso_2cc = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    iso_numerical = table.Column<int>(nullable: false),
                    economic_area = table.Column<int>(nullable: false),
                    name = table.Column<string>(type: "varchar(max)", nullable: false),
                    address_type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyCountry", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "article_group",
                schema: "erp",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created = table.Column<DateTime>(nullable: false),
                    modified = table.Column<DateTime>(nullable: false),
                    created_by = table.Column<long>(nullable: false),
                    modified_by = table.Column<long>(nullable: false),
                    IsInactive = table.Column<bool>(nullable: false),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_article_group", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "article_type",
                schema: "erp",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created = table.Column<DateTime>(nullable: false),
                    modified = table.Column<DateTime>(nullable: false),
                    created_by = table.Column<long>(nullable: false),
                    modified_by = table.Column<long>(nullable: false),
                    IsInactive = table.Column<bool>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    nature_type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_article_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Artists",
                schema: "erp",
                columns: table => new
                {
                    ArtistId = table.Column<Guid>(nullable: false),
                    ArtistName = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                schema: "erp",
                columns: table => new
                {
                    GenreId = table.Column<Guid>(nullable: false),
                    GenreDescription = table.Column<string>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "article",
                schema: "erp",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created = table.Column<DateTime>(nullable: false),
                    modified = table.Column<DateTime>(nullable: false),
                    created_by = table.Column<long>(nullable: false),
                    modified_by = table.Column<long>(nullable: false),
                    IsInactive = table.Column<bool>(nullable: false),
                    name = table.Column<string>(maxLength: 1000, nullable: false),
                    material_type = table.Column<int>(nullable: false),
                    is_archived = table.Column<bool>(nullable: false),
                    is_discontinued = table.Column<bool>(nullable: false),
                    is_batch = table.Column<bool>(nullable: false),
                    is_multistock = table.Column<bool>(nullable: false),
                    is_provision_enabled = table.Column<bool>(nullable: false),
                    is_discount_enabled = table.Column<bool>(nullable: false),
                    is_disposition = table.Column<bool>(nullable: false),
                    is_casting = table.Column<bool>(nullable: false),
                    scale_unit_qty = table.Column<int>(nullable: false),
                    scale_unit_type = table.Column<int>(nullable: false),
                    unit_stock = table.Column<int>(nullable: false),
                    unit_stock_in = table.Column<int>(nullable: false),
                    unit_stock_out = table.Column<int>(nullable: false),
                    dim_area = table.Column<int>(nullable: false),
                    dim_length = table.Column<int>(nullable: false),
                    dim_2 = table.Column<int>(nullable: false),
                    dim_3 = table.Column<int>(nullable: false),
                    dim_4 = table.Column<int>(nullable: false),
                    specific_weight = table.Column<decimal>(type: "decimal (38,20)", nullable: false),
                    item_number = table.Column<string>(nullable: true),
                    drawing_number = table.Column<string>(nullable: true),
                    din_norm1 = table.Column<string>(nullable: true),
                    din_norm2 = table.Column<string>(nullable: true),
                    fk_group = table.Column<Guid>(nullable: false),
                    fk_type = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_article", x => x.id);
                    table.ForeignKey(
                        name: "FK_article_article_group_fk_group",
                        column: x => x.fk_group,
                        principalSchema: "erp",
                        principalTable: "article_group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_article_article_type_fk_type",
                        column: x => x.fk_type,
                        principalSchema: "erp",
                        principalTable: "article_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                schema: "erp",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: false),
                    LabelName = table.Column<string>(nullable: true),
                    Price = table.Column<string>(nullable: true),
                    PictureUri = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<DateTimeOffset>(nullable: false),
                    Format = table.Column<string>(nullable: true),
                    AvailableStock = table.Column<int>(nullable: false),
                    GenreId = table.Column<Guid>(nullable: false),
                    ArtistId = table.Column<Guid>(nullable: false),
                    IsInactive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalSchema: "erp",
                        principalTable: "Artists",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Genres_GenreId",
                        column: x => x.GenreId,
                        principalSchema: "erp",
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "article_pricelist_in",
                schema: "erp",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created = table.Column<DateTime>(nullable: false),
                    modified = table.Column<DateTime>(nullable: false),
                    created_by = table.Column<long>(nullable: false),
                    modified_by = table.Column<long>(nullable: false),
                    IsInactive = table.Column<bool>(nullable: false),
                    scale_unit_qty = table.Column<int>(nullable: false),
                    scale_unit_type = table.Column<int>(nullable: false),
                    unit_order = table.Column<int>(nullable: false),
                    min_order_qty = table.Column<decimal>(type: "decimal (38,20)", nullable: false),
                    is_multiply_order_qty = table.Column<bool>(nullable: false),
                    valid_from = table.Column<DateTime>(nullable: false),
                    valid_to = table.Column<DateTime>(nullable: false),
                    fk_article = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_article_pricelist_in", x => x.id);
                    table.ForeignKey(
                        name: "FK_article_pricelist_in_article_fk_article",
                        column: x => x.fk_article,
                        principalSchema: "erp",
                        principalTable: "article",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "article_pricelist_out",
                schema: "erp",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created = table.Column<DateTime>(nullable: false),
                    modified = table.Column<DateTime>(nullable: false),
                    created_by = table.Column<long>(nullable: false),
                    modified_by = table.Column<long>(nullable: false),
                    IsInactive = table.Column<bool>(nullable: false),
                    scale_unit_qty = table.Column<int>(nullable: false),
                    scale_unit_type = table.Column<int>(nullable: false),
                    unit_order = table.Column<int>(nullable: false),
                    min_order_qty = table.Column<decimal>(type: "decimal (38,20)", nullable: false),
                    is_multiply_order_qty = table.Column<bool>(nullable: false),
                    priority = table.Column<long>(nullable: false),
                    reordertime = table.Column<DateTime>(nullable: false),
                    fk_article = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_article_pricelist_out", x => x.id);
                    table.ForeignKey(
                        name: "FK_article_pricelist_out_article_fk_article",
                        column: x => x.fk_article,
                        principalSchema: "erp",
                        principalTable: "article",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fag_binary",
                schema: "erp",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    file_name = table.Column<string>(type: "varchar(max)", nullable: true),
                    data = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ArticleId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fag_binary", x => x.id);
                    table.ForeignKey(
                        name: "FK_fag_binary_article_ArticleId",
                        column: x => x.ArticleId,
                        principalSchema: "erp",
                        principalTable: "article",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "article_range",
                schema: "erp",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created = table.Column<DateTime>(nullable: false),
                    modified = table.Column<DateTime>(nullable: false),
                    created_by = table.Column<long>(nullable: false),
                    modified_by = table.Column<long>(nullable: false),
                    IsInactive = table.Column<bool>(nullable: false),
                    quantity = table.Column<decimal>(type: "decimal (38,20)", nullable: false),
                    netprice = table.Column<decimal>(type: "decimal (38,20)", nullable: false),
                    discount = table.Column<decimal>(type: "decimal (38,20)", nullable: false),
                    addition = table.Column<decimal>(type: "decimal (38,20)", nullable: false),
                    price = table.Column<decimal>(type: "decimal (38,20)", nullable: false),
                    fk_article = table.Column<Guid>(nullable: false),
                    fk_pricelist_in = table.Column<Guid>(nullable: false),
                    fk_pricelist_out = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_article_range", x => x.id);
                    table.ForeignKey(
                        name: "FK_article_range_article_fk_article",
                        column: x => x.fk_article,
                        principalSchema: "erp",
                        principalTable: "article",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_article_range_article_pricelist_in_fk_pricelist_in",
                        column: x => x.fk_pricelist_in,
                        principalSchema: "erp",
                        principalTable: "article_pricelist_in",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_article_range_article_pricelist_out_fk_pricelist_out",
                        column: x => x.fk_pricelist_out,
                        principalSchema: "erp",
                        principalTable: "article_pricelist_out",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "address_person",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created = table.Column<DateTime>(nullable: false),
                    modified = table.Column<DateTime>(nullable: false),
                    created_by = table.Column<long>(nullable: false),
                    modified_by = table.Column<long>(nullable: false),
                    IsInactive = table.Column<bool>(nullable: false),
                    lastname = table.Column<string>(type: "varchar(max)", nullable: true),
                    firstname = table.Column<string>(type: "varchar(max)", nullable: true),
                    sex = table.Column<string>(type: "varchar(max)", nullable: true),
                    department = table.Column<string>(type: "varchar(max)", nullable: true),
                    phone_office = table.Column<string>(type: "varchar(max)", nullable: true),
                    phone_private = table.Column<string>(type: "varchar(max)", nullable: true),
                    email = table.Column<string>(type: "varchar(max)", nullable: true),
                    fk_picture = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address_person", x => x.id);
                    table.ForeignKey(
                        name: "FK_address_person_fag_binary_fk_picture",
                        column: x => x.fk_picture,
                        principalSchema: "erp",
                        principalTable: "fag_binary",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                schema: "erp",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created = table.Column<DateTime>(nullable: false),
                    modified = table.Column<DateTime>(nullable: false),
                    created_by = table.Column<long>(nullable: false),
                    modified_by = table.Column<long>(nullable: false),
                    IsInactive = table.Column<bool>(nullable: false),
                    name = table.Column<string>(type: "varchar(max)", maxLength: 1000, nullable: false),
                    addition = table.Column<string>(type: "varchar(max)", nullable: true),
                    addition2 = table.Column<string>(type: "varchar(max)", nullable: true),
                    street = table.Column<string>(type: "varchar(max)", nullable: true),
                    postcode = table.Column<string>(type: "varchar(max)", nullable: true),
                    city = table.Column<string>(type: "varchar(max)", nullable: true),
                    email = table.Column<string>(type: "varchar(max)", nullable: true),
                    phone = table.Column<string>(type: "varchar(max)", nullable: true),
                    fax = table.Column<string>(type: "varchar(max)", nullable: true),
                    vat_id_no = table.Column<string>(type: "varchar(max)", nullable: true),
                    timezone = table.Column<string>(type: "varchar(max)", nullable: true),
                    fk_parent_address = table.Column<Guid>(nullable: true),
                    fk_address_country = table.Column<Guid>(nullable: false),
                    fk_logo = table.Column<Guid>(nullable: true),
                    fk_address_company_type = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.id);
                    table.ForeignKey(
                        name: "FK_Company_CompanyCompanyType_fk_address_company_type",
                        column: x => x.fk_address_company_type,
                        principalSchema: "erp",
                        principalTable: "CompanyCompanyType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Company_CompanyCountry_fk_address_country",
                        column: x => x.fk_address_country,
                        principalSchema: "erp",
                        principalTable: "CompanyCountry",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Company_fag_binary_fk_logo",
                        column: x => x.fk_logo,
                        principalSchema: "erp",
                        principalTable: "fag_binary",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Company_Company_fk_parent_address",
                        column: x => x.fk_parent_address,
                        principalSchema: "erp",
                        principalTable: "Company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyPersonRelation",
                schema: "erp",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created = table.Column<DateTime>(nullable: false),
                    modified = table.Column<DateTime>(nullable: false),
                    created_by = table.Column<long>(nullable: false),
                    modified_by = table.Column<long>(nullable: false),
                    IsInactive = table.Column<bool>(nullable: false),
                    fk_address = table.Column<Guid>(nullable: false),
                    fk_person = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyPersonRelation", x => x.id);
                    table.ForeignKey(
                        name: "FK_CompanyPersonRelation_Company_fk_address",
                        column: x => x.fk_address,
                        principalSchema: "erp",
                        principalTable: "Company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyPersonRelation_address_person_fk_person",
                        column: x => x.fk_person,
                        principalTable: "address_person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "article_places",
                schema: "erp",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created = table.Column<DateTime>(nullable: false),
                    modified = table.Column<DateTime>(nullable: false),
                    created_by = table.Column<long>(nullable: false),
                    modified_by = table.Column<long>(nullable: false),
                    IsInactive = table.Column<bool>(nullable: false),
                    fk_address = table.Column<Guid>(nullable: false),
                    reserved_qty = table.Column<decimal>(type: "decimal (38,20)", nullable: false),
                    minimum_qty = table.Column<decimal>(type: "decimal (38,20)", nullable: false),
                    opo_qty = table.Column<decimal>(type: "decimal (38,20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_article_places", x => x.id);
                    table.ForeignKey(
                        name: "FK_article_places_Company_fk_address",
                        column: x => x.fk_address,
                        principalSchema: "erp",
                        principalTable: "Company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "document",
                schema: "erp",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created = table.Column<DateTime>(nullable: false),
                    modified = table.Column<DateTime>(nullable: false),
                    created_by = table.Column<long>(nullable: false),
                    modified_by = table.Column<long>(nullable: false),
                    IsInactive = table.Column<bool>(nullable: false),
                    address_text_document = table.Column<string>(type: "varchar(max)", nullable: true),
                    address_text_delivery = table.Column<string>(type: "varchar(max)", nullable: true),
                    address_text_invoice = table.Column<string>(type: "varchar(max)", nullable: true),
                    number = table.Column<string>(type: "varchar(max)", nullable: true),
                    type = table.Column<int>(nullable: false),
                    sub_type = table.Column<int>(nullable: false),
                    type_name = table.Column<string>(type: "varchar(max)", nullable: true),
                    value_basis = table.Column<int>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    print_date = table.Column<DateTime>(nullable: false),
                    reminder_date = table.Column<DateTime>(nullable: false),
                    print_count = table.Column<int>(nullable: false),
                    text_start = table.Column<string>(type: "varchar(max)", nullable: true),
                    text_start_rtf = table.Column<string>(type: "varchar(max)", nullable: true),
                    text_head = table.Column<string>(type: "varchar(max)", nullable: true),
                    text_head_rtf = table.Column<string>(type: "varchar(max)", nullable: true),
                    text_paymentterms = table.Column<string>(type: "varchar(max)", nullable: true),
                    text_paymentterms_rtf = table.Column<string>(type: "varchar(max)", nullable: true),
                    text_delivery = table.Column<string>(type: "varchar(max)", nullable: true),
                    text_delivery_rtf = table.Column<string>(type: "varchar(max)", nullable: true),
                    text_end = table.Column<string>(type: "varchar(max)", nullable: true),
                    text_end_rtf = table.Column<string>(type: "varchar(max)", nullable: true),
                    price_sum_net = table.Column<decimal>(type: "decimal (38,20)", nullable: false),
                    price_gross = table.Column<decimal>(type: "decimal (38,20)", nullable: false),
                    is_archive = table.Column<bool>(nullable: false),
                    fk_person = table.Column<Guid>(nullable: true),
                    fk_address = table.Column<Guid>(nullable: true),
                    fk_delivery_person = table.Column<Guid>(nullable: true),
                    fk_delivery_address = table.Column<Guid>(nullable: true),
                    fk_invoice_person = table.Column<Guid>(nullable: true),
                    fk_invoice_address = table.Column<Guid>(nullable: true),
                    fk_invoice_address1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_document", x => x.id);
                    table.ForeignKey(
                        name: "FK_document_Company_fk_delivery_address",
                        column: x => x.fk_delivery_address,
                        principalSchema: "erp",
                        principalTable: "Company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_document_address_person_fk_delivery_person",
                        column: x => x.fk_delivery_person,
                        principalTable: "address_person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_document_Company_fk_address",
                        column: x => x.fk_address,
                        principalSchema: "erp",
                        principalTable: "Company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_document_address_person_fk_person",
                        column: x => x.fk_person,
                        principalTable: "address_person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_document_address_person_fk_invoice_person",
                        column: x => x.fk_invoice_person,
                        principalTable: "address_person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_document_Company_fk_invoice_address1",
                        column: x => x.fk_invoice_address1,
                        principalSchema: "erp",
                        principalTable: "Company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "article_inventory",
                schema: "erp",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created = table.Column<DateTime>(nullable: false),
                    modified = table.Column<DateTime>(nullable: false),
                    created_by = table.Column<long>(nullable: false),
                    modified_by = table.Column<long>(nullable: false),
                    IsInactive = table.Column<bool>(nullable: false),
                    fk_article = table.Column<Guid>(nullable: false),
                    fk_place = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_article_inventory", x => x.id);
                    table.ForeignKey(
                        name: "FK_article_inventory_article_id",
                        column: x => x.id,
                        principalSchema: "erp",
                        principalTable: "article",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_article_inventory_article_places_fk_place",
                        column: x => x.fk_place,
                        principalSchema: "erp",
                        principalTable: "article_places",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "document_position",
                schema: "erp",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created = table.Column<DateTime>(nullable: false),
                    modified = table.Column<DateTime>(nullable: false),
                    created_by = table.Column<long>(nullable: false),
                    modified_by = table.Column<long>(nullable: false),
                    IsInactive = table.Column<bool>(nullable: false),
                    position_number_text = table.Column<string>(type: "varchar(max)", nullable: false),
                    position_type = table.Column<int>(nullable: false),
                    article_name_extern = table.Column<string>(type: "varchar(max)", nullable: true),
                    quantitiy = table.Column<decimal>(type: "decimal (38,20)", nullable: false),
                    scale_unit_qty = table.Column<int>(nullable: false),
                    scale_unit_type = table.Column<int>(nullable: false),
                    scale_unit = table.Column<string>(type: "varchar(max)", nullable: true),
                    delivered_quantity = table.Column<decimal>(type: "decimal (38,20)", nullable: false),
                    is_partial_delivery = table.Column<bool>(nullable: false),
                    price_base = table.Column<decimal>(type: "decimal (38,20)", nullable: false),
                    price_per_unit = table.Column<decimal>(type: "decimal (38,20)", nullable: false),
                    price_total = table.Column<decimal>(type: "decimal (38,20)", nullable: false),
                    sales_tax_percent = table.Column<decimal>(type: "decimal (38,20)", nullable: false),
                    fk_parent = table.Column<Guid>(nullable: true),
                    fk_document = table.Column<Guid>(nullable: false),
                    fk_article = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_document_position", x => x.id);
                    table.ForeignKey(
                        name: "FK_document_position_article_fk_article",
                        column: x => x.fk_article,
                        principalSchema: "erp",
                        principalTable: "article",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_document_position_document_fk_document",
                        column: x => x.fk_document,
                        principalSchema: "erp",
                        principalTable: "document",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_document_position_document_position_fk_parent",
                        column: x => x.fk_parent,
                        principalSchema: "erp",
                        principalTable: "document_position",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "fag_text",
                schema: "erp",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    text = table.Column<string>(type: "varchar(max)", nullable: true),
                    text_rtf = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    language_iso_3cc = table.Column<string>(type: "varchar(3)", nullable: true),
                    language_iso_2cc = table.Column<string>(type: "varchar(2)", nullable: true),
                    CompanyId = table.Column<Guid>(nullable: true),
                    CompanyPersonRelationId = table.Column<Guid>(nullable: true),
                    ArticleGroupId = table.Column<Guid>(nullable: true),
                    ArticleId = table.Column<Guid>(nullable: true),
                    ArticleInventoryId = table.Column<Guid>(nullable: true),
                    ArticlePlaceId = table.Column<Guid>(nullable: true),
                    ArticlePriceListInId = table.Column<Guid>(nullable: true),
                    ArticlePriceListOutId = table.Column<Guid>(nullable: true),
                    ArticleRangeId = table.Column<Guid>(nullable: true),
                    ArticleTypeId = table.Column<Guid>(nullable: true),
                    CompanyTypeId = table.Column<Guid>(nullable: true),
                    CountryId = table.Column<Guid>(nullable: true),
                    DocumentId = table.Column<Guid>(nullable: true),
                    DocumentPositionId = table.Column<Guid>(nullable: true),
                    PersonId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fag_text", x => x.id);
                    table.ForeignKey(
                        name: "FK_fag_text_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "erp",
                        principalTable: "Company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_fag_text_CompanyPersonRelation_CompanyPersonRelationId",
                        column: x => x.CompanyPersonRelationId,
                        principalSchema: "erp",
                        principalTable: "CompanyPersonRelation",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_fag_text_article_group_ArticleGroupId",
                        column: x => x.ArticleGroupId,
                        principalSchema: "erp",
                        principalTable: "article_group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_fag_text_article_ArticleId",
                        column: x => x.ArticleId,
                        principalSchema: "erp",
                        principalTable: "article",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_fag_text_article_inventory_ArticleInventoryId",
                        column: x => x.ArticleInventoryId,
                        principalSchema: "erp",
                        principalTable: "article_inventory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_fag_text_article_places_ArticlePlaceId",
                        column: x => x.ArticlePlaceId,
                        principalSchema: "erp",
                        principalTable: "article_places",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_fag_text_article_pricelist_in_ArticlePriceListInId",
                        column: x => x.ArticlePriceListInId,
                        principalSchema: "erp",
                        principalTable: "article_pricelist_in",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_fag_text_article_pricelist_out_ArticlePriceListOutId",
                        column: x => x.ArticlePriceListOutId,
                        principalSchema: "erp",
                        principalTable: "article_pricelist_out",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_fag_text_article_range_ArticleRangeId",
                        column: x => x.ArticleRangeId,
                        principalSchema: "erp",
                        principalTable: "article_range",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_fag_text_article_type_ArticleTypeId",
                        column: x => x.ArticleTypeId,
                        principalSchema: "erp",
                        principalTable: "article_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_fag_text_CompanyCompanyType_CompanyTypeId",
                        column: x => x.CompanyTypeId,
                        principalSchema: "erp",
                        principalTable: "CompanyCompanyType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_fag_text_CompanyCountry_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "erp",
                        principalTable: "CompanyCountry",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_fag_text_document_DocumentId",
                        column: x => x.DocumentId,
                        principalSchema: "erp",
                        principalTable: "document",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_fag_text_document_position_DocumentPositionId",
                        column: x => x.DocumentPositionId,
                        principalSchema: "erp",
                        principalTable: "document_position",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_fag_text_address_person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "address_person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_address_person_fk_picture",
                table: "address_person",
                column: "fk_picture");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Company_fk_address_company_type",
                schema: "erp",
                table: "Company",
                column: "fk_address_company_type");

            migrationBuilder.CreateIndex(
                name: "IX_Company_fk_address_country",
                schema: "erp",
                table: "Company",
                column: "fk_address_country");

            migrationBuilder.CreateIndex(
                name: "IX_Company_fk_logo",
                schema: "erp",
                table: "Company",
                column: "fk_logo");

            migrationBuilder.CreateIndex(
                name: "IX_Company_fk_parent_address",
                schema: "erp",
                table: "Company",
                column: "fk_parent_address");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyPersonRelation_fk_address",
                schema: "erp",
                table: "CompanyPersonRelation",
                column: "fk_address");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyPersonRelation_fk_person",
                schema: "erp",
                table: "CompanyPersonRelation",
                column: "fk_person");

            migrationBuilder.CreateIndex(
                name: "IX_article_fk_group",
                schema: "erp",
                table: "article",
                column: "fk_group");

            migrationBuilder.CreateIndex(
                name: "IX_article_fk_type",
                schema: "erp",
                table: "article",
                column: "fk_type");

            migrationBuilder.CreateIndex(
                name: "IX_article_inventory_fk_place",
                schema: "erp",
                table: "article_inventory",
                column: "fk_place");

            migrationBuilder.CreateIndex(
                name: "IX_article_places_fk_address",
                schema: "erp",
                table: "article_places",
                column: "fk_address");

            migrationBuilder.CreateIndex(
                name: "IX_article_pricelist_in_fk_article",
                schema: "erp",
                table: "article_pricelist_in",
                column: "fk_article");

            migrationBuilder.CreateIndex(
                name: "IX_article_pricelist_out_fk_article",
                schema: "erp",
                table: "article_pricelist_out",
                column: "fk_article");

            migrationBuilder.CreateIndex(
                name: "IX_article_range_fk_article",
                schema: "erp",
                table: "article_range",
                column: "fk_article");

            migrationBuilder.CreateIndex(
                name: "IX_article_range_fk_pricelist_in",
                schema: "erp",
                table: "article_range",
                column: "fk_pricelist_in");

            migrationBuilder.CreateIndex(
                name: "IX_article_range_fk_pricelist_out",
                schema: "erp",
                table: "article_range",
                column: "fk_pricelist_out");

            migrationBuilder.CreateIndex(
                name: "IX_document_fk_delivery_address",
                schema: "erp",
                table: "document",
                column: "fk_delivery_address");

            migrationBuilder.CreateIndex(
                name: "IX_document_fk_delivery_person",
                schema: "erp",
                table: "document",
                column: "fk_delivery_person");

            migrationBuilder.CreateIndex(
                name: "IX_document_fk_address",
                schema: "erp",
                table: "document",
                column: "fk_address");

            migrationBuilder.CreateIndex(
                name: "IX_document_fk_person",
                schema: "erp",
                table: "document",
                column: "fk_person");

            migrationBuilder.CreateIndex(
                name: "IX_document_fk_invoice_person",
                schema: "erp",
                table: "document",
                column: "fk_invoice_person");

            migrationBuilder.CreateIndex(
                name: "IX_document_fk_invoice_address1",
                schema: "erp",
                table: "document",
                column: "fk_invoice_address1");

            migrationBuilder.CreateIndex(
                name: "IX_document_position_fk_article",
                schema: "erp",
                table: "document_position",
                column: "fk_article");

            migrationBuilder.CreateIndex(
                name: "IX_document_position_fk_document",
                schema: "erp",
                table: "document_position",
                column: "fk_document");

            migrationBuilder.CreateIndex(
                name: "IX_document_position_fk_parent",
                schema: "erp",
                table: "document_position",
                column: "fk_parent");

            migrationBuilder.CreateIndex(
                name: "IX_fag_binary_ArticleId",
                schema: "erp",
                table: "fag_binary",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_fag_text_CompanyId",
                schema: "erp",
                table: "fag_text",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_fag_text_CompanyPersonRelationId",
                schema: "erp",
                table: "fag_text",
                column: "CompanyPersonRelationId");

            migrationBuilder.CreateIndex(
                name: "IX_fag_text_ArticleGroupId",
                schema: "erp",
                table: "fag_text",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_fag_text_ArticleId",
                schema: "erp",
                table: "fag_text",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_fag_text_ArticleInventoryId",
                schema: "erp",
                table: "fag_text",
                column: "ArticleInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_fag_text_ArticlePlaceId",
                schema: "erp",
                table: "fag_text",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_fag_text_ArticlePriceListInId",
                schema: "erp",
                table: "fag_text",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_fag_text_ArticlePriceListOutId",
                schema: "erp",
                table: "fag_text",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_fag_text_ArticleRangeId",
                schema: "erp",
                table: "fag_text",
                column: "ArticleRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_fag_text_ArticleTypeId",
                schema: "erp",
                table: "fag_text",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_fag_text_CompanyTypeId",
                schema: "erp",
                table: "fag_text",
                column: "CompanyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_fag_text_CountryId",
                schema: "erp",
                table: "fag_text",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_fag_text_DocumentId",
                schema: "erp",
                table: "fag_text",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_fag_text_DocumentPositionId",
                schema: "erp",
                table: "fag_text",
                column: "DocumentPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_fag_text_PersonId",
                schema: "erp",
                table: "fag_text",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ArtistId",
                schema: "erp",
                table: "Items",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_GenreId",
                schema: "erp",
                table: "Items",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "fag_text",
                schema: "erp");

            migrationBuilder.DropTable(
                name: "Items",
                schema: "erp");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CompanyPersonRelation",
                schema: "erp");

            migrationBuilder.DropTable(
                name: "article_inventory",
                schema: "erp");

            migrationBuilder.DropTable(
                name: "article_range",
                schema: "erp");

            migrationBuilder.DropTable(
                name: "document_position",
                schema: "erp");

            migrationBuilder.DropTable(
                name: "Artists",
                schema: "erp");

            migrationBuilder.DropTable(
                name: "Genres",
                schema: "erp");

            migrationBuilder.DropTable(
                name: "article_places",
                schema: "erp");

            migrationBuilder.DropTable(
                name: "article_pricelist_in",
                schema: "erp");

            migrationBuilder.DropTable(
                name: "article_pricelist_out",
                schema: "erp");

            migrationBuilder.DropTable(
                name: "document",
                schema: "erp");

            migrationBuilder.DropTable(
                name: "Company",
                schema: "erp");

            migrationBuilder.DropTable(
                name: "address_person");

            migrationBuilder.DropTable(
                name: "CompanyCompanyType",
                schema: "erp");

            migrationBuilder.DropTable(
                name: "CompanyCountry",
                schema: "erp");

            migrationBuilder.DropTable(
                name: "fag_binary",
                schema: "erp");

            migrationBuilder.DropTable(
                name: "article",
                schema: "erp");

            migrationBuilder.DropTable(
                name: "article_group",
                schema: "erp");

            migrationBuilder.DropTable(
                name: "article_type",
                schema: "erp");
        }
    }
}
