using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Nabil.Models;

namespace Nabil.ViewModels
{
    public class UserEditViewModel
    {


        public ApplicationUser ApplicationUser { get; set; }

        public string Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string UserRole { get; set; }


        public UserEditViewModel(ApplicationUser appUser)
        {
            
            Id = appUser.Id;
            Username = appUser.UserName;
            FirstName = appUser.FirstName;
            LastName = appUser.LastName;
            PhoneNumber = appUser.PhoneNumber;


        }

        public UserEditViewModel(ApplicationUser appUser, string role)
        {

            Id = appUser.Id;
            Username = appUser.UserName;
            FirstName = appUser.FirstName;
            LastName = appUser.LastName;
            PhoneNumber = appUser.PhoneNumber;
            UserRole = role;

        }

        public UserEditViewModel()
        {

           

        }

    }

}
