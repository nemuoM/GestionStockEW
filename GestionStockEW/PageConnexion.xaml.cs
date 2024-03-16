namespace GestionStockEW;

public partial class PageConnexion : ContentPage
{
	public PageConnexion()
	{
		InitializeComponent();
	}

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
		if (txtMdp.IsPassword)
		{
			txtMdp.IsPassword = false;
		}
		else
		{
            txtMdp.IsPassword = true;
        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Utilisateur unUser = await Contexte.GetUser(txtMail.Text, txtMdp.Text);

            if (unUser != null)
            {
                //Permet d'accéder à la page passée en paramètre
                await Navigation.PushAsync(new PageAccueil(unUser));
                //Supprime la page courante de la navigation afin de ne pas pouvoir revenir dessus
                Navigation.RemovePage(this);
            }
            else
            {
                lblErreur.IsVisible = true;
                txtMail.Text = txtMdp.Text = "";
            }
        }
        catch (ArgumentNullException)
        {
            await DisplayAlert("Erreur", "Vous devez saisir un nom d'utilisateur ET un mot de passe", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erreur", ex.Message, "OK");
        }
    }
}