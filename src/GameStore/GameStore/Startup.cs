namespace GameStore
{
    using Data;
    using SimpleMvc.Framework;
    using SimpleMvc.Framework.Routers;
    using WebServer;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var server = new WebServer(
                7777,
                DependencyControllerRouter.Get(),
                new ResourceRouter());

            var context = new GameStoreContext();
            MvcEngine.Run(server, context);
        }
    }
}
