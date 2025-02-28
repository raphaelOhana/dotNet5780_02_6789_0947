﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet_5780_02_6789_0947
{
    public class Host : IEnumerable<HostingUnit>
    {
        //a verifier 
       // private int numToHelpME ;
        public readonly int HostKey;
        public  List<HostingUnit> HostingUnitCollection;
        //ctor
        public Host(int id ,int x )
        {
            HostKey = id;
            HostingUnitCollection = new List<HostingUnit>();
             for(int i=0;i< x;i++)
                     HostingUnitCollection.Add(new HostingUnit());
            
        }
        public override string ToString()
        {
            string list = "";
            foreach(HostingUnit help in HostingUnitCollection)
                list+=help.HostingUnitKey+"\t"+ help.ToString()+"\n";
            return list;
        }
        private long SubmitRequest(GuestRequest guestReq)
        {
            foreach(HostingUnit help in HostingUnitCollection)
                if( help.ApproveRequest(guestReq))
                    return help.HostingUnitKey;
            return -1;
        }
        public int GetHostAnnualBusyDays()
        {
            int AnnualBusyDays =0;
            foreach(HostingUnit help in HostingUnitCollection)
                    AnnualBusyDays+=help.GetAnnualBusyDays();
            return AnnualBusyDays;
        }
        public void SortUnits()
        {
            HostingUnitCollection.Sort();
        }

        public bool AssignRequests(params GuestRequest[] request)
        {
           // bool allTrue=true;
            foreach(GuestRequest help in request)
               if(SubmitRequest(help)==-1)
                   return false;
            return true;
        }

        public HostingUnit this[int index]
	    {
		    get =>  HostingUnitCollection[index];
	    }
        public IEnumerator<HostingUnit> GetEnumerator()
        {
            return HostingUnitCollection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return this.GetEnumerator();
        }
    }
}
