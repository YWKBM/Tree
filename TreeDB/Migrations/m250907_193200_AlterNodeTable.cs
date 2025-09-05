using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TreeDB.Migrations;

[DbContext(typeof(AppDbContext))]
[Migration("m250907_193200_AlterNodeTable")]
public class m250907_193200_AlterNodeTable : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateIndex(
            name: "Idx-Node-ParentNodeId", 
            table: "Node",
            column: "ParentNodeId");

        migrationBuilder.CreateIndex(
            name: "Idx-Node-TreeName-Name", 
            table: "Node",
            columns: ["TreeName", "Name"],
            unique: true);
        
        migrationBuilder.CreateIndex(
            name: "IX-Node-TreeName",
            table: "Node",
            column: "TreeName");
    }
}