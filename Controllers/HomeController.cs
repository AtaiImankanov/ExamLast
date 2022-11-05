using homework_64_Atai.Models;
using homework_64_Atai.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace homework_64_Atai.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Models.AppContext _context;
        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly UserManager<User> _userManager;
        private User anon;
        public HomeController(ILogger<HomeController> logger, IStringLocalizer<HomeController> localizer, Models.AppContext context, UserManager<User> userManager)
        {
            _userManager=userManager;
            _localizer=localizer;
            _logger = logger;
            _context=context;
            anon = new User()
            {
                UserName = "Anon",
                Id = 0
            };
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

        [HttpPost]
        public async Task<IActionResult> TopUpAcc(int amount , int bill)
        {
            var user = _context.Users.Where(u => u.PersonalBill == bill).FirstOrDefault();  
           if(user!= null)
            {
                TransJ asd = new TransJ
                {
                    WhoGetId = user.Id,
                    WhoSendId = anon.Id,
                    WhoSend = anon,
                    dateCreated = DateTime.Now,
                    amountOfTrans = amount

                };
                user.Balance = user.Balance + amount;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Home");
            }
            else{
                return View();
            }
    }

        [HttpGet]
        public IActionResult TopUpAcc()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Transaction(int amount, int bill)
        {

            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            int idUser = Convert.ToInt32(_userManager.GetUserId(currentUser));
            var curuser = _userManager.Users.FirstOrDefault(x => x.Id == idUser);
            var user = _context.Users.Where(u => u.PersonalBill == bill).FirstOrDefault();

            if (user != null)
            {
                if (curuser.Balance - amount >= 0)
                {
                    TransJ asd = new TransJ
                    {
                        WhoGetId = user.Id,
                        WhoSendId = anon.Id,
                        WhoSend = anon,
                        dateCreated = DateTime.Now,
                        amountOfTrans = amount

                    };
                    curuser.Balance = curuser.Balance - amount;
                    user.Balance = user.Balance + amount;
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Home");
                }
                return View();
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult Transaction()
        {
            return View();
        }

        public IActionResult ShowTrans()
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            int idUser = Convert.ToInt32(_userManager.GetUserId(currentUser));
            var curuser = _userManager.Users.FirstOrDefault(x => x.Id == idUser);
            var trans = _context.Transjs.Where(t => t.WhoGetId == curuser.Id && t.WhoSendId == curuser.Id).Include(t => t.WhoGet).ToList();
            var trans1 = _context.Transjs.Where(t => t.WhoGetId == curuser.Id && t.WhoSendId == curuser.Id).Include(t => t.WhoSend).ToList();
            trans.AddRange(trans1);
            return View(trans);
        }

    }
}
