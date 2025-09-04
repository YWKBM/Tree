using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TreeDB.Migrations;

[DbContext(typeof(AppDbContext))]
[Migration("m250907_193100_AddErrorLogTable")]
public class m250907_193100_AddErrorLogTable : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "ErrorLog",
            columns: t => new
            {
                Id = t.Column<int>(type: "serial"),
                EventId = t.Column<Guid>(),
                Timestamp = t.Column<DateTimeOffset>(),
                Body = t.Column<string>(nullable: true),
                StackTrace = t.Column<string>(nullable: true),
            }).PrimaryKey("PK-ErrorLog", c => c.Id);
    }
}