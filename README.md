# Addressbook MVC

My notes regarding this project will go into this readme

(at this point the directions has turned into a cookbook style instruction manual)

---

## Before WORKING on the project we need to:

1. Add NuGet Packages to the solution:

    - Microsoft.EntityFrameworkCore
    - Microsoft.EntityFrameworkCore.Tools
    - Npgsql.EntityFrameworkCore.PostgreSQL

2. Add a new folder called "Data"

    - Add a class in the Data folder called "ApplicationDbContext"
    - To the newly created class add "`:DbContext`" to the public class ApplicationDbContext and add the using directive "`using Microsoft.EntityFrameworkCore`" to the class
    - Next we'll need to configure the options by adding:
    `public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }` into the ApllicationDbContext : DbContext class, inside the brackets of course..

3. As work around to the shoddy instruction add the following code block to Program.cs

    `using AddressBookMVC.Data;`
    `using Microsoft.EntityFrameworkCore;`
    `using System.Configuration;`

    `var builder = WebApplication.CreateBuilder(args);`
    
    `builder.Services.AddControllerWithViews();`
    `builder.Services.AddDBContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection)));`

    `AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);`
    
    `var app = builder.Build();`

4. Next we need to modify appsettings.json
    - from the first curly bracket create a space and type out:
    `"ConnectionStrings": {
    "DefaultConnection" :"Server=localhost;Port=5432;Database=AddressBook;User Id=postgres;Password=BushDid911;"
  },`
    - the name of the database will dictate the name of the database created in postgres by the entity framework via package manager console
 
5. Open the nuget package manager console
    - then type `update-database`
    - open pgAdmin 4 to confirm the database did in fact "update"

6.  Already added to the work around, but duly noted. If not added there will be a TimestampBehavior error when the form is submitted.
    - `AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true)`

### Congratulations! you completed the set-up you deserve a pat on the back, champ :D

---

go back to scaffold video and take notes, please

---

Register Image Service

Add new folder "Services"
    - inside Services add another folder "Interfaces"
    - add a new interface named IImageService
        - naming convention dictates that interfaces start with "I" regardless if the name of the file starts with an "I"
    - add a new class to services named BasicImageService
        - implement the IImageService interface with ` : IImageService`
        - don't forget the using directive
        - the compiler will complain that we're not using the methods declared in the interface, so use the drop down menu and have visualstudio implement an interface; then delete the throw-statements

Much later:
    - add `enctype="multipart/form-data"` to the form or else the post will not get the file
