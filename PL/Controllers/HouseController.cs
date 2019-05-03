using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BAL.Exceptions;
using BAL.Services;
using MVC.Helpers;
using PL.Models;

namespace PL.Controllers
{
    public class HouseController : ApiController
    {
        private HouseService service = new HouseService();

        // GET api/<controller>
        [ResponseType(typeof(List<UserViewModel>))]
        //[Authorize]
        public IHttpActionResult Get()
        {
            try
            {
                var house = service.GetAllHouses();
                return Content(HttpStatusCode.OK, house);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return Content(HttpStatusCode.InternalServerError, GetModelStateErrors(ModelState));
            }
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var house = service.GetHouseByID(id);
                return Content(HttpStatusCode.OK, house);
            }
            catch (HouseDoesNotExistException e)
            {
                ModelState.AddModelError("", e.Message);
                return Content(HttpStatusCode.NotFound, GetModelStateErrors(ModelState));
            }
            catch (Exception /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                return Content(HttpStatusCode.InternalServerError, GetModelStateErrors(ModelState));
            }
        }

        // POST api/<controller>
        [ResponseType(typeof(HouseViewModel))]
        public IHttpActionResult Post([FromBody]HouseViewModel house)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var h = HouseMapper.VMtoDTOHouse(house);
                    var newHouse = service.AddUpdateHouse(h);
                    {
                        return Content(HttpStatusCode.OK, newHouse);
                    }
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, GetModelStateErrors(ModelState));

                }
            }
            catch (Exception /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                return Content(HttpStatusCode.InternalServerError, GetModelStateErrors(ModelState));
            }
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]HouseViewModel house)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    house.CensusHouseNumber = house.CensusHouseNumber == 0 ? id : house.CensusHouseNumber;
                    var newHouseDTO = HouseMapper.VMtoDTOHouse(house);
                    house = HouseMapper.DTOtoVMHouse(service.AddUpdateHouse(newHouseDTO));
                    return Content(HttpStatusCode.OK, house);
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, GetModelStateErrors(ModelState));
                }
            }
            catch (HouseDoesNotExistException e)
            {
                ModelState.AddModelError("", e.Message);
                return Content(HttpStatusCode.NotFound, GetModelStateErrors(ModelState));
            }
            catch (Exception e/* dex */)
            {
                ModelState.AddModelError("", e.Message);
                return Content(HttpStatusCode.InternalServerError, GetModelStateErrors(ModelState));
            }
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var house = service.DeleteHouse(id);
                return Content(HttpStatusCode.OK, house);
            }
            catch (HouseDoesNotExistException e)
            {
                ModelState.AddModelError("", e.Message);
                return Content(HttpStatusCode.BadRequest, GetModelStateErrors(ModelState));
            }
            catch (Exception /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                return Content(HttpStatusCode.InternalServerError, GetModelStateErrors(ModelState));
            }
        }

        [Route("api/GetStateWisePopulation")]
        [HttpGet]
        public IHttpActionResult GetStateWisePopulation()
        {
            try
            {
                var stateWisePopulation = service.GetStateWisePopulation();
                return Content(HttpStatusCode.OK, stateWisePopulation);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return Content(HttpStatusCode.InternalServerError, GetModelStateErrors(ModelState));
            }
        }

        private List<string> GetModelStateErrors(System.Web.Http.ModelBinding.ModelStateDictionary modelState)
        {
            var errors = new List<string>();
            foreach (var state in modelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    errors.Add(error.ErrorMessage==""?error.Exception.Message:error.ErrorMessage);
                }
            }
            return errors;
        }

    }
}