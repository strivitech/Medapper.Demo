namespace Medapper.Demo.Contracts.Responses;

public class GetUserResponse
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = null!;
}