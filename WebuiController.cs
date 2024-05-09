using clinic.Models;
using Microsoft.AspNetCore.Mvc;

namespace clinic.Controllers
{
    public class WebuiController : Controller
    {
        private mycontext _mycontext;
        private IWebHostEnvironment _env;
        public WebuiController(IWebHostEnvironment env, mycontext context)
        {
            _env = env;
            _mycontext = context;

        }
        public IActionResult Index()
        {
           List<feedback> feedbacks = _mycontext.tbl_feedback.ToList();
            List<medicinecategory> medcat = _mycontext.tbl_medicinecateogry.ToList();
            List<clinicgallery> galleryimg = _mycontext.tbl_gallery.ToList();
            List<teachers> teacherz = _mycontext.tbl_teacher.ToList();
            List<scientifictools> scitools = _mycontext.tbl_scitools.ToList();
           
            ViewData["feedback"] = feedbacks;
            ViewData["medcategory"] = medcat;
            ViewData["gallery"] = galleryimg;
            ViewData["teacher"] = teacherz;
            ViewData["scitoolz"] = scitools;
          
          


            ViewBag.message = HttpContext.Session.GetString("userSessions");
            return View();
        }
        [HttpPost]
        public IActionResult feedbackadd(feedback feed)
        {
          
            _mycontext.tbl_feedback.Add(feed);
            _mycontext.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult register(client client_)
        {
            _mycontext.tbl_client.Add(client_);
            _mycontext.SaveChanges();
            return RedirectToAction("login");
        }
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login(string clientemail, string clientpass)
        {
           var row =  _mycontext.tbl_client.FirstOrDefault(a => a.client_email == clientemail);
            if(row!=null && row.client_password == clientpass)
            {
                HttpContext.Session.SetString("userSessions",row.client_id.ToString());
                return RedirectToAction("index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult forgot()
        {
            return View();
        }
        [HttpPost]
        public IActionResult forgot(string clientemail, string clientpass)
        {
            var row = _mycontext.tbl_client.FirstOrDefault(a => a.client_email == clientemail);
            if (row != null)
            {
                row.client_password = clientpass;
                _mycontext.SaveChanges();
                return RedirectToAction("login");
            }
            else
            {
                return View();
            }
        }
        public IActionResult logout()
        {
            HttpContext.Session.Remove("userSessions");
            return RedirectToAction("login");
        }
        public IActionResult myaccount()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("userSessions")))
            {
                return RedirectToAction("login");
            }
            else
            {
                var row = HttpContext.Session.GetString("userSessions");
                var row2 = _mycontext.tbl_client.Where(a => a.client_id == int.Parse(row)).ToList();
                return View(row2);
            }
          
        }
        [HttpPost]
        public IActionResult myaccount(client client_)
        {
            
            _mycontext.tbl_client.Update(client_);
            _mycontext.SaveChanges();
            return RedirectToAction("myaccount");
        }
        public IActionResult educationservice()
        {
            return View();
        }
        public IActionResult registereducation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult registereducation(client _client)
        {
            _mycontext.tbl_client.Add(_client);
            _mycontext.SaveChanges();
            return RedirectToAction("registereducation");
        }
       public IActionResult medproducts()
        {
            List<medicines> med = _mycontext.tbl_medicines.ToList();
            ViewData["meds"] = med;
            return View();
        }
        public IActionResult sciproducts()
        {
            return View();
        }
        public IActionResult twoproducts()
        {
            List<scitwo> two = _mycontext.tbl_scitwo.ToList();
            ViewData["scitwo"] = two;
            return View();
        }
        public IActionResult about()
        {
            List<teachers> teacherz = _mycontext.tbl_teacher.ToList();
            ViewData["teacher"] = teacherz;
            return View();
        }
        [HttpPost]
        public IActionResult feedsadd(feedback feeds)
        {
            _mycontext.tbl_feedback.Add(feeds);
            _mycontext.SaveChanges();
            return RedirectToAction("about");
        }
        public IActionResult contactweb()
        {
            return View();
        }
        [HttpPost]
        public IActionResult contactform(contact con)
        {
            _mycontext.tbl_contact.Add(con);
            _mycontext.SaveChanges();
            return RedirectToAction("contactweb");
        }
        public IActionResult quickview(int id)
        {
           var row =  _mycontext.tbl_medicines.Where(a => a.med_id == id).ToList();
            return View(row);
        }
        [HttpPost]
        public IActionResult cardview(cart card, string cart_name,string cart_price, int cart_qty,string cart_image)
        {
            string isLogin = HttpContext.Session.GetString("userSessions");
            if (isLogin != null)
            {
                card.cart_img = cart_image;
                card.cart_name = cart_name;
                card.cart_price = int.Parse(cart_price);
                card.cart_bill = int.Parse(cart_price) * cart_qty;
                _mycontext.tbl_cart.Add(card);
                _mycontext.SaveChanges();
                return RedirectToAction("showcart");
            }
            else
            {
                return RedirectToAction("login");
            }
                
        }
        public IActionResult showcart()
        {
          var row =   _mycontext.tbl_cart.ToList();
            return View(row);
        }



        public IActionResult quicktwo(int id)
        {
          var row =   _mycontext.tbl_scitwo.Where(a => a.two_id == id).ToList();
            return View(row);
        }
        [HttpPost]
        public IActionResult cardtwoview(cart card,string carttwoname, string cart_price, string carttwoimg,int cart_qty)
        {
            string isLogin = HttpContext.Session.GetString("userSessions");
            if (isLogin != null)
            {
                card.cart_name = carttwoname;
                card.cart_img = carttwoimg;
                card.cart_price = int.Parse(cart_price);
                card.cart_bill = cart_qty * int.Parse(cart_price);
                _mycontext.tbl_cart.Add(card);
                _mycontext.SaveChanges();
                return RedirectToAction("showcart");
            }
            else
            {
                return RedirectToAction("login");
            }
        }
        
    }
}
