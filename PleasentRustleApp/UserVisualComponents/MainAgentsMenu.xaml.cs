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
        public MainAgentsMenu()
        {
            InitializeComponent();
            Update();
        }

        public void Update()
        {
            DbClass.DbConnection(out LonGerEntities db);
            string SearchSource = SearchBox.Text;
            var DataSource = SearchSource == "" ? db.Agent : db.Agent.Where(x => x.Title.StartsWith(SearchSource));

            if (DataSource.Count() == 0)
                SearchNoResults.Visibility = Visibility.Visible;

            if (SortBox.SelectedItem.ToString() == "А-я")
                DataSource = DataSource.OrderBy(x => x.Title);

            if (SortBox.SelectedItem.ToString() == "Я-а")
                DataSource = DataSource.OrderByDescending(x => x.Title);


            IControl.ItemsSource = DataSource.ToList();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}