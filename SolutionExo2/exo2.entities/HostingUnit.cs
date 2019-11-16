using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet_5780_02_6789_0947
{
    /*a utiliser si besoin*/
    enum Mounth { January = 1, February, March, April, May, June, July, August, September, October, November, December }

    public class HostingUnit:IComparable<HostingUnit>
    {
        /*variable*/
        public readonly  int HostingUnitKey;/*id hotel*/
        static public int stSerialKey = 10000000;
        public bool[,] Diary = new bool[12, 31];
        /*ctor*/
        public HostingUnit()
        {
            HostingUnitKey = stSerialKey++;
        }

        // fonction en plus 
        int NbTotalDaysReservation(GuestRequest X)
        {
            return X.Release_Date.Day - X.Entry_Date.Day + (X.Release_Date.Month - X.Entry_Date.Month) * 31;
        }
        static int count(bool[,] tab, bool flag, int days, int mounth, int nbOfDays)
        {
            int count = 0;
            for (int i = 0, j = mounth, k = days; (i < nbOfDays); i++, k++)
            {

                if (k > 31)
                {
                    j++;
                    k = 1;
                }
                if (tab[j - 1, k - 1] == flag) //false = jour libre 
                    count++;                 // verifie si tt les jours sont libre 
            }
            return count;
        }

        //all fonction
        public override string ToString()
        {
            string ListOfBusy = "";
            bool busy = false;
            for (int i = 0, j = 1, k = 1; i < 372; i++, k++)
            {
                if (k > 31)
                {
                    j++;
                    k = 1;
                }
                if ((Diary[j - 1, k - 1] == true) && (busy == false)) //ca veut dire si c'est le premier d une liste de jour prit 
                {
                    ListOfBusy+= Convert.ToString( k)+ " " + Convert.ToString((Mounth)j)+ " -> "; 
                    busy = true;
                }
                if ((Diary[j - 1, k - 1] == false) && (busy == true))//ca veut dire si c'est le dernier d une liste de jour prit
                {
                   ListOfBusy += Convert.ToString( k) + Convert.ToString((Mounth)j)+ "\n";
                    busy = false;
                }
            }
            return ListOfBusy;
        }
        public bool ApproveRequest(GuestRequest guestReq)
        {
            int mounth = guestReq.Entry_Date.Month;
            int day = guestReq.Entry_Date.Day;
            int nbOfDays = NbTotalDaysReservation(guestReq);
;
            if (count(Diary, false, day,mounth , nbOfDays - 1) == nbOfDays - 1) //si tout les jour demander sont libres(sans m interesser au premier jour)
            {
                for (int i = 0, j = mounth, k = day; i < nbOfDays; i++, k++)
                {
                    if (k > 31)
                    {
                        j++;
                        k = 1;
                    }
                    Diary[j - 1, k - 1] = true; //ecrit quil sont occupé 
                }
                guestReq.IsApproved = true;
                return true;
            }
            else
            {
                guestReq.IsApproved =false;
                return false;
            }
        }
        public int GetAnnualBusyDays()
        {
            return count(Diary, true, 1, 1, 372);
        }
        public float GetAnnualBusyPercentage()
        {
            return (100 * GetAnnualBusyDays() / 372);
        }

        public int CompareTo(HostingUnit other)
        {
            if(this.GetAnnualBusyDays()<other.GetAnnualBusyDays())// plus libre 
                 return -1;
            if(this.GetAnnualBusyDays()>other.GetAnnualBusyDays())//moin libre 
                return 1;
            return 0;//pareille
        }
    }

}
