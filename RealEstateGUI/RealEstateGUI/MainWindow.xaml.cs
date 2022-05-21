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

using Microsoft.EntityFrameworkCore;
using RealEstateGUI.Models;

namespace RealEstateGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ingatlanContext context = new ingatlanContext();
        public MainWindow()
        {
            InitializeComponent();
            context.Categories.Load();
            context.Sellers.Load();
            context.Realestates.Load();

            LB_sellers.ItemsSource = context.Sellers.Local.ToObservableCollection().OrderBy(x=>x.Name);
            this.DataContext = context.Sellers.Local.ToObservableCollection();
        }

        private void BTN_loadHirdetesek_Click(object sender, RoutedEventArgs e)
        {
            LBL_hirdetesekSzama.Content = (from r in context.Realestates.Local
                                          where r.SellerId == ((Seller)LB_sellers.SelectedItem).Id
                                          select r).Count();
        }
    }
}
