﻿using FiorelloP416app.ModelViews.AdminSlider;
using Microsoft.AspNetCore.Hosting;

namespace FiorelloP416app.Extension
{
    public static class FileExtension
    {
        public static bool CheckImage(this IFormFile file)
        {
            return file.ContentType.Contains("image/");
        }
        public static bool CheckImageSize(this IFormFile file, int size)
        {
            return file.Length / 1024 > size;
        }
        public static string SaveImage(this IFormFile file, string folder, IWebHostEnvironment webHostEnvironment)
        {
            string filename = Guid.NewGuid() + file.FileName;
            string path = Path.Combine(webHostEnvironment.WebRootPath, folder, filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return filename;
        }
    }
}
