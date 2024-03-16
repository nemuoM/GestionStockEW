using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GestionStockEW
{
    public class Contexte
    {
        public static string url = "http://10.0.2.2/ServiceWebEW"; //Android 10.0.2.2

        public static HttpClient client = new HttpClient();

        public static async Task<Utilisateur> GetUser(string mail, string mdp)
        {
            Utilisateur leUser = null;

            string urlApi = Contexte.url + "/connexion/";
            MultipartFormDataContent form = new MultipartFormDataContent();
            form.Add(new StringContent(mail), name: "mail");
            form.Add(new StringContent(mdp), name: "mdp");

            HttpResponseMessage reponse = await Contexte.client.PostAsync(urlApi, form);
            if(reponse.IsSuccessStatusCode)
            {
                string resultat = await reponse.Content.ReadAsStringAsync();
                if(resultat.Contains("false") == false) //Si le résultat ne contient pas la chaine False : il existe un utilisateur
                {
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;
                    leUser = JsonSerializer.Deserialize<Utilisateur>(resultat, options);
                }
                //Sinon le login et le mot de passe n'existe pas, alors leUser reste null
            }
            else
            {
                throw new Exception("Problème de connexion. Merci de réessayer ultérieurement."); //Lève une exception si la connexion n'a pas aboutie
            }
            return leUser;
        }

        public static async Task<List<Marque>> GetMarques(int? id)
        {
            string urlApi;
            if (id == null)
            {
                urlApi = Contexte.url + "/marque/";
            }
            else
            {
                urlApi = Contexte.url + "/marque/" + id + "/";
            }
            HttpResponseMessage resultatRequete = await Contexte.client.GetAsync(new Uri(urlApi));
            if (resultatRequete.IsSuccessStatusCode)
            {
                string contenu = await resultatRequete.Content.ReadAsStringAsync();

                JsonSerializerOptions options = new JsonSerializerOptions();
                options.PropertyNameCaseInsensitive = true;
                List<Marque> lesMarques = JsonSerializer.Deserialize<List<Marque>>(contenu, options);

                return lesMarques;
            }
            else
            {
                throw new Exception("Erreur au chargement des données : " + resultatRequete.StatusCode.ToString());
            }
        }

        public static async Task<List<Genre>> GetGenre(int? id)
        {
            string urlApi;
            if (id == null)
            {
                urlApi = Contexte.url + "/genre/";
            }
            else
            {
                urlApi = Contexte.url + "/genre/" + id + "/";
            }
            HttpResponseMessage resultatRequete = await Contexte.client.GetAsync(new Uri(urlApi));
            if (resultatRequete.IsSuccessStatusCode)
            {
                string contenu = await resultatRequete.Content.ReadAsStringAsync();

                JsonSerializerOptions options = new JsonSerializerOptions();
                options.PropertyNameCaseInsensitive = true;
                List<Genre> lesGenre = JsonSerializer.Deserialize<List<Genre>>(contenu, options);

                return lesGenre;
            }
            else
            {
                throw new Exception("Erreur au chargement des données : " + resultatRequete.StatusCode.ToString());
            }
        }

        public static async Task<List<Couleur>> GetCouleur(int? id)
        {
            string urlApi;
            if (id == null)
            {
                urlApi = Contexte.url + "/couleur/";
            }
            else
            {
                urlApi = Contexte.url + "/couleur/" + id + "/";
            }
            HttpResponseMessage resultatRequete = await Contexte.client.GetAsync(new Uri(urlApi));
            if (resultatRequete.IsSuccessStatusCode)
            {
                string contenu = await resultatRequete.Content.ReadAsStringAsync();

                JsonSerializerOptions options = new JsonSerializerOptions();
                options.PropertyNameCaseInsensitive = true;
                List<Couleur> lesCouleur = JsonSerializer.Deserialize<List<Couleur>>(contenu, options);

                return lesCouleur;
            }
            else
            {
                throw new Exception("Erreur au chargement des données : " + resultatRequete.StatusCode.ToString());
            }
        }

        public static async Task<List<Style>> GetStyle(int? id)
        {
            string urlApi;
            if (id == null)
            {
                urlApi = Contexte.url + "/style/";
            }
            else
            {
                urlApi = Contexte.url + "/style/" + id + "/";
            }
            HttpResponseMessage resultatRequete = await Contexte.client.GetAsync(new Uri(urlApi));
            if (resultatRequete.IsSuccessStatusCode)
            {
                string contenu = await resultatRequete.Content.ReadAsStringAsync();

                JsonSerializerOptions options = new JsonSerializerOptions();
                options.PropertyNameCaseInsensitive = true;
                List<Style> lesStyle = JsonSerializer.Deserialize<List<Style>>(contenu, options);

                return lesStyle;
            }
            else
            {
                throw new Exception("Erreur au chargement des données : " + resultatRequete.StatusCode.ToString());
            }
        }

        public static async Task<List<Mouvement>> GetMouvement(int? id)
        {
            string urlApi;
            if (id == null)
            {
                urlApi = Contexte.url + "/mouvement/";
            }
            else
            {
                urlApi = Contexte.url + "/mouvement/" + id + "/";
            }
            HttpResponseMessage resultatRequete = await Contexte.client.GetAsync(new Uri(urlApi));
            if (resultatRequete.IsSuccessStatusCode)
            {
                string contenu = await resultatRequete.Content.ReadAsStringAsync();

                JsonSerializerOptions options = new JsonSerializerOptions();
                options.PropertyNameCaseInsensitive = true;
                List<Mouvement> lesMouvement = JsonSerializer.Deserialize<List<Mouvement>>(contenu, options);

                return lesMouvement;
            }
            else
            {
                throw new Exception("Erreur au chargement des données : " + resultatRequete.StatusCode.ToString());
            }
        }

        public static async Task<List<Matiere>> GetMatiere(int? id)
        {
            string urlApi;
            if (id == null)
            {
                urlApi = Contexte.url + "/matiere/";
            }
            else
            {
                urlApi = Contexte.url + "/matiere/" + id + "/";
            }
            HttpResponseMessage resultatRequete = await Contexte.client.GetAsync(new Uri(urlApi));
            if (resultatRequete.IsSuccessStatusCode)
            {
                string contenu = await resultatRequete.Content.ReadAsStringAsync();

                JsonSerializerOptions options = new JsonSerializerOptions();
                options.PropertyNameCaseInsensitive = true;
                List<Matiere> lesMatiere = JsonSerializer.Deserialize<List<Matiere>>(contenu, options);

                return lesMatiere;
            }
            else
            {
                throw new Exception("Erreur au chargement des données : " + resultatRequete.StatusCode.ToString());
            }
        }


        public static async Task<List<Montre>> GetMontres(int? marque)
        {
            string urlApi;
            if (marque == null)
            {
                urlApi = Contexte.url + "/montresa/";
            }
            else
            {
                urlApi = Contexte.url + "/montresa/" + marque + "/";
            }

            HttpResponseMessage respsonse = await Contexte.client.GetAsync(new Uri(urlApi));
            if (respsonse.IsSuccessStatusCode)
            {
                string contenu = await respsonse.Content.ReadAsStringAsync();
                JsonSerializerOptions option = new JsonSerializerOptions();
                option.PropertyNameCaseInsensitive = true;
                List<Montre> lesMontres = JsonSerializer.Deserialize<List<Montre>>(contenu, option);

                List<Marque> lesMarques = await Contexte.GetMarques(null);
                List<Genre> lesGenres = await Contexte.GetGenre(null);
                List<Couleur> lesCouleurs = await Contexte.GetCouleur(null);
                List<Style> lesStyles = await Contexte.GetStyle(null);
                List<Mouvement> lesMouvements = await Contexte.GetMouvement(null);
                List<Matiere> lesMatieres = await Contexte.GetMatiere(null);

                foreach (Montre uneM in lesMontres)
                {
                    uneM.Marque = (from uneMar in lesMarques
                                   where uneMar.Id == uneM.idMarque
                                   select uneMar).FirstOrDefault();
                    uneM.Genre = (from unG in lesGenres
                                  where unG.Id == uneM.idGenre
                                  select unG).FirstOrDefault();
                    uneM.Couleur = (from uneC in lesCouleurs
                                    where uneC.Id == uneM.idCouleur
                                    select uneC).FirstOrDefault();
                    uneM.Style = (from unS in lesStyles
                                  where unS.Id == uneM.idStyle
                                  select unS).FirstOrDefault();
                    uneM.Mouvement = (from unMouv in lesMouvements
                                      where unMouv.Id == uneM.idMouvement
                                      select unMouv).FirstOrDefault();
                    uneM.MatiereB = (from uneMatB in lesMatieres
                                     where uneMatB.Id == uneM.idMatiereB
                                     select uneMatB).FirstOrDefault();
                    uneM.MatiereC = (from uneMatC in lesMatieres
                                     where uneMatC.Id == uneM.idMatiereC
                                     select uneMatC).FirstOrDefault();
                }
                return lesMontres;
            }
            else
            {
                throw new Exception("Erreur au chargement des données : " + respsonse.StatusCode.ToString());
            }
        }

        public static async Task<List<Montre>> GetMontresDesc(int? marque)
        {
            string urlApi;
            if (marque == null || marque == 0)
            {
                urlApi = Contexte.url + "/montresd/";
            }
            else
            {
                urlApi = Contexte.url + "/montresd/" + marque + "/";
            }

            HttpResponseMessage respsonse = await Contexte.client.GetAsync(new Uri(urlApi));
            if (respsonse.IsSuccessStatusCode)
            {
                string contenu = await respsonse.Content.ReadAsStringAsync();
                JsonSerializerOptions option = new JsonSerializerOptions();
                option.PropertyNameCaseInsensitive = true;
                List<Montre> lesMontres = JsonSerializer.Deserialize<List<Montre>>(contenu, option);

                List<Marque> lesMarques = await Contexte.GetMarques(null);
                List<Genre> lesGenres = await Contexte.GetGenre(null);
                List<Couleur> lesCouleurs = await Contexte.GetCouleur(null);
                List<Style> lesStyles = await Contexte.GetStyle(null);
                List<Mouvement> lesMouvements = await Contexte.GetMouvement(null);
                List<Matiere> lesMatieres = await Contexte.GetMatiere(null);

                foreach (Montre uneM in lesMontres)
                {
                    uneM.Marque = (from uneMar in lesMarques
                                   where uneMar.Id == uneM.idMarque
                                   select uneMar).FirstOrDefault();
                    uneM.Genre = (from unG in lesGenres
                                  where unG.Id == uneM.idGenre
                                  select unG).FirstOrDefault();
                    uneM.Couleur = (from uneC in lesCouleurs
                                    where uneC.Id == uneM.idCouleur
                                    select uneC).FirstOrDefault();
                    uneM.Style = (from unS in lesStyles
                                  where unS.Id == uneM.idStyle
                                  select unS).FirstOrDefault();
                    uneM.Mouvement = (from unMouv in lesMouvements
                                      where unMouv.Id == uneM.idMouvement
                                      select unMouv).FirstOrDefault();
                    uneM.MatiereB = (from uneMatB in lesMatieres
                                     where uneMatB.Id == uneM.idMatiereB
                                     select uneMatB).FirstOrDefault();
                    uneM.MatiereC = (from uneMatC in lesMatieres
                                     where uneMatC.Id == uneM.idMatiereC
                                     select uneMatC).FirstOrDefault();
                }
                return lesMontres;
            }
            else
            {
                throw new Exception("Erreur au chargement des données : " + respsonse.StatusCode.ToString());
            }
        }

        public static async Task<List<Statut>> GetStatuts()
        {
            string urlApi = Contexte.url + "/statut/";

            HttpResponseMessage resultatRequete = await Contexte.client.GetAsync(new Uri(urlApi));
            if (resultatRequete.IsSuccessStatusCode)
            {
                string contenu = await resultatRequete.Content.ReadAsStringAsync();

                JsonSerializerOptions options = new JsonSerializerOptions();
                options.PropertyNameCaseInsensitive = true;
                List<Statut> lesStatut = JsonSerializer.Deserialize<List<Statut>>(contenu, options);

                return lesStatut;
            }
            else
            {
                throw new Exception("Erreur au chargement des données : " + resultatRequete.StatusCode.ToString());
            }
        }

        public static async Task<List<Demande>> GetDemandes()
        {
            string urlApi = Contexte.url + "/demande/";

            HttpResponseMessage resultatRequete = await Contexte.client.GetAsync(new Uri(urlApi));
            if (resultatRequete.IsSuccessStatusCode)
            {
                string contenu = await resultatRequete.Content.ReadAsStringAsync();

                JsonSerializerOptions options = new JsonSerializerOptions();
                options.PropertyNameCaseInsensitive = true;
                List<Demande> lesDemande = JsonSerializer.Deserialize<List<Demande>>(contenu, options);

                List<Marque> lesMarques = await Contexte.GetMarques(null);

                foreach (Demande uneD in lesDemande)
                {
                    uneD.Marque = (from uneMar in lesMarques
                                   where uneMar.Id == uneD.idMarque
                                   select uneMar).FirstOrDefault();
                    
                }

                return lesDemande;
            }
            else
            {
                throw new Exception("Erreur au chargement des données : " + resultatRequete.StatusCode.ToString());
            }
        }

        public static async Task<List<DetailsDmd>> GetDetailsDmds(int idD)
        {
            string urlApi = Contexte.url + $"/demande/details/{idD}/";

            HttpResponseMessage resultatRequete = await Contexte.client.GetAsync(new Uri(urlApi));
            if (resultatRequete.IsSuccessStatusCode)
            {
                string contenu = await resultatRequete.Content.ReadAsStringAsync();

                JsonSerializerOptions options = new JsonSerializerOptions();
                options.PropertyNameCaseInsensitive = true;
                List<DetailsDmd> laDemande = JsonSerializer.Deserialize<List<DetailsDmd>>(contenu, options);

                List<Montre> lesMontres = await Contexte.GetMontres(null);

                foreach (DetailsDmd uneD in laDemande)
                {
                    uneD.Montre = (from uneM in lesMontres
                                   where uneM.Id == uneD.idMontre
                                   select uneM).FirstOrDefault();
                }

                return laDemande;
            }
            else
            {
                throw new Exception("Erreur au chargement des données : " + resultatRequete.StatusCode.ToString());
            }
        }

        public static async Task<List<Changement_Statut>> GetChangement_Statuts(string idC)
        {
            string urlApi = Contexte.url + $"/changement/{idC}/";
            HttpResponseMessage resultatRequete = await Contexte.client.GetAsync(new Uri(urlApi));
            if (resultatRequete.IsSuccessStatusCode)
            {
                string contenu = await resultatRequete.Content.ReadAsStringAsync();

                JsonSerializerOptions options = new JsonSerializerOptions();
                options.PropertyNameCaseInsensitive = true;
                List<Changement_Statut> lesChangmt = JsonSerializer.Deserialize<List<Changement_Statut>>(contenu, options);

                List<Statut> lesStatuts = await Contexte.GetStatuts();
                foreach (Changement_Statut unC in lesChangmt)
                {
                    unC.Statut = (from unS in lesStatuts
                                  where unS.Id == unC.idStatut
                                  select unS).FirstOrDefault();
                }
                return lesChangmt;
            }
            else
            {
                throw new Exception("Erreur au chargement des données : " + resultatRequete.StatusCode.ToString());
            }
        }

        public static async Task<List<Utilisateur>> GetUtilisateurs()
        {
            string urlApi = Contexte.url + "/client/";
            HttpResponseMessage resultatRequete = await Contexte.client.GetAsync(new Uri(urlApi));
            if (resultatRequete.IsSuccessStatusCode)
            {
                string contenu = await resultatRequete.Content.ReadAsStringAsync();

                JsonSerializerOptions options = new JsonSerializerOptions();
                options.PropertyNameCaseInsensitive = true;
                List<Utilisateur> lesClient = JsonSerializer.Deserialize<List<Utilisateur>>(contenu, options);

                return lesClient;
            }
            else
            {
                throw new Exception("Erreur au chargement des données : " + resultatRequete.StatusCode.ToString());
            }
        }

        public static async Task<List<Transporteur>> GetTransporteurs()
        {
            string urlApi = Contexte.url + "/transporteur/";
            HttpResponseMessage resultatRequete = await Contexte.client.GetAsync(new Uri(urlApi));
            if (resultatRequete.IsSuccessStatusCode)
            {
                string contenu = await resultatRequete.Content.ReadAsStringAsync();

                JsonSerializerOptions options = new JsonSerializerOptions();
                options.PropertyNameCaseInsensitive = true;
                List<Transporteur> lesTranporteurs = JsonSerializer.Deserialize<List<Transporteur>>(contenu, options);

                return lesTranporteurs;
            }
            else
            {
                throw new Exception("Erreur au chargement des données : " + resultatRequete.StatusCode.ToString());
            }
        }

        public static async Task<List<Commande>> GetCommandes(int? idC)
        {
            string urlApi;
            if (idC == null)
            {
                urlApi = Contexte.url + "/commande/";
            }
            else
            {
                urlApi = Contexte.url + "/commande/" + idC + "/";
            }
            HttpResponseMessage resultatRequete = await Contexte.client.GetAsync(new Uri(urlApi));
            if (resultatRequete.IsSuccessStatusCode)
            {
                string contenu = await resultatRequete.Content.ReadAsStringAsync();

                JsonSerializerOptions options = new JsonSerializerOptions();
                options.PropertyNameCaseInsensitive = true;
                List<Commande> lesCmds = JsonSerializer.Deserialize<List<Commande>>(contenu, options);

                List<Statut> lesStatuts = await Contexte.GetStatuts();
                List<Transporteur> lesT = await Contexte.GetTransporteurs();
                List<Utilisateur> lesUtils = await Contexte.GetUtilisateurs();
                foreach (Commande unC in lesCmds)
                {
                    unC.Statut = (from unS in lesStatuts
                                  where unS.Id == unC.idStatut
                                  select unS).FirstOrDefault();
                    unC.Transporteur = (from unT in lesT
                                        where unT.Id == unC.idTransporteur
                                        select unT).FirstOrDefault();
                    unC.Utilisateur = (from unU in lesUtils
                                       where unU.Id == unC.idUtil
                                       select unU).FirstOrDefault();
                    unC.LesChangements = await Contexte.GetChangement_Statuts(unC.Id.ToString());
                }
                return lesCmds;
            }
            else
            {
                throw new Exception("Erreur au chargement des données : " + resultatRequete.StatusCode.ToString());
            }
        }

        public static async Task<List<Montre>> GetReapro()
        {
            string urlApi = Contexte.url + "/reapro/";
            HttpResponseMessage resultatRequete = await Contexte.client.GetAsync(new Uri(urlApi));
            if (resultatRequete.IsSuccessStatusCode)
            {
                string contenu = await resultatRequete.Content.ReadAsStringAsync();

                JsonSerializerOptions options = new JsonSerializerOptions();
                options.PropertyNameCaseInsensitive = true;
                List<Montre> lesMontres = JsonSerializer.Deserialize<List<Montre>>(contenu, options);

                List<Marque> lesMarques = await Contexte.GetMarques(null);

                foreach (Montre uneM in lesMontres)
                {
                    uneM.Marque = (from uneMar in lesMarques
                                   where uneMar.Id == uneM.idMarque
                                   select uneMar).FirstOrDefault();
                }
                return lesMontres;
            }
            else
            {
                throw new Exception("Erreur au chargement des données : " + resultatRequete.StatusCode.ToString());
            }
        }

        public static async Task<bool> UpdateStock(int id, string newS)
        {
            string urlApi = Contexte.url + "/reapro/update/";

            MultipartFormDataContent form = new MultipartFormDataContent();
            form.Add(new StringContent(id.ToString()), name: "id");
            form.Add(new StringContent(newS), name: "newS");

            HttpResponseMessage response = await Contexte.client.PostAsync(new Uri(urlApi), form);
            if (response.IsSuccessStatusCode)
            {
                string contenu = await response.Content.ReadAsStringAsync();
                if (contenu[0] == '1') //Cela signifie qu'une ligne a bien été mise à jour !
                {
                    return true;
                }
                else
                {
                    throw new Exception($"Erreur au réapprovisionnement: {contenu}");
                }
            }
            else
            {
                throw new Exception($"Erreur au réapprovisionnement: {response.StatusCode.ToString()}");
            }
        }

        public static async Task<bool> UpdateSeuil(int id, string newS)
        {
            string urlApi = Contexte.url + "/montre/update/";

            MultipartFormDataContent form = new MultipartFormDataContent();
            form.Add(new StringContent(id.ToString()), name: "id");
            form.Add(new StringContent(newS), name: "newS");

            HttpResponseMessage response = await Contexte.client.PostAsync(new Uri(urlApi), form);
            if (response.IsSuccessStatusCode)
            {
                string contenu = await response.Content.ReadAsStringAsync();
                if (contenu[0] == '1') //Cela signifie qu'une ligne a bien été mise à jour !
                {
                    return true;
                }
                else
                {
                    throw new Exception($"Erreur au réapprovisionnement: {contenu}");
                }
            }
            else
            {
                throw new Exception($"Erreur au réapprovisionnement: {response.StatusCode.ToString()}");
            }
        }
    }
}
