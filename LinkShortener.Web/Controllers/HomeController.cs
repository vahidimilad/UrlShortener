using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinkShortener.Core.Services.Interfaces;

namespace LinkShortener.Web.Controllers
{
    public class HomeController : Controller
    {
        private IUrlService _urlService;
        private IUserService _userService;

        public HomeController(IUrlService urlService, IUserService userService)
        {
            _urlService = urlService;
            _userService = userService;
        }
        public IActionResult Index()
        {
            var userId = 1;
            ViewData["UserUrlList"]=_userService.GetUserUrlList(userId);
            return View();
        }

        [HttpPost]
        [Route("/ShortenUrl")]
        public IActionResult ShortenUrl(string originalUrl)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            string shortKey=_urlService.GetShortKeyForOriginalUrl(originalUrl);
            
            _urlService.AddUrl(originalUrl, shortKey);
            var userId = 1;
            ViewData["UserUrlList"] = _userService.GetUserUrlList(userId);

            return View("Index");
        }

        [Route("/{shortKey}")]
        public IActionResult RedirectShortUrl(string shortKey)
        {
           
            if (_urlService.FindOriginalUrlByShortKey(shortKey)==null)
            {
                return NotFound();
            }

            string originalUrl = _urlService.FindOriginalUrlByShortKey(shortKey);
            _urlService.IncrementUrlClicks(shortKey);
            return Redirect(originalUrl);
            
        }
        public IActionResult GetChartData()
        {
            var data = _urlService.GetUrlListStatus(1);
            return Json(data);
        }
    }
}
