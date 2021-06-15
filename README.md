This is my Book Worm website!

I just have a few things to point out for you guys as well as some comments about the project.

First, there is a SQL script in the "Accompanying_Files" folder that will create my BookWorm DB
that the project uses. It creates the DB and the Book table.

Second, there is another SQL script in the same file that will seed the DB with some books that I
used for developing. You can use it if you wish. However, in it I use paths to image files for the
book cover art that you will need to chage for the script to work.

Third, there is a connection string in the appsettings.json file called DefaultConnection that NHibernate
uses to connect to the database. This will need to be changed so it will hook up to whatever DB you
guys are using. I just used MSSQLLocalDB for my development.

Fourth, I have never used NHibernate before! I did my best using online tutorials that I could find, but I
got it working :) You will notice that I do have some EF code in the BookWorm.Data project in the solution.
BUT, I didn;t neglect the requirements, I just used that first to get the site up and running. Then I
switched it over to using NHibernate. I use DI in the startup.cs file, right now the line of code to use EF
is commented out and the NHibernate code is what is being used.

Fifth, I didn't add all of the files in the bin folder to my zip file to cut down on its size, I figured
you wouldn't need it to get it up and running. I apologize if that made it more difficult.

Sixth, I had fun putting this together. There are several things I would do differently if I had more time and
this was an application that was gonna be used heavily. But I did try to make it look nice and it meets all of
the requirements. I hope you enjoy it!

Jarom Williams