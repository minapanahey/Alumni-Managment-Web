using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniManagment.Services
{
    public class Picture
    {
        public async Task<string> toString(IFormFile pic)
        {
            var result = new StringBuilder();
            using (var reader = new StreamReader(pic.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    result.AppendLine(await reader.ReadLineAsync());
            }
            return result.ToString();
        }
        public void uploadPicture()
        {

        }
    }
}
