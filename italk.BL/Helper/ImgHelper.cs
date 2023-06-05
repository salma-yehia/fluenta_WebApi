using Microsoft.AspNetCore.Http;
using System;
using System.Runtime.InteropServices;

namespace italk.BL.Helper
{
    public static class ImgHelper
    {
        public static async Task<string> UploadImg(IFormFile stdimg)
        {
            if (stdimg != null)
            {
                string imgname = Guid.NewGuid() + "." + stdimg.FileName.Split(".").Last();
                using (var obj = new FileStream(@".\images\" + imgname, FileMode.Create))
                {
                    await stdimg.CopyToAsync(obj);

                    return imgname;
                }
            }

            return null; 
        }
    }
}
