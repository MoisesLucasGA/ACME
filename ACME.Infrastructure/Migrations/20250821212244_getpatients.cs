using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ACME.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class getpatients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
                        CREATE PROCEDURE [dbo].[getPatients]
                            @paramSearch varchar(100) = null,
                            @paramStatus int = null
                        AS
                        BEGIN
                            SELECT * FROM [dbo].Patients as P
                                WHERE
                                    (@paramSearch IS NULL OR (P.Name LIKE '%' + @paramSearch + '%' OR P.CPF LIKE '%' + @paramSearch + '%'))
                                AND
                                    (@paramStatus IS NULL OR P.Status = @paramStatus);
                        END;
                        GO
             ";

            migrationBuilder.Sql(sql);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sql = @"
                        DROP PROCEDURE [dbo].[getPatients]
                        GO
            ";

            migrationBuilder.Sql(sql);
        }
    }
}
