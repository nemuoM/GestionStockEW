namespace GestionStockEW;

public partial class PageDemande : ContentPage
{
	public PageDemande()
	{
		InitializeComponent();
	}

    private async void ContentPage_Loaded(object sender, EventArgs e)
    {
        this.colViewDemande.ItemsSource = await Contexte.GetDemandes();
    }

    private async void colViewDemande_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Demande dmdSelect = (Demande)e.CurrentSelection.FirstOrDefault();
        await Navigation.PushAsync(new PageDetailsDmd(dmdSelect));
    }
}