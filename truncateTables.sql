SELECT Concat('TRUNCATE TABLE ', table_schema, '.', TABLE_NAME, ';') 
FROM INFORMATION_SCHEMA.TABLES where table_schema in ('CABS');