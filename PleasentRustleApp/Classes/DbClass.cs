using PleasentRustleApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PleasentRustleApp.Classes
{
    class DbClass
    {
        public static bool DbConnection(out LonGerEntities db)
        {
            try
            {
                db = new LonGerEntities();
                return true;
            }
            catch(Exception e)
            {
                MessageBoxes.ExceptionMessage("Ошибка подключения к базе данных", "Исключение!" + e.Message);
                db = null;
                return false;
            }
        }
    }
}