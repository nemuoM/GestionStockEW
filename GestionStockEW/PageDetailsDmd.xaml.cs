
namespace GestionStockEW;

public partial class PageDetailsDmd : ContentPage
{
	public PageDetailsDmd(Demande uneD)
	{
		InitializeComponent();
        colViewDMontre.ItemsSource = uneD.Le
    }
}