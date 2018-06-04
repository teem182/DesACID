using DesACID_ApiWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DesAcid_MVC.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            //http://desacidapiweb2.azurewebsites.net/api/Paises

            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("http://desacidapiweb2.azurewebsites.net/api/Paises");
            var ListaPaises = JsonConvert.DeserializeObject<List<Paises>>(json);
            return View(ListaPaises);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}