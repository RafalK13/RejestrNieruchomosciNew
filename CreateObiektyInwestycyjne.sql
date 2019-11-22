Create table [ObiektyKomercyjne]
(
 ObiektyKomercyjneId int identity (1,1),
 GUID UNIQUEIDENTIFIER DEFAULT NEWID(),
 Nazwa VARCHAR(39)
)