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
    public partial class GamePage : ContentPage
    {
        const int NB_MIN = 1;
        const int NB_MAX = 10;
        int magicNumber = 0;
        int nbVies = 4;
        public GamePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            intervalle.Text = "Entre" + NB_MIN + " et " + NB_MAX;
            magicNumber = new Random().Next(NB_MIN, NB_MAX);
#pragma warning disable CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
            SelectLevel();
#pragma warning restore CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
        }
        private void Guess_Button(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(numberEntry.Text))
            {
                DisplayAlert("Attention", "Vous devez rentrer un nombre", "OK");
                numberEntry.Text = "";
                numberEntry.Focus();
                return;
            }

            int number = 0;

            try
            {
                number = Int32.Parse(numberEntry.Text);
                numberEntry.Text = "";
            }
            catch(Exception)
            {
                DisplayAlert("Attention", "Vous devez rentrer uniquement des chiffres", "OK");
                return;
            }
            

            if(number < NB_MIN || number > NB_MAX)
            {
                DisplayAlert("Attention", "Vous devez rentrer un nombre entre "+NB_MIN+" et "+NB_MAX, "OK");
                return;
            }
            
            if(number == magicNumber)
            {
#pragma warning disable CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
                WinOrLoseAction(true);
#pragma warning restore CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
                return;
            }

            --nbVies;

            if(nbVies<1)
            {
#pragma warning disable CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
                WinOrLoseAction(false);
#pragma warning restore CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
            }
            else if (number > magicNumber)
            {
                DisplayAlert("Réessayez encore", "Le nombre magique est inférieur à " + number + ".\nIl vous reste: " + nbVies + " vie(s).", "OK");
            }
            else
            {
                DisplayAlert("Réessayez encore", "Le nombre magique est supérieur à " + number + ".\nIl vous reste: "+ nbVies+" vie(s).", "OK");
            }

            numberEntry.Focus();
            return;
        }

        private async Task WinOrLoseAction(Boolean status)
        {
            if(status)
            {
                await this.Navigation.PushAsync(new WinPage(magicNumber));
            }
            else
            {
                await DisplayAlert("Désolé", "Vous avez perdu.\nLe nombre magique était: " + magicNumber, "OK");
                await this.Navigation.PopAsync();
            }
        }

        private async Task SelectLevel()
        {
            string action = await DisplayActionSheet("Quel est votre niveau ?", "Quitter", null, "Facile", "Normal", "Difficile");
            if(action == "Facile")
            {
                nbVies = 5;
            }
            else if (action == "Difficile")
            {
                nbVies = 3;
            }
            else if (action == "Quitter")
            {
                await this.Navigation.PopAsync();
            }
        }

    }
}