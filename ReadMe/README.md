# Sad Trombone Productions App

## Description

This app was created from a music production company. Within the app a user can login in or sign up. Users can upload images, videos, or audio recordings of their talents for others to see. This function is to help people in the music industry get discovered.

## Usage 

All frontend, xaml and viewmodels are in the mobile final .net maui appliication. The Media API is the backend api that connects to the database through controllers.

## How to create a simpliar app

### Front-End

The front end is what your user is going to see. Ideas to understand

1. Create a .net maui project 
	- This is done by adding a new .net maui project through visual studios
2. Use the MVVM pattern to create new pages and content
	- The MVVM pattern stands for the Model View ViewModel. 
	- We use the MVVM pattern to organize the design and operations from the UI side of things
		- ViewModel holds the data between the view and the model, this is where we do most of our operations. Normal C# classes in the viewmodel directory
		- the View is the actual design or what we will actually see on the front-end side, examples in any file ending in .xaml

 Possible errors or problems
	- Make sure in the xaml.cs page has the bindingcontext property set to the viewmodel. 
	- 

### Back-End

The backend is the operations that aren't creating the UI or user interface. Our API project talks to our database and our blob storage. Here we use http routing for the two projects to talk to each other. 

Componts of the Back-end

1. Controllers - the controllers hold the logic that talks to the database. In the controller are all our C# queries are held. 
2. DBcontext - our DBContext has all the information when you scaffold your database. Note all the classes that represent ours tables in the database are in the Shared project so both the backend and frontend have access to them. 

Possible errors or fixes 
	- example of scaffolding database "dotnet ef dbcontext scaffold "host=database-1.cisqkskacvfb.us-west-2.rds.amazonaws.com; database=instantrunoff; user id=iroapp; password=EasyToGuess" Npgsql.EntityFrameworkCore.PostgreSQL -o Data -c InstantRunoffContext"
	- if This command isn't working make sure all the right packages are installed: dotnet, ef core, dotnet add package npgsql.entityframeworkcore.postgresql
	- 

## Using our app as a new user
### Login
First you will see the login page. If you don't already have an account, then click the sign up button. Enter in your first and last name. You will then be taken to a online login where you will click the sign up button, entering in your email and a password. Your username will then be set to your email. 

### Main Page 
You will be taken to the main home page with the navigation bar at the bottom. On the home page you will see a list of videos, audios, and images. This page is for artist, musician, or whatever to display their talents. People can comment on others arts.

### Scedule Page
This page is were people can schedule appointments with Sad Trombone productions for records, or infomation. There is a calendar displaying what times are already taken and the plus buttom that'll display the popup page that people can create their appointments. 

### Upload Page
This page is where you can upload your art or music. Just make sure you select the media type and give the file a name

### Profile Page
Here you can see your personal information. Your name, username, profile picture, and your upload history. You can view each one of your uploads to see the comments that have been posted on them and how posted the comment.  










