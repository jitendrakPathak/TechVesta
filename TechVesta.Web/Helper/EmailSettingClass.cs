using System;
using Microsoft.Extensions.Configuration;

namespace TechVesta.Web.Helper
{
    public static class EmailSetting
    {    
        public static string emailID { get; set; }
        public static string password { get; set; }
        public static int port { get; set; }
        public static string smtp { get; set; }
    }
}
