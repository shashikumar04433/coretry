using System.Diagnostics;
using coretry.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace coretry.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private Mycontext _mycontext;

       
        public HomeController(ILogger<HomeController> logger, Mycontext mycontext)
        {
            _logger = logger;
            _mycontext = mycontext;

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

        public IActionResult getdata()
        {
            var data = _mycontext.Books.ToList();

            return View(data);
        }

        public IActionResult Adddata() {
        
            return View();
        }
        [HttpPost]
        public IActionResult Adddata(Book t)
        {
            _mycontext.Books.Add(t);
            _mycontext.SaveChanges();
            return RedirectToAction("Index");
        }

        


        public IActionResult Editdata(int id)
        {
            var data = _mycontext.Books.Where(x => x.Id == id).SingleOrDefault();
            return View(data);
        }
        [HttpPost]
        public IActionResult Editdata(int id, Book t)
        {
            var data = _mycontext.Books.FirstOrDefault(x => x.Id == id);
            if(data != null)
            {
                data.Title = t.Title;
                data.Description = t.Description;
                data.Author = t.Author;

                _mycontext.SaveChanges();
                return RedirectToAction("getdata");
            }
            else
            {
                return RedirectToAction("Index");
            }
            

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _mycontext.Books.FirstOrDefault(x => x.Id == id);
            if (data != null)
            {
                

                _mycontext.Books.Remove(data);
                _mycontext.SaveChanges();
                return RedirectToAction("getdata");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


        public IActionResult AddProducts()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProducts(Product p)
        {
            if (ModelState.IsValid)
            {
                _mycontext.Products.Add(p);
                _mycontext.SaveChanges();
                return RedirectToAction("Productlist");
            }
            else
            {
                return View(p);
            }
            
        }

        public IActionResult Productlist()
        {
            var data = _mycontext.Products.ToList();

            return View(data);
        }

        public IActionResult UpdateProduct(int id)
        {
            var data = _mycontext.Products.Where(x => x.Id == id).SingleOrDefault();
            return View(data);
        }
        [HttpPost]
        public IActionResult UpdateProduct(int id, Product p)
        {
            var data = _mycontext.Products.FirstOrDefault(x => x.Id == id);
            if (data != null)
            {
                data.Name = p.Name;
                data.Description = p.Description;
                data.Type = p.Type;
                data.Isavailable = p.Isavailable;
                data.Deliverable = p.Deliverable;   


                _mycontext.SaveChanges();
                return RedirectToAction("Productlist");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
        [HttpGet]
        public IActionResult DeleteProduct(int id)
        {
            var data = _mycontext.Products.FirstOrDefault(x => x.Id == id);
            if (data != null)
            {


                _mycontext.Products.Remove(data);
                _mycontext.SaveChanges();
                return RedirectToAction("Productlist");
            }
            else
            {
                return RedirectToAction("Productlist");
            }
        }
    }
}