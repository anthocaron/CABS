namespace CABS.BaseDonnees
{
	public enum NomTable
	{
		actionactivite,
		activite,
		arejoindre,
		beneficiaire,
		beneficiaireactionactivite,
		beneficiaireroutepopoteroulante,
		benevole,
		benevoleactionactivite,
		benevolereunion,
		champactivite,
		couple,
		disponibiliteservice,
		employe,
		employereunion,
		etatcivil,
		evaluationdepannagealimentaire,
		inscriptionatelierjouets,
		inscriptionclubmarche,
		inscriptiondepannagealimentaire,
		inscriptionpopoteroulante,
		inscriptionservice,
		inscriptiontelesurveillancelifeline,
		inscriptiontransportaccompagement,
		inscriptiontransportcommunautaire,
		inscriptionviactive,
		inscriptionvisitesamitie,
		langue,
		languepersonne,
		livraisonpopoteroulante,
		personne,
		reunion,
		routepopoteroulante,
		service,
		souschampactivite,
		statut
	};

	public static class actionactivite
	{
		public static string actaId = "actaId";
		public static string actaDate = "actaDate";
		public static string actId = "actId";
		public static string actaNbBenevolesNonInscrits = "actaNbBenevolesNonInscrits";
	};

	public static class activite
	{
		public static string actId = "actId";
		public static string actNom = "actNom";
		public static string scaId = "scaId";
	};

	public static class arejoindre
	{
		public static string arjId = "arjId";
		public static string arjNom = "arjNom";
		public static string arjPrenom = "arjPrenom";
		public static string arjLien = "arjLien";
		public static string arjTelephone = "arjTelephone";
		public static string perId = "perId";
	};

	public static class beneficiaire
	{
		public static string perId = "perId";
	};

	public static class beneficiaireactionactivite
	{
		public static string perId = "perId";
		public static string actaId = "actaId";
	};

	public static class beneficiaireroutepopoteroulante
	{
		public static string perId = "perId";
		public static string rprId = "rprId";
		public static string brprOrdre = "brprOrdre";
	};

	public static class benevole
	{
		public static string perId = "perId";
		public static string benvNoCarte = "benvNoCarte";
		public static string benvDebutProbation = "benvDebutProbation";
		public static string benvFinProbation = "benvFinProbation";
		public static string benvEnProbation = "benvEnProbation";
	};

	public static class benevoleactionactivite
	{
		public static string benaHeures = "benaHeures";
		public static string perId = "perId";
		public static string actaId = "actaId";
	};

	public static class benevolereunion
	{
		public static string benrHeures = "benrHeures";
		public static string perId = "perId";
		public static string reuId = "reuId";
	};

	public static class champactivite
	{
		public static string chaId = "chaId";
		public static string chaNom = "chaNom";
	};

	public static class couple
	{
		public static string perIdPremier = "perIdPremier";
		public static string perIdDeuxieme = "perIdDeuxieme";
	};

	public static class disponibiliteservice
	{
		public static string perId = "perId";
		public static string serId = "serId";
	};

	public static class employe
	{
		public static string perId = "perId";
	};

	public static class employereunion
	{
		public static string erHeures = "erHeures";
		public static string perId = "perId";
		public static string reuId = "reuId";
	};

	public static class etatcivil
	{
		public static string etaId = "etaId";
		public static string etaNom = "etaNom";
	};

	public static class evaluationdepannagealimentaire
	{
		public static string edaId = "edaId";
		public static string edaNbPersonnes = "edaNbPersonnes";
		public static string edaChomage = "edaChomage";
		public static string edaAideSociale = "edaAideSociale";
		public static string edaTalonPaie = "edaTalonPaie";
		public static string edaPrestationsFamProv = "edaPrestationsFamProv";
		public static string edaPrestationsFamFed = "edaPrestationsFamFed";
		public static string edaPensionAlimentaireRevenu = "edaPensionAlimentaireRevenu";
		public static string edaRRQ = "edaRRQ";
		public static string edaPensionVieillesse = "edaPensionVieillesse";
		public static string edaTPS = "edaTPS";
		public static string edaImpotSolidarite = "edaImpotSolidarite";
		public static string edaNomAutresRevenus1 = "edaNomAutresRevenus1";
		public static string edaAutresRevenus1 = "edaAutresRevenus1";
		public static string edaNomAutresRevenus2 = "edaNomAutresRevenus2";
		public static string edaAutresRevenus2 = "edaAutresRevenus2";
		public static string edaNomAutresRevenus3 = "edaNomAutresRevenus3";
		public static string edaAutresRevenus3 = "edaAutresRevenus3";
		public static string edaHydroQuebec = "edaHydroQuebec";
		public static string edaCableInternetTelephone = "edaCableInternetTelephone";
		public static string edaCellulaire = "edaCellulaire";
		public static string edaLoyerHypotheque = "edaLoyerHypotheque";
		public static string edaChauffage = "edaChauffage";
		public static string edaTaxesScolairesMun = "edaTaxesScolairesMun";
		public static string edaAssuranceLogement = "edaAssuranceLogement";
		public static string edaRemboursementAuto = "edaRemboursementAuto";
		public static string edaAssuranceAuto = "edaAssuranceAuto";
		public static string edaImmatriculationPermis = "edaImmatriculationPermis";
		public static string edaEssenceEntretien = "edaEssenceEntretien";
		public static string edaPensionAlimentaireDepense = "edaPensionAlimentaireDepense";
		public static string edaAssuranceVie = "edaAssuranceVie";
		public static string edaDepensesCourantes = "edaDepensesCourantes";
		public static string edaNomAutreDepenses1 = "edaNomAutreDepenses1";
		public static string edaAutresDepenses1 = "edaAutresDepenses1";
		public static string edaNomAutresDepenses2 = "edaNomAutresDepenses2";
		public static string edaAutresDepenses2 = "edaAutresDepenses2";
		public static string edaNomAutresDepenses3 = "edaNomAutresDepenses3";
		public static string edaAutresDepenses3 = "edaAutresDepenses3";
		public static string edaDate = "edaDate";
		public static string edaAccepte = "edaAccepte";
		public static string edaCommentaires = "edaCommentaires";
		public static string idaId = "idaId";
	};

	public static class inscriptionatelierjouets
	{
		public static string perId = "perId";
		public static string iajNombreEnfants = "iajNombreEnfants";
		public static string iajAgesEnfants = "iajAgesEnfants";
		public static string iajAllocationFamiliale = "iajAllocationFamiliale";
		public static string iajCarteMedicament = "iajCarteMedicament";
		public static string iajCarteAssuranceMaladie = "iajCarteAssuranceMaladie";
		public static string iajPermisConduire = "iajPermisConduire";
		public static string iajProprietaire = "iajProprietaire";
		public static string iajLocataire = "iajLocataire";
		public static string iajBail = "iajBail";
		public static string iajFactures = "iajFactures";
		public static string iajDetailsFactures = "iajDetailsFactures";
		public static string iajPerteEmploi = "iajPerteEmploi";
		public static string iajSeparation = "iajSeparation";
		public static string iajAccidentAutoMaladie = "iajAccidentAutoMaladie";
		public static string iajFaibleRevenu = "iajFaibleRevenu";
		public static string iajAccidentTravail = "iajAccidentTravail";
		public static string iajDemenagement = "iajDemenagement";
		public static string iajAutres = "iajAutres";
		public static string iajDetailsAutres = "iajDetailsAutres";
	};

	public static class inscriptionclubmarche
	{
		public static string perId = "perId";
		public static string icmProblemeCardiaque = "icmProblemeCardiaque";
		public static string icmDouleurPoitrine = "icmDouleurPoitrine";
		public static string icmProblemesOsseux = "icmProblemesOsseux";
		public static string icmRestrictionPhysique = "icmRestrictionPhysique";
		public static string icmDetailsRestrictionPhysique = "icmDetailsRestrictionPhysique";
		public static string icmProblemeSante = "icmProblemeSante";
		public static string icmDetailsProblemeSante = "icmDetailsProblemeSante";
	};

	public static class inscriptiondepannagealimentaire
	{
		public static string idaId = "idaId";
		public static string idaNombreEnfants = "idaNombreEnfants";
		public static string idaAgesEnfants = "idaAgesEnfants";
		public static string idaAllocationFamiliale = "idaAllocationFamiliale";
		public static string idaCarteMedicament = "idaCarteMedicament";
		public static string idaCarteAssuranceMaladie = "idaCarteAssuranceMaladie";
		public static string idaPermisConduire = "idaPermisConduire";
		public static string idaProprietaire = "idaProprietaire";
		public static string idaLocataire = "idaLocataire";
		public static string idaBail = "idaBail";
		public static string idaFactures = "idaFactures";
		public static string idaDetailsFactures = "idaDetailsFactures";
		public static string idaPerteEmploi = "idaPerteEmploi";
		public static string idaSeparation = "idaSeparation";
		public static string idaAccidentAutoMaladie = "idaAccidentAutoMaladie";
		public static string idaFaibleRevenu = "idaFaibleRevenu";
		public static string idaAccidentTravail = "idaAccidentTravail";
		public static string idaDemenagement = "idaDemenagement";
		public static string idaAutres = "idaAutres";
		public static string idaDetailsAutres = "idaDetailsAutres";
		public static string perId = "perId";
	};

	public static class inscriptionpopoteroulante
	{
		public static string perId = "perId";
		public static string iprDiabetique = "iprDiabetique";
		public static string iprConjointDiabetique = "iprConjointDiabetique";
		public static string iprListeAllergies = "iprListeAllergies";
		public static string iprListeAllergiesConjoint = "iprListeAllergiesConjoint";
		public static string iprIndicationsLivraison = "iprIndicationsLivraison";
		public static string iprSolde = "iprSolde";
	};

	public static class inscriptionservice
	{
		public static string perId = "perId";
		public static string insDateDemande = "insDateDemande";
		public static string insCommentaires = "insCommentaires";
		public static string insSuspendu = "insSuspendu";
		public static string serId = "serId";
	};

	public static class inscriptiontelesurveillancelifeline
	{
		public static string perId = "perId";
		public static string itlNoUnite = "itlNoUnite";
	};

	public static class inscriptiontransportaccompagement
	{
		public static string perId = "perId";
		public static string itaNoDossierCLE = "itaNoDossierCLE";
		public static string itaNoDossierCSST = "itaNoDossierCSST";
		public static string itaNomAgentCSST = "itaNomAgentCSST";
		public static string itaPrenomAgentCSST = "itaPrenomAgentCSST";
		public static string itaTelephoneAgentCSST = "itaTelephoneAgentCSST";
		public static string itaMobiliteReduite = "itaMobiliteReduite";
		public static string itaCapaciteAuditive = "itaCapaciteAuditive";
		public static string itaCapaciteVisuelle = "itaCapaciteVisuelle";
		public static string itaMemoire = "itaMemoire";
		public static string itaVuDDN = "itaVuDDN";
	};

	public static class inscriptiontransportcommunautaire
	{
		public static string perId = "perId";
		public static string itcVuDDN = "itcVuDDN";
	};

	public static class inscriptionviactive
	{
		public static string perId = "perId";
		public static string ivProblemeCardiaque = "ivProblemeCardiaque";
		public static string ivDouleurPoitrine = "ivDouleurPoitrine";
		public static string ivProblemesOsseux = "ivProblemesOsseux";
		public static string ivRestrictionPhysique = "ivRestrictionPhysique";
		public static string ivDetailsRestrictionPhysique = "ivDetailsRestrictionPhysique";
		public static string ivProblemeSante = "ivProblemeSante";
		public static string ivDetailsProblemeSante = "ivDetailsProblemeSante";
	};

	public static class inscriptionvisitesamitie
	{
		public static string perId = "perId";
		public static string ivaMobiliteReduite = "ivaMobiliteReduite";
		public static string ivaCapaciteAuditive = "ivaCapaciteAuditive";
		public static string ivaCapaciteVisuelle = "ivaCapaciteVisuelle";
		public static string ivaMemoire = "ivaMemoire";
	};

	public static class langue
	{
		public static string lanId = "lanId";
		public static string lanNom = "lanNom";
	};

	public static class languepersonne
	{
		public static string perId = "perId";
		public static string lanId = "lanId";
	};

	public static class livraisonpopoteroulante
	{
		public static string perId = "perId";
		public static string lprDate = "lprDate";
		public static string lprNombreRepas = "lprNombreRepas";
		public static string lprPrixRepas = "lprPrixRepas";
	};

	public static class personne
	{
		public static string perId = "perId";
		public static string perNom = "perNom";
		public static string perPrenom = "perPrenom";
		public static string perSexe = "perSexe";
		public static string perDateNaissance = "perDateNaissance";
		public static string perTelephone1 = "perTelephone1";
		public static string perTelephone2 = "perTelephone2";
		public static string perTelephone3 = "perTelephone3";
		public static string perCourriel = "perCourriel";
		public static string perFumeur = "perFumeur";
		public static string perInfoCAB = "perInfoCAB";
		public static string perInfoCABCourriel = "perInfoCABCourriel";
		public static string perCommentaires = "perCommentaires";
		public static string perNoCivique = "perNoCivique";
		public static string perRue = "perRue";
		public static string perNoAppart = "perNoAppart";
		public static string perVille = "perVille";
		public static string perCasePostale = "perCasePostale";
		public static string perCodePostal = "perCodePostal";
		public static string etaId = "etaId";
		public static string staId = "staId";
		public static string perDateDerniereMaj = "perDateDerniereMaj";
		public static string perDateOuverture = "perDateOuverture";
		public static string perDateFermeture = "perDateFermeture";
		public static string perDateInactivite = "perDateInactivite";
	};

	public static class reunion
	{
		public static string reuId = "reuId";
		public static string reuDescription = "reuDescription";
		public static string reuDate = "reuDate";
		public static string actId = "actId";
	};

	public static class routepopoteroulante
	{
		public static string rprId = "rprId";
		public static string rprNom = "rprNom";
	};

	public static class service
	{
		public static string serId = "serId";
		public static string serNom = "serNom";
	};

	public static class souschampactivite
	{
		public static string scaId = "scaId";
		public static string scaNom = "scaNom";
		public static string chaId = "chaId";
	};

	public static class statut
	{
		public static string staId = "staId";
		public static string staNom = "staNom";
	};
}
