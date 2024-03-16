namespace GestionStockEW;

public partial class PageCommandes : ContentPage
{
	public PageCommandes()
	{
		InitializeComponent();
	}

    private async void ContentPage_Loaded(object sender, EventArgs e)
    {
		this.colViewCommande.ItemsSource = await Contexte.GetCommandes(null);
    }

    private async void colViewCommande_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Commande cmdSelect = (Commande)e.CurrentSelection.FirstOrDefault();
        await Navigation.PushAsync(new PageDetailsCmd(cmdSelect));
    }

    private async void btnRecherche_Clicked(object sender, EventArgs e)
    {
        if(string.IsNullOrEmpty(entrIdC.Text))
        {
            colViewCommande.ItemsSource = await Contexte.GetCommandes(null);
        }
        else
        {
            colViewCommande.ItemsSource = await Contexte.GetCommandes(int.Parse(entrIdC.Text));
        }
    }
}