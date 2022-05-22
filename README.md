# Book Assessment API

This application is built using C#/Asp.net core and SQL Server. it follows a RESTful API design architecture. It's richly built with a simple scientific technique and best practice in the world of API design.


## INSTRUCTIONS ON HOW TO RUN THE PROJECT:

* Download the project from Github
* Setup your database connection string locally
* Run **update-database** on your Package manager console, then 
* Click on **IIS Express** on Visual Studio to start the project (you can either use Swagger or Postman)	

## API ENDPOINTS - Uisng either Swagger or Postman

| Methods | Endpoints                                   | Access  | Description                              |
| ------- | ------------------------------------------- | ------- | ---------------------------------------- |
| PUT     | /api/books/{id}                             | Public  | Update Single Book                       |
| GET	    | /api/books                                  | Public  | Get Single Book                          |
| POST    | /api/categories                             | Public  | Add Category                             |
| GET     | /api/categories                             | Public  | Get All Category                         |
| PUT     | /api/categories/{id}                        | Public  | Update Category                          |
| DELETE  | /api/categories/{id}                        | Public  | Delete Category                          |
| POST 	  | ​/api​/categories​/add-books-to-categories  | Public  | Add Book To Category                     |
|	        | 	                                          |         |                                          |
|     	  | 			                                      | 	      |                                          |
| 	      | 			                                      |         |                                          |        





