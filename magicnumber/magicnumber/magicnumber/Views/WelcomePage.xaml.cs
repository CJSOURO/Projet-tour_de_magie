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
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
#pragma warning disable CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
            InfiniteScale(play_magic_number_button, 1000, 1);
            InfiniteScale(play_miss_number_button, 1000, 2);
#pragma warning restore CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
            NavigationPage.SetHasNavigationBar(this, false);
        }
        
        private async Task InfiniteScale(View play, uint time, int s)
        {
            Boolean always = true;
            while (always)
            {
                if(s == 1)
                {
                    await play.ScaleTo(1.1, time);
                    await play.ScaleTo(1.0, time);
                }
                else if(s == 2)
                {
                    await play.ScaleTo(1.0, time);
                    await play.ScaleTo(1.1, time);
                }
                
            }
        }

        private void Play_Magic_Number_Game_Button(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GamePage());
        }
        private void Play_Miss_Number_Game_Button(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GuessPage());
        }
    }
}