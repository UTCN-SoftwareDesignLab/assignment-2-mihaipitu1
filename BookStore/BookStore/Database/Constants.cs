using Assignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Database
{
    public class Constants
    {
        public static class Roles
        {
            public static string ADMIN = "admin";
            public static string EMPLOYEE = "employee";

            public static string[] ROLES = { ADMIN, EMPLOYEE };
        }

        public static class Rights
        {
            public static string CREATE_USER = "create_user";
            public static string DELETE_USER = "delete_user";
            public static string UPDATE_USER = "update_user";
            public static string CREATE_BOOK = "create_book";
            public static string UPDATE_BOOK = "update_book";
            public static string DELETE_BOOK = "delete_book";
            public static string GENERATE_REPORT = "generate_report";

            public static string SEARCH_BYTITLE = "search_bytitle";
            public static string SEARCH_BYAUTHOR= "search_byauthor";
            public static string SEARCH_BYGENRE= "search_bygenre";
            public static string SELL_BOOK = "sell_book";

            public static string[] ADMIN_RIGHTS = { CREATE_USER, DELETE_USER, UPDATE_USER,CREATE_BOOK,DELETE_BOOK,UPDATE_BOOK,GENERATE_REPORT };
            public static string[] USER_RIGHTS = { SEARCH_BYTITLE,SEARCH_BYAUTHOR,SEARCH_BYGENRE,SELL_BOOK};
        }
    }
}
