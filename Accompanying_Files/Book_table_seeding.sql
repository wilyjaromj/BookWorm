USE BookWorm;
GO

INSERT INTO Book (Title, Author, [Description], Rating, Series, CoverArt) 
SELECT 'The Lord of the Rings', 'J. R. R. Tolkein',
'The Lord of the Rings is the saga of a group of sometimes reluctant heroes who set forth to save their world from consummate evil. Its many worlds and creatures were drawn from Tolkien''s extensive knowledge of philology and folklore.',
5, NULL, BulkColumn 
FROM Openrowset( Bulk 'C:\dev\BookWorm\Accompanying_Files\Cover_Art\lotrCover.jpg', Single_Blob) as cover_art

INSERT INTO Book (Title, Author, [Description], Rating, Series, CoverArt) 
SELECT 'The Count of Monte Cristo', 'Alexandre Dumas',
'The Count of Monte Cristo, French Le Comte de Monte-Cristo, Romantic novel by French author Alexandre Dumas père (possibly in collaboration with Auguste Maquet), published serially in 1844–46 and in book form in 1844–45. The work, which is set during the time of the Bourbon Restoration in France, tells the story of an unjustly incarcerated man who escapes to find revenge.',
5, NULL, BulkColumn 
FROM Openrowset( Bulk 'C:\dev\BookWorm\Accompanying_Files\Cover_Art\cofmcCover.jpg', Single_Blob) as cover_art

INSERT INTO Book (Title, Author, [Description], Rating, Series, CoverArt) 
SELECT 'Harry Potter and the Sorcerer''s Stone', 'J. K. Rowling',
'Harry Potter Book 1',
2, 'Harry Potter', BulkColumn 
FROM Openrowset( Bulk 'C:\dev\BookWorm\Accompanying_Files\Cover_Art\hp1Cover.jpg', Single_Blob) as cover_art

INSERT INTO Book (Title, Author, [Description], Rating, Series, CoverArt) 
SELECT 'Harry Potter and the Chamber of Secrets', 'J. K. Rowling',
'Harry Potter Book 2',
3, 'Harry Potter', BulkColumn 
FROM Openrowset( Bulk 'C:\dev\BookWorm\Accompanying_Files\Cover_Art\hp2Cover.jpg', Single_Blob) as cover_art

INSERT INTO Book (Title, Author, [Description], Rating, Series, CoverArt) 
SELECT 'Harry Potter and the Prisoner of Azkaban', 'J. K. Rowling',
'Harry Potter Book 3',
2, 'Harry Potter', BulkColumn 
FROM Openrowset( Bulk 'C:\dev\BookWorm\Accompanying_Files\Cover_Art\hp3Cover.jpg', Single_Blob) as cover_art

INSERT INTO Book (Title, Author, [Description], Rating, Series, CoverArt) 
SELECT 'The Silmarillion', 'J. R. R. Tolkein',
'The Silmarillion is actually Tolkien''s first book and also his last. In origin it precedes even The Hobbit, and is the story of the First Age of Tolkien''s Middle Earth. It shows us the ancient history to which characters in The Lord of the Rings look back, talk, rhyme and sing about. Tolkien worked on it, changed it, and enlarged it throughout his entire life. It was edited and published posthumously by his son Christopher Tolkien, with the assistance of fantasy fiction writer Guy Gavriel Kay to reconstruct some major parts.',
3, NULL, BulkColumn 
FROM Openrowset( Bulk 'C:\dev\BookWorm\Accompanying_Files\Cover_Art\silmarillionCover.jpg', Single_Blob) as cover_art

INSERT INTO Book (Title, Author, [Description], Rating, Series, CoverArt) 
SELECT 'Airborn', 'Kenneth Oppel',
'Airborn is a fantasy adventure book set in an alternate world at some point in the early twentieth century. Most of the action takes place aboard airships, which are the only forms of air transport, since aeroplanes have not yet been invented.',
5, 'Matt Cruse Series', BulkColumn 
FROM Openrowset( Bulk 'C:\dev\BookWorm\Accompanying_Files\Cover_Art\airbornCover.png', Single_Blob) as cover_art

INSERT INTO Book (Title, Author, [Description], Rating, Series, CoverArt) 
SELECT 'Skybreaker', 'Kenneth Oppel',
'A legendary ghost ship. An incredible treasure. A death-defying adventure. Forty years ago, the airship Hyperion vanished with untold riches in its hold. Now, accompanied by heiress Kate de Vries and a mysterious gypsy, Matt Cruse is determined to recover the ship and its treasures. But 20,000 feet above the Earth''s surface, pursued by those who have hunted the Hyperion since its disappearance, and surrounded by deadly high-altitude life forms, Matt and his companions soon find themselves fighting not only for the Hyperion—but for their very lives.',
5, 'Matt Cruse Series', BulkColumn 
FROM Openrowset( Bulk 'C:\dev\BookWorm\Accompanying_Files\Cover_Art\skybreakerCover.jpg', Single_Blob) as cover_art

INSERT INTO Book (Title, Author, [Description], Rating, Series, CoverArt) 
SELECT 'Starclimber', 'Kenneth Oppel',
'Starclimber follows the adventures of Matt Cruse, boy pilot, as he begins his summer break. He plans to spend his summer in Paris with his sort of girlfriend Kate de Vries, but his plans are quickly changed when he is offered a place on an astralnaut training programme in their Canadian home town.',
5, 'Matt Cruse Series', BulkColumn 
FROM Openrowset( Bulk 'C:\dev\BookWorm\Accompanying_Files\Cover_Art\starclimberCover.jpg', Single_Blob) as cover_art

INSERT INTO Book (Title, Author, [Description], Rating, Series, CoverArt) 
SELECT 'The Time Machine', 'H. G. Wells',
'The story follows a Victorian scientist, who claims that he has invented a device that enables him to travel through time, and has visited the future, arriving in the year 802,701 in what had once been London.',
4, NULL, BulkColumn 
FROM Openrowset( Bulk 'C:\dev\BookWorm\Accompanying_Files\Cover_Art\timeMachineCover.jpg', Single_Blob) as cover_art