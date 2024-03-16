namespace GestionStockEW;

public partial class PageMontres : ContentPage
{
	public PageMontres()
	{
		InitializeComponent();
	}
    private async void ContentPage_Loaded(object sender, EventArgs e)
    {
        try
        {
            int? marque = null;
            this.colViewMontre.ItemsSource = await Contexte.GetMontres(marque);
            List<Marque> lesM = await Contexte.GetMarques(null);
            pickMarque.ItemsSource = lesM;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erreur", ex.Message, "OK");
        }
    }

    private async void colViewMontre_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Montre montreSelect = (Montre)e.CurrentSelection.FirstOrDefault();
        await Navigation.PushAsync(new PageDetails(montreSelect));

    }

    private async void pickMarque_SelectedIndexChanged(object sender, EventArgs e)
    {
        Marque laM = pickMarque.SelectedItem as Marque;
        if (radioDecroissant.IsChecked)
        {
            colViewMontre.ItemsSource = await Contexte.GetMontresDesc(laM.Id);
        }
        else
        {
            colViewMontre.ItemsSource = await Contexte.GetMontres(laM.Id);
        }
    }

    private async void radio_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        Marque laM = new Marque();
        if(pickMarque.SelectedItem != null)
        {
            laM = pickMarque.SelectedItem as Marque;
        }
        
        if (radioDecroissant.IsChecked)
        {
            colViewMontre.ItemsSource = await Contexte.GetMontresDesc(laM.Id);
        }
        else
        {
            colViewMontre.ItemsSource = await Contexte.GetMontres(laM.Id);
        }
    }
}