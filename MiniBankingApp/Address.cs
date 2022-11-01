using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankingApp
{
    public class Address
    {
        public int StreetNo { get; set; }
        public string StreetName { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public static bool operator ==(Address a, Address b)
        {
            if (a.StreetNo == b.StreetNo && a.StreetName == b.StreetName && a.ZipCode == b.ZipCode
                && a.City == b.City && a.State == b.State)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Address a, Address b)
        {
            if (a.StreetNo != b.StreetNo || a.StreetName != b.StreetName || a.ZipCode != b.ZipCode
                || a.City != b.City || a.State != b.State)
            {
                return true;
            }
            return false;
        }

        public static Address operator +(Address a, Address b)
        {
            return new Address();
        }

        public override string ToString()
        {
            return $"{StreetNo} {StreetName} street, {City}, {State} state.";
        }

        public override bool Equals(object? obj)
        {
            if(obj.GetType() != typeof(Address))
            {
                return false;
            }
            if (this.StreetNo == ((Address)obj).StreetNo && this.StreetName == ((Address)obj).StreetName && this.ZipCode == ((Address)obj).ZipCode
                && this.City == ((Address)obj).City && this.State == ((Address)obj).State)
            {
                return true;
            }
            return false;
        }
    }
}
