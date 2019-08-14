using System.Collections;
namespace SQLTestRAD.Model
{
    public class DataItem
    {
        public string Title
        {
            get;
            private set;
        }

        public string DataSource
        {
            get;
            private set;
        }

        public string InitialCatalog
        {
            get;
            set;
        }

        public string UserId
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public DataItem(string title, Hashtable defaultValue)
        {
            Title = title;
            DataSource = defaultValue["datasource"] as string;
            InitialCatalog = defaultValue["initialcatalog"] as string;
            UserId = defaultValue["userid"] as string;
            Password = defaultValue["password"] as string;
        }
    }
}