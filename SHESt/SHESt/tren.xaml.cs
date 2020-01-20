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

namespace SHESt
{
    /// <summary>
    /// Логика взаимодействия для tren.xaml
    /// </summary>
    public partial class tren : Window
    {
        public tren()
        {
            InitializeComponent();
        }
        
        private void EXit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            w.Show();
            this.Close();
        }
    }
}
