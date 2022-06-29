---ETL---
by Jon Cauble
Framework: .NET Framework 4.7.2
Language: C#

This application is one component of the final project in my C# class at Reynolds Community College taken Spring 2022.  It is an ETL (Extract-Transform-Load) program that, in this particular configuration, retrieves data from:

- Entity Framework relational database table
- CSV file
- XML file

The process is as follows:

1) Data is extracted from each source and stored in temporary memory as POCOs.

2) The data is then transformed and grouped together by the primary key based on yyyy-MM using a series of joins in query syntax Linq.  A list of objects of a new class is again stored in temporary memory.

3) The data is saved, using Entity Framework, in a database table in a file on a remote server.

Without re-implementing the entire Entity Framework structure and connecting to the server, this app currently does not work...at all.  Also, the code is structured to incorporate other ETL processes into the execution.  This would allow multiple ETL processes to be run at once rather than having to individually execute each ETL process.