using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Archive_of_views.Models;
using System.IO;

namespace Archive_of_views.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            
            try
            {
                var check_id = System.Web.HttpContext.Current.User.Identity.GetUserId();
                if (check_id == null)
                    throw new Exception();
                return RedirectToAction("Personal_record","Home");
            }
            catch
            {

            }

            return View();
        }
        public ActionResult Personal_record(string id)
        {
            
            id = string.IsNullOrEmpty(id) ? System.Web.HttpContext.Current.User.Identity.GetUserId() : id;
            var res = new Person(db.Users.First(x1=>x1.Id==id));
            {
                var bk = db.Books.Where(x1 => x1.Person_id == id).ToList();
                if(bk!=null)
                    res.Books.AddRange(bk);
                var f = db.Films.Where(x1 => x1.Person_id == id).ToList();
                if (f != null)
                    res.Films.AddRange(f);
                var s = db.Series.Where(x1 => x1.Person_id == id).ToList();
                if (s != null)
                    res.Series.AddRange(s);
            }
            
            
            
            return View(res);
        }
        public ActionResult Edit_personal_record()
        {
            
            string check_id=System.Web.HttpContext.Current.User.Identity.GetUserId();
            var res = db.Users.First(x1 => x1.Id == check_id);
            return View();
        }

        public ActionResult List(string person_id,string what,string search)//string поменять на класс srch  идописать функцию под сортировку
        {
            ViewBag.person_id = person_id;
            ViewBag.what = what;
            /*var res = new List<List_view_all>();
            person_id = string.IsNullOrEmpty(person_id) ? System.Web.HttpContext.Current.User.Identity.GetUserId() : person_id;
            //var check_id = ;
            switch (what)
            {
                case "Film":
                    {
                        var not_res = db.Films.Where(x1=>x1.Person_id== person_id);
                        foreach(var i in not_res)
                        {
                            res.Add(new List_view_all(i));
                        }
                    }
                    break;
                case "Series":
                    {
                        var not_res = db.Series.Where(x1 => x1.Person_id == person_id);
                       
                        foreach (var i in not_res)
                        {
                            res.Add(new List_view_all(i));
                        }
                    }
                    break;
                case "Book":
                    {
                        var not_res = db.Books.Where(x1 => x1.Person_id == person_id);
                        foreach (var i in not_res)
                        {
                            res.Add(new List_view_all(i));
                        }
                    }
                    break;
                default:
                    {
                        //выгрузить все , склеить и вернуть
                    }
                    break;
            }
            */





            return View();
        }
        public ActionResult Film_view(string id)
        {
            int int_id = Convert.ToInt32(id);
            var res = db.Films.First(x1=>x1.Id== int_id);


            return View(res);
        }
        public ActionResult Series_view(string id)
        {
            int int_id = Convert.ToInt32(id);
            var res = db.Series.First(x1 => x1.Id == int_id);


            return View(res);
        }
        public ActionResult Book_view(string id)
        {
            int int_id = Convert.ToInt32(id);
            var res = db.Books.First(x1 => x1.Id == int_id);


            return View(res);
        }
        //add----------------------------------------------------------------------------------------------

        public ActionResult Add_film()
        {
            var res = new Film();


            return View(res);
        }
        [HttpPost]
        public ActionResult Add_film(HttpPostedFileBase[] uploadImage, Film a)
        {
            string check_id = System.Web.HttpContext.Current.User.Identity.GetUserId();
            a.Image = Get_photo_post(uploadImage)[0];
            a.Person_id = check_id;
            db.Films.Add(a);
            db.SaveChanges();

            return RedirectToAction("Film_view",new {id=a.Id });
        }
        public ActionResult Add_series()
        {
            var res = new Series();


            return View(res);
        }
        [HttpPost]
        public ActionResult Add_series(HttpPostedFileBase[] uploadImage, Series a)
        {
            string check_id = System.Web.HttpContext.Current.User.Identity.GetUserId();
            a.Image = Get_photo_post(uploadImage)[0];
            a.Person_id = check_id;
            db.Series.Add(a);
            db.SaveChanges();

            return RedirectToAction("Series_view", new { id = a.Id });


            
        }
        public ActionResult Add_season()
        {
            var res = new Season();


            return View(res);
        }
        [HttpPost]
        public ActionResult Add_season( Season a)
        {
            var res = new Season();


            return View(res);
        }
        public ActionResult Add_book()
        {
            var res = new Book();


            return View(res);
        }
        [HttpPost]
        public ActionResult Add_book(HttpPostedFileBase[] uploadImage, Book a)
        {
            string check_id = System.Web.HttpContext.Current.User.Identity.GetUserId();
            a.Image = Get_photo_post(uploadImage)[0];
            a.Person_id = check_id;
            db.Books.Add(a);
            db.SaveChanges();

            return RedirectToAction("Book_view", new { id = a.Id });


            
        }

        //edit--------------------------------------------------------------------------------------------------
        public ActionResult Edit_film(string id)
        {

            var check_id = System.Web.HttpContext.Current.User.Identity.GetUserId();
            ViewBag.person_id = check_id;
            if (!string.IsNullOrEmpty(id))
            {
                int int_id = Convert.ToInt32(id);
                var res = db.Films.FirstOrDefault(x1 => x1.Id == int_id && x1.Person_id == check_id);
                ViewBag.page = res;
               
            }
            


            return View();
        }
        //TODO см Edit_film
        public ActionResult Edit_series(string id)
        {
            var check_id = System.Web.HttpContext.Current.User.Identity.GetUserId();
            ViewBag.person_id = check_id;
            if (!string.IsNullOrEmpty(id))
            {
                int int_id = Convert.ToInt32(id);
                var res = db.Series.FirstOrDefault(x1 => x1.Id == int_id && x1.Person_id == check_id);
                ViewBag.page = res;
               
            }
            


            return View();
        }
        //TODO см Edit_film
        public ActionResult Edit_season(string id)
        {
            var res = new Season();


            return View(res);
        }
        //TODO см Edit_film
        public ActionResult Edit_book(string id)
        {
            var check_id = System.Web.HttpContext.Current.User.Identity.GetUserId();
            ViewBag.person_id = check_id;
            if (!string.IsNullOrEmpty(id))
            {
                int int_id = Convert.ToInt32(id);
                var res = db.Books.FirstOrDefault(x1 => x1.Id == int_id && x1.Person_id == check_id);
                ViewBag.page = res;
                
            }
            
            return View();
        }
        //delete
        public ActionResult Delete(string id,string what)
        {
            var check_id = System.Web.HttpContext.Current.User.Identity.GetUserId();
            switch (what)
            {
                case "Film":
                    {
                        int int_id = Convert.ToInt32(id);
                        var del=db.Films.FirstOrDefault(x1 => x1.Id == int_id && x1.Person_id == check_id);
                        if (del != null)
                        {
                            db.Films.Remove(del);
                        }
                    }
                    break;
                case "Series":
                    {
                        int int_id = Convert.ToInt32(id);
                        var del = db.Series.FirstOrDefault(x1 => x1.Id == int_id && x1.Person_id == check_id);
                        if (del != null)
                        {
                            db.Series.Remove(del);
                            db.Seasons.RemoveRange(db.Seasons.Where(x1 => x1.Series_id == int_id&&x1.Person_id==check_id));
                        }
                        
                    }
                    break;
                case "Book":
                    {
                        int int_id = Convert.ToInt32(id);
                        var del = db.Books.FirstOrDefault(x1 => x1.Id == int_id && x1.Person_id == check_id);
                        if (del != null)
                        {
                            db.Books.Remove(del);
                        }
                    }
                    break;
                case "Season":
                    {
                        int int_id = Convert.ToInt32(id);
                        var del = db.Seasons.FirstOrDefault(x1 => x1.Id == int_id && x1.Person_id == check_id);
                        if (del != null)
                        {
                            db.Seasons.Remove(del);
                        }
                    }
                    break;
                default:
                    {
                        //выгрузить все , склеить и вернуть
                    }
                    break;
            }


            return View();
        }







        [ChildActionOnly]
        public ActionResult Main_header()
        {
            
                var check_id = System.Web.HttpContext.Current.User.Identity.GetUserId();
            ViewBag.My_id = check_id;
            


            return PartialView();
        }

        
        public ActionResult List_view_partial(string what,string id,string mode)
        {
            ViewBag.mode = mode;
            var check_id = System.Web.HttpContext.Current.User.Identity.GetUserId();
            if ((mode.IndexOf("Edit") != -1)|| string.IsNullOrEmpty(id))
                id = check_id;
            //if (string.IsNullOrEmpty(id))
                //id = check_id;




            switch (what)
            {
                case "Film":
                    {
                        
                        
                            var res = new List<List_view_all>();
                            var not_res = db.Films.Where(x1 => x1.Person_id == id);
                            foreach (var i in not_res)
                            {
                                res.Add(new List_view_all(i));
                            }
                            ViewBag.list = res;
                            
                        
                    }
                    break;
                case "Series":
                    {
                       
                            var res = new List<List_view_all>();
                            var not_res = db.Series.Where(x1 => x1.Person_id == id);
                            foreach (var i in not_res)
                            {
                                res.Add(new List_view_all(i));
                            }
                            ViewBag.list = res;
                           
                        
                    }
                    break;
                case "Book":
                    {
                        
                            var res = new List<List_view_all>();
                            var not_res = db.Books.Where(x1 => x1.Person_id == id);
                            foreach (var i in not_res)
                            {
                                res.Add(new List_view_all(i));
                            }
                            ViewBag.list = res;
                            
                        
                    }
                    break;
            }
            



            return PartialView();
        }


        //function-----------------------------------------------------------------



        public List<byte[]> Get_photo_post(HttpPostedFileBase[] uploadImage)
        {

            /* сохранение картинок как файл ...
              HttpPostedFileBase image = Request.Files["fileInput"];
            
            if (image != null && image.ContentLength > 0 && !string.IsNullOrEmpty(image.FileName))
            {
                string fileName = image.FileName;
                image.SaveAs(Path.Combine(Server.MapPath("Images"), fileName));
            }
             
             * */
            List<byte[]> res = new List<byte[]>();
            if (uploadImage != null)
            {

                foreach (var i in uploadImage)
                {
                    try
                    {
                        byte[] imageData = null;
                        // считываем переданный файл в массив байтов
                        using (var binaryReader = new BinaryReader(i.InputStream))
                        {
                            imageData = binaryReader.ReadBytes(i.ContentLength);
                        }
                        // установка массива байтов
                        res.Add(imageData);

                    }
                    catch
                    {

                    }



                }

            }


            return res;
        }

    }
}