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
    public partial class StarsView : ContentView
    {
        public StarsView()
        {
            InitializeComponent();
#pragma warning disable CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
            InfiniteRotation(star1, 5000);
            InfiniteRotation(star2, 3000);
            InfiniteRotation(star3, 7000);
#pragma warning restore CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
        }

        private async Task InfiniteRotation(View star, uint time)
        {
            Boolean always = true;
            while (always)
            {
                await star.RotateTo(360, time);
                star.Rotation = 0;
            }
        }
    }
}