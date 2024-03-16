
namespace GestionStockEW;

public partial class PageAccueil : ContentPage
{
	public PageAccueil(Utilisateur user)
	{
		InitializeComponent();
		lblAccueil.Text += user.Nom.ToUpper() + " " + user.Prenom;
		Application.Current.Resources["user"] = user;
	}

    private async void btnMontre_Clicked(object sender, EventArgs e)
    {
        //Permet d'accéder à la page passée en paramètre
        await Navigation.PushAsync(new PageMontres());
    }

    private async void btnCommande_Clicked(object sender, EventArgs e)
    {
        //Permet d'accéder à la page passée en paramètre
        await Navigation.PushAsync(new PageCommandes());
    }

    private async void btnRepro_Clicked(object sender, EventArgs e)
    {
        //Permet d'accéder à la page passée en paramètre
        await Navigation.PushAsync(new PageReapro());
    }

    private async void btnDeco_Clicked(object sender, EventArgs e)
    {
        Application.Current.Resources.Remove("user");
        await Navigation.PushAsync(new PageConnexion());
        Navigation.RemovePage(this);
    }

    private async void btnDemande_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PageDemande());
    }
}