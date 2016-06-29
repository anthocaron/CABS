DROP DATABASE CABS;
CREATE DATABASE CABS;

USE CABS;

CREATE TABLE EtatCivil
(
	etaId int NOT NULL AUTO_INCREMENT,
	etaNom nvarchar(32),
	PRIMARY KEY	(etaId)
);

CREATE TABLE Statut
(
	staId int NOT NULL AUTO_INCREMENT,
	staNom nvarchar(16),
	PRIMARY KEY	(staId)
);

CREATE TABLE Langue
(
	lanId int NOT NULL AUTO_INCREMENT,
	lanNom nvarchar(32),
	PRIMARY KEY	(lanId)
);

CREATE TABLE Personne
(
	perId int NOT NULL AUTO_INCREMENT,
	perNom nvarchar(64) NOT NULL,
	perPrenom nvarchar(64) NOT NULL,
	perSexe bool NOT NULL,
	perDateNaissance date NOT NULL,
	perTelephone1 nvarchar(32) NOT NULL,
	perTelephone2 nvarchar(32),
	perTelephone3 nvarchar(32),
	perCourriel nvarchar(128),
	perFumeur bool DEFAULT 0,
	perInfoCAB bool DEFAULT 0,
	perInfoCABCourriel bool DEFAULT 0,
	perCommentaires text,
	perNoCivique int NOT NULL,
	perRue nvarchar(128) NOT NULL,
	perNoAppart nvarchar(16),
	perVille nvarchar(128) NOT NULL,
	perCasePostale int,
	perCodePostal nvarchar(16) NOT NULL,
    perDateDerniereMaj date DEFAULT NULL,
	perDateOuverture date DEFAULT NULL,
	perDateFermeture date DEFAULT NULL,
	perDateInactivite date DEFAULT NULL,
	etaId int NOT NULL,
	staId int NOT NULL DEFAULT 1,
	PRIMARY KEY	(perId),
	FOREIGN KEY (etaId) REFERENCES EtatCivil(etaId),
	FOREIGN KEY (staId) REFERENCES Statut	(staId)
);

CREATE TABLE LanguePersonne
(
	perId int NOT NULL,
	lanId int NOT NULL,
	PRIMARY KEY	(perId, lanId),
	FOREIGN KEY (perId) REFERENCES Personne	(perId) ON DELETE CASCADE,
	FOREIGN KEY (lanId) REFERENCES Langue	(lanId) ON DELETE CASCADE
);

CREATE TABLE ARejoindre
(
	arjId int NOT NULL AUTO_INCREMENT,
	arjNom nvarchar(64) NOT NULL,
	arjPrenom nvarchar(64) NOT NULL,
	arjLien nvarchar(32) NOT NULL,
	arjTelephone nvarchar(32) NOT NULL,
	perId int NOT NULL,
	PRIMARY KEY	(arjId),
	FOREIGN KEY (perId) REFERENCES Personne	(perId) ON DELETE CASCADE
);

CREATE TABLE Couple
(
	perIdPremier int NOT NULL,
	perIdDeuxieme int NOT NULL,
	PRIMARY KEY (perIdPremier, perIdDeuxieme),
	FOREIGN KEY (perIdPremier) 	REFERENCES Personne	(perId) ON DELETE CASCADE,
	FOREIGN KEY (perIdDeuxieme) REFERENCES Personne	(perId) ON DELETE CASCADE
);

CREATE TABLE Beneficiaire
(
	perId int NOT NULL,
	PRIMARY KEY	(perId),
	FOREIGN KEY (perId) REFERENCES Personne	(perId) ON DELETE CASCADE
);

CREATE TABLE Employe
(
	perId int NOT NULL,
	PRIMARY KEY	(perId),
	FOREIGN KEY (perId) REFERENCES Personne	(perId) ON DELETE CASCADE
);

CREATE TABLE Benevole
(
	perId int NOT NULL,
	benvNoCarte int DEFAULT 0,
    benvEnProbation bool DEFAULT 0,
    benvDebutProbation date,
    benvFinProbation date,
	PRIMARY KEY	(perId),
	FOREIGN KEY (perId) REFERENCES Personne	(perId) ON DELETE CASCADE
);

CREATE TABLE Service
(
	serId int NOT NULL AUTO_INCREMENT,
	serNom nvarchar(64) NOT NULL,
	PRIMARY KEY	(serId)
);

