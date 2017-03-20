using System;

namespace WebCamApplication.Models
{
    public class DrawingModel
    {
        public string imageData { get; set; }
        public string Email { get; set; }
        public string Save { get; set; }
        public string EmailAddress { get; set; }
        public string FileName { get; set; }
        public bool IsPublished { get; set; }
        public string UserName { get; set; }
        public int ViewCount { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}