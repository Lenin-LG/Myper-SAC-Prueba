using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trabajadores.Migrations
{
    /// <inheritdoc />
    public partial class AddStoredProcedures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
          EXEC('
          CREATE PROCEDURE GetWorkers
          AS
          BEGIN
           SELECT * FROM Workers
          END
          ')
          ");

            migrationBuilder.Sql(@"
          EXEC('
          CREATE PROCEDURE GetWorkersByGender
              @Gender NVARCHAR(50)
          AS
          BEGIN
              SELECT * FROM Workers WHERE Gender = @Gender
          END
          ')
           ");
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS GetWorkers");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS GetWorkersByGender");

        }
    }
}
