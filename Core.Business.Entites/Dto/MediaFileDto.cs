using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Entites.Dto
{
    public class MediaFileDto
    {
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public string? FileType { get; set; }
    }
}
