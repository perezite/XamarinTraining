using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterDetail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StuffMaster : ContentPage
    {
        public ListView ListView;

        public StuffMaster()
        {
            InitializeComponent();

            BindingContext = new StuffMasterViewModel();
            ListView = MenuItemsListView;
        }

        class StuffMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<StuffMenuItem> MenuItems { get; set; }
            
            public StuffMasterViewModel()
            {
                MenuItems = new ObservableCollection<StuffMenuItem>(new[]
                {
                    new StuffMenuItem { Id = 0, Title = "Page 1" },
                    new StuffMenuItem { Id = 1, Title = "Page 2" },
                    new StuffMenuItem { Id = 2, Title = "Page 3" },
                    new StuffMenuItem { Id = 3, Title = "Page 4" },
                    new StuffMenuItem { Id = 4, Title = "Page 5", TargetType = typeof(AlternativStuffDetail) },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}