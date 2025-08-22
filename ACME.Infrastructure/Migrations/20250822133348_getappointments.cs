using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ACME.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class getappointments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
CREATE PROCEDURE [dbo].[getAppointments]
    @paramInitialDate Datetime = null,
    @paramFinalDate Datetime = null,
    @paramPatientId int = null,
    @paramStatus int = null
AS
BEGIN
SELECT 
    A.AppointmentId,
    A.Description,
    A.Date,
    A.Status,
    A.PatientId,
    P.Name,
    P.CPF
FROM [dbo].Appointments AS A
    INNER JOIN [dbo].Patients AS P ON
        P.PatientId = A.PatientId
    WHERE
        (@paramInitialDate IS NULL OR @paramFinalDate IS NULL OR A.Date BETWEEN @paramInitialDate AND @paramFinalDate)
    AND
        (@paramStatus IS NULL OR A.Status = @paramStatus)
    AND
        (@paramPatientId IS NULL OR A.PatientId = @paramStatus);
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
