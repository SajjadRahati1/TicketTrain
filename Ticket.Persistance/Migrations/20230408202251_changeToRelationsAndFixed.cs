using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticket.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class changeToRelationsAndFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightTicketRefundRules_GroupTrainTicketRefundRules_GroupTrainTicketRefundRulesId",
                table: "FlightTicketRefundRules");

            migrationBuilder.DropIndex(
                name: "IX_FlightTicketRefundRules_GroupTrainTicketRefundRulesId",
                table: "FlightTicketRefundRules");

            migrationBuilder.DropColumn(
                name: "GroupTrainTicketRefundRulesId",
                table: "FlightTicketRefundRules");

            migrationBuilder.AddColumn<long>(
                name: "GroupTrainTicketRefundRulesId",
                table: "TrainTicketRefundRules",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AirLineCompanyId",
                table: "AirLines",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_TrainTicketRefundRules_GroupTrainTicketRefundRulesId",
                table: "TrainTicketRefundRules",
                column: "GroupTrainTicketRefundRulesId");

            migrationBuilder.CreateIndex(
                name: "IX_AirLines_AirLineCompanyId",
                table: "AirLines",
                column: "AirLineCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AirLines_AirLineCompanies_AirLineCompanyId",
                table: "AirLines",
                column: "AirLineCompanyId",
                principalTable: "AirLineCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainTicketRefundRules_GroupTrainTicketRefundRules_GroupTrainTicketRefundRulesId",
                table: "TrainTicketRefundRules",
                column: "GroupTrainTicketRefundRulesId",
                principalTable: "GroupTrainTicketRefundRules",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AirLines_AirLineCompanies_AirLineCompanyId",
                table: "AirLines");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainTicketRefundRules_GroupTrainTicketRefundRules_GroupTrainTicketRefundRulesId",
                table: "TrainTicketRefundRules");

            migrationBuilder.DropIndex(
                name: "IX_TrainTicketRefundRules_GroupTrainTicketRefundRulesId",
                table: "TrainTicketRefundRules");

            migrationBuilder.DropIndex(
                name: "IX_AirLines_AirLineCompanyId",
                table: "AirLines");

            migrationBuilder.DropColumn(
                name: "GroupTrainTicketRefundRulesId",
                table: "TrainTicketRefundRules");

            migrationBuilder.DropColumn(
                name: "AirLineCompanyId",
                table: "AirLines");

            migrationBuilder.AddColumn<long>(
                name: "GroupTrainTicketRefundRulesId",
                table: "FlightTicketRefundRules",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FlightTicketRefundRules_GroupTrainTicketRefundRulesId",
                table: "FlightTicketRefundRules",
                column: "GroupTrainTicketRefundRulesId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightTicketRefundRules_GroupTrainTicketRefundRules_GroupTrainTicketRefundRulesId",
                table: "FlightTicketRefundRules",
                column: "GroupTrainTicketRefundRulesId",
                principalTable: "GroupTrainTicketRefundRules",
                principalColumn: "Id");
        }
    }
}