CREATE TABLE DisponibiliteService
(
	perId int NOT NULL,
    serId int NOT NULL,
    PRIMARY KEY	(perId, serId),
    FOREIGN KEY (perId)	REFERENCES Benevole		(perId) ON DELETE CASCADE,
    FOREIGN KEY (serId)	REFERENCES Service		(serId) ON DELETE CASCADE
);

CREATE TABLE InscriptionService
(
	perId int NOT NULL,
	insDateDemande date,
	insCommentaires text,
    insSuspendu bool DEFAULT 0,
    serId int NOT NULL,
    PRIMARY KEY	(perId, serId),
    FOREIGN KEY (perId)	REFERENCES Beneficiaire	(perId) ON DELETE CASCADE,
    FOREIGN KEY (serId)	REFERENCES Service		(serId) ON DELETE CASCADE
);

CREATE TABLE InscriptionPopoteRoulante
(
	perId int NOT NULL,
    iprDiabetique bool NOT NULL,
    iprConjointDiabetique bool NOT NULL,
    iprListeAllergies text,
    iprListeAllergiesConjoint text,
    iprIndicationsLivraison text,
    iprSolde numeric(8,2) DEFAULT 0.00,
    PRIMARY KEY	(perId),
    FOREIGN KEY (perId)	REFERENCES beneficiaire	(perId)	ON DELETE CASCADE
);

CREATE TABLE RoutePopoteRoulante
(
	rprId int NOT NULL AUTO_INCREMENT,
    rprNom nvarchar(64) NOT NULL,
    PRIMARY KEY (rprId)
);

CREATE TABLE BeneficiaireRoutePopoteRoulante
(
	perId int NOT NULL,
    rprId int NOT NULL,
    brprOrdre int NOT NULL,
    PRIMARY KEY (perId),
    FOREIGN KEY (perId)	REFERENCES inscriptionpopoteroulante	(perId)	ON DELETE CASCADE,
    FOREIGN KEY (rprId)	REFERENCES routepopoteroulante			(rprId)	ON DELETE CASCADE
);

CREATE TABLE LivraisonPopoteRoulante
(
	perId int NOT NULL,
    lprDate date NOT NULL,
    lprNombreRepas int NOT NULL,
	lprPrixRepas numeric(8,2) DEFAULT 0.00,
    PRIMARY KEY (perId, lprDate),
    FOREIGN KEY (perId)	REFERENCES inscriptionpopoteroulante	(perId)	ON DELETE CASCADE
);

CREATE TABLE InscriptionAtelierJouets
(
	perId int NOT NULL,
    iajNombreEnfants int NOT NULL,
    iajAgesEnfants nvarchar(32),
    iajAllocationFamiliale bool NOT NULL,
    iajCarteMedicament bool NOT NULL,
    iajCarteAssuranceMaladie bool NOT NULL,
    iajPermisConduire bool NOT NULL,
    iajProprietaire bool NOT NULL,
    iajLocataire bool NOT NULL,
    iajBail bool NOT NULL,
    iajFactures bool NOT NULL,
    iajDetailsFactures nvarchar(64),
    iajPerteEmploi bool NOT NULL,
    iajSeparation bool NOT NULL,
    iajAccidentAutoMaladie bool NOT NULL,
    iajFaibleRevenu bool NOT NULL,
    iajAccidentTravail bool NOT NULL,
    iajDemenagement bool NOT NULL,
    iajAutres bool NOT NULL,
    iajDetailsAutres nvarchar(64),
    PRIMARY KEY	(perId),
    FOREIGN KEY (perId)	REFERENCES beneficiaire	(perId)	ON DELETE CASCADE
);

CREATE TABLE InscriptionClubMarche
(
	perId int NOT NULL,
    icmProblemeCardiaque bool NOT NULL,
    icmDouleurPoitrine bool NOT NULL,
    icmProblemesOsseux bool NOT NULL,
    icmRestrictionPhysique bool NOT NULL,
    icmDetailsRestrictionPhysique text,
    icmProblemeSante bool NOT NULL,
    icmDetailsProblemeSante text,
    PRIMARY KEY	(perId),
    FOREIGN KEY (perId)	REFERENCES beneficiaire	(perId)	ON DELETE CASCADE
);

