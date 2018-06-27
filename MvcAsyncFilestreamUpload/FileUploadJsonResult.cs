using System.Web.Mvc;

namespace MvcAsyncFilestreamUpload
{
    public sealed class FileUploadJsonResult :
        JsonResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            ContentType = "text/html";
            base.ExecuteResult(context);
        }
    }
}