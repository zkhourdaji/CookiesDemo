using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CookiesDemo.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// View current cookies
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            IRequestCookieCollection cookies = HttpContext.Request.Cookies;
            return View(cookies);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Edit(string key)
        {
            var value = HttpContext.Request.Cookies[key];
            return View((key: key,value: value));
        }

        [HttpPost]
        public IActionResult Edit(string key, string newValue)
        {
            Response.Cookies.Append(key, newValue);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(string key)
        {
            Response.Cookies.Delete(key);
            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(string key, string value)
        {
            Response.Cookies.Append(key, value);
            return RedirectToAction("Index");
        }

        public IActionResult Details(string key)
        {
            string value = Request.Cookies[key];
            return View((key,value));
        }

        /// <summary>
        /// Delete all cookies
        /// </summary>
        /// <returns>Redirects to the Index page</returns>
        public IActionResult Clear()
        {
            ICollection<string> keys = Request.Cookies.Keys;
            foreach(string key in keys)
            {
                Response.Cookies.Delete(key);
            }
            return RedirectToAction("Index");
        }
    }
}
