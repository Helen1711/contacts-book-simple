using ContactsBook.models;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace ContactsBook
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Contacts = new ObservableCollection<Contact>();
            SavedContacts = new ObservableCollection<Contact>();
        }

        public ObservableCollection<Contact> Contacts { get; set; }
        public ObservableCollection<Contact> SavedContacts { get; set; }

        private void SaveContact(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact(name.Text);
            Contacts.Add(contact);
            SavedContacts.Add(contact);
            name.Text = String.Empty;
        }
        
        private void SelectContacts(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (var contact in Contacts)
                {
                    if (contact.IsSelected)
                    {
                         Contacts.Remove(contact);
                    }
                }
            }
            catch(InvalidOperationException ex)
            {
                Console.WriteLine(ex.StackTrace);
                SelectContacts(sender, e);
            }
        }

        private void ShowAll(object sender, RoutedEventArgs e)
        {
            Storage.Visibility = Visibility.Visible;
        }
        private void RefreshContacts(object sender, RoutedEventArgs e)
        {
            foreach (var contact in SavedContacts)
            {
                if (!Contacts.Contains(contact))
                {
                    contact.IsSelected = false;
                    Contacts.Add(contact);
                }
            }
        }
    }
}