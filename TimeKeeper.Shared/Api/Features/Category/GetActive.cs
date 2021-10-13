namespace TimeKeeper.Shared.Api.Features.Category
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