CREATE TABLE InscriptionDepannageAlimentaire
(
	idaId int NOT NULL AUTO_INCREMENT,
    idaNombreEnfants int NOT NULL,
    idaAgesEnfants nvarchar(32) NOT NULL,
    idaAllocationFamiliale bool NOT NULL,
    idaCarteMedicament bool NOT NULL,
    idaCarteAssuranceMaladie bool NOT NULL,
    idaPermisConduire bool NOT NULL,
    idaProprietaire bool NOT NULL,
    idaLocataire bool NOT NULL,
    idaBail bool NOT NULL,
    idaFactures bool NOT NULL,
    idaDetailsFactures nvarchar(64),
    idaPerteEmploi bool NOT NULL,
    idaSeparation bool NOT NULL,
    idaAccidentAutoMaladie bool NOT NULL,
    idaFaibleRevenu bool NOT NULL,
    idaAccidentTravail bool NOT NULL,
    idaDemenagement bool NOT NULL,
    idaAutres bool NOT NULL,
    idaDetailsAutres nvarchar(64),
	perId int NOT NULL,
    PRIMARY KEY	(idaId, perId),
    FOREIGN KEY (perId)	REFERENCES beneficiaire	(perId)	ON DELETE CASCADE
);

CREATE TABLE EvaluationDepannageAlimentaire
(
	edaId int NOT NULL AUTO_INCREMENT,
    edaNbPersonnes int NOT NULL,
    edaChomage numeric(8,2) DEFAULT 0.00,
    edaAideSociale numeric(8,2) DEFAULT 0.00,
    edaTalonPaie numeric(8,2) DEFAULT 0.00,
    edaPrestationsFamProv numeric(8,2) DEFAULT 0.00,
    edaPrestationsFamFed numeric(8,2) DEFAULT 0.00,
    edaPensionAlimentaireRevenu numeric(8,2) DEFAULT 0.00,
    edaRRQ numeric(8,2) DEFAULT 0.00,
    edaPensionVieillesse numeric(8,2) DEFAULT 0.00,
    edaTPS numeric(8,2) DEFAULT 0.00,
    edaImpotSolidarite numeric(8,2) DEFAULT 0.00,
    edaNomAutresRevenus1 nvarchar(64),
    edaAutresRevenus1 numeric(8,2) DEFAULT 0.00,
    edaNomAutresRevenus2 nvarchar(64),
    edaAutresRevenus2 numeric(8,2) DEFAULT 0.00,
    edaNomAutresRevenus3 nvarchar(64),
    edaAutresRevenus3 numeric(8,2) DEFAULT 0.00,
    edaHydroQuebec numeric(8,2) DEFAULT 0.00,
    edaCableInternetTelephone numeric(8,2) DEFAULT 0.00,
    edaCellulaire numeric(8,2) DEFAULT 0.00,
    edaLoyerHypotheque numeric(8,2) DEFAULT 0.00,
    edaChauffage numeric(8,2) DEFAULT 0.00,
    edaTaxesScolairesMun numeric(8,2) DEFAULT 0.00,
    edaAssuranceLogement numeric(8,2) DEFAULT 0.00,
    edaRemboursementAuto numeric(8,2) DEFAULT 0.00,
    edaAssuranceAuto numeric(8,2) DEFAULT 0.00,
    edaImmatriculationPermis numeric(8,2) DEFAULT 0.00,
    edaEssenceEntretien numeric(8,2) DEFAULT 0.00,
    edaPensionAlimentaireDepense numeric(8,2) DEFAULT 0.00,
    edaAssuranceVie numeric(8,2) DEFAULT 0.00,
    edaDepensesCourantes numeric(8,2) DEFAULT 0.00,
    edaNomAutreDepenses1 nvarchar(64),
    edaAutresDepenses1 numeric(8,2) DEFAULT 0.00,
    edaNomAutresDepenses2 nvarchar(64),
    edaAutresDepenses2 numeric(8,2) DEFAULT 0.00,
    edaNomAutresDepenses3 nvarchar(64),
    edaAutresDepenses3 numeric(8,2) DEFAULT 0.00,
	edaDate date NOT NULL,
    edaAccepte bool NOT NULL,
    edaCommentaires text,
	idaId int NOT NULL,
    PRIMARY KEY	(edaId),
    FOREIGN KEY (idaId)	REFERENCES InscriptionDepannageAlimentaire	(idaId)	ON DELETE CASCADE
);

