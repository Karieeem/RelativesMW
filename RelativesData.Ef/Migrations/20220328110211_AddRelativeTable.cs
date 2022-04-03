using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RelativesData.Ef.Migrations
{
    public partial class AddRelativeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Relatives",
                columns: table => new
                {
                    RelativeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SapNumber = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(maxLength: 500, nullable: false),
                    Relationship = table.Column<string>(maxLength: 20, nullable: false),
                    Gender = table.Column<string>(maxLength: 10, nullable: false),
                    BirthDate = table.Column<string>(maxLength: 20, nullable: false),
                    SourceDate = table.Column<string>(maxLength: 20, nullable: false),
                    LastChange = table.Column<string>(maxLength: 20, nullable: false),
                    isEmployee = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relatives", x => x.RelativeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Relatives");
        }
    }
}
