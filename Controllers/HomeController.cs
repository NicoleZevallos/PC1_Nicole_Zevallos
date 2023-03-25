using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PC1_Zevallos_Varillas_Nicole.Models;

namespace PC1_Zevallos_Varillas_Nicole.Controllers;


public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

   
    public IActionResult pago(Pago pago1)
    {
        var model = new Pago(); 
        model.FechaVencimiento = DateTime.Now;
        return View("ingresarPago", model);
    }

     [HttpPost]
        public IActionResult CalcularMora(Pago pago)
        {
            decimal mora = 0;
            decimal montoTotal = pago.MontoPagar;
            DateTime fechaActual = DateTime.Now;
            TimeSpan diasRetraso = fechaActual.Date - pago.FechaVencimiento.Date;

            if (diasRetraso.TotalDays > 0)
            {
                mora = Decimal.Round(pago.MontoPagar * (decimal)(0.00005 * diasRetraso.TotalDays),3);
                montoTotal += mora;
            }

            ViewBag.MontoTotal = montoTotal;
            ViewBag.Mora = mora;

            return View("pagoTotal", pago);
        }
}
