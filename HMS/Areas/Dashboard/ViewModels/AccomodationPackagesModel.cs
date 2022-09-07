using HMS.Entities;
using HMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMS.Areas.Dashboard.ViewModels
{
    public class AccomodationPackagesListingModel
    {
        public IEnumerable<AccomodationPackage> AccomodationPackages { get; set; }
        public object SearchTerm { get; set; }
        public IEnumerable<AccomodationType> AccomodationTypes { get; set; }
        public int? AccomodationTypeID { get; set; }
        public Pager Pager { get; set; }
    }

    public class AccomodationPackagesActionModel
    {
        public int ID { get; set; }

        public int AccomodationTypeID { get; set; }
        public AccomodationType AccomodationType { get; set; }

        public string Name { get; set; }
        public int NoOfRoom { get; set; }
        public decimal FeePerNight { get; set; }

        public IEnumerable <AccomodationType> AccomodationTypes { get; set; }
       
    }
}