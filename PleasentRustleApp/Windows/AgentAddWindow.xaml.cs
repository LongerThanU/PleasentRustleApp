using PleasentRustleApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PleasentRustleApp.Windows
{
    /// <summary>
    /// Interaction logic for AgentAddWindow.xaml
    /// </summary>
    public partial class AgentAddWindow : Window
    {
        public AgentAddWindow()
        {
            InitializeComponent();
        }

        private void ExitBut_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBoxes.QuestionMessage("Вы точно хотите отменить редактирование?", "Внимание!"))
            {
                Close();
            }
        }
    }
}
