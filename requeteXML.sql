USE CABS;

DELIMITER //
CREATE FUNCTION XMLTables(nomBD varchar(64)) RETURNS text NOT DETERMINISTIC
BEGIN
    DECLARE schemasXML text DEFAULT '<?xml version=\'1.0\'?>\n<tables>';
	DECLARE finCurseur bool;
    
    DECLARE nomTable varchar(64);
    DECLARE nomChamp varchar(64);
    
    DECLARE curseurTables CURSOR FOR SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA LIKE nomBD;
	DECLARE curseurChamps CURSOR FOR SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA LIKE nomBD AND TABLE_NAME LIKE nomTable;
    
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET finCurseur = 1;
    
    OPEN curseurTables;
    
    boucleTables : LOOP
        SET finCurseur = 0;
		FETCH curseurTables INTO nomTable;
        
        IF finCurseur THEN
			LEAVE boucleTables;
		END IF;
        
        SET schemasXML = CONCAT(schemasXML, '\n\t<table nom="', nomTable, '" service="">');
        SET finCurseur = 0;
        
        OPEN curseurChamps;
        
        boucleChamps : loop
			FETCH curseurChamps INTO nomChamp;
            
            IF finCurseur THEN
				LEAVE boucleChamps;
            END IF;
            
            SET schemasXML = CONCAT(schemasXML, '\n\t\t<champ nom="', nomChamp, '" nomEntete="" type="DEFAUT" />');
        END LOOP boucleChamps;
        
        CLOSE curseurChamps;
        
        SET schemasXML = CONCAT(schemasXML, '\n\t</table>');
	END LOOP boucleTables;
    
    CLOSE curseurTables;
    
    SET schemasXML = CONCAT(schemasXML, '\n</tables>');
    RETURN schemasXML;
END
// DELIMITER ;