using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nabil.ViewModels
{
    public class GroupedUserViewModel
    {
        public List<UserViewModel> Employees { get; set; }
        public List<UserViewModel> Admins { get; set; }
        public List<UserViewModel> Managers { get; set; }
    }

    public class UserViewModel
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string RoleName { get; set; }
    }
}