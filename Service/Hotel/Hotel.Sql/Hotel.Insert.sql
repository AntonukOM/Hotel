USE HotelService;

SET IDENTITY_INSERT Client ON;
INSERT INTO Client(Id, FirstName, LastName, Email, Phone) 
VALUES
	(1, 'Roman', 'Romanenko', 'roma@gmail.cm', NULL),
	(2, 'Petro', 'Petrenko', 'petro@gmil.com', '098-236-11-00'),
	(3, 'Vasyl', 'Vasylenko', 'vasyl@gmail.co', NULL);
SET IDENTITY_INSERT Client OFF;

SET IDENTITY_INSERT Hotel ON;
INSERT INTO Hotel(Id, Name, RoomCount)
VALUES
	(1, 'Ukraine', 200),
	(2, 'Victory', 500),
	(3, 'Star', 750);
SET IDENTITY_INSERT Hotel OFF;


SET IDENTITY_INSERT Room ON;
INSERT INTO Room(Id, ClientId, HotelId, Name, ReservationStatus)
VALUES
	(1, 1, 1, '101', 1),
	(2, 2, 1, '102', 1),
	(3, 3, 1, '103', 1),
	(4, 1, 1, '104', 0),
	(5, 2, 2, '101', 0),
	(6, 3, 2, '102', 1),
	(7, 1, 2, '103', 0),
	(8, 1, 3, '101', 1),
	(9, 2, 3, '102', 0),
	(10, 3, 3, '103', 0);
SET IDENTITY_INSERT Room OFF;

SELECT * FROM Room