CREATE TABLE InscriptionTelesurveillanceLifeline
(
	perId int NOT NULL,
	itlNoUnite nvarchar(64) NOT NULL,
    PRIMARY KEY	(perId),
    FOREIGN KEY (perId)	REFERENCES beneficiaire	(perId)	ON DELETE CASCADE
);

CREATE TABLE InscriptionTransportAccompagement
(
	perId int NOT NULL,
    itaNoDossierCLE nvarchar(64),
    itaNoDossierCSST nvarchar(64),
    itaNomAgentCSST nvarchar(64),
    itaPrenomAgentCSST nvarchar(64),
    itaTelephoneAgentCSST nvarchar(32),
    itaMobiliteReduite text NOT NULL,
    itaCapaciteAuditive text NOT NULL,
    itaCapaciteVisuelle text NOT NULL,
    itaMemoire text NOT NULL,
    itaVuDDN bool NOT NULL,
    PRIMARY KEY	(perId),
    FOREIGN KEY (perId)	REFERENCES beneficiaire	(perId)	ON DELETE CASCADE
);

CREATE TABLE InscriptionTransportCommunautaire
(
	perId int NOT NULL,
    itcVuDDN bool NOT NULL,
    PRIMARY KEY	(perId),
    FOREIGN KEY (perId)	REFERENCES beneficiaire	(perId)	ON DELETE CASCADE
);

CREATE TABLE InscriptionViactive
(
	perId int NOT NULL,
    ivProblemeCardiaque bool NOT NULL,
    ivDouleurPoitrine bool NOT NULL,
    ivProblemesOsseux bool NOT NULL,
    ivRestrictionPhysique bool NOT NULL,
    ivDetailsRestrictionPhysique text,
    ivProblemeSante bool NOT NULL,
    ivDetailsProblemeSante text,
    PRIMARY KEY	(perId),
    FOREIGN KEY (perId)	REFERENCES beneficiaire	(perId)	ON DELETE CASCADE
);

CREATE TABLE InscriptionVisitesAmitie
(
	perId int NOT NULL,
    ivaMobiliteReduite text NOT NULL,
    ivaCapaciteAuditive text NOT NULL,
    ivaCapaciteVisuelle text NOT NULL,
    ivaMemoire text NOT NULL,
    PRIMARY KEY	(perId),
    FOREIGN KEY (perId)	REFERENCES beneficiaire	(perId)	ON DELETE CASCADE
);

CREATE TABLE ChampActivite
(
	chaId int NOT NULL AUTO_INCREMENT,
    chaNom nvarchar(256) NOT NULL,
    PRIMARY KEY(chaId)
);

CREATE TABLE SousChampActivite
(
	scaId int NOT NULL AUTO_INCREMENT,
    scaNom nvarchar(256) NOT NULL,
    chaId int NOT NULL,
    PRIMARY KEY	(scaId),
    FOREIGN KEY (chaId) REFERENCES champactivite (chaId) ON DELETE CASCADE
);

CREATE TABLE Activite
(
	actId int NOT NULL AUTO_INCREMENT,
    actNom nvarchar(256) NOT NULL,
	scaId int NOT NULL,
    PRIMARY KEY	(actId),
    FOREIGN KEY (scaId) REFERENCES souschampactivite (scaId) ON DELETE CASCADE
);

CREATE TABLE ActionActivite
(
	actaId int NOT NULL AUTO_INCREMENT,
    actaDate date NOT NULL,
    actaNombreBenevolesNonInscrits int NOT NULL,
    actId int NOT NULL,
    PRIMARY KEY (actaId),
    FOREIGN KEY (actId) REFERENCES activite (actId) ON DELETE CASCADE
);

CREATE TABLE BenevoleActionActivite
(
	benaHeures int NOT NULL DEFAULT 0,
    perId int NOT NULL,
    actaId int NOT NULL,
    PRIMARY KEY (perId, actaId),
    FOREIGN KEY (perId)		REFERENCES benevole			(perId) ON DELETE CASCADE,
    FOREIGN KEY (actaId)	REFERENCES actionactivite 	(actaId) ON DELETE CASCADE
);

CREATE TABLE BeneficiaireActionActivite
(
    perId int NOT NULL,
    actaId int NOT NULL,
    PRIMARY KEY (perId, actaId),
    FOREIGN KEY (perId)		REFERENCES 	beneficiaire	(perId)		ON DELETE CASCADE,
    FOREIGN KEY (actaId) 	REFERENCES 	actionactivite 	(actaId) 	ON DELETE CASCADE
);

