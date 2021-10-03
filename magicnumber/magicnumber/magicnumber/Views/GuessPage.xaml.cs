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
	public partial class GuessPage : ContentPage
	{
		const int COMPLEMENT = 9;
		public GuessPage ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar(this, false);
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
			if (String.IsNullOrWhiteSpace(numberEntry.Text))
			{
				DisplayAlert("Attention", "Vous devez rentrer un nombre", "OK");
				numberEntry.Text = "";
				numberEntry.Focus();
				return;
			}

			int userNumber = 0;
			string result;
			try
			{
				userNumber = Int32.Parse(numberEntry.Text);
				result = numberEntry.Text;
				numberEntry.Text = "";
			}
			catch (Exception)
			{
				DisplayAlert("Attention", "Vous devez rentrer uniquement des chiffres", "OK");
				numberEntry.Text = "";
				return;
			}

			if(result.Length != 3)
            {
				DisplayAlert("Attention", "Vous devez rentrer 3 chiffres", "OK");
				numberEntry.Text = "";
				return;
			}

			int sum = 0;

			for (int i = result.Length - 1; i >= 0; --i)
			{
				int nb = 0;

				int.TryParse(result[i].ToString(), out nb);
				sum += nb;

				if (i == 0 && sum >= 10)
				{
					result = sum.ToString();
					sum = 0;
					i = result.Length;
				}
			}

			if (sum == '0')
			{
				userNumber = 0;
			}
			else
			{
				userNumber = COMPLEMENT - sum;
			}

#pragma warning disable CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
            Replay(userNumber);
#pragma warning restore CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
		}

		private async Task Replay(int userNumber)
        {
			bool answer = await DisplayAlert("Tadaaa", "Votre chiffre est le : " + userNumber + "\n" + "Voulez-vous réessayer ?", "Oui", "Non");
			if(!answer)
            {
				await this.Navigation.PopAsync();
			}
		}
    }
}