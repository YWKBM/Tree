using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TreeDB.Migrations;

[DbContext(typeof(AppDbContext))]
[Migration("m250907_193000_AddNodeTable")]
public class m250907_193000_AddNodeTable : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Node",
            columns: t => new
            {
                Id = t.Column<int>(),
                Name = t.Column<string>(),
                ParentNodeId = t.Column<int>(nullable: true),
                TreeName = t.Column<string>(defaultValue: string.Empty)
            }).PrimaryKey("PK-Node", c => c.Id);
    }
}