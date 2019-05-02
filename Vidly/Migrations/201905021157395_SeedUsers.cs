namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'16ab306b-50fd-4263-9c02-4829399732ce', N'admin@vidly.com', 0, N'AHbxO67JcDDo6UNkM9vV83t6OLlWQn2nAOvktqwRtuW8J2aj8fE/xOAPaWqx+ZXwhw==', N'cca72e5d-e2f7-471f-8fae-2a8ded7592ae', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f49dcbaa-d819-428e-ac54-e77c6f4b460f', N'guest@vidly.com', 0, N'AL6y8LNzKIRQJISLqnRDlcUa/7oZUzeIRtrPaVBpvaIY7qkJzn3ndWk1IYEArOZ1ig==', N'380b61c9-830f-44b7-a1b5-867fde8c6516', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7cf1b2a3-1470-4553-9d96-d1c6581d0f62', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'16ab306b-50fd-4263-9c02-4829399732ce', N'7cf1b2a3-1470-4553-9d96-d1c6581d0f62')

");
        }
        
        public override void Down()
        {
        }
    }
}
