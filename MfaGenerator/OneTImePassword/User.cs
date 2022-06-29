using System;

namespace OneTImePassword
{
    internal class User
    {
        internal string Name { get; set; }
        internal string Pass { get; set; }
        internal string Contact { get; set; }

        internal User(string username, string password, string contactEmail)
        {
            Name = username;
            Pass = password;
            this.Contact = contactEmail;
        }
        internal User(string username, string password)
        {
            Name = username;
            Pass = password;
        }
    }
}
