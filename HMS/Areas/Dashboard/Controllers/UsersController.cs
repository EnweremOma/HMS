using HMS.Areas.Dashboard.ViewModels;
using HMS.Entities;
using HMS.Service;
using HMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS.Areas.Dashboard.Controllers
{
    public class UsersController : Controller
    {
        // GET: Dashboard/Users
        AccomodationsService accomodationsService = new AccomodationsService();
        AccomodationPackagesService accomodationPackagesService = new AccomodationPackagesService();
        // GET: Dashboard/Accomodations
        public ActionResult Index(string searchTerm, string roleID, int? page)
        {
            int recordSize = 5;
            page = page ?? 1;

            UsersListingModel model = new UsersListingModel();

            model.SearchTerm = searchTerm;
            model.RoleID = roleID;
            //model.Roles = accomodationPackagesService.GetAllAccomodationPackages();

            //model.Users = accomodationsService.SearchAccomodations(searchTerm, roleID, page.Value, recordSize);
            var totalRecords = 0; // accomodationsService.SearchAccomodationsCount(searchTerm, roleID);

            model.Pager = new Pager(totalRecords, page, recordSize);

            return View(model);
        }

        [HttpGet]
        public ActionResult Action(int? ID)
        {
            AccomodationsActionModel model = new AccomodationsActionModel();
            if (ID.HasValue) //we are trying to edit a record
            {
                var accomodation = accomodationsService.GetAccomodationByID(ID.Value);

                model.ID = accomodation.ID;
                model.AccomodationPackageID = accomodation.AccomodationPackageID;
                model.Name = accomodation.Name;
                model.Description = accomodation.Description;
            }

            model.AccomodationPackages = accomodationPackagesService.GetAllAccomodationPackages();

            return PartialView("_Action", model);
        }

        [HttpPost]
        public JsonResult Action(AccomodationsActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            if (model.ID > 0) //we are trying to edit a record
            {
                var accomodation = accomodationsService.GetAccomodationByID(model.ID);

                accomodation.AccomodationPackageID = model.AccomodationPackageID;
                accomodation.Name = model.Name;
                accomodation.Description = model.Description;


                result = accomodationsService.UpdateAccomodation(accomodation);
            }
            else //we are trying to create a record
            {
                Accomodation accomodation = new Accomodation();

                accomodation.AccomodationPackageID = model.AccomodationPackageID;
                accomodation.Name = model.Name;
                accomodation.Description = model.Description;


                result = accomodationsService.SaveAccomodation(accomodation);
            }


            if (result)
            {
                json.Data = new { success = true };
            }
            else
            {
                json.Data = new { success = false, Message = "unable to perform action on accomodation." };
            }

            return json;
        }


        [HttpGet]
        public ActionResult Delete(int ID)
        {
            AccomodationsActionModel model = new AccomodationsActionModel();

            var accomodation = accomodationsService.GetAccomodationByID(ID);

            model.ID = accomodation.ID;

            return PartialView("_Delete", model);
        }

        [HttpPost]
        public JsonResult Delete(AccomodationsActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            var accomodation = accomodationsService.GetAccomodationByID(model.ID);

            result = accomodationsService.DeleteAccomodation(accomodation);


            if (result)
            {
                json.Data = new { success = true };
            }
            else
            {
                json.Data = new { success = false, Message = "unable to perform action on accomodation." };
            }

            return json;
        }
    }
}
