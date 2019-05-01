using BuscaCep.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BuscaCep.ViewModels
{
    sealed class CepsViewModel : ViewModelBase
    {
        public CepsViewModel():base()
        {
        }

        public ObservableCollection<string> Ceps { get; private set; } = new ObservableCollection<string>();

        private Command _BuscarCommand;

        public Command BuscarCommand => _BuscarCommand ?? (_BuscarCommand = new Command(async ()=> await BuscarCommandExecute()));

        async Task BuscarCommandExecute()
        {
            try
            {
                MessagingCenter.Subscribe<BuscaCepViewModel>(this, "ADICIONAR_CEP", (sender) =>
                {
                    if (!Ceps.Any(x => x.Equals(sender.CEP)))
                        Ceps.Add(sender.CEP);

                    MessagingCenter.Unsubscribe<BuscaCepViewModel>(this, "ADICIONAR_CEP");
                });

                await PushAsync(new BuscaCepPage());
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
