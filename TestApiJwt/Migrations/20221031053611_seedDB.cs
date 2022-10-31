using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestApiJwt.Migrations
{
    public partial class seedDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            
            migrationBuilder.InsertData(
                
                table: "AspNetRoles",
                columns: new[] { "Id","Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] {Guid.NewGuid().ToString(),"user","user".ToUpper(),Guid.NewGuid().ToString()}
             );
            migrationBuilder.InsertData(

                table: "AspNetRoles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] { Guid.NewGuid().ToString(), "admin", "admin".ToUpper(), Guid.NewGuid().ToString() }
             );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM AspNetRoles");
        }
    }
}
