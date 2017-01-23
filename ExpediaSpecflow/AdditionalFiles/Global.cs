using System.Collections.Generic;

namespace ExpediaSpecflow
{
    static class Global
    {
        //Dictionary for importing csv file with city airport codes
        public static Dictionary<string, string> cityAirportCodesDict = new Dictionary<string, string>();

        //Variables that store input content
        public static string orCity = "orcity";

        public static string OriginCity
            {
                get
                {
                    return orCity;
                }
                set
                {
                    orCity = value;
                }
            }

        public static string destCity = "destcity";

        public static string DestinationCity
        {
            get
            {
                return destCity;
            }
            set
            {
                destCity = value;
            }
        }

        public static string depDate = "depdate";

        public static string DepartureDate
        {
            get
            {
                return depDate;
            }
            set
            {
                depDate = value;
            }
        }

        public static string retDate = "retdate";

        public static string ReturningDate
        {
            get
            {
                return retDate;
            }
            set
            {
                retDate = value;
            }
        }

        public static string adults = "adults";

        public static string AdultsAmount
        {
            get
            {
                return adults;
            }
            set
            {
                adults = value;
            }
        }

        public static string children = "children";

        public static string ChildrenAmount
        {
            get
            {
                return children;
            }
            set
            {
                children = value;
            }
        }

        public static string ticketCost = "ticketCost";

        public static string TicketCost
        {
            get
            {
                return ticketCost;
            }
            set
            {
                ticketCost = value;
            }
        }

        public static string depTimeTo = "depTimeTo";

        public static string DepurtureTimeFlyTo
        {
            get
            {
                return depTimeTo;
            }
            set
            {
                depTimeTo = value;
            }
        }

        public static string arriveTimeTo = "arrivTimeTo";

        public static string ArriveTimeFlyTo
        {
            get
            {
                return arriveTimeTo;
            }
            set
            {
                arriveTimeTo = value;
            }
        }

        public static string depTimeFrom = "depTimeFrom";

        public static string DepurtureTimeFlyFrom
        {
            get
            {
                return depTimeFrom;
            }
            set
            {
                depTimeFrom = value;
            }
        }

        public static string arriveTimeFrom = "arrivTimeFrom";

        public static string ArriveTimeFlyFrom
        {
            get
            {
                return arriveTimeFrom;
            }
            set
            {
                arriveTimeFrom = value;
            }
        }
    }
}
