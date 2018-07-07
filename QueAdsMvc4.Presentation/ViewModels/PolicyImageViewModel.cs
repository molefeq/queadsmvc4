using System;

namespace QueAdsMvc4.Presentation.ViewModels
{
    public class PolicyImageViewModel
    {
        public int Id { get; set; }
        public int Policy_Id { get; set; }
        public string ImageFileName { get; set; }
        public string ThumbnailImageUrl { get; set; }
        public string NormalImageUrl { get; set; }
        public string PreviewImageUrl { get; set; }
        public int CreateUser_Id { get; set; }
        public string CreateDate { get; set; }
        public string EditDate { get; set; }
    }
}
