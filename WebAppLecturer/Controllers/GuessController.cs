using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLecturer.Controllers
{
    public class GuessController : Controller
    {
        public static int NumberGenerator()
        {
            Random rn = new Random();
            int mysteryNumber = rn.Next(1, 101);
            return mysteryNumber;
        }

        public static string GuessCheck(int angka, int mysteryNumber)
        {
            if (angka == mysteryNumber)
            {
               return "You win!";
            }
            else if (angka > mysteryNumber)
            {
                return "You guessed too high, please guess smaller number";
            }
            else
            {
               return "You guessed too low, please guess higher number";
            }

        }

        [HttpGet]
        public IActionResult GuessingGame()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GuessingGame(int angka, int mysteryNumber)
        {
            if (
               angka.Equals(null) ||
               angka.Equals("")
              )
            {
                ViewBag.Msg = "You need to fill in the valid number";
                return View();
            }

            NumberGenerator();
            HttpContext.Session.SetInt32("MysteryNumber", mysteryNumber);
            
            if (GuessCheck(angka, mysteryNumber).Contains("win"))
            {
                ViewBag.message = "You win";
                NumberGenerator();
            }
            else if (GuessCheck(angka, mysteryNumber).Contains("smaller"))
            {
                ViewBag.message = "You guessed too high, please guess smaller number";
                GuessCheck(angka, mysteryNumber);
            }
            else
            {
                ViewBag.message = "You guessed too low, please guess higher number";
                GuessCheck(angka, mysteryNumber);
            }
            return View();
        }
    }
}


