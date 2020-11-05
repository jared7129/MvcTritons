CREATE DATABASE MvcTritons
GO

CREATE TABLE Branches (
    ID int NOT NULL,
    BranchName varchar(255),
    BranchEmail varchar(255),
    PhoneNumber varchar(255),
    PhysicalAddress varchar(255),
    Manager varchar(255),
	PRIMARY KEY (ID)
);

CREATE TABLE Waybills (
    ID int NOT NULL,
    CustomerName varchar(255),
    CustomerAddress varchar(255),
    CustomerNumber varchar(255),
    TotalWeight int NOT NULL,
    NoParcels int NOT NULL,
	PRIMARY KEY (ID)
);

CREATE TABLE Vehciles (
    ID int NOT NULL,
    Make varchar(255),
    Model varchar(255),
    Mileage varchar(255),
    Description varchar(255),
    NoParcels int NOT NULL,
	FOREIGN KEY (ID) REFERENCES Branches(ID),
	FOREIGN KEY (ID) REFERENCES Waybills(ID)
);