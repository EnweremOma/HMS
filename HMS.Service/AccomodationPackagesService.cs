﻿using HMS.Data;
using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Service
{
    public class AccomodationPackagesService
    {
        public IEnumerable<AccomodationPackage> GetAllAccomodationPackages()
        {
            var context = new HMSContext();

            return context.AccomodationPackages.ToList();
        }

        public IEnumerable<AccomodationPackage> SearchAccomodationPackages(string searchTerm, int? accomodationTypeID, int page, int recordSize)
        {
            var context = new HMSContext();

            var accomodationPackages = context.AccomodationPackages.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                accomodationPackages = accomodationPackages.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            if (accomodationTypeID.HasValue && accomodationTypeID.Value > 0)
            {
                accomodationPackages = accomodationPackages.Where(a => a.AccomodationTypeID == accomodationTypeID.Value);
            }

            var skip = (page - 1) * recordSize;
            //  skip   (1    - 1) = 0 * 3 = 0
            //  skip   (2    - 1) = 1 * 3 = 3
            //  skip   (3    - 1) = 2 * 3 = 6
            return accomodationPackages.ToList().OrderBy(x=>x.AccomodationTypeID).Skip(skip).Take(recordSize);
        }


        public int SearchAccomodationPackagesCount(string searchTerm, int? accomodationTypeID)
        {
            var context = new HMSContext();

            var accomodationPackages = context.AccomodationPackages.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                accomodationPackages = accomodationPackages.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            if (accomodationTypeID.HasValue && accomodationTypeID.Value > 0)
            {
                accomodationPackages = accomodationPackages.Where(a => a.AccomodationTypeID == accomodationTypeID.Value);
            }

            return accomodationPackages.Count();
        }

        public AccomodationPackage GetAccomodationPackageByID(int ID)
        {
            using (var context = new HMSContext())
            {
                return context.AccomodationPackages.Find(ID);
            }

        }
        public bool SaveAccomodationPackage(AccomodationPackage accomodationPackage)
        {
            var context = new HMSContext();

            context.AccomodationPackages.Add(accomodationPackage);

            return context.SaveChanges() > 0;
        }
        public bool UpdateAccomodationPackage(AccomodationPackage accomodationPackage)
        {
            var context = new HMSContext();

            context.Entry(accomodationPackage).State = System.Data.Entity.EntityState.Modified;

            return context.SaveChanges() > 0;
        }
        public bool DeleteAccomodationPackage(AccomodationPackage accomodationPackage)
        {
            var context = new HMSContext();

            context.Entry(accomodationPackage).State = System.Data.Entity.EntityState.Deleted;

            return context.SaveChanges() > 0;
        }

    }
}
