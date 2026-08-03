using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Portfolio.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "kullanici",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    isim = table.Column<string>(type: "text", nullable: false),
                    soyisim = table.Column<string>(type: "text", nullable: false),
                    unvan = table.Column<string>(type: "text", nullable: false),
                    durum = table.Column<string>(type: "text", nullable: false),
                    iletisim = table.Column<string>(type: "text", nullable: false),
                    cv = table.Column<string>(type: "text", nullable: true),
                    foto_url = table.Column<string>(type: "text", nullable: true),
                    telefonno = table.Column<string>(type: "text", nullable: true),
                    hakkimda = table.Column<string>(type: "text", nullable: true),
                    kullanici_adi = table.Column<string>(type: "text", nullable: false),
                    sifre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kullanici", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "duyurular",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    kullanici_id = table.Column<int>(type: "integer", nullable: false),
                    baslik = table.Column<string>(type: "text", nullable: false),
                    icerik = table.Column<string>(type: "text", nullable: false),
                    gonderitarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    kategori = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_duyurular", x => x.id);
                    table.ForeignKey(
                        name: "FK_duyurular_kullanici_kullanici_id",
                        column: x => x.kullanici_id,
                        principalSchema: "public",
                        principalTable: "kullanici",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "kullanici_linkleri",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    kullanici_id = table.Column<int>(type: "integer", nullable: false),
                    baslik = table.Column<string>(type: "text", nullable: false),
                    url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kullanici_linkleri", x => x.id);
                    table.ForeignKey(
                        name: "FK_kullanici_linkleri_kullanici_kullanici_id",
                        column: x => x.kullanici_id,
                        principalSchema: "public",
                        principalTable: "kullanici",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "navbar",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    kullanici_id = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    href = table.Column<string>(type: "text", nullable: false),
                    sira = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_navbar", x => x.id);
                    table.ForeignKey(
                        name: "FK_navbar_kullanici_kullanici_id",
                        column: x => x.kullanici_id,
                        principalSchema: "public",
                        principalTable: "kullanici",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projeler",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    kullanici_id = table.Column<int>(type: "integer", nullable: false),
                    proje = table.Column<string>(type: "text", nullable: false),
                    aciklama = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projeler", x => x.id);
                    table.ForeignKey(
                        name: "FK_projeler_kullanici_kullanici_id",
                        column: x => x.kullanici_id,
                        principalSchema: "public",
                        principalTable: "kullanici",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teklifler",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    kullanici_id = table.Column<int>(type: "integer", nullable: false),
                    sirket = table.Column<string>(type: "text", nullable: false),
                    eposta = table.Column<string>(type: "text", nullable: false),
                    mesaj = table.Column<string>(type: "text", nullable: false),
                    ucret = table.Column<decimal>(type: "numeric", nullable: true),
                    olusturulma_tarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teklifler", x => x.id);
                    table.ForeignKey(
                        name: "FK_teklifler_kullanici_kullanici_id",
                        column: x => x.kullanici_id,
                        principalSchema: "public",
                        principalTable: "kullanici",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "yetenek_kategorileri",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    kullanici_id = table.Column<int>(type: "integer", nullable: false),
                    kategori = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_yetenek_kategorileri", x => x.id);
                    table.ForeignKey(
                        name: "FK_yetenek_kategorileri_kullanici_kullanici_id",
                        column: x => x.kullanici_id,
                        principalSchema: "public",
                        principalTable: "kullanici",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "yetenekler",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    kullanici_id = table.Column<int>(type: "integer", nullable: false),
                    yetenek_kategorileri_id = table.Column<int>(type: "integer", nullable: false),
                    yetenek = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_yetenekler", x => x.id);
                    table.ForeignKey(
                        name: "FK_yetenekler_kullanici_kullanici_id",
                        column: x => x.kullanici_id,
                        principalSchema: "public",
                        principalTable: "kullanici",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_yetenekler_yetenek_kategorileri_yetenek_kategorileri_id",
                        column: x => x.yetenek_kategorileri_id,
                        principalSchema: "public",
                        principalTable: "yetenek_kategorileri",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_duyurular_kullanici_id",
                schema: "public",
                table: "duyurular",
                column: "kullanici_id");

            migrationBuilder.CreateIndex(
                name: "IX_kullanici_linkleri_kullanici_id",
                schema: "public",
                table: "kullanici_linkleri",
                column: "kullanici_id");

            migrationBuilder.CreateIndex(
                name: "IX_navbar_kullanici_id",
                schema: "public",
                table: "navbar",
                column: "kullanici_id");

            migrationBuilder.CreateIndex(
                name: "IX_projeler_kullanici_id",
                schema: "public",
                table: "projeler",
                column: "kullanici_id");

            migrationBuilder.CreateIndex(
                name: "IX_teklifler_kullanici_id",
                schema: "public",
                table: "teklifler",
                column: "kullanici_id");

            migrationBuilder.CreateIndex(
                name: "IX_yetenek_kategorileri_kullanici_id",
                schema: "public",
                table: "yetenek_kategorileri",
                column: "kullanici_id");

            migrationBuilder.CreateIndex(
                name: "IX_yetenekler_kullanici_id",
                schema: "public",
                table: "yetenekler",
                column: "kullanici_id");

            migrationBuilder.CreateIndex(
                name: "IX_yetenekler_yetenek_kategorileri_id",
                schema: "public",
                table: "yetenekler",
                column: "yetenek_kategorileri_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "duyurular",
                schema: "public");

            migrationBuilder.DropTable(
                name: "kullanici_linkleri",
                schema: "public");

            migrationBuilder.DropTable(
                name: "navbar",
                schema: "public");

            migrationBuilder.DropTable(
                name: "projeler",
                schema: "public");

            migrationBuilder.DropTable(
                name: "teklifler",
                schema: "public");

            migrationBuilder.DropTable(
                name: "yetenekler",
                schema: "public");

            migrationBuilder.DropTable(
                name: "yetenek_kategorileri",
                schema: "public");

            migrationBuilder.DropTable(
                name: "kullanici",
                schema: "public");
        }
    }
}
