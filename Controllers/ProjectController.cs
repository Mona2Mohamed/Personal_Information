using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Project5.Models;
namespace Project5.Controllers
{
    public class ProjectController : Controller
    {
        Project5Model1 db = new Project5Model1();
        // GET: Project

        public ActionResult Adddata()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ViewData(Personal_Information ps, HttpPostedFileBase file)
        {
            Personal_Information di = new Personal_Information();
            string path = Uploadimage(file);
            if (path.Equals("-1"))
            {

            }
            else
            {
                di.First_Name = ps.First_Name;
                di.Last_Name_ = ps.Last_Name_;
                di.National_Id_ = ps.National_Id_;
                di.Phone_Number_ = ps.Phone_Number_;
                di.ImagePath = path;
                di.Email = ps.Email;
                db.Personal_Information.Add(di);
                db.SaveChanges();
                ViewBag.msg = "data added....";
            }

            return RedirectToAction("Index");
        }
        public string Uploadimage(HttpPostedFileBase file)
        {
            Random r = new Random();
            string path = "-1";
            int random = r.Next();
            if (file != null && file.ContentLength > 0)
            {
                string extension = Path.GetExtension(file.FileName);
                if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".png") || extension.ToLower().Equals(".jfif") || extension.ToLower().Equals(".jepg"))
                {
                    try
                    {
                        path = Path.Combine(Server.MapPath("~/Content/img"), random + Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        path = "~/Content/img" + random + Path.GetFileName(file.FileName);
                        ViewBag.Message = "File uploaded successfully";

                    }
                    catch (Exception ex)
                    {
                        path = "-1";
                    }
                }
                else
                {
                    Response.Write("<script>alter('Only jpg , jepg Or png format are acceptable.... ');</script>");
                }
            }
            else
            {
                Response.Write("<script>alter('please select a file.... ');</script>");
                path = "-1";
            }


            return path;
        }


        public ActionResult Index()
        {
            var data= db.Personal_Information.ToList();
            return View(data);
        }
    }
}