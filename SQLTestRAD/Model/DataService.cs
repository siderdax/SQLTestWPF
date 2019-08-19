using System;
using System.Collections;

namespace SQLTestRAD.Model
{
    public class DataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to connect to the actual data service
            Hashtable defaultData = new Hashtable();
            defaultData.Add("dataaddress", "127.0.0.1");
            defaultData.Add("dataport", "8080");
            defaultData.Add("initialcatalog", "TEST");
            defaultData.Add("userid", "admin");
            defaultData.Add("password", "");
            var item = new DataItem("SQL Test", defaultData);
            callback(item, null);
        }
    }
}