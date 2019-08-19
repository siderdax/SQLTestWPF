using System.Threading;
using System.Data;
using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using SQLTestRAD.Model;

using SqlDataManager;

namespace SQLTestRAD.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;
        private string _sqlDataAddress = string.Empty;
        private string _sqlDataPort = string.Empty;
        private string _sqlInitialCatalog = string.Empty;
        private string _sqlUserId = string.Empty;
        private string _sqlPassword = string.Empty;
        private string _sqlQuery = string.Empty;

        /// <summary>
        /// Get properties.
        /// Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }
            set
            {
                Set(ref _welcomeTitle, value);
            }
        }

        public string SqlDataAddress
        {
            get
            {
                return _sqlDataAddress;
            }
            set
            {
                Set(ref _sqlDataAddress, value);
            }
        }

        public string SqlDataPort
        {
            get
            {
                return _sqlDataPort;
            }
            set
            {
                Set(ref _sqlDataPort, value);
            }
        }

        public string SqlInitialCatalog
        {
            get
            {
                return _sqlInitialCatalog;
            }
            set
            {
                Set(ref _sqlInitialCatalog, value);
            }
        }

        public string SqlUserId
        {
            get
            {
                return _sqlUserId;
            }
            set
            {
                Set(ref _sqlUserId, value);
            }
        }

        public string SqlPassword
        {
            get
            {
                return _sqlPassword;
            }
            set
            {
                Set(ref _sqlPassword, value);
            }
        }

        public string SqlQuery
        {
            get
            {
                return _sqlQuery;
            }
            set
            {
                Set(ref _sqlQuery, value);
            }
        }

        /// <summary>
        /// Initializes Button command method
        /// </summary>
        public ICommand RunQueryCommand { get; private set; }

        public void RunQueryMethod()
        {
            WelcomeTitle = "Running...";
            Random r = new Random();
            DatabaseConnection dc = new DatabaseConnection(SqlDataAddress, SqlDataPort, SqlInitialCatalog, SqlUserId, SqlPassword);
            // int ret = -1;
            DataTable dbData;

            // ret = dc.RunNonQuery(strQuery);
            dbData = dc.RunQuery(SqlQuery);
            
            // if(ret < 0) {
            //     WelcomeTitle = "Query Error";
            // } else {
            //     WelcomeTitle = ret + " rows Changed.";
            // }

            

            if(dbData.Columns.Count > 0)
            {
                if(dbData.Columns[0].ColumnName.Equals("error"))
                {
                    WelcomeTitle = "Error: ";
                    foreach(DataRow row in dbData.Rows)
                    {
                        WelcomeTitle += row["error"];
                    }
                } else
                {
                    WelcomeTitle = DataTableToString(dbData);
                }
            } else
            {
                WelcomeTitle = "Query done.";
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    WelcomeTitle = item.Title;
                    SqlDataAddress = item.DataAddress;
                    SqlDataPort = item.DataPort;
                    SqlInitialCatalog = item.InitialCatalog;
                    SqlUserId = item.UserId;
                    SqlPassword = item.Password;
                });

            RunQueryCommand = new RelayCommand(RunQueryMethod);
        }

        private string DataTableToString(DataTable table)
        {
            string str = "";

            foreach (DataColumn col in table.Columns)
            {
                str += String.Format("{0,-14}", col.ColumnName);
            }
            str += "\r\n";

            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn col in table.Columns)
                {
                    if (col.DataType.Equals(typeof(DateTime)))
                        str += String.Format("{0,-14:d}", row[col]);
                    else
                        str += String.Format("{0,-14}", row[col]);
                }
                str += "\r\n";
            }
            str += "\r\n";

            return str;
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}