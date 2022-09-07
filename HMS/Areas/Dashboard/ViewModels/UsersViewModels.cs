using HMS.Entities;
using HMS.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace HMS.Areas.Dashboard.ViewModels
{
    public class UsersListingModel
    {
        public IEnumerable<HMSUser> Users { get; set; }
        public object SearchTerm { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
        public Pager Pager { get; set; }
        public string RoleID { get; set; }
    }

    public class UsersActionModel
    {
        public int ID { get; set; }

        public string RoleID { get; set; }
        public IdentityRole Role { get; set; }

        public string Name { get; set; }

        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}


