namespace GestionStockEW;

public partial class PageDetailsReapro : ContentPage
{
	public PageDetailsReapro(Montre montre)
	{
		InitializeComponent();
        Application.Current.Resources["montre"] = montre;
        imgM.Source = montre.Image;
        lblRea.Text += $"{montre.Nom}:";
        entryStock.Text = montre.Stock.ToString();
        lblFour.Text = $"Cette montre nous est fournit par '{montre.Marque.Libelle}'";
        lblAdresse.Text += montre.Marque.Adresse;
        lblVille.Text += montre.Marque.Ville;
        lblCp.Text += montre.Marque.Cp;
    }

    private void btnMoins_Clicked(object sender, EventArgs e)
    {
        int ancienneVal = int.Parse(entryStock.Text);
        ancienneVal--;
        entryStock.Text = ancienneVal.ToString();
        grpModif.IsVisible = true;
        if (ancienneVal <= 0)
        {
            btnMoins.IsEnabled = false;
        }
    }

    private void btnPlus_Clicked(object sender, EventArgs e)
    {
        int ancienneVal = int.Parse(entryStock.Text);
        ancienneVal++;
        entryStock.Text = ancienneVal.ToString();
        grpModif.IsVisible = true;
        if (ancienneVal >= 1)
        {
            btnMoins.IsEnabled = true;
        }
    }

    private async void btnSave_Clicked(object sender, EventArgs e)
    {
        try
        {
            if(int.Parse(entryStock.Text) <= ((Montre)Application.Current.Resources["montre"]).Seuil)
            {
                throw new Exception("Le réapprovisionnement ne peut pas être inférieur au seuil actuel !");
            }
            if (int.Parse(entryStock.Text) <= ((Montre)Application.Current.Resources["montre"]).Stock)
            {
                throw new Exception("Le nouveau stock ne peut pas être inférieur au stock actuel !");
            }
            bool updateOk = await Contexte.UpdateStock(((Montre)Application.Current.Resources["montre"]).Id, entryStock.Text);
            if (updateOk)
            {
                ((Montre)Application.Current.Resources["montre"]).Stock = int.Parse(entryStock.Text);
                grpModif.IsVisible= false;
            }
            else
            {
                throw new Exception("Échec au réapprovisionnement.");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erreur", ex.Message, "OK");
        }

    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        entryStock.Text = ((Montre)Application.Current.Resources["montre"]).Stock.ToString();
        grpModif.IsVisible = false;
        btnMoins.IsEnabled= true;
    }
}