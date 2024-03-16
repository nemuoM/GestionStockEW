namespace GestionStockEW;

public partial class PageDetails : ContentPage
{
	public PageDetails(Montre montre)
	{
		InitializeComponent();
        Application.Current.Resources["montre"] = montre;
		lblNom.Text = montre.Nom;
        entrySeuil.Text = montre.Seuil.ToString();
        imgM.Source = montre.Image;

        lblMarque.Text += montre.Marque.Libelle;
        lblCouleur.Text += montre.Couleur.Libelle;
        lblGenre.Text += montre.Genre.Libelle;
        lblStyle.Text += montre.Style.Libelle;
        lblMouv.Text += montre.Mouvement.Libelle;
        lblMatB.Text += montre.MatiereB.Libelle;
        lblMatC.Text += montre.MatiereC.Libelle;
    }

    private void btnPlus_Clicked(object sender, EventArgs e)
    {
        int ancienneVal = int.Parse(entrySeuil.Text);
        ancienneVal++;
        entrySeuil.Text = ancienneVal.ToString();
        grpModif.IsVisible = true;
        if (ancienneVal >= 1)
        {
            btnMoins.IsEnabled = true;
        }
    }

    private void btnMoins_Clicked(object sender, EventArgs e)
    {
        int ancienneVal = int.Parse(entrySeuil.Text);
        ancienneVal--;
        entrySeuil.Text = ancienneVal.ToString();
        grpModif.IsVisible = true;
        if (ancienneVal <= 0)
        {
            btnMoins.IsEnabled = false;
        }
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        entrySeuil.Text = ((Montre)Application.Current.Resources["montre"]).Seuil.ToString();
        grpModif.IsVisible = false;
    }

    private async void btnSave_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (int.Parse(entrySeuil.Text) <= ((Montre)Application.Current.Resources["montre"]).Seuil)
            {
                throw new Exception("Le nouveau seuil ne peut pas être inférieur au seuil actuel !");
            }
            if (int.Parse(entrySeuil.Text) <= ((Montre)Application.Current.Resources["montre"]).Stock)
            {
                throw new Exception("Le nouveau seuil ne peut pas être inférieur au stock actuel !");
            }
            bool updateOk = await Contexte.UpdateSeuil(((Montre)Application.Current.Resources["montre"]).Id, entrySeuil.Text);
            if (updateOk)
            {
                ((Montre)Application.Current.Resources["montre"]).Seuil = int.Parse(entrySeuil.Text);
                grpModif.IsVisible = false;
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
}