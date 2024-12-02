using WebSocketSharp;

namespace PWST_v0._3_client.Networking.Abstract.Classes {
    public abstract class BaseClient {

        // Properties
        public int SessionID { get; private set; }
        public string Username { get; protected set; }
        public WebSocket WebSocket { get; protected set; }

        // Constructors
        protected BaseClient() {
            Username = "Anonymous";
        }
        protected BaseClient(string username) {
            Username = username;
        }

        // Methods
        public abstract void Connect();
        public abstract void Disconnect();
    }
}
