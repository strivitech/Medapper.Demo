using FluentMigrator;

namespace Medapper.Demo.Migrations;

[Migration(202308191)]
public class CreateUserTableMigration : Migration
{
    public override void Up()
    {
        Create.Table("users")
            .WithColumn("id").AsGuid().PrimaryKey().WithDefault(SystemMethods.NewSequentialId)
            .WithColumn("name").AsString();
    }

    public override void Down()
    {
        Delete.Table("users");
    }
}