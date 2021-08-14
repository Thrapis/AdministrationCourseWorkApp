using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TheRamShop.Models.DataBase
{
    public class MRConnection
    {
        private static string connectionString = @"server=WIN-QSRMNQOT9SQ;database=the_ram_shop;user id=BAA;password=Artyom1";

        public static SqlConnection GetConnection() => new SqlConnection(connectionString);
    }
}