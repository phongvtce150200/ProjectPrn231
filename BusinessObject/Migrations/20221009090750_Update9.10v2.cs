using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessObject.Migrations
{
    public partial class Update910v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PrescriptionDetails",
                table: "PrescriptionDetails");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8edc2ad5-79f7-4367-aec1-1cd52d7751ce");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "df0b8239-c80e-4818-a55e-defba0f7d5bc");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e22e5ad9-9725-477b-9a07-4387b02e1104");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "39df837d-b29e-4063-abee-038423f1e3da");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "d06f5bc7-3290-4ec9-912b-ce05e0a0d852");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "db8423e8-37ca-431d-9aee-abecdaf26113");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrescriptionDetails",
                table: "PrescriptionDetails",
                columns: new[] { "PrescriptionId", "MedicineId" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8949eb84-0eed-445b-8af5-0f784a4da8aa", "9e0dcf5d-084b-4b4c-918a-abfb5f7ee54e", "Admin", "ADMIN" },
                    { "edcde8e0-29ba-492b-a9e7-47b52b700b30", "5ba99b36-3376-4d60-8ff2-c057edeb369a", "Doctor", "DOCTOR" },
                    { "cda5a388-53c8-4556-82a4-654d43284787", "4834f70f-eda2-478c-ae64-55fd2e6b5e3d", "Patient", "PATIENT" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Birhtday", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "e3fd2e63-5cf1-44a0-81fd-4475932a9458", 0, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7f61f1da-e111-4d5e-85a5-8ad598b2bd11", "admin@clinc.com", true, "admin", 1, false, null, "ADMIN@CLINIC.COM", "ADMIN", "AQAAAAEAACcQAAAAEBLKyoJyCWhe0UOEiagY0QS76wuHxX/JCP75aThdqe5JBNmQEfO3PRnJYeMSlzwm9w==", "0909090090", true, "8647343b-4d04-4671-82a1-33c7841f7afd", false, "admin" },
                    { "0cd28eff-0ab8-4fe8-bb42-69667bb2f95c", 0, null, new DateTime(2001, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "45b69d88-01c5-4025-a46a-63247ec5df4a", "v.thanhphong1712@gmail.com", true, "Võ Thanh Phong", 1, false, null, "V.THANHPHONG1712@GMAIL.COM", "PHONGVT1712", "AQAAAAEAACcQAAAAENPJrqlID/hPZzOjnfh//wymu4sPxYvh1ui6FMGaySHj3vPbJOoJwIxPKVMvCgbJ1g==", "0769339456", true, "b2eb8ea5-a6f4-4937-b3b9-474cb8a90c89", false, "phongvt1712" },
                    { "9a7fab7d-2e1c-44f6-883d-75bab7e9ae77", 0, null, new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "8138e93b-e19d-41cb-bf94-974678fec7e3", "hauphan@gmail.com", true, "Phan Công Hậu", 1, false, null, "HAUPHAN@GMAIL.COM", "HAUPHAN", "AQAAAAEAACcQAAAAEA3Rgg5FArl5GBv4w6sJF8Jioq1nUvjnMVPdOudn3UkOUM03P3Gna97cactHGxldiA==", "0808080080", true, "3de3b6c2-713c-4363-be1e-0ccaf1758146", false, "hauphan" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PrescriptionDetails",
                table: "PrescriptionDetails");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8949eb84-0eed-445b-8af5-0f784a4da8aa");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cda5a388-53c8-4556-82a4-654d43284787");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "edcde8e0-29ba-492b-a9e7-47b52b700b30");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "0cd28eff-0ab8-4fe8-bb42-69667bb2f95c");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9a7fab7d-2e1c-44f6-883d-75bab7e9ae77");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "e3fd2e63-5cf1-44a0-81fd-4475932a9458");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrescriptionDetails",
                table: "PrescriptionDetails",
                column: "PrescriptionId");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8edc2ad5-79f7-4367-aec1-1cd52d7751ce", "f9957945-5a69-47a3-8217-368f3e122885", "Admin", "ADMIN" },
                    { "df0b8239-c80e-4818-a55e-defba0f7d5bc", "83389994-8023-4ef9-a6e8-727422ad6d06", "Doctor", "DOCTOR" },
                    { "e22e5ad9-9725-477b-9a07-4387b02e1104", "5979bcdf-fa10-4dc5-985f-e9ea6d78a85f", "Patient", "PATIENT" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Birhtday", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "d06f5bc7-3290-4ec9-912b-ce05e0a0d852", 0, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9fc7ae24-dec8-4314-b169-b7b188bd7983", "admin@clinc.com", true, "admin", 1, false, null, "ADMIN@CLINIC.COM", "ADMIN", "AQAAAAEAACcQAAAAEKl/AEfoV9forW+hxAygtnAz5cN5jIAnr6jp0UIMGSjqfYilm0s8wIyXyO7xPJ3mww==", "0909090090", true, "9b826308-f581-43de-a106-831ae28e193d", false, "admin" },
                    { "39df837d-b29e-4063-abee-038423f1e3da", 0, null, new DateTime(2001, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "92b1f244-83ed-417f-836c-e266f6bd4083", "v.thanhphong1712@gmail.com", true, "Võ Thanh Phong", 1, false, null, "V.THANHPHONG1712@GMAIL.COM", "PHONGVT1712", "AQAAAAEAACcQAAAAEKRbcaTAGhcJzloc0p/zUsbbWjWEpXd1GjreKx8hFdp7EDqbOVesStBbycmXc8hBRA==", "0769339456", true, "1fc8fda5-70dc-4634-983c-5848356726ee", false, "phongvt1712" },
                    { "db8423e8-37ca-431d-9aee-abecdaf26113", 0, null, new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "788f9c25-817c-46ed-a2da-1a323ce57938", "hauphan@gmail.com", true, "Phan Công Hậu", 1, false, null, "HAUPHAN@GMAIL.COM", "HAUPHAN", "AQAAAAEAACcQAAAAEF6Usu85hGUGN3CQk8TDMwBtSViKLGx0jp7yVztS9GlClV/yrN2NnaV/RcmTH4/qrA==", "0808080080", true, "f9fa089f-1c49-431e-8ece-1c975ea9e49b", false, "hauphan" }
                });
        }
    }
}
