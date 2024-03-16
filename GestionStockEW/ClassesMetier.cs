using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestionStockEW
{
    public class Utilisateur
    {
        [JsonPropertyName("idClient")]
        public int Id { get; set; }
        public string Nom {  get; set; }
        public string Prenom { get; set; }
    }

    public class Marque
    {
        [JsonPropertyName("idMarque")]
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Adresse { get; set; }
        public string Cp {  get; set; }
        public string Ville { get; set; }
        public string Telephone { get; set;}
        public override string ToString()
        {
            return $"{this.Libelle}";
        }
    }

    public class Genre
    {
        [JsonPropertyName("idGenre")]
        public int Id { get; set; }
        public string Libelle { get; set; }
    }

    public class Couleur
    {
        [JsonPropertyName("idCouleur")]
        public int Id { get; set; }
        public string Libelle { get; set;}
    }

    public class Style
    {
        [JsonPropertyName("idStyle")]
        public int Id { get; set; }
        public string Libelle { get; set;}
    }

    public class Mouvement
    {
        [JsonPropertyName("idMouvement")]
        public int Id { get; set; }
        public string Libelle { get; set;}
    }

    public class Matiere
    {
        [JsonPropertyName("idMatiere")]
        public int Id { get; set; }
        public string Libelle { get; set;}
    }

    public class Montre
    {
        [JsonPropertyName("idMontre")]
        public int Id { get; set; }
        public string Image { get; set; }
        public string Nom { get; set; }
        public float Prix { get; set; }
        public int Stock { get; set; }

        [JsonPropertyName("seuil_alerte")]
        public int Seuil { get; set; }

        public int idMarque { get; set; }
        public Marque Marque { get; set;}

        public int idGenre { get; set; }
        public Genre Genre { get; set; }

        public int idCouleur { get; set; }
        public Couleur Couleur { get; set; }

        public int idStyle { get; set; }
        public Style Style { get; set; }

        public int idMouvement { get; set; }
        public Mouvement Mouvement { get; set; }

        [JsonPropertyName("idMatiereCadran")]
        public int idMatiereC {  get; set; }
        public Matiere MatiereC { get; set; }

        [JsonPropertyName("idMatiereBracelet")]
        public int idMatiereB { get; set; }
        public Matiere MatiereB { get; set; }

        public string Affichage
        {
            get { return $"Réf. {this.Id}\n{this.Nom}\nStock: {this.Stock} - Prix: {this.Prix} €"; }
        }

        public string AffichageR
        {
            get { return $"{this.Nom}\nStock: {this.Stock}\nSeuil de Réaprovisionnement: {this.Seuil}"; }
        }
    }

    public class Statut
    {
        [JsonPropertyName("idStatut")]
        public int Id { get; set; }
        public string Libelle { get; set;}
    }

    public class Demande
    {
        [JsonPropertyName("idDemande")]
        public int Id { get; set; }
        public int idMarque { get; set; }
        public Marque Marque { get; set; }

        List<DetailsDmd> LesMontres { get; set; }

        public string Affichage
        {
            get { return $"Demande n°{this.Id}\nAuprès de {this.Marque.Libelle}";  }
        }
    }

    public class DetailsDmd
    {
        public int idMontre { get; set; }
        public Montre Montre { get; set;}
    }

    public class Transporteur
    {
        [JsonPropertyName("idTransporteur")]
        public int Id { get; set; }
        public string Nom { get; set;}
    }

    public class Commande
    {
        [JsonPropertyName("idCommande")]
        public int Id { get; set; }
        public DateTime dateCmd { get; set; }

        public int idStatut { get; set; }
        public Statut Statut { get; set; }
        public int idTransporteur { get; set; }
        public Transporteur Transporteur { get; set; }

        [JsonPropertyName("idClient")]
        public int idUtil { get; set; }
        public Utilisateur Utilisateur { get; set; }
        public List<Changement_Statut> LesChangements {  get; set; }

        public string Affichage1
        {
            get { return $"N° commande: {this.Id}"; }
        }
        public string Affichage2
        {
            get { return $"{this.Utilisateur.Nom} {this.Utilisateur.Prenom}"; }
        }

        public string Affichage3
        {
            get { return $"{this.dateCmd.ToString("dd/MM/yyyy")}      -      Statut: {this.Statut.Libelle}"; }
        }

    }

    public class Changement_Statut
    {
        public int idCommande { get; set; }
        public int idStatut { get; set; }
        public Statut Statut { get; set; }
        public DateTime dateChangement { get; set; }

        public string AffichageD
        {
            get { return $"{this.dateChangement.ToString("dd/MM/yyyy")}"; }
        }
    } 
}
