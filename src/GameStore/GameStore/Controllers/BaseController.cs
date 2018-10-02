namespace GameStore.Controllers
{
    using System;
    using SimpleMvc.Framework.Controllers;
    using SimpleMvc.Framework.Interfaces;

    public class BaseController : Controller
    {
        protected BaseController()
        {
            this.Model.Data["show-error"] = "none";
            this.Model.Data["year"] = DateTime.Now.Year.ToString();
        }

        protected IActionResult RedirectToHome() => this.RedirectToAction("/home/index");

        protected IActionResult RedirectToLogin() => this.RedirectToAction("/user/login");

        protected void ShowError(string error)
        {
            this.Model.Data["show-error"] = "block";
            this.Model.Data["error"] = error;
        }
    }
}