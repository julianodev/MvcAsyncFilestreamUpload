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

        public ActionResult Index() => View();

        public FileUploadJsonResult AjaxUpload(
            HttpPostedFileBase file)
        {
            if (file != null && !string.IsNullOrEmpty(file.FileName))
            {
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
                return new FileUploadJsonResult
                {
                    Data = new
                    {
                        message = "FileUploadJsonResultMessage"
                    }
                };

            return new FileUploadJsonResult
            {
                Data = new
                {
                    message = System.IO.Path.GetFileName(file.FileName),
                    date = DateTime.Now
                }
            };
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
