<?php
header ("Cache-Control: no-cache, must-revalidate");
header ("pragma: no-cache");

try{
    $pdo_options[PDO::ATTR_ERRMODE] = PDO::ERRMODE_EXCEPTION;
	$bdd = new PDO('mysql:host=127.0.0.1:3307;dbname=db_emporium_sw', 'root', '');
	$bdd->query("SET NAMES utf8");  

    if($_SERVER['REQUEST_METHOD'] == 'GET')
    {
        switch($_GET['data'])
        {
            case 'client':
                $req = $bdd->prepare('SELECT idClient, nom, prenom FROM client');
                $req->execute();
                $results = $req->fetchAll(PDO::FETCH_ASSOC);
                print(json_encode($results));
                break;
            case 'statut':
                $req = $bdd->prepare('SELECT idStatut, libelle FROM statut');
                $req->execute();
                $results = $req->fetchAll(PDO::FETCH_ASSOC);
                print(json_encode($results));
                break;
            case 'transporteur':
                $req = $bdd->prepare('SELECT idTransporteur, nom FROM transporteur');
                $req->execute();
                $results = $req->fetchAll(PDO::FETCH_ASSOC);
                print(json_encode($results));
                break;
            case 'changement':
                $req = $bdd->prepare('SELECT idStatut, dateChangement FROM changement_statut WHERE idCommande = :idC');
                $req->execute(array('idC' => $_GET['idC']));
                $results = $req->fetchAll(PDO::FETCH_ASSOC);
                print(json_encode($results));
                break;
            case 'marque':
                if(!empty($_GET['idM'])){
                    $req = $bdd->prepare('SELECT idMarque, libelle, adresse, cp, ville, telephone FROM marque WHERE idMarque = :idM');
                    $req->execute(array('idM' => $_GET['idM']));

                }else{
                    $req = $bdd->prepare('SELECT idMarque, libelle, adresse, cp, ville, telephone FROM marque');
                    $req->execute();
                }
                $results = $req->fetchAll(PDO::FETCH_ASSOC);
                print(json_encode($results));
                break;
            
            case 'genre':
                if(!empty($_GET['idG'])){
                    $req = $bdd->prepare('SELECT idGenre, libelle FROM genre WHERE idGenre = :idM');
                    $req->execute(array('idM' => $_GET['idG']));

                }else{
                    $req = $bdd->prepare('SELECT idGenre, libelle FROM genre');
                    $req->execute();
                }
                $results = $req->fetchAll(PDO::FETCH_ASSOC);
                print(json_encode($results));
                break;

            case 'couleur':
                if(!empty($_GET['idC'])){
                    $req = $bdd->prepare('SELECT idCouleur, libelle FROM couleur WHERE idCouleur = :idM');
                    $req->execute(array('idM' => $_GET['idC']));

                }else{
                    $req = $bdd->prepare('SELECT idCouleur, libelle FROM couleur');
                    $req->execute();
                }
                $results = $req->fetchAll(PDO::FETCH_ASSOC);
                print(json_encode($results));
                break;

            case 'style':
                if(!empty($_GET['idS'])){
                    $req = $bdd->prepare('SELECT idStyle, libelle FROM style WHERE idStyle = :idM');
                    $req->execute(array('idM' => $_GET['idS']));

                }else{
                    $req = $bdd->prepare('SELECT idStyle, libelle FROM style');
                    $req->execute();
                }
                $results = $req->fetchAll(PDO::FETCH_ASSOC);
                print(json_encode($results));
                break;

            case 'mouvement':
                if(!empty($_GET['idMouv'])){
                    $req = $bdd->prepare('SELECT idMouvement, libelle FROM mouvement WHERE idMouvement = :idM');
                    $req->execute(array('idM' => $_GET['idMouv']));

                }else{
                    $req = $bdd->prepare('SELECT idMouvement, libelle FROM mouvement');
                    $req->execute();
                }
                $results = $req->fetchAll(PDO::FETCH_ASSOC);
                print(json_encode($results));
                break;

            case 'matiere':
                if(!empty($_GET['idMat'])){
                    $req = $bdd->prepare('SELECT idMatiere, libelle FROM matiere WHERE idMatiere = :idM');
                    $req->execute(array('idM' => $_GET['idMat']));

                }else{
                    $req = $bdd->prepare('SELECT idMatiere, libelle FROM matiere');
                    $req->execute();
                }
                $results = $req->fetchAll(PDO::FETCH_ASSOC);
                print(json_encode($results));
                break;
            case 'reapro':
                $req = $bdd->prepare('SELECT idMontre, image, nom, prix, stock, seuil_alerte, idMarque, idGenre, idCouleur, idStyle, idMouvement, idMatiereCadran, idMatiereBracelet FROM montre WHERE stock <= seuil_alerte');
                $req->execute();
                $results = $req->fetchAll(PDO::FETCH_ASSOC);
                print(json_encode($results));
                break;
            case 'cmd':
                if(!empty($_GET['idC'])){
                    $req = $bdd->prepare('SELECT idCommande, dateCmd, idStatut, idTransporteur, idClient FROM commande WHERE idCommande = :idC');
                    $req->execute(array('idC' => $_GET['idC']));

                }else{
                    $req = $bdd->prepare('SELECT idCommande, dateCmd, idStatut, idTransporteur, idClient FROM commande');
                    $req->execute();
                }
                $results = $req->fetchAll(PDO::FETCH_ASSOC);
                foreach($results as &$result) {
                    if($result['idTransporteur'] === null) {
                        $result['idTransporteur'] = 0;
                    }
                }
                print(json_encode($results));
                break;
            case 'dmd':
                $req = $bdd->prepare('SELECT idDemande, idMarque FROM demande_four WHERE estValide = 0');
                $req->execute();
                $results = $req->fetchAll(PDO::FETCH_ASSOC);
                print(json_encode($results));
                break;
            case 'details':
                $req = $bdd->prepare('SELECT idMontre FROM details_dmd WHERE idDemande = :idD');
                $req->execute(array('idD' => $_GET['idD']));
                $results = $req->fetchAll(PDO::FETCH_ASSOC);
                print(json_encode($results));
                break;

            case 'montresasc':
                if(!empty($_GET['idM'])){
                    $req = $bdd->prepare('SELECT idMontre, image, nom, prix, stock, seuil_alerte, idMarque, idGenre, idCouleur, idStyle, idMouvement, idMatiereCadran, idMatiereBracelet FROM montre WHERE idMarque = :idM ORDER BY stock asc');
                    $req->execute(array('idM' => $_GET['idM']));

                }else{
                    $req = $bdd->prepare('SELECT idMontre, image, nom, prix, stock, seuil_alerte, idMarque, idGenre, idCouleur, idStyle, idMouvement, idMatiereCadran, idMatiereBracelet FROM montre ORDER BY stock asc');
                    $req->execute();
                }
                $results = $req->fetchAll(PDO::FETCH_ASSOC);
                print(json_encode($results));
                break;
            
            case 'montresdesc':
                if(!empty($_GET['idM'])){
                    $req = $bdd->prepare('SELECT idMontre, image, nom, prix, stock, seuil_alerte, idMarque, idGenre, idCouleur, idStyle, idMouvement, idMatiereCadran, idMatiereBracelet FROM montre WHERE idMarque = :idM ORDER BY stock desc');
                    $req->execute(array('idM' => $_GET['idM']));

                }else{
                    $req = $bdd->prepare('SELECT idMontre, image, nom, prix, stock, seuil_alerte, idMarque, idGenre, idCouleur, idStyle, idMouvement, idMatiereCadran, idMatiereBracelet FROM montre ORDER BY stock desc');
                    $req->execute();
                }
                $results = $req->fetchAll(PDO::FETCH_ASSOC);
                print(json_encode($results));
                break;
        }

    } else if ($_SERVER['REQUEST_METHOD'] == 'POST'){
        switch($_GET['action'])
        {
            case 'connexion':
                $req = $bdd->prepare('SELECT idClient, nom, prenom FROM client WHERE mail = :mail and mdp = :mdp and idRole != 3');
                $req->execute(array('mail' => $_POST['mail'],'mdp' => $_POST['mdp']));
                $resultat = $req->fetch(PDO::FETCH_ASSOC);
				print(json_encode($resultat));
				break;
            
            case 'reapro':
                $bdd->beginTransaction();
                $req = $bdd->prepare('UPDATE montre SET stock = :nbM WHERE idMontre = :idM');
                $req->execute(array('nbM' => $_POST['newS'],
                                    'idM' => $_POST['id']));
                print("1");
                $bdd->commit();
                break;
            case 'seuil':
                $bdd->beginTransaction();
                $req = $bdd->prepare('UPDATE montre SET seuil_alerte = :nbM WHERE idMontre = :idM');
                $req->execute(array('nbM' => $_POST['newS'],
                                    'idM' => $_POST['id']));
                print("1");
                $bdd->commit();
                break;
        }

    } else if ($_SERVER['REQUEST_METHOD'] == 'DELETE'){

    }
}
catch (Exception $e)
{
	die('Erreur : ' . $e->getMessage());
}