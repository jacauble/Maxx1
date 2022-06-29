using System;
using System.Text;
using System.Net.Mail;

namespace OneTImePassword
{
    internal class OTP
    {
        internal int TransactionId { get; set; } // Primary Key
        internal string OneTimePass { get; set; }
        //internal bool WasOtpUsed { get; set; }
        internal DateTime TimeOtpGenerated { get; set; }
        //internal DateTime TimeOtpUsed {get;set;}

        internal OTP(int otpTransactionId)
        {
            this.TransactionId = otpTransactionId;
            TimeOtpGenerated = DateTime.Now;
        }

        internal static string CreateNewOtp()
        {
            string charSetAlphabetic = "ABCDEFGHJKLMNPQRSTUVWXYZ";
            string charSetNumeric = "23456789";
            string charSet;
            const int otpLength = 6;
            StringBuilder newOtp = new StringBuilder();
            Random rand = new Random();

            for (int i = 0; i < otpLength; i++)
            {
                if (rand.Next(0, 2) == 0)
                {
                    charSet = charSetAlphabetic;
                }
                else
                {
                    charSet = charSetNumeric;
                } 
                int nextCharacter = rand.Next(0, charSet.Length);
                newOtp.Append(charSet[nextCharacter]);
            }
            return newOtp.ToString();
        }
        internal static void SendIt(OTP otp1, User user1)
        {
            string email = ""; // Sender's email would go here 
            string user = ""; // Email acount username goes here
            string password = ""; // Email account password goes here
            MailMessage newMail = new MailMessage();
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            newMail.From = new MailAddress(email);
            newMail.To.Add(user1.Contact);
            newMail.Subject = "One-Time Password";
            newMail.IsBodyHtml = true;
            newMail.Body = $"<h3>Your one-time password is:<br>{otp1.OneTimePass.Substring(0, 3)} - {otp1.OneTimePass.Substring(3, 3)}</h3>";
            client.EnableSsl = true;
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(user, password);
            client.Send(newMail);
            //
            Console.WriteLine($"OTP sent to cauble.ja@gmail.com...\n");
        }
    }
}
