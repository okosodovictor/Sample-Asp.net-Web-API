# Sample Asp.net-Web-API Project with JWT athorization flow

Sample RESTful Asp.net Web Api with demonstration of Onion Achitecture and security implementation with JWT.

This Project is a RESTful web services that exposes data related to customer invoices to Acme Cable TV Company. 
This solution is a RESTful Api build with Microsoft Asp.Net web Api and C# language. 

Tools Used:
1.	 IDE:  used is Visual studio 2015.
2.	 Database: Microsoft SQL server. 
3.	Framework/ library: Entity framework i.e the object relational mapper, Ninject, Operation etc.

   Architecture used: I used Onion Architecture which is also called  Hexagonal architecture.
   
How to set it up: Microsoft Visual studio 2015 or above can be used to open the solution source code. The solution comprise of four projects:
i.	BEAssignment.Api which is the web api part and it comprise of the following files: 
1.	It has folder called Controller, the files here coordinate and handles all request from the client.
2.	NinjectApi file does the work of handling all dependencies i.e  Ninject the IOC container which is a dependency injection framework for .NET.
3.	MainModule file is where I specify the Bindings.

ii.	BEAssignment.Core comprises of the Business layer and include the following sub folders
1.	Business -: The business object files are here.
2.	Interfaces -: Here contains the interfaces implemented by business managers. They are IInvoiceRepository and IInvoicemanager.
3.	Managers -: Here we have the business managers also called the business logic of the solution. The file here is Invoicemanager which implements the interface IInvoicemanager.  
4.	The las file here is the Extension class that has a generic function called Assign. The function help to assign values from source object to destination object using reflection.
 
iii.	BEAssignment.Data comprises of the data access layer. 
It has InvoiceRepository class which implements IInvoiceRepository interface and coordinate all data access i.e. getting invoices and creating Invoices. It also include a folder were I have all the Entities i.e the Customer, Invoice and address. The Migrations folder and DataEntities that serve the bridge between my entities and the database. 

 How to build: 
 Once the solution loads on Visual studio and all the projects loads correctly go ahead and build the solution. Once is building correctly change the connection string in web.config file of BEAssignment.Api project to your MSSQL server credentials.
 Then set the BEAssignment.Api as the start-up project and Run the below command on the Package manager console making sure the default project selected is BEAssignment.Data. 
Command: pm> update-database –verbose.
The command will create the database and create the tables for the solution. Finally run the solution by clicking on run by selecting either Google Chrome or any browser convenient for you.

ER Diagram: 
 
https://docs.google.com/document/d/1yq7QkHdtRFPOWycK3cMg5OkRj7pMth0eC_SLJqP602A/edit?usp=sharing
 
