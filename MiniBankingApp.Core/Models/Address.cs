using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankingApp.Core.Models
{
    public class Address : BaseEntity
    {
        public int StreetNo { get; set; }
        public string StreetName { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
