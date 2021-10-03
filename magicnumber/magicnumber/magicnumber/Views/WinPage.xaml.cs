using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace magicnumber.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WinPage : ContentPage
    {
        public WinPage(int magicNumber)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            mainLayout.Scale = 0.7;
            mainLayout.ScaleTo(1.0, 1500, Easing.BounceIn);

            win_number.Text = "Le nombre magique était: "+ magicNumber;

#pragma warning disable CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
            RootPageButtonClicked();
#pragma warning restore CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
        }

        private async Task RootPageButtonClicked()
        {
            await Task.Delay(3000);
            await Navigation.PopToRootAsync();
        }
    }
}