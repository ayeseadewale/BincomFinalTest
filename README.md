**Car Dealer Web Application Documentation**
Overview
This web application is designed for a car dealership to manage car listings and handle customer inquiries. It allows an admin to manage car listings (add, edit, delete cars) and view all inquiries submitted by users. Users can browse cars, view detailed information, and submit inquiries regarding specific cars.

The application consists of an Admin interface for managing car listings, a User interface for browsing and inquiring about cars, and API endpoints to manage cars and inquiries.

**Features**
**Admin Features:**__

Login (admin credentials)
Add, Edit, and Delete car listings
View all car listings
Manage customer inquiries
User Features:

Browse and view car listings
Submit inquiries about specific cars
API Endpoints:

CRUD operations for car listings
Inquiry submission
Technologies Used
Backend: C# with ASP.NET Core MVC
Database: SQL Server (or any other relational database with Entity Framework Core)
Frontend: Razor Pages for Admin and User interfaces
Authentication: No authentication required for the public (user side). Admin login with hardcoded credentials.
Deployment: Azure (via GitHub Actions for CI/CD)
Architecture
The application follows a typical Model-View-Controller (MVC) pattern, which is organized as follows:

Model: Represents the data and business logic. In this case, Car and Inquiry are the main models.
View: The UI for both Admin and User. Admin views allow managing cars and inquiries, while the user views display the cars and a form for submitting inquiries.
Controller: Handles requests and business logic. There are two main controllers: AdminController (for managing cars and inquiries) and HomeController (for the user side of the application).
Conclusion
This web application provides the car dealer with an efficient way to manage their car listings and respond to customer inquiries. It is built using C#, ASP.NET Core MVC, and Entity Framework Core. The application offers both an Admin interface for managing cars and inquiries, and a User interface for browsing cars and submitting inquiries. The application is ready for deployment and can be easily extended or customized as needed.
**Admin Login Credentials**
Username: admin
Password: password123
