namespace TimeKeeper.Shared.Api.Features.Client
{
    public class GetActive
    {
        public record Model
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}