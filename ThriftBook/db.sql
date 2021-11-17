
IF OBJECT_ID('BookDetails', 'U')    
	IS NOT NULL DROP TABLE BookDetails;
IF OBJECT_ID('BookRating', 'U')    
	IS NOT NULL DROP TABLE BookRating;

    GO
    
CREATE TABLE BookDetails(
	bookID INT IDENTITY(1,1)	PRIMARY KEY,
	title	  VARCHAR(30),	
	author	  VARCHAR(30),	
	gennre	  VARCHAR(30),
	bookQuality VARCHAR(20),
	bookQuantity INT,
	bookPhoto  VARCHAR(255),
	price	  MONEY CHECK(price>0));
INSERT INTO BookDetails VALUES( 'Your Next Five Moves', ' Greg Dinkin', 'Business & Investing', 'like new',5,'https://images-na.ssl-images-amazon.com/images/I/41z2wSFrXbL._SX326_BO1,204,203,200_.jpg',14);
INSERT INTO BookDetails VALUES( 'The Christmas Pig', 'J.K. Rowling', 'Children Books','good', 3,'https://images-na.ssl-images-amazon.com/images/I/51rg5EDPpDL._SX336_BO1,204,203,200_.jpg',12);
INSERT INTO BookDetails VALUES('The Very Hungry Caterpillar', 'Eric Carle ', 'Children Books','old',2, 'https://images-na.ssl-images-amazon.com/images/I/41tyokViuNL._SY355_BO1,204,203,200_.jpg',6.25);
INSERT INTO BookDetails VALUES('Will', 'Will Smith ', 'Biographies & Memoirs', 'like new', 3, 'https://images-na.ssl-images-amazon.com/images/I/51oDyfsqKwL._SX327_BO1,204,203,200_.jpg',10);

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
