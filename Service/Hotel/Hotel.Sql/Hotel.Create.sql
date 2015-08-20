USE HotelService;

CREATE TABLE Client
(
	Id INT NOT NULL IDENTITY(1, 1),
	FirstName NVARCHAR(64) NOT NULL,
	LastName NVARCHAR(64) NOT NULL,
	Email NVARCHAR(64) NOT NULL,
	Phone NVARCHAR(64) NULL
	CONSTRAINT PK_Client_Id PRIMARY KEY(Id)
);

CREATE TABLE Hotel
(
	Id INT NOT NULL IDENTITY(1, 1),
	Name NVARCHAR(128) NOT NULL,
	RoomCount INT NOT NULL,
	CONSTRAINT PK_Hotel_Id PRIMARY KEY(Id)
);

CREATE TABLE Room
(
	Id INT NOT NULL IDENTITY(1, 1),
	ClientId INT NULL,
	HotelId INT NOT NULL,
	ReservationBegin DATE NOT NULL,
	ReservationEnd DATE NOT NULL,
	ReservationStatus BIT NOT NULL
	CONSTRAINT PK_Room_Id PRIMARY KEY(Id),

	CONSTRAINT FK_Room_ClientId_Client_Id
	FOREIGN KEY (ClientId) REFERENCES Client(Id),

	CONSTRAINT FK_Room_HotelId_Hotel_Id
	FOREIGN KEY (HotelId) REFERENCES Hotel(Id)
);