using System.Collections.Generic;

namespace MvcAsyncFilestreamUpload.Models
{
    public sealed class UploadModel
    {
        public IEnumerable<DocumentModel> Documents { get; set; }
    }
}