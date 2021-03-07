using PleasentRustleApp.Classes;
using PleasentRustleApp.Entities;
using PleasentRustleApp.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PleasentRustleApp.UserVisualComponents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainAgentsMenu : Window
    {
        public string SelectedFilter { get; set; } = "Без фильтра";
        public string SelectedAgentTypeFilter { get; set; } = "Все типы";

        public List<string> Filters = new List<string>
        {
            "Без фильтра",
            "Имя агента по алфавиту",
            "Имя агента по алфавиту с конца",
            "Тип агента по алфавиту",
            "Тип агента по алфавиту с конца",
            "По приоритету с начала",
            "По приоритету с конца"
        };

        public List<string> AgentType 
        {
            get
            {
                DbClass.DbConnection(out LonGerEntities db);
                var AgentType = db.AgentType.Select(x => x.Title).Distinct().ToList();
                AgentType.Insert(0, "Все типы");
                return AgentType;
            }
        }

        public MainAgentsMenu()
        {
            InitializeComponent();
            DataContext = this;
            SortBox.ItemsSource = Filters;
            Update();
        }

        public void Update()
        {
            DbClass.DbConnection(out LonGerEntities db);
            string SearchSource = SearchBox.Text;
            var DataSource = SearchSource == "" ? db.Agent : db.Agent.Where(x => x.Title.StartsWith(SearchSource));

            if (DataSource.Count() == 0)
                SearchNoResults.Visibility = Visibility.Visible;
            else 
                SearchNoResults.Visibility = Visibility.Collapsed;

            if (SortBox.SelectedItem != null)
            {
                if (SortBox.SelectedItem.ToString() == "Имя агента по алфавиту")
                    DataSource = DataSource.OrderBy(x => x.Title);

                if (SortBox.SelectedItem.ToString() == "Имя агента по алфавиту с конца")
                    DataSource = DataSource.OrderByDescending(x => x.Title);

                if (SortBox.SelectedItem.ToString() == "Тип агента по алфавиту")
                    DataSource = DataSource.OrderBy(x => x.AgentType.Title);

                if (SortBox.SelectedItem.ToString() == "Тип агента по алфавиту с конца")
                    DataSource = DataSource.OrderByDescending(x => x.AgentType.Title);

                if (SortBox.SelectedItem.ToString() == "По приоритету с начала")
                    DataSource = DataSource.OrderBy(x => x.Priority);

                if (SortBox.SelectedItem.ToString() == "По приоритету с конца")
                    DataSource = DataSource.OrderByDescending(x => x.Priority);
            }


            if(AgentTypeBox.SelectedItem != null)
            {
                string AgentTypeSource = AgentTypeBox.SelectedItem.ToString();

                if (AgentTypeBox.SelectedItem.ToString() != "Все типы")
                {
                    DataSource = DataSource.Where(x => x.AgentType.Title == AgentTypeSource);
                }
            }            

            IControl.ItemsSource = DataSource.ToList();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {            
            Update();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void ExitBut_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBoxes.QuestionMessage("Вы точно хотите закрыть приложение?", "Внимание!") == true)
            {
                this.Close();
            }            
        }

        private void ChangeWinOpenBut_Click(object sender, RoutedEventArgs e)
        {
            AgentChangeWindow Win = new AgentChangeWindow();
            Win.ShowDialog();
        }

        private void DeleteAgentBut_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxes.QuestionMessage("Вы точно хотите удалить агента?", "Внимание!");
        }

        private void AgentTypeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }
    }
}