using PleasentRustleApp.Classes;
using PleasentRustleApp.Entities;
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

        public List<string> Filters = new List<string>
        {
            "Без сортировки",
            "Имя агента по алфавиту",
            "Имя агента по алфавиту с конца",
            "Тип агента по алфавиту",
            "Тип агента по алфавиту с конца",
            "По приоритету с начала",
            "По приоритету с конца"
        };

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
            if (MessageBoxes.WarningMessage("Вы точно хотите закрыть приложение?", "Внимание!") == true)
            {
                this.Close();
            }            
        }
    }
}