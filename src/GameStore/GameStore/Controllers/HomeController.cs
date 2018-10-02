namespace GameStore.Controllers
{
    using SimpleMvc.Framework.Interfaces;

    public class HomeController : BaseController
    {
        public IActionResult Index() => this.View();
    }
}