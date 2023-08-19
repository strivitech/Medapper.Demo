namespace Medapper.Demo.Settings;

public class DbConnectionSettings
{
    public const string SectionName = "DbConnection";
    
    public string ConnectionString { get; set; } = null!;
}