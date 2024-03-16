namespace GestionStockEW;

public partial class PageDetailsCmd : ContentPage
{
	public PageDetailsCmd(Commande cmd)
	{
		InitializeComponent();
		colViewChgmnt.ItemsSource = cmd.LesChangements;
		if (cmd.LesChangements.Count != 0)
		{
			lblDateCmd.Text = $"Commande effectué le {cmd.dateCmd.ToString("dd/MM/yyyy")}";
			lblDateCmd.IsVisible = true ;
			lblVide.IsVisible = false ;
		}
		
	}
}