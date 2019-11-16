using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet_5780_02_6789_1947
{
    public class GuestRequest
    {
        
        public DateTime Release_Date { get => Release_Date; /*set => Release_Date = Convert.ToDateTime(Console.ReadLine()); */}
        public DateTime Entry_Date { get =>Entry_Date;  }
        public bool IsApproved { get; set; }
        override public string ToString()
        {
            string result = "";
            result += Convert.ToString(Entry_Date)+" "+ Convert.ToString(Entry_Date)+ " " + Convert.ToString(IsApproved);
            return result;
        }
    }
}
