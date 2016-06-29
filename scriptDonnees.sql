USE CABS;

SET FOREIGN_KEY_CHECKS = 0;

TRUNCATE TABLE cabs.actionactivite;
TRUNCATE TABLE cabs.activite;
TRUNCATE TABLE cabs.arejoindre;
TRUNCATE TABLE cabs.beneficiaire;
TRUNCATE TABLE cabs.beneficiaireactionactivite;
TRUNCATE TABLE cabs.beneficiaireroutepopoteroulante;
TRUNCATE TABLE cabs.benevole;
TRUNCATE TABLE cabs.benevoleactionactivite;
TRUNCATE TABLE cabs.benevolereunion;
TRUNCATE TABLE cabs.champactivite;
TRUNCATE TABLE cabs.couple;
TRUNCATE TABLE cabs.disponibiliteservice;
TRUNCATE TABLE cabs.employe;
TRUNCATE TABLE cabs.employereunion;
TRUNCATE TABLE cabs.evaluationdepannagealimentaire;
TRUNCATE TABLE cabs.inscriptionatelierjouets;
TRUNCATE TABLE cabs.inscriptionclubmarche;
TRUNCATE TABLE cabs.inscriptiondepannagealimentaire;
TRUNCATE TABLE cabs.inscriptionpopoteroulante;
TRUNCATE TABLE cabs.inscriptionservice;
TRUNCATE TABLE cabs.inscriptiontelesurveillancelifeline;
TRUNCATE TABLE cabs.inscriptiontransportaccompagement;
TRUNCATE TABLE cabs.inscriptiontransportcommunautaire;
TRUNCATE TABLE cabs.inscriptionviactive;
TRUNCATE TABLE cabs.inscriptionvisitesamitie;
TRUNCATE TABLE cabs.languepersonne;
TRUNCATE TABLE cabs.livraisonpopoteroulante;
TRUNCATE TABLE cabs.personne;
TRUNCATE TABLE cabs.reunion;
TRUNCATE TABLE cabs.routepopoteroulante;
TRUNCATE TABLE cabs.souschampactivite;

SET FOREIGN_KEY_CHECKS = 1;

INSERT INTO Personne (perNom, perPrenom, perSexe, perDateNaissance, etaId, perTelephone1, perNoCivique, perRue, perVille, perCodePostal, perDateDerniereMaj)
	VALUES	('Caron', 'Anthony', 0, '1993-05-20', 1, '8198795280', 31, 'St-Philippe', 'Asbestos', 'J1T1K1', '1998-02-22'),
			('Lajoie', 'Jean', 0, '1993-06-01', 1, '8191231111', 123, 'Lavoie', 'Danville', 'J0A1A0', '2001-02-22'),
			('Raymond', 'Raymond', 0, '1995-10-10', 1, '8191232222', 123, 'Lavoie', 'Donville', 'J0A2A0', '2012-02-22'),
			('Parent', 'Marie', 1, '1960-01-25', 2, '8191233333', 123, 'Lavoie', 'Danvil', 'J0A3A0', '2005-02-22'),
			('Spot', 'Alex', 0, '1976-12-13', 2, '8191234444', 123, 'Lavoie', 'Danvylle', 'J0A4A0', '1990-02-22'),
			('Trobuscus', 'Maurice', 0, '1988-04-15', 3, '8191235555', 123, 'Lavoie', 'Denville', 'J0A5A0', '2003-02-22'),
			('11111111', '222222222', 0, '1988-04-15', 3, '8291235795', 123, 'Lavoie', 'Denville', 'J0A5A0', '1993-02-22'),
			('3333333333', '444444444444', 0, '1988-04-15', 3, '8411235555', 123, 'Lavoie', 'Denville', 'J0A5A0', '1987-02-22'),
			('555555555', '6666666666', 0, '1988-04-15', 3, '8191235175', 123, 'Lavoie', 'Denville', 'J0A5A0', '2014-02-22'),
			('777777777', '8888888', 0, '1988-04-15', 3, '8191232235', 123, 'Lavoie', 'Denville', 'J0A5A0', '2015-02-22');
           
INSERT INTO LanguePersonne (perId, lanId)
	VALUES	(1, 1),
			(1, 2),
			(2, 1),
			(3, 2),
			(4, 2),
			(5, 3),
			(6, 3),
			(7, 1),
			(8, 1),
			(9, 1),
			(10, 1);

INSERT INTO ARejoindre (arjNom, arjPrenom, arjLien, arjTelephone, perId)
	VALUES	('Jacques', 'Frère', 'Frère', '8191231111', 2),
			('Doughtfire', 'M.', 'Soeur', '8191232222', 3),
			('Bean', 'Mr.', 'Fils', '8191233333', 4),
			('T', 'Mr.', 'Père', '8191234444', 5);

INSERT INTO Couple
	VALUES	(4, 6);

INSERT INTO Beneficiaire (perId)
	VALUES	(1),
			(2),
			(7),
			(8),
			(9),
			(10);

INSERT INTO Benevole (perId, benvNoCarte, benvDebutProbation, benvFinProbation)
	VALUES	(4, 1, '2016-01-13', '2016-01-13'),
			(5, 2, '2016-01-13', '2016-01-13'),
			(6, 3, '2016-01-13', '2016-01-13');

INSERT INTO Employe (perId)
	VALUES	(3);