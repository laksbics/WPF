using ContactApp.Models;
using SQLite;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContactApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> contacts;
        public MainWindow()
        {
            InitializeComponent();
            contacts = new List<Contact>();
            LoadContacts();
        }

        private void btnNewContactWIndow_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
            newContactWindow.ShowDialog();
            LoadContacts();
        }

        private void LoadContacts()
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                contacts = connection.Table<Contact>().ToList();

                if (contacts != null)
                {
                    lstContacts.ItemsSource = contacts;
                }
            }
        }

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox filterBox = sender as TextBox;
            var filteredList = contacts.Where(c=>c.Name.ToUpper().Contains(txtFilter.Text.ToUpper())).ToList();
            lstContacts.ItemsSource = filteredList;
        }

        private void contactsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact selectedContact = lstContacts.SelectedItem as Contact;

            if (selectedContact != null)
            {
                ContactDetailsWindow contactDetailsWindow = new ContactDetailsWindow(selectedContact);
                contactDetailsWindow.ShowDialog();

                LoadContacts();
            }
        }

    }
}