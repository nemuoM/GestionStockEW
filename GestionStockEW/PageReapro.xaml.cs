namespace GestionStockEW;

public partial class PageReapro : ContentPage
{
	public PageReapro()
	{
		InitializeComponent();
	}

    private async void ContentPage_Loaded(object sender, EventArgs e)
    {
        this.colViewReapro.ItemsSource = await Contexte.GetReapro();
        this.colViewReapro.EmptyView = "Il n'y a aucune montre à réapprovisionner.";
    }

    private async void colViewReapro_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Montre montreSelect = (Montre)e.CurrentSelection.FirstOrDefault();
        await Navigation.PushAsync(new PageDetailsReapro(montreSelect));
    }
}