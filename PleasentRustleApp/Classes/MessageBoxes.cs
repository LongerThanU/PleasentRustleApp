using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PleasentRustleApp.Classes
{
    class MessageBoxes
    {
        public static void WarningMessage(string body, string title)
        {
            MessageBox.Show(body, title, MessageBoxButton.YesNo, MessageBoxImage.Question);
        }

        public static void ExceptionMessage(string body, string title)
        {
            MessageBox.Show(body, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void InfoMessage(string body, string title)
        {
            MessageBox.Show(body, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }        
    }
}
