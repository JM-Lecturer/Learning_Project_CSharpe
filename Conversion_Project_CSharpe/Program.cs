using System.ComponentModel.DataAnnotations;
using System.Runtime.Versioning;

namespace Conversion_Project_CSharpe
{
    class User
    {

        private string m_fName;
        private string m_lName;
        private string m_userName;
        private string m_password;

        public string FirstName { get { return m_fName; } set { m_fName = value; } }
        public string LastName { get { return m_lName; } set { m_lName = value; } }
        public string Username { get { return m_userName; } set { m_userName = value; } }
        public string Password { get { return m_password; } set { m_password = value; } }

        public User(string fName, string lName, string userName, string password)
        {

            m_fName=fName;
            m_lName=lName;
            m_userName=userName;
            m_password=password;

        }
        public string GetFullName()
        {

            return m_fName + " " +  m_lName;

        }

    }

    internal class Program
    {
        
        static void RunMenu(ref List<string> menuList, ref int menuChoice)
        {

            bool isValid = true;

            do
            {

                Console.WriteLine(menuList[0] + "\n");

                for (int i = 1; i < menuList.Count; i++)
                {

                    Console.WriteLine(i + ": " + menuList[i]);

                }

                try
                {

                    Console.WriteLine("\nPlease enter in a value from the list provided:");
                    menuChoice = Convert.ToInt16(Console.ReadLine());

                    isValid = true;

                    if (menuChoice < 1 || menuChoice > menuList.Count - 1)
                    {

                        throw new IndexOutOfRangeException();

                    }

                }
                catch (IndexOutOfRangeException)
                {

                    Console.Clear();
                    Console.WriteLine("You can only enter in numbers from the list provided...\n[Press Enter to Try Again]");
                    Console.ReadLine();
                    isValid = false;
                    Console.Clear();

                }
                catch (FormatException) {

                    Console.Clear();
                    Console.WriteLine("You can only enter in whole numbers...\n[Press Enter to Try Again]");
                    Console.ReadLine();
                    isValid = false;
                    Console.Clear();

                }
                catch (Exception) {

                    Console.Clear();
                    Console.WriteLine("Sorry, an unknown error has occurred...\n[Press Enter to Try Again]");
                    Console.ReadLine();
                    isValid = false;
                    Console.Clear();

                }

            } while (isValid == false);
            
        }
        static void DisplayAllUsers(ref List<User> myUsers)
        {

            Console.Clear();

            foreach (User user in myUsers)
            {

                Console.WriteLine("Your name is: " + user.GetFullName() + "\nYour Username is: " + user.Username + "\nYour password is: " + user.Password + "\n\n");

            }

            Console.WriteLine("\n[Press Enter to Return]");
            Console.ReadLine();
            Console.Clear();

        }
        static void RunStart(ref User myUser)
        {

            Console.Clear();
            Console.WriteLine("Your name is: " + myUser.GetFullName() + "\nYour Username is: " + myUser.Username + "\nYour password is: " + myUser.Password + "\n[Press Enter to Return]");
            Console.ReadLine();
            Console.Clear();

        }
        static void Main(string[] args)
        {
            //Program begins running from this point!

            int menuChoice = 0;

            do
            {

                List<string> menuList = new List<string> { "-----------Menu-----------", "Display One User", "Display More Users", "Exit" };
                RunMenu(ref menuList, ref menuChoice);

                User MyUser = new User("Jay", "Miles", "JM", "123");

                List<User> myUsers = new List<User>();

                myUsers.Add(new User("Jay", "Miles", "JM", "123"));
                myUsers.Add(new User("Jon", "Barnett", "JoB", "123"));
                myUsers.Add(new User("Jack", "Burnet", "JaB", "123"));

                switch (menuChoice)
                {

                    case 1:

                        Console.Clear();
                        RunStart(ref MyUser);
                        Console.Clear();
                        break;

                    case 2:

                        Console.Clear();
                        DisplayAllUsers(ref myUsers);
                        Console.Clear();
                        break;

                    case 3:

                        Console.WriteLine("Good Bye!\n[Press Enter to Close]");
                        Console.ReadLine();
                        break;
                }

            } while (menuChoice != 3);

        }
    }
}