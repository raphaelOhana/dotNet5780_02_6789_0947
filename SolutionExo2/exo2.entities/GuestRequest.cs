using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet_5780_02_6789_0947
{
    public class GuestRequest
    {
        
        public DateTime Entry_Date { get;set;}//date de debut 
        public DateTime Release_Date { get;set;}//date de fin

        public bool IsApproved;//a initianiliser apres verification de la fonction de host
        override public string ToString()
        {
            string result = "";
            result += Convert.ToString(Entry_Date)+"\t"
                + Convert.ToString(Release_Date)+ "\t" 
                + Convert.ToString(IsApproved)+"\n";
            return result;
        }
    }
}
