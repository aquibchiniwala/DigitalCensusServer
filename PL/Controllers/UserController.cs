using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using BAL.Exceptions;
using BAL.Services;
using MVC.Helpers;
using PL.Models;
using Shared.Enums;

namespace PL.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        private UserService service = new UserService();

        // GET api/values
        [ResponseType(typeof(UserViewModel))]
        [Route("api/GetVolunteers/{status}")]
        [HttpGet]
        public IHttpActionResult Get(ApprovalStatus status)
        {
            try
            {
                var user = service.GetAllUsers(status);
                return Content(HttpStatusCode.OK, user);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return Content(HttpStatusCode.InternalServerError, GetModelStateErrors(ModelState));
            }
        }

        // GET api/values/5
        [ResponseType(typeof(UserViewModel))]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var user = service.GetUserByID(id);
                return Content(HttpStatusCode.OK, user);
            }
            catch (UserDoesNotExistException e)
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

        // POST api/values
        [ResponseType(typeof(UserViewModel))]
        public IHttpActionResult Post([FromBody]UserViewModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var u = UserMapper.VMtoDTOUser(user);
                    var newUser = service.AddUser(u);
                    {
                        return Content(HttpStatusCode.OK, user);
                    }
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, GetModelStateErrors(ModelState));

                }
            }
            catch (UserAlreadyExistsException e)
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

        //PUT api/values/5
        [ResponseType(typeof(UserViewModel))]
        public IHttpActionResult Put(int id, [FromBody]UserViewModel user)
        {
            try
            {
                //var outDatedUser = UserMapper.DTOtoVMUser(service.GetUserByID(id));

                if (ModelState.IsValid)
                {
                    user.UserID = user.UserID == 0 ? id : user.UserID;
                    var newUserDTO = UserMapper.VMtoDTOUser(user);
                    user = UserMapper.DTOtoVMUser(service.EditUser(newUserDTO));
                    return Content(HttpStatusCode.OK, user);
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, GetModelStateErrors(ModelState));
                }
            }
            catch (UserAlreadyExistsException e)
            {
                ModelState.AddModelError("", e.Message);
                return Content(HttpStatusCode.BadRequest, GetModelStateErrors(ModelState));

            }
            catch (UserDoesNotExistException e)
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

        // DELETE api/values/5
        [ResponseType(typeof(UserViewModel))]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var user = service.DeleteUser(id);
                return Content(HttpStatusCode.OK, user);
            }
            catch (UserDoesNotExistException e)
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

        [Route("api/ChangeApprovalStatus/{id}")]
        [HttpPut]
        public IHttpActionResult ChangeApprovalStatus(int id, [FromBody]ApprovalStatus newStatus)
        {
            try
            {
                var user = service.ChangeApprovalStatus(id,newStatus);
                return Content(HttpStatusCode.OK, user);
            }
            catch (UserDoesNotExistException e)
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

        [Route("api/isAlive")]
        [HttpGet]
        public IHttpActionResult isAlive()
        {
            return Content(HttpStatusCode.OK, true);
        }

        private List<string> GetModelStateErrors(System.Web.Http.ModelBinding.ModelStateDictionary modelState)
        {
            var errors = new List<string>();
            foreach (var state in modelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    errors.Add(error.ErrorMessage == "" ? error.Exception.Message : error.ErrorMessage);
                }
            }
            return errors;
        }
    }
}
