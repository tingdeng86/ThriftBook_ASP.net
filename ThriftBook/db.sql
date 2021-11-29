IF OBJECT_ID('BookRating', 'U')    
	IS NOT NULL DROP TABLE BookRating;
IF OBJECT_ID('BookInvoice', 'U')    
	IS NOT NULL DROP TABLE BookInvoice;
IF OBJECT_ID('Invoice', 'U')    
	IS NOT NULL DROP TABLE Invoice;
IF OBJECT_ID('Book', 'U')    
	IS NOT NULL DROP TABLE Book;
IF OBJECT_ID('Buyer', 'U')    
	IS NOT NULL DROP TABLE Buyer;
IF OBJECT_ID('Store', 'U')    
	IS NOT NULL DROP TABLE Store;
    GO
   
CREATE TABLE Store (
	storeName VARCHAR(30),	
	email VARCHAR(40),
	city VARCHAR(30),
	street VARCHAR(30),
	postalCode VARCHAR(30),
	phoneNumber VARCHAR(30),
	PRIMARY KEY (storeName));
INSERT INTO Store VALUES('ThriftBook','thriftbook@thriftbook.com','Vancouver', 'Pacific Boulevard', 'V2W1B5', '778-689-1000');

	GO
CREATE TABLE Book(
	bookID INT	PRIMARY KEY,
	title	  VARCHAR(30),	
	author	  VARCHAR(30),	
	genre	  VARCHAR(30),
	bookQuality VARCHAR(20),
	bookQuantity INT,
	bookPhoto  VARCHAR(255),
	price	  MONEY CHECK(price>0),
	storeName	VARCHAR(30) FOREIGN KEY REFERENCES Store(storeName));
INSERT INTO Book VALUES(1, 'Your Next Five Moves', ' Greg Dinkin', 'Business & Investing', 'like new',5,'https://images-na.ssl-images-amazon.com/images/I/41z2wSFrXbL._SX326_BO1,204,203,200_.jpg',14,'ThriftBook');
INSERT INTO Book VALUES(2, 'The Christmas Pig', 'J.K. Rowling', 'Children Books','good', 3,'https://images-na.ssl-images-amazon.com/images/I/51rg5EDPpDL._SX336_BO1,204,203,200_.jpg',12,'ThriftBook');
INSERT INTO Book VALUES(3,'The Very Hungry Caterpillar', 'Eric Carle ', 'Children Books','old',2, 'https://images-na.ssl-images-amazon.com/images/I/41tyokViuNL._SY355_BO1,204,203,200_.jpg',6.25,'ThriftBook');
INSERT INTO Book VALUES(4,'Will', 'Will Smith ', 'Biographies & Memoirs', 'like new', 3, 'https://images-na.ssl-images-amazon.com/images/I/51oDyfsqKwL._SX327_BO1,204,203,200_.jpg',10,'ThriftBook');

    GO
CREATE TABLE Buyer (
	buyerID INT,
	firstName VARCHAR(30),
	lastName VARCHAR(30),
	email VARCHAR(40),
	city VARCHAR(30),
	street VARCHAR(30),
	postalCode VARCHAR(10),
	phoneNumber INT
	PRIMARY KEY (buyerID));
INSERT INTO Buyer VALUES(1,'Keanu','Reeves', 'keanureeves@gmail.com', 'Los Angeles', 'Coldwater Canyon', '90210', 123456);
INSERT INTO Buyer VALUES(2,'Tiger','King', 'tigerking@gmail.com', 'Miami', 'Sunset Blvd.', '10101', 654321);
INSERT INTO Buyer VALUES(3,'Homer','Simpson', 'homer.j.simpson@gmail.com', 'Springfield', 'Evergreen Terrace', '12121', 123321);
INSERT INTO Buyer VALUES(4,'Daenerys', 'Targaryen', 'emailia.clarke@gmail.com', 'Dragonstone', 'Free Cities St.', '13337', 654321);

	GO



CREATE TABLE BookRating(
	bookID	INT FOREIGN KEY REFERENCES Book(bookID),
	buyerID	INT FOREIGN KEY REFERENCES Buyer(buyerID),
	bookRating DECIMAL,
	comments VARCHAR(255),
	PRIMARY KEY (bookID, buyerID));
INSERT INTO BookRating VALUES(1,1,4.5,'good book');
INSERT INTO BookRating VALUES(2,1,4.8,'children like it');
INSERT INTO BookRating VALUES(3,2,4.3,'');
    GO

CREATE TABLE Invoice (
	transactionId INT,	
	buyerID  INT FOREIGN KEY REFERENCES Buyer(buyerID),
	totalPrice FLOAT,
	dateOfTransaction DATE,
	PRIMARY KEY (transactionId));
INSERT INTO Invoice VALUES( 100001, 1, 12.50, '2021-10-16');
INSERT INTO Invoice VALUES( 100002, 2, 8.10, '2021-11-03');
 GO

	CREATE TABLE BookInvoice (	
	transactionId INT FOREIGN KEY REFERENCES Invoice(transactionId),
	bookID	INT FOREIGN KEY REFERENCES Book(bookID),
	
	PRIMARY KEY (bookID, transactionId));
	
INSERT INTO BookInvoice VALUES( 100001, 1);
INSERT INTO BookInvoice VALUES( 100002, 2);


	GO