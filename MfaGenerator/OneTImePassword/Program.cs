using System;

namespace OneTImePassword
{
    class Program
    {
        // This demo version asks the user for contact info.  In the full version, user credentials are stored in a database and checked against input values.
        // It also requires you to enter your own sender email account in OTP.SendIt().
        static void Main(string[] args)
        {
            int otpTransactionId = 42; // Placeholder, will eventually be auto-incrementing
            OTP otp1 = new OTP(otpTransactionId);
            User user1 = new User("Maxx", "password1"/*, contact*/);
            int loginTransactionId = 999;
            Login login1 = new Login(loginTransactionId);
            login1 = EnterCredentials(login1);
            int counter = 1;
            while (counter < 3 && (user1.Pass != login1.Password || user1.Name != login1.Username))
            {
                login1 = EnterCredentials(login1);
                counter++;
            } 
            bool isValid = IsLoginGood(user1, login1.Username, login1.Password);
            if (isValid)
            {
                Console.Write("Enter the email address where you would like your one-time password sent >> "); // This feature is added for demo
                user1.Contact = Console.ReadLine();
                otp1.OneTimePass = OTP.CreateNewOtp();
                OTP.SendIt(otp1, user1);
                
                bool areWeGood = EnterOTP(otp1);
                int counter2 = 1;
                while (counter2 < 3 && !areWeGood)
                {
                    areWeGood = EnterOTP(otp1);
                    counter2++;
                }
                if (areWeGood)
                {
                    Console.WriteLine("You get the cake!");
                }
                else
                {
                    Console.WriteLine("Too many attempts\n\nPress any key to exit application...");
                }
            }
            else
            {
                Console.WriteLine("Too many login attempts\n\nPress any key to exit application...");
            }
            //TestDisplay(otp1, user1, login1);
            Console.ReadKey();
            Environment.Exit(0);
        }
        public static Login EnterCredentials(Login login1)
        {
            Console.Write("USERNAME >> ");
            login1.Username = Console.ReadLine();
            Console.Write("PASSWORD >> ");
            login1.Password = Console.ReadLine();
            Console.Clear();

            return login1;
        }
        public static bool IsLoginGood(User user1, string inputUsername, string inputPassword)
        {
            bool isValid = false;

            if (inputUsername == user1.Name && inputPassword == user1.Pass)
            {
                isValid = true;
            }
            
            return isValid;
        }
        public static bool EnterOTP(OTP otp1)
        {
            bool areWeGood = false;
            Console.Write("Enter the OTP >> ");
            string enteredOtp = Console.ReadLine();
            if (enteredOtp == otp1.OneTimePass)
            {
                areWeGood = true;
            }
            Console.Clear();

            return areWeGood;
        }
        public static void TestDisplay(OTP otp1, User user1, Login login1)
        {
            Console.WriteLine($"LOGIN:\t{login1.Username}\t{login1.Password}");
            Console.WriteLine($"user: {user1.Name}\tpass: {user1.Pass}\temail: {user1.Contact}");
            Console.WriteLine($"\nid: {otp1.TransactionId}\t\ttime: {otp1.TimeOtpGenerated}\t" +
                $"otp: {otp1.OneTimePass.Substring(0, 3)} - {otp1.OneTimePass.Substring(3, 3)}");
        }
    }
}
