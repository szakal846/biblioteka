using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Book> Booklist { get; set; }
       
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Booklist = new ObservableCollection<Book>();
            this.TypesCombobox.ItemsSource = Enum.GetValues(typeof(Book.Types)).Cast<Book.Types>();
            this.TypesCombobox.SelectedIndex = 0;
               }

        private  void AddButton_Click(object sender, RoutedEventArgs e)
        {

           
            string author = this.AuthorTextbox.Text;
            string title = this.TitleTextbox.Text;
            int number = int.Parse(this.NumberTextbox.Text);
            int id = int.Parse(this.IdTextbox.Text);
            Book.Types type = (Book.Types)Enum.Parse(typeof(Book.Types), this.TypesCombobox.Text);

            Book book = new Book(author, number, type, title, id) ;


         
            Booklist.Add(book);

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Booklist.RemoveAt(this.ListView1.SelectedIndex);
            }
            catch (Exception ex)
            {
                 MessageBox.Show("First select book" , "Delete book");
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "BookListofproducts";
            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML documents (.xml)|*.xml*";

            Nullable<bool> result = dlg.ShowDialog();
            if( result == true)
            {
                string filePath = dlg.FileName;

                ListToXMlFile(filePath);
            }
        }

        private void ListToXMlFile(string filePath)
        {
            using (var sw = new StreamWriter(filePath))
            {
                var serializer = new XmlSerializer(typeof(ObservableCollection<Book>));
                serializer.Serialize(sw, Booklist);
            }
        }
        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML documents (.xml)|*.xml*";

            Nullable<bool> result = dlg.ShowDialog();
            string filename = "";
            if (result == true)
            {
                filename = dlg.FileName;
            }
            if (File.Exists(filename))
            {
                XmlFiletoList(filename);
            }
            else
            {
                MessageBox.Show(@"Such file doesn't exist");
            }
            }

        private void XmlFiletoList(string filename)
        {
            using (var sr = new StreamReader(filename))
            {
                var deserializer = new XmlSerializer(typeof(ObservableCollection<Book>));
                ObservableCollection<Book> tmplist = (ObservableCollection<Book>)deserializer.Deserialize(sr);
                foreach(var item in tmplist)
                {
                    Booklist.Add(item);
                }
            }
        }

    
       
    }
}

