

CREATE Table Neighborhood (
  Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
  [Name] VARCHAR(55) NOT NULL
)



CREATE Table Walker (
  Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
 [Name] VARCHAR(55) NOT NULL,
  NeighborhoodId INTEGER  NOT NULL,
  CONSTRAINT FK_Walker_Neighborhood FOREIGN KEY(NeighborhoodId) REFERENCES Neighborhood(Id),
)

CREATE Table Walks (
  Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
  Date datetime NOT NULL,
  Duration INTEGER NOT NULL,
  WalkerId INTEGER NOT NULL,
  DogId INTEGER NOT NULL,
  [Date] DATETIME NOT NULL,
  CONSTRAINT FK_Walks_Walker FOREIGN KEY(WalkerId) REFERENCES Walker(Id),
  CONSTRAINT FK_Walks_Dog FOREIGN KEY(DogId) REFERENCES Dog(Id)
)

CREATE Table Dog (
Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
 [Name] VARCHAR(55) NOT NULL,
  OwnerId INTEGER,
  Breed VARCHAR(55),
  Notes VARCHAR(255),
  CONSTRAINT FK_Dog_Owner FOREIGN KEY(OwnerId) REFERENCES [Owner](Id)
);

CREATE Table [Owner] (
  Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
 [Name] VARCHAR(55) NOT NULL,
  Address VARCHAR(255)  NOT NULL,
  NeighborhoodId INTEGER  NOT NULL,
  Phone VARCHAR(55)  NOT NULL,
 CONSTRAINT FK_Owner_Neighborhood FOREIGN KEY(NeighborhoodId) REFERENCES Neighborhood(Id)
)







--Populate each table with data. You should have 
--2-3 neighborhoods, 5-10 dogs, 4-8 owners, 2-5 walkers 
--and each walker should have 1-2 walks recorded.

--2-3 neighborhoods
INSERT INTO Neighborhood (Name) VALUES ('Victory Point');
INSERT INTO Neighborhood (Name) VALUES ('DownTown');
INSERT INTO Neighborhood (Name) VALUES ('NiceVille');

--5-10 dogs,

INSERT INTO Dog (Name) VALUES ('Angel');
INSERT INTO Dog (OwnerId) VALUES (1);
INSERT INTO Dog (Breed) VALUES ('Weimereiner');
INSERT INTO Dog (Notes) VALUES ('Older dog likes to sleep alot');

INSERT INTO Dog (Name) VALUES ('Bonita');
INSERT INTO Dog (OwnerId) VALUES (2);
INSERT INTO Dog (Breed) VALUES ('Pit Bull');
INSERT INTO Dog (Notes) VALUES ('Really happy and likes to jump up on you');

INSERT INTO Dog (Name) VALUES ('Fido');
INSERT INTO Dog (OwnerId) VALUES (3);
INSERT INTO Dog (Breed) VALUES ('Black Lab');
INSERT INTO Dog (Notes) VALUES ('Has a thick fur and gets hot on walks');

INSERT INTO Dog (Name) VALUES ('Bongo');
INSERT INTO Dog (OwnerId) VALUES (4);
INSERT INTO Dog (Breed) VALUES ('Weiner Dog');
INSERT INTO Dog (Notes) VALUES ('Likes to chase things');

INSERT INTO Dog (Name) VALUES ('Fluffy');
INSERT INTO Dog (OwnerId) VALUES (5);
INSERT INTO Dog (Breed) VALUES ('Poodle');
INSERT INTO Dog (Notes) VALUES ('Is a big lap dog');


 --4-8 owners
  
 

INSERT INTO Owner (Name) VALUES ('Maura');
INSERT INTO Owner (Address) VALUES ('123 Main Street');
INSERT INTO Owner (NeighborhoodId) VALUES (1);
INSERT INTO Owner (Phone) VALUES ('615-555-1212');


INSERT INTO Owner (Name) VALUES ('Catherine');
INSERT INTO Owner (Address) VALUES ('123 Main Street');
INSERT INTO Owner (NeighborhoodId) VALUES (1);
INSERT INTO Owner (Phone) VALUES ('615-555-7777');


INSERT INTO Owner (Name) VALUES ('Joe Jones');
INSERT INTO Owner (Address) VALUES ('500 Adams Street');
INSERT INTO Owner (NeighborhoodId) VALUES (2);
INSERT INTO Owner (Phone) VALUES ('303-922-5555');


INSERT INTO Owner (Name) VALUES ('Sam Smith');
INSERT INTO Owner (Address) VALUES ('15 Jackson Street');
INSERT INTO Owner (NeighborhoodId) VALUES (3);
INSERT INTO Owner (Phone) VALUES ('212-333-6432');

 --2-5 walkers 

INSERT INTO Walker (Name) VALUES ('Sue Puppieas');
INSERT INTO Walker (NeighborhoodId) VALUES (1);

INSERT INTO Walker (Name) VALUES ('Jim Coles');
INSERT INTO Walker (NeighborhoodId) VALUES (1);

INSERT INTO Walker (Name) VALUES ('Noah Biggs');
INSERT INTO Walker (NeighborhoodId) VALUES (2);

INSERT INTO Walker (Name) VALUES ('Jane Short');
INSERT INTO Walker (NeighborhoodId) VALUES (3);





 --and each walker should have 1-2 walks recorded.


INSERT INTO Walks([Date], Duration, WalkerId, DogId) VALUES (2020-03-17, 35, 1, 1);
INSERT INTO Walks([Date], Duration, WalkerId, DogId) VALUES (2020-03-17, 35, 1, 2);
INSERT INTO Walks([Date], Duration, WalkerId, DogId) VALUES (2020-03-17, 45, 2, 1);
INSERT INTO Walks([Date], Duration, WalkerId, DogId) VALUES (2020-03-17, 45, 2, 2);
INSERT INTO Walks([Date], Duration, WalkerId, DogId) VALUES (2020-03-17, 30, 3, 3);
INSERT INTO Walks([Date], Duration, WalkerId, DogId) VALUES (2020-03-18, 40, 3, 3);
INSERT INTO Walks([Date], Duration, WalkerId, DogId) VALUES (2020-03-18, 40, 4, 4);
INSERT INTO Walks([Date], Duration, WalkerId, DogId) VALUES (2020-03-18, 35, 4, 4);
INSERT INTO Walks([Date], Duration, WalkerId, DogId) VALUES (2020-03-19, 40, 4, 4);
INSERT INTO Walks([Date], Duration, WalkerId, DogId) VALUES (2020-03-19, 35, 4, 4);






