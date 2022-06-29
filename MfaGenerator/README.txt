---Multi-Factor Authentication Code Generator and Test Console---
by Jon Cauble
Framework: .NET 5
Language: C#

This application generates a one-time password which is sent via email.  The user must then enter the six-digit code contained in that email in order to progress past the login section.  The app is currently broken as of May 2022 as Google has deprecated a feature which allowed 'less-secure apps' to access Google services including Gmail.  This could be remedied by changing the mail client used.

The full version of this app would also be linked to an encrypted relational database to manage login credentials of multiple users without any hard-coding of credentials.

** Credentials for this demo version **
user: Maxx
password: Gonzo

The process is as follows:

1) Enter your username and password.  The software searches POCOs for a match.  If there is a match, a one-time password is sent to the user's email address on file.  In the demo version, the user is prompted to provide an email address.

2) In this demo, which is admittedly broken as of now, a SMTP exception is thrown and the one-time password is instead displayed in the CLI.

3) Enter the one-time password when prompted to.  Is the cake a lie?

There is still much work to do on this project.  With some more work and proper encryption methods, this software could be integrated into pretty much any other application that involves password-protected functionality.