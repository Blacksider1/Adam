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
using Microsoft.Win32;
using System.Xml.Serialization;
using System.IO;
namespace SHESt
{
    /// <summary>
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Otch { get; set; }
        public string Pol { get; set; }
        public string Date { get; set; }
        public string Log { get; set; }
        public string Pas { get; set; }
        
        public string Num { get; set; }
        public Person()
        { }
        public Person(string name, string surname, string otch, string pol,string date,string log, string pas, string num)
        {
            Name = name;
            Surname = surname;
            Otch = otch;
            Pol = pol;
            Date = date;
            Log = log;
            Pas = pas;
            
            Num = num;
        }
    }
    public class Persons
    {
        public List<Person> items;

        public Persons()
        {
            items = new List<Person>();
        }
    }

public partial class Reg : Window
    {
        public Reg()
        {
            InitializeComponent();
            pol1.Items.Add("м");
            pol1.Items.Add("ж");
        }

        private void Phot_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";

            if (openDialog.ShowDialog() == true)
            {
                image.Source = new BitmapImage(new Uri(openDialog.FileName));
                nameim.Text = openDialog.FileName.Substring(openDialog.FileName.LastIndexOf(@"\") + 1);
            }
        }

        private void Zareg_Click(object sender, RoutedEventArgs e)
        {
            // объект для сериализации
            Person p = new Person(name1.Text, fam1.Text,otch1.Text,pol1.Text,date1.Text, log1.Text,pas1.Password,num1.Text);
            // передаем в конструктор тип класса
            XmlSerializer formatter = new XmlSerializer(typeof(Persons));
            Persons ps;
            using (Stream ins = File.Open(@"Persons.xml", FileMode.OpenOrCreate))
            {
                //если файл имеет данные, то они выведутся в таблицу
                try
                {
                    ps = (Persons)formatter.Deserialize(ins); //десериализация данных
                }
                //если файл пустой, то лист инициализируется
                catch
                {
                    ps = new Persons();
                }
                ps.items.Add(p); //добавление нового человека в лист
                
                //dataGridPersons.ItemsSource = ps.items; //устанавливаем ресурсы у таблицы

            }
            //сериализация лист с новой информацией
            using (FileStream fs = new FileStream(@"Persons.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, ps);
            }
        }
    }
}
