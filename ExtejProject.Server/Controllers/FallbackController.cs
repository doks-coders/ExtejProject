using Microsoft.AspNetCore.Mvc;

namespace ExtejProject.Controllers
{
	public class FallbackController : Controller
	{
		public ActionResult Index()
		{
			return PhysicalFile(
				Path.Combine(Directory.GetCurrentDirectory(),
				"wwwroot", "index.html"), "text/HTML");
		}
	}
}
