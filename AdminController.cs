using clinic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using NuGet.DependencyResolver;

namespace clinic.Controllers
{
	public class AdminController : Controller
	{
		private mycontext _mycontext;
		private IWebHostEnvironment _env;
		public AdminController(IWebHostEnvironment env, mycontext context)
		{
			_env = env;
			_mycontext = context;

		}
		public IActionResult Index()
		{
			var row=HttpContext.Session.GetString("userSessions");
			if (row != null)
			{
				return View();
			}
			else
			{
				return RedirectToAction("login");
			}
			
		}
		public IActionResult register()
		{
			return View();
		}
		[HttpPost]
		public IActionResult register(admin _admin)
		{
			_mycontext.tbl_admin.Add(_admin);
			_mycontext.SaveChanges();
			return RedirectToAction("login");
		}
		public IActionResult login()
		{
			return View();
		}
		[HttpPost]
		public IActionResult login(string adminemail, string adminpassword)
		{
			var row = _mycontext.tbl_admin.FirstOrDefault(a => a.admin_email == adminemail);
			if (row != null && row.admin_password == adminpassword)
			{
				HttpContext.Session.SetString("userSessions", row.admin_id.ToString());
				return RedirectToAction("index");
			}
			else
			{
				return View();
			}
		}
		public IActionResult forgotpassword()
		{
			return View();
		}
		[HttpPost]
		public IActionResult forgotpassword(string adminemail, string adminpassword, string robot)
		{
			var row = _mycontext.tbl_admin.FirstOrDefault(a => a.admin_email == adminemail);
			if (row != null && robot == "no")
			{
				row.admin_password = adminpassword;
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
        public IActionResult updateProfile()
        {
            var adminId = HttpContext.Session.GetString("userSessions");
            var rows = _mycontext.tbl_admin.Where(a => a.admin_id == int.Parse(adminId)).ToList();
            return View(rows);
        }
        [HttpPost]
        public IActionResult updateProfile(admin _admin)
        {
            _mycontext.tbl_admin.Update(_admin);
            _mycontext.SaveChanges();
            return RedirectToAction("updateProfile");

        }
        [HttpPost]
        public IActionResult imgupload(IFormFile admin_image,admin _admin)
        {
            var filePath = Path.Combine(_env.WebRootPath, "adminimages", admin_image.FileName);
            FileStream fs = new FileStream(filePath, FileMode.Create);
            admin_image.CopyTo(fs);
            _admin.admin_image = admin_image.FileName;
            _mycontext.tbl_admin.Update(_admin);
            _mycontext.SaveChanges();
            return RedirectToAction("updateProfile");
        }
        public IActionResult addclient()
		{
			return View();
		}
		[HttpPost]
		public IActionResult addclient(client _client, IFormFile client_image)
		{
			string filename = Path.GetFileName(client_image.FileName);
			string filepath = Path.Combine(_env.WebRootPath, "clientimages", filename);
			FileStream fs = new FileStream(filepath, FileMode.Create);
			client_image.CopyTo(fs);
			_client.client_image = client_image.FileName;
			_mycontext.tbl_client.Add(_client);
			_mycontext.SaveChanges();
			return RedirectToAction("showclient");
		}
		public IActionResult showclient()
		{
			var row=_mycontext.tbl_client.ToList();
			return View(row);
		}
		public IActionResult updateclient(int id)
		{
			var row=_mycontext.tbl_client.Find(id);
			return View(row);
		}
		[HttpPost]
		public IActionResult updateclient(client _client, IFormFile client_image)
		{
            string filename = Path.GetFileName(client_image.FileName);
            string filepath = Path.Combine(_env.WebRootPath, "clientimages", filename);
            FileStream fs = new FileStream(filepath, FileMode.Create);
            client_image.CopyTo(fs);
            _client.client_image = client_image.FileName;
            _mycontext.tbl_client.Update(_client);
            _mycontext.SaveChanges();
            return RedirectToAction("showclient");
        }
		public IActionResult deleteclient(int id)
		{
			var row=_mycontext.tbl_client.Find(id);
			_mycontext.tbl_client.Remove(row);
			_mycontext.SaveChanges();
			return RedirectToAction("showclient");
		}
		public IActionResult detailclient(int id)
		{
			var row=_mycontext.tbl_client.FirstOrDefault(a => a.client_id == id);
			return View(row);
		}
		public IActionResult addscitools()
		{
			return View();
		}
		[HttpPost]
		public IActionResult addscitools(IFormFile sci_image, scientifictools scitools)
		{
            string filename = Path.GetFileName(sci_image.FileName);
            string filepath = Path.Combine(_env.WebRootPath, "scitoolsimage", filename);
            FileStream fs = new FileStream(filepath, FileMode.Create);
            sci_image.CopyTo(fs);
            scitools.sci_image = sci_image.FileName;
			_mycontext.tbl_scitools.Add(scitools);
            _mycontext.SaveChanges();
            return RedirectToAction("showscitools");
        }
		public IActionResult showscitools(int id)
		{
			var row =_mycontext.tbl_scitools.ToList();
			return View(row);
		}
		public IActionResult updatescitools(int id)
		{
			var row=_mycontext.tbl_scitools.Find(id);
			return View(row);
		}
		[HttpPost]
		public IActionResult updatescitools(IFormFile sci_image,scientifictools _scitools)
		{
            string filename = Path.GetFileName(sci_image.FileName);
            string filepath = Path.Combine(_env.WebRootPath, "scitoolsimage", filename);
            FileStream fs = new FileStream(filepath, FileMode.Create);
            sci_image.CopyTo(fs);
            _scitools.sci_image = sci_image.FileName;
            _mycontext.tbl_scitools.Update(_scitools);
            _mycontext.SaveChanges();
            return RedirectToAction("showscitools");
        }
		public IActionResult deletescitools(int id)
		{
            var row2 = _mycontext.tbl_scitools.Find(id);
			_mycontext.tbl_scitools.Remove(row2);
            _mycontext.SaveChanges();
            return RedirectToAction("showscitools");
        }
		public IActionResult detailscitools(int id)
		{
			var row=_mycontext.tbl_scitools.FirstOrDefault(a => a.sci_id == id);
			return View(row);
		}

		public IActionResult addevent()
		{
			return View();
		}
        [HttpPost]
        public IActionResult addevent(IFormFile event_image, educationevents events)
        {
            string filename = Path.GetFileName(event_image.FileName);
            string filepath = Path.Combine(_env.WebRootPath, "eventimage", filename);
            FileStream fs = new FileStream(filepath, FileMode.Create);
            event_image.CopyTo(fs);
            events.event_image = event_image.FileName;
            _mycontext.tbl_educationevents.Add(events);
            _mycontext.SaveChanges();
            return RedirectToAction("showevent");
        }
        public IActionResult showevent()
        {
            var row = _mycontext.tbl_educationevents.ToList();
            return View(row);
        }
        public IActionResult detailevent(int id)
        {
            var row = _mycontext.tbl_educationevents.FirstOrDefault(a => a.event_id == id);
            return View(row);
        }
		public IActionResult updateevent(int id)
		{
			var row=_mycontext.tbl_educationevents.Find(id);
			return View(row);
		}
		[HttpPost]
		public IActionResult updateevent(IFormFile event_image, educationevents _events)
		{
            string filename = Path.GetFileName(event_image.FileName);
            string filepath = Path.Combine(_env.WebRootPath, "eventimage", filename);
            FileStream fs = new FileStream(filepath, FileMode.Create);
            event_image.CopyTo(fs);
            _events.event_image = event_image.FileName;
            _mycontext.tbl_educationevents.Update(_events);
            _mycontext.SaveChanges();
            return RedirectToAction("showevent");
        }
		public IActionResult deleteevent(int id)
		{
			var row=_mycontext.tbl_educationevents.Find(id);
			_mycontext.tbl_educationevents.Remove(row);
			_mycontext.SaveChanges();
			return RedirectToAction("showevent");
		}
		public IActionResult addfeedback()
		{
			return View();
		}
		[HttpPost]
		public IActionResult addfeedback(feedback feedback_)
		{
			_mycontext.tbl_feedback.Add(feedback_);
			_mycontext.SaveChanges();
			return RedirectToAction("showfeedback");
		}
		public IActionResult showfeedback()
		{
			var row=_mycontext.tbl_feedback.ToList();
			return View(row);
		}
		public IActionResult detailfeedback(int id)
		{
		var row = _mycontext.tbl_feedback.FirstOrDefault(a => a.feedback_id == id);
			return View(row);
		}
		public IActionResult updatefeedback(int id)
		{
			var row=_mycontext.tbl_feedback.Find(id);
			return View(row);
		}
		[HttpPost]
		public IActionResult updatefeedback(feedback feedback__)
		{
			_mycontext.tbl_feedback.Update(feedback__);
			_mycontext.SaveChanges();
			return RedirectToAction("showfeedback");
		}
		public IActionResult deletefeedback(int id)
		{
			var row = _mycontext.tbl_feedback.Find(id);
			_mycontext.tbl_feedback.Remove(row);
			_mycontext.SaveChanges();
			return RedirectToAction("showfeedback");
		}
		public IActionResult addcatmed()
		{
			return View();
		}
		[HttpPost]
		public IActionResult addcatmed(medicinecategory medcat, IFormFile medicinecat_image)
		{
			string filename = Path.GetFileName(medicinecat_image.FileName);
			string filepath = Path.Combine(_env.WebRootPath, "catmedimages", filename);
			FileStream fs = new FileStream(filepath, FileMode.Create);
			medicinecat_image.CopyTo(fs);
			medcat.medicinecat_image = medicinecat_image.FileName;
			_mycontext.tbl_medicinecateogry.Add(medcat);
			_mycontext.SaveChanges();
			return RedirectToAction("showcatmed");
		}
		public IActionResult showcatmed()
		{
			var row = _mycontext.tbl_medicinecateogry.ToList();
			return View(row);
		}
		public IActionResult updatecatmed(int id)
		{
			var row = _mycontext.tbl_medicinecateogry.Find(id);
			return View(row);
		}
		[HttpPost]
		public IActionResult updatecatmed(medicinecategory catmed_, IFormFile medicinecat_image)
		{
            string filename = Path.GetFileName(medicinecat_image.FileName);
            string filepath = Path.Combine(_env.WebRootPath, "catmedimages", filename);
            FileStream fs = new FileStream(filepath, FileMode.Create);
            medicinecat_image.CopyTo(fs);
            catmed_.medicinecat_image = medicinecat_image.FileName;
            _mycontext.tbl_medicinecateogry.Update(catmed_);
            _mycontext.SaveChanges();
            return RedirectToAction("showcatmed");
        }
		public IActionResult deletecatmed(int id)
		{
            var row = _mycontext.tbl_medicinecateogry.Find(id);
            _mycontext.tbl_medicinecateogry.Remove(row);
            _mycontext.SaveChanges();
            return RedirectToAction("showcatmed");
        }
		public IActionResult addmed()
		{
			List<medicinecategory> categories = _mycontext.tbl_medicinecateogry.ToList();
			ViewData["category"] = categories;
			return View();
		}
		[HttpPost]
		public IActionResult addmed(medicines med, IFormFile med_image)
		{
            string filename = Path.GetFileName(med_image.FileName);
            string filepath = Path.Combine(_env.WebRootPath, "medimages", filename);
            FileStream fs = new FileStream(filepath, FileMode.Create);
            med_image.CopyTo(fs);
            med.med_image = med_image.FileName;
            _mycontext.tbl_medicines.Add(med);
            _mycontext.SaveChanges();
            return RedirectToAction("showmed");
        }
		public IActionResult showmed()
		{
			var row =_mycontext.tbl_medicines.ToList();
			return View(row);
		}
		public IActionResult detailmed(int id)
		{
			var row = _mycontext.tbl_medicines.FirstOrDefault(a => a.med_id == id);
			return View(row);
		}
		public IActionResult updatemed(int id)
		{
            List<medicinecategory> categories = _mycontext.tbl_medicinecateogry.ToList();
            ViewData["category"] = categories;
            var row = _mycontext.tbl_medicines.Find(id);
			return View(row);
		}
		[HttpPost]
		public IActionResult updatemed(medicines med_, IFormFile med_image)
		{
            string filename = Path.GetFileName(med_image.FileName);
            string filepath = Path.Combine(_env.WebRootPath, "medimages", filename);
            FileStream fs = new FileStream(filepath, FileMode.Create);
            med_image.CopyTo(fs);
            med_.med_image = med_image.FileName;
            _mycontext.tbl_medicines.Update(med_);
            _mycontext.SaveChanges();
            return RedirectToAction("showmed");
        }
		public IActionResult deletemed(int id)
		{
            var row = _mycontext.tbl_medicines.Find(id);
            _mycontext.tbl_medicines.Remove(row);
            _mycontext.SaveChanges();
            return RedirectToAction("showmed");
        }

		public IActionResult addbusiness()
		{
			return View();
		}
		[HttpPost]
		public IActionResult addbusiness(bussinesstransaction buss)
		{
			_mycontext.tbl_bussinesstransaction.Add(buss);
            _mycontext.SaveChanges();
            return RedirectToAction("showbusiness");
        }
        public IActionResult showbusiness()
        {
            var row = _mycontext.tbl_bussinesstransaction.ToList();
            return View(row);
        }
		public IActionResult updatebusiness(int id)
		{
			var row = _mycontext.tbl_bussinesstransaction.Find(id);
			return View(row);
		}
		[HttpPost]
		public IActionResult updatebusiness(bussinesstransaction buss_)
		{
			_mycontext.tbl_bussinesstransaction.Update(buss_);
			_mycontext.SaveChanges();
			return RedirectToAction("showbusiness");
		}
		public IActionResult deletebusiness(int id)
		{
			var row = _mycontext.tbl_bussinesstransaction.Find(id);
			_mycontext.tbl_bussinesstransaction.Remove(row);
			_mycontext.SaveChanges();
			return RedirectToAction("showbusiness");
		}
		public IActionResult gallery()
		{
			return View();
		}
		[HttpPost]
		public IActionResult gallery(clinicgallery gall, IFormFile gallery_img)
		{
			string filename = Path.GetFileName(gallery_img.FileName);
			string filepath = Path.Combine(_env.WebRootPath, "gallery", filename);
			FileStream fs = new FileStream(filepath,FileMode.Create);
			gallery_img.CopyTo(fs);
			gall.gallery_img = gallery_img.FileName;
			_mycontext.tbl_gallery.Add(gall);
			_mycontext.SaveChanges();
			return RedirectToAction("showgallery");
		}
		public IActionResult showgallery()
		{
			var row = _mycontext.tbl_gallery.ToList();
			return View(row);
		}
		public IActionResult deletegallery(int id)
		{
			var row = _mycontext.tbl_gallery.Find(id);
			_mycontext.tbl_gallery.Remove(row);
			_mycontext.SaveChanges();
			return RedirectToAction("showgallery");
		}
		public IActionResult teacherimg()
		{
			return View();
		}
        [HttpPost]
        public IActionResult teacherimg(teachers teacher, IFormFile teacher_img)
        {
            string filename = Path.GetFileName(teacher_img.FileName);
            string filepath = Path.Combine(_env.WebRootPath, "teacherimg", filename);
            FileStream fs = new FileStream(filepath, FileMode.Create);
            teacher_img.CopyTo(fs);
            teacher.teacher_img = teacher_img.FileName;
            _mycontext.tbl_teacher.Add(teacher);
            _mycontext.SaveChanges();
            return RedirectToAction("showteacher");
        }
		public IActionResult showteacher()
		{
			var row =_mycontext.tbl_teacher.ToList();
			return View(row);
		}
		public IActionResult deleteteacher(int id)
		{
			var row=_mycontext.tbl_teacher.Find(id);
			_mycontext.tbl_teacher.Remove(row);
			_mycontext.SaveChanges();
			return RedirectToAction("showteacher");
		}
		public IActionResult updateteacher(int id)
		{
			var row = _mycontext.tbl_teacher.Find(id);
			return View(row);
		}
		[HttpPost]
		public IActionResult updateteacher(IFormFile teacher_img, teachers teacher)
		{
            string filename = Path.GetFileName(teacher_img.FileName);
            string filepath = Path.Combine(_env.WebRootPath, "teacherimg", filename);
            FileStream fs = new FileStream(filepath, FileMode.Create);
            teacher_img.CopyTo(fs);
            teacher.teacher_img = teacher_img.FileName;
            _mycontext.tbl_teacher.Update(teacher);
            _mycontext.SaveChanges();
            return RedirectToAction("showteacher");
        }
		public IActionResult scitwo()
		{
			return View();
		}
		[HttpPost]
		public IActionResult scitwo(scitwo two, IFormFile two_img)
		{
            string filename = Path.GetFileName(two_img.FileName);
            string filepath = Path.Combine(_env.WebRootPath, "medimages", filename);
            FileStream fs = new FileStream(filepath, FileMode.Create);
            two_img.CopyTo(fs);
            two.two_img = two_img.FileName;
            _mycontext.tbl_scitwo.Add(two);
            _mycontext.SaveChanges();
            return RedirectToAction("showscitwo");
        }
		public IActionResult showscitwo()
		{
			var row = _mycontext.tbl_scitwo.ToList();
			return View(row);
		}
		
		public IActionResult deletescitwo(int id)
		{
			var row = _mycontext.tbl_scitwo.Find(id);
			_mycontext.tbl_scitwo.Remove(row);
			_mycontext.SaveChanges();
			return RedirectToAction("showscitwo");
		}
		public IActionResult updatescitwo(int id)
		{
			var row = _mycontext.tbl_scitwo.Find(id);
			return View(row);
		}
		[HttpPost]
		public IActionResult updatescitwo(scitwo sci, IFormFile two_img)
		{
            string filename = Path.GetFileName(two_img.FileName);
            string filepath = Path.Combine(_env.WebRootPath, "medimages", filename);
            FileStream fs = new FileStream(filepath, FileMode.Create);
            two_img.CopyTo(fs);
            sci.two_img = two_img.FileName;
            _mycontext.tbl_scitwo.Update(sci);
			_mycontext.SaveChanges();
			return RedirectToAction("showscitwo");
		}
		public IActionResult detailscitwo(int id)
		{
			var row = _mycontext.tbl_scitwo.FirstOrDefault(a => a.two_id == id);
			return View(row);
		}
		public IActionResult contact()
		{
			return View();
		}
		[HttpPost]
		public IActionResult contact(contact con)
		{
			_mycontext.tbl_contact.Add(con);
			_mycontext.SaveChanges();
			return RedirectToAction("showcontact");
		}
		public IActionResult showcontact()
		{
			var row = _mycontext.tbl_contact.ToList();
			return View(row);
		}
		public IActionResult deletecontact(int id)
		{
			var row = _mycontext.tbl_contact.Find(id);
			_mycontext.tbl_contact.Remove(row);
			_mycontext.SaveChanges();
			return RedirectToAction("showcontact");
		}
		public IActionResult showaddtocart()
		{
			var row = _mycontext.tbl_cart.ToList();
			return View(row);
			
		}
		public IActionResult deletecart(int id)
		{
			var row = _mycontext.tbl_cart.Find(id);
			_mycontext.tbl_cart.Remove(row);
			_mycontext.SaveChanges();
			return RedirectToAction("showaddtocart");
		}
		

    }
}
