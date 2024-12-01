using PWST_v0._3_server.Abstract.Interfaces;


namespace PWST_v0._3_server.Abstract {
    public abstract class BaseServer : IAccessable {

        public int MyProperty { get; set; }
        public abstract void StartServer();
        public abstract void StopServer();
    }
}
