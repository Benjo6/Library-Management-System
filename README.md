# Assignment 4: Mini-Project 3: APIs

### Description of the project and mandatory requirement

The objective of this assignment is to let you compare, choose, design, and implement
various APIs as a mean of inter-service communication in microservices architecture.
The task is to extend the School Micro Info System with services that allow the students to
buy books, related to their study programme, from the library.

Your solution should consider using a source of books recommendation, control of books’
availability at the library store, and some accounting, useful for the student’s budget

It is a mandatory requirement to develop and implement at least one RESTful API
and at least one gRPC API.


### Architecture

![](https://github.com/Benjo6/Library-Management-System/blob/master/Images/ER-Diagram.png) 

For fulfilling the requirements of the project have we constructed the classes in Grpc Servers, while REST is used to act as client for the Grpc Servers. We could made one of the Grpc Server into a REST Server, but we decided it would be more interesting to experiment with Grpc. The REST Server also offers that the Grpc Servers have web browser support, which makes it possible to try the methods in Swagger. We also decided to make the Grpc servers in two different programming languages to showcase two ways of implementing Grpc Servers. The languages are Go and C#.

### Methods

The Methods are mainly simple CRUD functionalities, but we also made a suggest book method, which searching for books of same category. The idea behind this is when you are selecting a book on the website, then it will show books of the same category as suggested books.

**Author**

Get() = It returns a list of all authors in the database.

Get(int id) = It returns the author with the inserted id. 

Post(AddAuthorRequest request) = It creates a new author into the database.

Delete(RemoveRequest request) = It removes the inserted author from the database.

**Book**

Get() = It returns a list of all books in the database.

Get(int id) = It returns the book with the inserted id. 

Post(AddBookRequest request) = It creates a new book into the database.

Delete(RemoveBookRequest request) = It removes the inserted id from the database.

SuggestBook(int id) = It returns all books with the same category as the insert book (via id). In a final project on an interface should it probably return only five books.

**Student**

Get() = It returns a list of all students in the database.

Get(int id) = It returns the student with the inserted id. 
 
Post(CreateStudentRequest request) = It creates a new student into the database.

Delete(int id) = It removes the inserted id from the database.

## How To Start The Database

### prerequisite
* Docker installed

### Instructions

* cd into Infrastructure/Databases/mysql
* run command: docker-compose -f docker-compose.yml up -d

Now you should have a mysql database with data. It can be accessed in mysql workbench with the following credentials:

* host: 127.0.0.1
* port: 3307
* user: root
* password: abed123

## How To Start The Program

- Clone the Github Repo

- Open the project in Visual Studio Code

- Then Run all Services in the project

**For C# Projects**

Use this command for each service under Modules except for the Go Project (Student)

dotnet run

**For Go Project**

Add Coderunner to your Visual Studio Code and run the Server.go file.

Last: Run the API project with the same command as the other C# Projects.
