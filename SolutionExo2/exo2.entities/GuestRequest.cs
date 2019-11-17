using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet_5780_02_6789_0947
{
    public class GuestRequest
    {
        
        public DateTime Release_Date { get => Release_Date; } //date de fin 
        public DateTime Entry_Date { get =>Entry_Date;  } //date de debut
        public bool IsApproved ;//a initialiser apres verification de la foncion de host 
        override public string ToString()
        {
            string result = "";
            result += Convert.ToString(Entry_Date)+"\t"+ Convert.ToString(Release_Date)+ "\t" + Convert.ToString(IsApproved) +"\n";
            return result;
        }
    }
}
