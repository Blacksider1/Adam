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
using System.Xml.Serialization;
namespace SHESt
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Vhod(object sender, RoutedEventArgs e)
        {
            tren ter = new tren();
            if (log.Text == "ter1" && pas.Password == "123")
            {
                ter.Show();
                this.Hide();
            }
            if (log.Text == "ter2" && pas.Password == "123123")
            {
                ter.Show();
                this.Hide();
            }
        }

        private void Reg(object sender, RoutedEventArgs e)
        {
            Reg r = new Reg();
            r.Show();
        }
    }
}
