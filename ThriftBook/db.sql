
IF OBJECT_ID('BookDetails', 'U')    
	IS NOT NULL DROP TABLE BookDetails;
IF OBJECT_ID('BookRating', 'U')    
	IS NOT NULL DROP TABLE BookRating;

    GO
    
CREATE TABLE BookDetails(
	bookID INT	PRIMARY KEY,
	title	  VARCHAR(30),	
	author	  VARCHAR(30),	
	gennre	  VARCHAR(30),
	bookQuality VARCHAR(20),
	bookQuantity INT,
	bookPhoto  VARCHAR(255),
	price	  MONEY CHECK(price>0));
INSERT INTO BookDetails VALUES(1, 'Your Next Five Moves', ' Greg Dinkin', 'Business & Investing', 'like new',5,'https://images-na.ssl-images-amazon.com/images/I/41z2wSFrXbL._SX326_BO1,204,203,200_.jpg',14);
INSERT INTO BookDetails VALUES(2, 'The Christmas Pig', 'J.K. Rowling', 'Children Books','good', 3,'https://images-na.ssl-images-amazon.com/images/I/51rg5EDPpDL._SX336_BO1,204,203,200_.jpg',12);
INSERT INTO BookDetails VALUES(3,'The Very Hungry Caterpillar', 'Eric Carle ', 'Children Books','old',2, 'https://images-na.ssl-images-amazon.com/images/I/41tyokViuNL._SY355_BO1,204,203,200_.jpg',6.25);
INSERT INTO BookDetails VALUES(4,'Will', 'Will Smith ', 'Biographies & Memoirs', 'like new', 3, 'https://images-na.ssl-images-amazon.com/images/I/51oDyfsqKwL._SX327_BO1,204,203,200_.jpg',10);

    GO

CREATE TABLE BookRating(
	bookID	INT FOREIGN KEY REFERENCES BookDetails(bookID),
	buyerID	INT FOREIGN KEY REFERENCES Buyers(buyerID),
	bookRating DECIMAL,
	comments VARCHAR(255),
	PRIMARY KEY (bookID, buyerID));
INSERT INTO BookRating VALUES(1,1,4.5,'good book');
INSERT INTO BookRating VALUES(2,1,4.8,'children like it');
INSERT INTO BookRating VALUES(3,2,4.3,'');
    GO
SELECT * FROM BookDetails

	GO

CREATE TABLE Buyer (
	buyerID INT,
	firstName VARCHAR(30),
	lastName VARCHAR(30),
	email VARCHAR(40),
	city VARCHAR(30),
	street VARCHAR(30),
	postalCode VARCHAR(10),
	phoneNumber int
	PRIMARY KEY (buyerID));
INSERT INTO Buyer VALUES(1,'Keanu','Reeves', 'keanureeves@gmail.com', 'Los Angeles', 'Coldwater Canyon', '90210', 123456);
INSERT INTO Buyer VALUES((2,'Tiger','King', 'tigerking@gmail.com', 'Miami', 'Sunset Blvd.', '10101', 654321);
INSERT INTO Buyer VALUES((3,'Homer','Simpson', 'homer.j.simpson@gmail.com', 'Springfield', 'Evergreen Terrace', '12121', 123321);
INSERT INTO Buyer VALUES((4,'Daenerys', 'Targaryen', 'emailia.clarke@gmail.com', 'Dragonstone', 'Free Cities St.', '13337', 654321);

	GO

CREATE TABLE Store (
	storeName VARCHAR(30),	
	email VARCHAR(40),
	city VARCHAR(30),
	street VARCHAR(30),
	postalCode VARCHAR(30),
	phoneNumber int
	PRIMARY KEY (storeName));
INSERT INTO Store VALUES('ThriftBook','thriftbook@thriftbook.com','Vancouver', 'Pacific Boulevard', 'V2W1B5', '778-689-1000');

	GO


	CREATE TABLE Profile (
	customerId int,	
	email VARCHAR(40),
	pword VARCHAR(40),
	buyerID int,
	PRIMARY KEY (customerId));
INSERT INTO Profile VALUES( 1,'keanureeves@gmail.com','socuteguy', 1);
INSERT INTO Profile VALUES( 2,'tigerking@gmail.com','TingKing', 2);
INSERT INTO Profile VALUES( 3,'homer.j.simpson@gmail.com','theSimpsons', 3);
INSERT INTO Profile VALUES( 4,'emailia.clarke@gmail.com','emailMe', 4);
INSERT INTO Profile VALUES( 5,'beourguest@gmail.com','beautyandthebeast', null);
INSERT INTO Profile VALUES( 6,'alicelost@gmail.com','inCodeland', null);

	GO


CREATE TABLE Invoice (
	transactionId int,	
	buyerID int,
	totalPrice float,
	dateOfTransaction date,
	PRIMARY KEY (transactionId));
INSERT INTO Invoice VALUES( 100001, 1, 4.30, 2021-10-16);
INSERT INTO Invoice VALUES( 100002, 2, 8.10, 2021-11-03);
INSERT INTO Invoice VALUES( 100003, 3, 11.20, 2021-11-08);
INSERT INTO Invoice VALUES( 100004, 4, 7.50, 2021-11-13);
INSERT INTO Invoice VALUES( 100005, 1, 5.60, 2021-11-15);

	GO


CREATE TABLE OrderDetail (
    transactionId INT,
    bookID	INT FOREIGN KEY REFERENCES BookDetails(bookID),
	bookQuantity INT);
INSERT INTO OrderDetail VALUES( 100001, 1, 1);
INSERT INTO OrderDetail VALUES( 100002, 2, 1);
INSERT INTO OrderDetail VALUES( 100003, 3, 1);
INSERT INTO OrderDetail VALUES( 100004, 4, 1);
INSERT INTO OrderDetail VALUES( 100005, 3, 1);

  GO