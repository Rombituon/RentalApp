using Microsoft.AspNetCore.Mvc;
using RentalApp.Data;
using RentalApp.Models;

namespace RentalApp.Controllers
{
    //[Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly RentalDataContext _context;

        public HomeController(RentalDataContext context)
        {
            this._context = context;
        }


        #region MyLogic
        public List<string> getBankList()
        {
            List<string> banks = new List<string>
            {
                "Maybank",
                "RHB",
                "CIMB"
            };

            return banks;

        }
        public IActionResult Index()
        {
            ViewData["WelcomeMessage"] = "Selamat Datang Ke JPKN";
            ViewBag.Message = "Sistem Terbuka JPKN";
            ViewBag.Banks = getBankList();



            var renter = new Renter()
            {
                Name="ABC",
                IcNo="12345",
                PhoneNo="999999999"
            };

            if(ModelState.IsValid)
            {
                _context.Add(renter);
                _context.SaveChanges();
            }

          
            //var renter = _context.Renters.Find(1);

            //_context.Renters.Remove(renter);
            ////renter.Name = "Just Updated";
            ////_context.SaveChanges();

            ViewBag.Renters = _context.Renters.Where(x=>x.Name== "Jurin 2").ToList();


            return View();
        }
        #endregion

        public string Color(string colorName)
        {
            string hexCode = "0xFFF";

            if (colorName == "Red")
            {
                hexCode = "0xffff";
            }
            else if(colorName == "Blue")
            {
                hexCode = "0xfffh";
            }
            else
            {
                hexCode = "0xfffh";
            }
            return hexCode;
        }

       
    }
}
