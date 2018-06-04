using DesACID_ApiWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DesAcid_MVC.Controllers
{
    public class TasaNatMorController : Controller
    {
        // GET: TasaNatMor
        public async Task<ActionResult> TasaNatMor()
        {
            //http://desacidapiweb2.azurewebsites.net/api/Paises

            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("http://desacidapiweb2.azurewebsites.net/api/Paises");
            var ListaPaises = JsonConvert.DeserializeObject<List<Paises>>(json);

            var json2 = await httpClient.GetStringAsync("http://desacidapiweb2.azurewebsites.net/api/Datos");
            var Datos = JsonConvert.DeserializeObject<List<Datos>>(json2);

            Session["Datos"] = Datos;

            Session["Paises"] = ListaPaises;

            return View(ListaPaises);
        }

        public ActionResult Busqueda(string Paises, string Desde, string Hasta)
        {
            ViewBag.Message = Paises;
            
            List<Datos> Dat = (List<Datos>)Session["Datos"];
          
            DateTime dtDesde = DateTime.ParseExact(Desde, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DateTime dtHasta = DateTime.ParseExact(Hasta, "dd/MM/yyyy", CultureInfo.InvariantCulture);

           

            string HTML="";
           
            
            foreach (var item in Dat)
            {
                if (Paises.IndexOf(item.Country_code) >= 0 && item.Ano >= dtDesde.Year && item.Ano <= dtHasta.Year)
                {
                   
                    HTML = HTML +item.Country_Name.Replace(",","") + 
                        "," + item.Indicador.Replace(",", "") +
                        "," + item.Ano.ToString() + 
                        "," + item.Tasa.Replace(",", ".")+
                        "|";

                }
              
            }
            
            return Content(HTML.TrimEnd('|'));
            //return View();
        }



    }
}