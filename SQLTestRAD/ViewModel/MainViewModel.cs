using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using SQLTestRAD.Model;

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
        private string _sqlDataSource = string.Empty;
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

        public string SqlDataSource
        {
            get
            {
                return _sqlDataSource;
            }
            set
            {
                Set(ref _sqlDataSource, value);
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
            WelcomeTitle = "Click";
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
                    SqlDataSource = item.DataSource;
                    SqlInitialCatalog = item.InitialCatalog;
                    SqlUserId = item.UserId;
                    SqlPassword = item.Password;
                });

            RunQueryCommand = new RelayCommand(RunQueryMethod);
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}