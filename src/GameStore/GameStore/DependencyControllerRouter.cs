namespace GameStore
{
    using System;
    using Data;
    using SimpleInjector;
    using SimpleInjector.Lifestyles;
    using SimpleMvc.Framework.Controllers;
    using SimpleMvc.Framework.Routers;

    public class DependencyControllerRouter : ControllerRouter
    {
        public DependencyControllerRouter()
        {
            this.Container = new Container();
            this.Container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
        }

        public Container Container { get; }

        public static DependencyControllerRouter Get()
        {
            var router = new DependencyControllerRouter();

            var container = router.Container;

            container.Register<GameStoreContext>(Lifestyle.Scoped);

            container.Verify();

            return router;
        }

        protected override Controller CreateController(Type controllerType)
        {
            AsyncScopedLifestyle.BeginScope(this.Container);
            return (Controller)this.Container.GetInstance(controllerType);
        }
    }
}