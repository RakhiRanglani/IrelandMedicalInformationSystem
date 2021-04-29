ALTER TABLE dbo.Pharmacy 
ADD CONSTRAINT pharmacyID FOREIGN KEY (pharmacyID) References dbo.Medicine(MedicineID)