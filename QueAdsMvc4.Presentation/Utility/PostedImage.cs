using System.Collections.Generic;
using System.Web;

namespace QueAdsMvc4.Presentation.Utility
{
    public class PostedImage
    {
        public HttpPostedFileBase AdImage { get; set; }
        public HttpPostedFile PostedAdImage { get; set; }
        public string AdImageFileName { get; set; }
        public string FileName { get; set; }
        public List<AdImageInformation> AdImageInformations { get; set; }
    }
}
