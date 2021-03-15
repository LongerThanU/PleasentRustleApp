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
        public static bool QuestionMessage(string body, string title)
        {
            if (MessageBox.Show(body, title, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }           
        }
        public static bool ExceptionMessage(string body, string title)
        {
            if (MessageBox.Show(body, title, MessageBoxButton.OK, MessageBoxImage.Error) == MessageBoxResult.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool InfoMessage(string body, string title)
        {
            if (MessageBox.Show(body, title, MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool WarningMessage(string body, string title)
        {
            if (MessageBox.Show(body, title, MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
