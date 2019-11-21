using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace dotNet_5780_02_6789_0947
{

    class Program
    {
        public enum Mounth { January = 1, February, March, April, May, June, July, August, September, October, November, December }


        static Random rand = new Random(DateTime.Now.Millisecond);
        private static GuestRequest CreateRandomRequest()
        {
            GuestRequest gs = new GuestRequest();

            int my_mois= DateTime.Today.Month + rand.Next(1, 11);
            int annee = DateTime.Today.Year;
           // Mounth mois=(Mounth)my_mois;

            if (my_mois > 12)
            {
                my_mois %= 12;
                annee++;
            }
            int jourD, moisFin,jourF;
            switch (my_mois)
            {
                case 2:
                    jourD = rand.Next(1, 28);
                    gs.Entry_Date = new DateTime(annee, my_mois, jourD);
                    jourF = gs.Entry_Date.Day + rand.Next(2, 10);
                    if (jourF > 28)
                    {
                        jourF%= 28;
                       my_mois++;
                    }
                    gs.Release_Date = new DateTime(annee, my_mois, jourF);
                    break;
                case 1:
                case 3:
                case 5:
                case 7:
                case 10:
                case 8:
                case 12:
                    jourD = rand.Next(1, 31);
                    gs.Entry_Date = new DateTime(annee, my_mois, jourD);
                    jourF = gs.Entry_Date.Day + rand.Next(2, 10);
                    if (jourF > 31)
                    {
                        jourF %= 31;
                        if (++my_mois > 12)
                        {
                            my_mois %= 12;
                            annee++;
                        }
                    }
                    gs.Release_Date = new DateTime(annee, my_mois, jourF);
                    break;
                default:
                    jourD = rand.Next(1, 30);
                    gs.Entry_Date = new DateTime(annee, my_mois, jourD);
                    jourF = gs.Entry_Date.Day + rand.Next(2, 10);
                    if (jourF > 30)
                    {
                        jourF %= 28;
                        my_mois++;
                    }
                    gs.Release_Date = new DateTime(annee, my_mois, jourF);
                    break;
                
            }
             

            return gs;
        }
        static void Main(string[] args)
        {
            List<Host> lsHosts;
            lsHosts = new List<Host>()
                {
                    new Host(1, rand.Next(1,4)),
                    new Host(2, rand.Next(1,4)),
                    new Host(3, rand.Next(1,4)),
                    new Host(4, rand.Next(1,4)),
                    new Host(5, rand.Next(1,4))
                };
            GuestRequest gs1 = new GuestRequest();
            GuestRequest gs2 = new GuestRequest();
            GuestRequest gs3 = new GuestRequest();
            for (int i = 0; i < 100; i++)
            {
                foreach (var host in lsHosts)
                {
                    if (!gs1.IsApproved)
                        gs1 = CreateRandomRequest();
                    if (!gs2.IsApproved)
                        gs2 = CreateRandomRequest();
                    if (!gs3.IsApproved)
                        gs3 = CreateRandomRequest();
                    switch (rand.Next(1, 3))
                    {
                        case 1:
                            host.AssignRequests(gs1);
                            break;
                        case 2:
                            host.AssignRequests(gs1, gs2);
                            break;
                        case 3:
                            host.AssignRequests(gs1, gs2, gs3);
                            break;
                        default:
                            break;
                    }
                }
            }
            //Create dictionary for all units <unitkey, occupancy_percentage>
            Dictionary<long, float> dict = new Dictionary<long, float>();
            foreach (var host in lsHosts)
            {
                //test Host IEnuramble is ok
                foreach (HostingUnit unit in host)
                {
                    dict[unit.HostingUnitKey] = unit.GetAnnualBusyPercentage();
                }
            }
            //get max value in dictionary
            float maxVal = dict.Values.Max();
            //get max value key name in dictionary
            long maxKey =
           dict.FirstOrDefault(x => x.Value == dict.Values.Max()).Key;
            //find the Host that its unit has the maximum occupancy percentage
            foreach (var host in lsHosts)
            {
                //test indexer of Host
                for (int i = 0; i < (host.HostingUnitCollection.Count); i++)
                {
                    if (host[i].HostingUnitKey == maxKey)
                    {
                        //sort this host by occupancy of its units
                        host.SortUnits();
                        //print this host detailes
                        Console.WriteLine("**** Details of the Host with the most occupied unit: \n");
                        Console.WriteLine(host);
                    }
                }
            }
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }

}


