using Microsoft.Win32;
using PleasentRustleApp.Classes;
using PleasentRustleApp.Entities;
using System;
using System.Collections.Generic;
using System.IO;
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
            if (MessageBoxes.QuestionMessage("Вы точно хотите отменить добавление?", "Внимание!"))
            {
                Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OPF = new OpenFileDialog();
            OPF.Filter = "Файлы PNG|*.png";
            if(OPF.ShowDialog() == true)
            {
                ImageSourceConverter imgs = new ImageSourceConverter();
                AgentAddPhoto.SetValue(Image.SourceProperty, imgs.ConvertFromString(OPF.FileName));
            }
        }

        private void AddNewAgentBut_Click(object sender, RoutedEventArgs e)
        {
            DbClass.DbConnection(out LonGerEntities db);
            Agent agent = new Agent
            {
                Title = TitleBox.Text,
                Ag

            };
            db.Agent.Add(agent);
        }
    }
}
