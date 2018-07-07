using QueAds.Common.Utilities;

using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace QueAdsMvc4.Presentation.Utility
{
    public class PostedImageHandler
    {
        public static string SaveAdUploadedImages(HttpPostedFile postedAdImage, List<AdImageInformation> adImageInformations)
        {
            if (postedAdImage == null)
            {
                return null;
            }

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(postedAdImage.FileName);

            foreach (AdImageInformation adImageInformation in adImageInformations)
            {
                SaveAdUploadedImage(postedAdImage, fileName, adImageInformation);
            }

            return fileName;
        }

        public static void SaveAdUploadedImages(PostedImage postedImage)
        {
            if (postedImage.AdImage == null)
            {
                return;
            }

            postedImage.FileName = Guid.NewGuid().ToString() + Path.GetExtension(postedImage.AdImage.FileName);

            foreach (AdImageInformation adImageInformation in postedImage.AdImageInformations)
            {
                SaveAdUploadedImage(postedImage.AdImage, postedImage.FileName, adImageInformation);
            }
        }

        public static void SaveAdUploadedImage(HttpPostedFile adImage, string fileName, AdImageInformation adImageInformation)
        {
            if (adImage == null)
            {
                return;
            }

            adImageInformation.PhysicalFileName = GetPhysicalFileName(adImageInformation.PhysicalDirectory, fileName);
            adImageInformation.RelativeFileName = GetRelativeFileName(adImageInformation.RelativeDirectory, fileName);

            adImage.SaveAs(adImageInformation.PhysicalFileName);
            ResizeImage(adImageInformation);
        }

        public static void SaveAdUploadedImage(HttpPostedFileBase adImage, string fileName, AdImageInformation adImageInformation)
        {
            if (adImage == null)
            {
                return;
            }

            adImageInformation.PhysicalFileName = GetPhysicalFileName(adImageInformation.PhysicalDirectory, fileName);
            adImageInformation.RelativeFileName = GetRelativeFileName(adImageInformation.RelativeDirectory, fileName);

            adImage.SaveAs(adImageInformation.PhysicalFileName);
            ResizeImage(adImageInformation);
        }

        public static void ResizeImage(string imageFileName, string fileName, AdImageInformation adImageInformation)
        {
            adImageInformation.PhysicalFileName = GetPhysicalFileName(adImageInformation.PhysicalDirectory, fileName);
            ImageResizer imageResizer = new ImageResizer(imageFileName, adImageInformation.PhysicalFileName, adImageInformation.Width, adImageInformation.Height);
            imageResizer.ResizeImage();
        }

        public static void ResizeImage(AdImageInformation adImageInformation)
        {
            ImageResizer imageResizer = new ImageResizer(adImageInformation.PhysicalFileName, adImageInformation.PhysicalFileName, adImageInformation.Width, adImageInformation.Height);
            imageResizer.ResizeImage();
        }

        public static string GetPhysicalFileName(string directory, string fileName, string fileSuffix = "")
        {
            if (string.IsNullOrEmpty(fileSuffix))
            {
                return Path.Combine(directory, fileName);
            }

            return Path.Combine(directory, Path.GetFileNameWithoutExtension(fileName) + "_" + fileSuffix + Path.GetExtension(fileName));
        }

        public static string GetRelativeFileName(string virtualDirectory, string fileName, string fileSuffix = "")
        {
            if (string.IsNullOrEmpty(fileSuffix))
            {
                return Path.Combine(virtualDirectory, fileName);
            }

            return Path.Combine(virtualDirectory, Path.GetFileNameWithoutExtension(fileName) + "_" + fileSuffix + Path.GetExtension(fileName));
        }

        public static string GetExistingRelativeFileName(string physicalDirectory, string virtualDirectory, string fileName, string fileSuffix = "")
        {
            string physicalFileName = GetPhysicalFileName(physicalDirectory, fileName, fileSuffix);

            if (!File.Exists(physicalFileName))
            {
                return "";
            }

            return GetRelativeFileName(virtualDirectory, fileName, fileSuffix);
        }
    }
}
