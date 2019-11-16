using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet_5780_02_6789_0947
{
    public class GuestRequest
    {
        static Random rand = new Random(DateTime.Now.Millisecond);
        public DateTime Entry_Date { get;set;}//date de debut 
        public DateTime Release_Date { get;set;}//date de fin

        public GuestRequest ()
	    {
                         /*start*/
            int  dOs,mOs,yOs;
            /*help*/ int randomStart=rand.Next(1,11);
            /*jour*/ dOs=rand.Next(1,31);
            /*mois*/ mOs=((DateTime.Today.Month+randomStart)>12)?((DateTime.Today.Month+randomStart)%12):((DateTime.Today.Month+randomStart));
            /*an*/ yOs=DateTime.Today.Year+(DateTime.Today.Month+randomStart)/12;
                        /*end*/
            int  dOe,mOe,yOe;
            /*help*/int randomDuration=rand.Next(2,10);
            /*jour*/dOe=(dOs+randomDuration>31)?((dOs+randomDuration)%31):((dOs+randomDuration));
            /*mois*/mOe=((mOs+((dOs+randomDuration)/31))>12)?((mOs+((dOs+randomDuration)/31))%12):((mOs+((dOs+randomDuration)/31)));
            /*an*/yOe= ((mOs+((dOs+randomDuration)/31))>12)?(yOs+(mOs+((dOs+randomDuration)/31))/12):(yOs);


            Entry_Date=new DateTime(yOs,mOs,dOs);
            Release_Date=new DateTime(yOe,mOe,dOe);
	    }
       /*Entry_Date.Year+((Entry_Date.Day+rand.Next(2,10))/31)/12, ((Entry_Date.Day+rand.Next(2,10))/31)%12,(Entry_Date.Day+rand.Next(2,10))%31*/
       
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
