using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nabil.Models
{
    public static class RoleNames
    {
        public const string Admin = "Admin";
        public const string Pracownik = "Pracownik";
        public const string Manager = "Manager";
        public const string AdminOrManager = Admin + "," + Manager;
        public const string AllUsers = Admin + "," + Manager + "," + Pracownik;

    }
}