using System;
using Microsoft.AspNetCore.Mvc;

namespace AspnetCoreRC2Poc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

             using (var db = new BloggingContext())
            {
                try{
                db.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
             //   var count = db.SaveChanges();
                }
                catch(Exception ex){
                    
                }
                foreach (var blog in db.Blogs)
                {
                   // Console.WriteLine(" - {0}", blog.Url);
                }
            }

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
