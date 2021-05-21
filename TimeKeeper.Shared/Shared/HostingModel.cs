namespace TimeKeeper.Shared.Shared
{
    public class HostingModel
    {
        private readonly string uri;
        
        public HostingModel(string uri)
        {
            this.uri = uri;
        }
        public bool IsWasm => uri.Contains("localhost:44360") || uri.Contains("localhost:5003");
        public string Name => IsWasm ? "Client (WASM)" : "Server Side";
    }
}