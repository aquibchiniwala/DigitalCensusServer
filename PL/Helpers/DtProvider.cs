using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BAL.Services;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using MVC.Helper;
using MVC.Models;
using Shared.Enums;

namespace Nagarro.CensusPopulation.Web.Helper
{
    public class DotNetTechyAuthServerProvider : OAuthAuthorizationServerProvider
    {
        public DotNetTechyAuthServerProvider()
        {
        }
        private UserService service = new UserService();
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            //context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            LoginViewModel user = new LoginViewModel();
            user.Email = context.UserName;
            user.Password = context.Password;
            var userDTO = LoginMapper.VMtoDTOLogin(user);
            var currentUser = service.Login(userDTO);
            if (currentUser != null)
            {
                identity.AddClaim(new Claim("Role", currentUser.Role == Role.Volunteer ? "0" : "1"));
                identity.AddClaim(new Claim("ApprovalStatus", currentUser.ApprovalStatus == ApprovalStatus.Pending ? "0" : currentUser.ApprovalStatus == ApprovalStatus.Approved ? "1" : "2"));
                identity.AddClaim(new Claim("UserID", Convert.ToString(currentUser.UserID)));
                identity.AddClaim(new Claim("Email", Convert.ToString(currentUser.Email)));
                identity.AddClaim(new Claim("FirstName", Convert.ToString(currentUser.FirstName)));
                identity.AddClaim(new Claim("LastName", Convert.ToString(currentUser.LastName)));
                var props = new AuthenticationProperties(new Dictionary<string, string>
                                             {
                                                    {
                                                    "Email", context.UserName
                                                    },
                                                    {
                                                    "Role",  currentUser.Role==Role.Volunteer?"0":"1"
                                                    },
                                                    {
                                                    "ApprovalStatus", currentUser.ApprovalStatus==ApprovalStatus.Pending?"0": currentUser.ApprovalStatus == ApprovalStatus.Approved ? "1":"2"

                                                    },
                                                    {
                                                    "FirstName", currentUser.FirstName
                                                    },
                                                    {
                                                    "LastName", currentUser.LastName
                                                    },
                                                    {
                                                    "Image", currentUser.Image
                                                    },
                                                    {
                                                    "UserID", Convert.ToString(currentUser.UserID)
                                                    }
                                                    });
                var ticket = new AuthenticationTicket(identity, props);
                context.Validated(ticket);
                //else
                //{
                //    //context.SetError("invalid_grant", "Provided username and password is not matching, Please retry!");
                //    //context.Rejected();
                //}
            }
            else
            {
                context.SetError("invalid_grant", "Provided username and password is not matching, Please retry!");
                //context.Rejected();
            }
            return;

        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
    }
}