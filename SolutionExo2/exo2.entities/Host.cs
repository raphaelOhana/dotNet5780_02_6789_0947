﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet_5780_02_6789_1947
{
    public class Host:IEnumerable<HostingUnit>
    {
        //a verifier 
        public readonly int HostKey;
        public  List<HostingUnit> HostingUnitCollection;
        //ctor
        public Host(int id ,int x )
        {
            HostKey = id;
            HostingUnitCollection = new List<HostingUnit>();
           
            //a completer
        }
        public override string ToString()
        {
            string list = "";
            for(int i=0;i< 10;i++)
            return "";
        }
        private long SubmitRequest(GuestRequest guestReq)
        {
            return 100;
        }
        public int GetHostAnnualBusyDays()
        {
            return 1;
        }
        public void SortUnits()
        {

        }

        public bool AssignRequests(params GuestRequest[] request)
        {
            return true;
        }
        public string indexer()
        {
            return "";
        }

        public IEnumerator<HostingUnit> GetEnumerator()
        {
            return HostingUnitCollection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return HostingUnitCollection.GetEnumerator();
        }
    }
}
