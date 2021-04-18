using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebAppLecturer.Controllers
{
    public class DoctorController : Controller
    {
        [HttpGet]
        public IActionResult Check()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Check(int temp)
        {
            if (
               temp.Equals(null) ||
               temp.Equals("")
              )
            {
                ViewBag.Msg = "You need to fill in temperature in Celcius!";
                return View();
            }

            string message = FeverCheck.FeverCheck1(temp);

            ViewBag.result = message;
            return View("ResultCheck");
            }

            //ViewBag.Msg = "Somthing has gone wronge";
            //return View();
        }
    }

