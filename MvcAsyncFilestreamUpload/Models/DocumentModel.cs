using System;

namespace MvcAsyncFilestreamUpload.Models
{
    public sealed class DocumentModel
    {
        public int Id { get; set; }

        public string DocumentName { get; set; }

        public DateTime RecievedDate { get; set; }

        public DateTime UploadDate { get; set; }

        public bool IsChecked { get; set; }
    }
}