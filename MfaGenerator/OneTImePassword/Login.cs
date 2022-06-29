using System;
namespace OneTImePassword
{
    internal class Login
    {
        internal int TransactionId { get; set; }
        internal string Username { get; set; }
        internal string Password { get; set; }

        internal Login(int loginTransactionId)
        {
            this.TransactionId = loginTransactionId;
        }
    }
}
