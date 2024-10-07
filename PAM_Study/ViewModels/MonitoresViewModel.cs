
using CommunityToolkit.Mvvm.ComponentModel;
using PAM_Study.Models;
using PAM_Study.Services;



using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PAM_Study.ViewModels
{
    public partial class MonitoresViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Models.Monitor> monitores;

        public ICommand getMonitoresCommand { get; }

        public MonitoresViewModel()
        {
            getMonitoresCommand = new Command(getMonitores);
        }

        public async void getMonitores()
        {

            RestService restService = new RestService();
            Monitores = await restService.getAllMonitorsAsync();
        }
    }
}
