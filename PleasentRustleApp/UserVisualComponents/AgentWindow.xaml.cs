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
using System.Windows.Shapes;

namespace PleasentRustleApp.UserVisualComponents
{
    /// <summary>
    /// Interaction logic for AgentWindow.xaml
    /// </summary>
    public partial class AgentWindow : Window
    {
        public AgentWindow()
        {
            InitializeComponent();
            Update();
        }

        public void Update()
        {
            DbClass.DbConnection(out LonGerEntities db);
            string SearchSource = SearchBox.Text;
            var DataSource = SearchSource == "" ? db.Agent : db.Agent.Where(x => x.Title.StartsWith(SearchSource));
            IControl.ItemsSource = DataSource.ToList();

            if (DataSource.Count() == 0)
            {
                SearchNoResults.text
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
    }
}
