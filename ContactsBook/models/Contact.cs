using System.ComponentModel;

namespace ContactsBook.models
{
    public class Contact : INotifyPropertyChanged
    {
        private string name;

        //public Contact(string name)
        //{
        //    Name = name;
        //}

        public string Name
        {
            get { return name; }
            set { name = value; Notify("Name"); }
        }
        public bool IsSelected { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
