using System;
using System.Collections;
using SQLTestRAD.Model;

namespace SQLTestRAD.Design
{
    public class DesignDataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to create design time data
            Hashtable defaultData = new Hashtable();
            defaultData.Add("dataaddress", "127.0.0.1");
            defaultData.Add("dataport", "1433");
            defaultData.Add("initialcatalog", "TEST_DB");
            defaultData.Add("userid", "id");
            defaultData.Add("password", "password");
            var item = new DataItem("SQL test", defaultData);
            callback(item, null);
        }
    }
}