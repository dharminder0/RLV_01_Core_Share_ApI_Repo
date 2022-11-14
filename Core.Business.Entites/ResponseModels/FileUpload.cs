using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Entites.ResponseModels {
    public class FileUpload {
        public string FileName { get; set; }
        public string FileIdentifier { get; set; }
        public string FileLink { get; set; }
    }
}
