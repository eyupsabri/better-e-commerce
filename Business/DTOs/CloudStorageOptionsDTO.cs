using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class CloudStorageOptionsDTO
    {
        public string ConnectionString { get; set; }

        public string CategoryImgContainer { get; set; }
        public string ProductImgContainer { get; set; }
    }
}
