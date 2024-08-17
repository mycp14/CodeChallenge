# CodeChallenge
Please see here the instructions on how this code will run into your local. I've used the technologies .Net Core 6 and Entity Framework Core Code-Base First and other libraries for this project.
1. Once this solution is cloned, open this in Visual Studio 2022.
2. Under WebAPI, you can find the appssettings.json and please change the connection string base to your respective local SQL credentials.
3. Once the SQL credential is changed. We can now proceed with the migration.
   1. Open the Package Manager Console, and change the current Default project to "WebAPI.DbMigrator"
   2. And type this in the CLI command "add-migration salesDB"
   3. When add migration is completed, there was an EF designer pop-up
   4. You need once again to type in the CLI command "update-database".
   5. Done.
4. And, if the instructions above are completed then under "Build Tab" you can now click the clean and build solution.
5. If there's no error then you can now run the API application.
