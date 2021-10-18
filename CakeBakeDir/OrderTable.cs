using System;
using System.Collections.Generic;

#nullable disable

namespace CakeBake.CakeBakeDir
{
    public partial class OrderTable
    {
        public int OrderId { get; set; }
        public string Username { get; set; }
        public string Uaddress { get; set; }
        public double Price { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}
