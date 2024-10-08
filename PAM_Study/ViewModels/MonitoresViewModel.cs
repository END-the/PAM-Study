
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using PAM_Study.Services;
using PAM_Study.Models;
using System.Windows.Input;

namespace PAM_Study.ViewModels
{
    public partial class MonitoresViewModel : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Models.Monitor> monitores;


        public MonitoresViewModel()
        {
            getMonitoresCommand = new Command(getMonitores);
            getMonitoresCommand.Execute(this);
        }

        public ICommand getMonitoresCommand { get; }

        public async void getMonitores()
        {
            monitores = await new MonitorService().getAllMonitorsAsync();
        }





    }
}
