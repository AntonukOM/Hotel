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
INSERT INTO Room(Id, ClientId, HotelId, ReservationBegin, ReservationEnd, ReservationStatus)
VALUES
	(1, 1, 1, '2015-09-19', '2015-09-21', 1),
	(2, 2, 1, '2015-09-24', '2015-09-25', 1),
	(3, 3, 1, '2015-09-19', '2015-09-26', 1),
	(4, NULL, 1, '2015-09-19', '2015-09-26', 0),
	(5, NULL, 2, '2015-09-19', '2015-09-26', 0);
SET IDENTITY_INSERT Room OFF;