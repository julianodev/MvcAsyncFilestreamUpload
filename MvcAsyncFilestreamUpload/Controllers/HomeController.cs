using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using MvcAsyncFilestreamUpload.Models;

namespace MvcAsyncFilestreamUpload.Controllers
{
    public class HomeController : Controller
    {
        public static List<DocumentModel> Docs = new List<DocumentModel>();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetFileAsync(int id)
        {
            // get your file from the database asnyc...
            return View();
        }

        public JsonResult AjaxUpload(
            HttpPostedFileBase file)
        {
            if (file != null && !string.IsNullOrEmpty(file.FileName))
            {
                // here you can save your file to the database...
                var doc = new DocumentModel
                {
                    Id = Docs.Count + 1,
                    DocumentName = file.FileName,
                    RecievedDate = DateTime.Now,
                    UploadDate = DateTime.Now
                };
                Docs.Add(doc);
            }

            if (file == null)
                return new JsonResult
                {
                    Data = new
                    {
                        message = "FileUploadJsonResultMessage"
                    }
                };

            return Json(new
            {
                data = new
                {
                    message = System.IO.Path.GetFileName(file.FileName),
                    date = DateTime.Now
                }
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UploadForm()
        {
            var model = new UploadModel
            {
                Documents = Docs
            };

            return PartialView("UploadForm", model);
        }
    }
}