CREATE TABLE Reunion
(
	reuId int NOT NULL AUTO_INCREMENT,
    reuDescription nvarchar(256) NOT NULL,
    reuDate date NOT NULL,
    actId int NOT NULL,
    PRIMARY KEY (reuId),
    FOREIGN KEY (actId) REFERENCES activite (actId) ON DELETE CASCADE
);

CREATE TABLE BenevoleReunion
(
    benrHeures int NOT NULL DEFAULT 0,
    perId int NOT NULL,
    reuId int NOT NULL,
    PRIMARY KEY (perId, reuId),
    FOREIGN KEY (perId)	REFERENCES benevole	(perId) ON DELETE CASCADE,
    FOREIGN KEY (reuId) REFERENCES reunion 	(reuId) ON DELETE CASCADE
);

CREATE TABLE EmployeReunion
(
    erHeures int NOT NULL DEFAULT 0,
    perId int NOT NULL,
    reuId int NOT NULL,
    PRIMARY KEY (perId, reuId),
    FOREIGN KEY (perId)	REFERENCES employe	(perId) ON DELETE CASCADE,
    FOREIGN KEY (reuId) REFERENCES reunion 	(reuId) ON DELETE CASCADE
);
				
INSERT INTO EtatCivil (etaNom)
	VALUES	('Célibataire'),
			('Monoparentale'),
			('Séparé(e)/Divorcé(e)'),
			('Marié(e)/Conjoint(e) de fait'),
			('Veuf/Veuve');
           
INSERT INTO Statut (staNom)
	VALUES	('Actif'),
			('Inactif'),
			('Fermé');
           
INSERT INTO Langue (lanNom)
	VALUES	('Français'),
			('Anglais'),
			('Espagnol');

INSERT INTO Service (serNom)
	VALUES	('Aide à la marche'),
			('Atelier de jouets'),
			('Club de marche'),
			('Comptoir familial'),
			('Dépannage alimentaire La Manne'),
			('Menus travaux'),
			('Popote roulante'),
			('Programme Pair'),
			('Rencontres d\'amitié'),
			('Télésurveillance Philips Lifeline'),
			('Transport accompagnement'),
			('Transport communautaire'),
			('Viactive'),
			('Visites d\'amitié');
            
DELIMITER //
CREATE PROCEDURE PersonnesInactives ()
BEGIN
  SELECT p.*
	FROM personne p
	WHERE timestampdiff(year, p.perDateDerniereMaj, curdate()) > 0 AND p.perDateInactivite IS NULL AND p.perDateFermeture IS NULL
		AND p.staId = (SELECT staId FROM statut WHERE staNom LIKE 'Actif')
		AND (SELECT ins.perId FROM inscriptionservice ins
				WHERE timestampdiff(year, ins.insDateDemande, curdate()) < 1 AND ins.insSuspendu = 0 AND ins.perId = p.perId) IS NULL
		AND (SELECT l.perId FROM livraisonpopoteroulante l
				WHERE l.perId = p.perId AND timestampdiff(year, l.lprDate, curdate()) < 1) IS NULL
		AND (SELECT ida.perId FROM inscriptiondepannagealimentaire ida
				INNER JOIN evaluationdepannagealimentaire e ON e.idaId = ida.idaId
				WHERE ida.perId = p.perId AND timestampdiff(year, e.edaDate, curdate()) < 1) IS NULL
		AND (SELECT bena.perId FROM benevoleactionactivite bena
				INNER JOIN actionactivite acta ON acta.actaId = bena.actaId
				WHERE bena.perId = p.perId AND timestampdiff(year, acta.actaDate, curdate()) < 1) IS NULL
		AND (SELECT benaa.perId FROM beneficiaireactionactivite benaa
				INNER JOIN actionactivite actaa ON actaa.actaId = benaa.actaId
				WHERE benaa.perId = p.perId AND timestampdiff(year, actaa.actaDate, curdate()) < 1) IS NULL
		AND (SELECT br.perId FROM benevolereunion br
				INNER JOIN reunion r ON br.reuId = r.reuId
				WHERE br.perId = p.perId AND timestampdiff(year, r.reuDate, curdate()) < 1) IS NULL;
END //
DELIMITER ;