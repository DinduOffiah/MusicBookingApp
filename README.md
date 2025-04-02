Music Booking App API
The Music Booking App API is a backend service designed to handle artist profiles, event listings, and booking transactions. Built with ASP.NET Core (C#), it offers secure, scalable functionality for managing and booking music events.

🧰 Features
Artist Profiles Create, read, update, and delete (CRUD) artist information like name, biography, and genre.

Event Listings Manage event details, including title, description, venue, date, and associated artist.

Booking Transactions Securely create and manage bookings for events, with details such as customer name, email, and payment information.

User Authentication & Authorization Secure endpoints with JSON Web Token (JWT)-based authentication to ensure only authorized users can perform sensitive operations.

Scalable Architecture Designed with clean, maintainable code and Microsoft’s best practices.

🏗️ Project Structure
MusicBookingApp/
├── Controllers/
│   ├── ArtistsController.cs
│   ├── EventsController.cs
│   ├── BookingsController.cs
│   └── AuthController.cs
├── Data/
│   └── ApplicationDbContext.cs
├── Models/
│   ├── Artist.cs
│   ├── Event.cs
│   ├── Booking.cs
│   ├── AppUser.cs
│   └── AuthDtos.cs   (RegisterDto and LoginDto)
├── Services/
│   └── TokenService.cs
├── Program.cs
└── appsettings.json
🛠️ Technologies Used
Framework: ASP.NET Core (C#)

Database: SQL Server with Entity Framework Core

Authentication: ASP.NET Identity with JWT

API Testing: Postman (recommended)

Documentation: Swagger / OpenAPI

🚀 Getting Started
1. Clone the Repository
bash
git clone https://github.com/DinduOffiah/MusicBookingApp.git
cd music-booking-app
2. Configure the Database
Update the appsettings.json file with your SQL Server connection string:

json
"ConnectionStrings": {
  "DefaultConnection": "YourDatabaseConnectionString"
}
3. Run Database Migrations
Apply the migrations to create the database schema:

bash
dotnet ef database update
4. Run the Application
Start the API locally:

bash
dotnet run
The API will be available at https://localhost:7012; http://localhost:5200 (or as configured).

5. Test the API with Postman
Import the API endpoints into Postman.

Add a Bearer Token to the Authorization header for secured endpoints (authentication required).

Example token format:

Authorization: Bearer <your-jwt-token>
🔑 Authentication Workflow
Register a New User: Send a POST request to /api/auth/register with the following JSON:

json
{
    "userName": "testuser",
    "email": "testuser@example.com",
    "password": "Password123!",
    "confirmPassword": "Password123!"
}
Log In: Send a POST request to /api/auth/login with the following JSON:

json
{
    "userName": "testuser",
    "password": "Password123!"
}
You will receive a JWT token. Use this token to authenticate requests to protected endpoints.

📋 API Endpoints
Artists
Method	Endpoint	Description
GET	/api/artists	List all artists
GET	/api/artists/{id}	Get a specific artist
POST	/api/artists	Create a new artist
PUT	/api/artists/{id}	Update an artist
DELETE	/api/artists/{id}	Delete an artist
Events
Method	Endpoint	Description
GET	/api/events	List all events
GET	/api/events/{id}	Get a specific event
POST	/api/events	Create a new event
PUT	/api/events/{id}	Update an event
DELETE	/api/events/{id}	Delete an event
Bookings
Method	Endpoint	Description
GET	/api/bookings	List all bookings
GET	/api/bookings/{id}	Get a specific booking
POST	/api/bookings	Create a new booking
PUT	/api/bookings/{id}	Update a booking
DELETE	/api/bookings/{id}	Delete a booking
🛡️ Security Features
JWT Authentication: Secures API endpoints with tokens that include user claims.

📚 How to Test the API (Recommended with Postman)
Install Postman Download Postman.

Set up Requests Create requests for each endpoint. Use the appropriate HTTP method (GET, POST, PUT, DELETE).

Authentication For secured endpoints, include the Authorization header with your JWT token:

Authorization: Bearer <your-jwt-token>
Example Flow in Postman:

Register a user.

Log in to get a token.

Use the token to create, update, and delete artists, events, or bookings.

📝 License
This project is open-source and free to use. Feel free to modify and adapt it to suit your needs!
