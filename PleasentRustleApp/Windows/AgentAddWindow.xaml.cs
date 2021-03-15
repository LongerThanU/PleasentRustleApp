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
        public Agent Agent { get; set; }
        public AgentAddWindow()
        {            
            InitializeComponent();
            DbClass.DbConnection(out LonGerEntities db);
            AgentTypeBox.ItemsSource = db.AgentType.ToList();
            AgentTypeBox.SelectedIndex = 0;
            DataContext = Agent;
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
            OPF.Filter = "Файлы PNG|*.png|Файлы JPEG|*.jpeg|Файлы JPG|*.jpg";
            if(OPF.ShowDialog() == true)
            {
                ImageSourceConverter imgs = new ImageSourceConverter();
                AgentAddPhoto.SetValue(Image.SourceProperty, imgs.ConvertFromString(OPF.FileName));
            }
        }

        private void AddNewAgentBut_Click(object sender, RoutedEventArgs e)
        {
            //int Priority = 0;
            //try
            //{
            //    Priority = int.Parse(PriorityBox.Text);
            //}
            //catch (Exception)
            //{
            //    MessageBoxes.ExceptionMessage("Внимание!", "В окне \"Приоритет\" могут быть записаны только цифры");
            //}

            //DbClass.DbConnection(out LonGerEntities db);
            //Agent.Title = TitleBox.Text;
            //Agent.AgentType.Title = AgentTypeBox.Text;
            //Agent.Priority = Priority;
            //Agent.Address = AdressBox.Text;
            //db.Agent.Add(Agent);
        }
    }
}
