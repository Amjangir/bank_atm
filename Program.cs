

using System;
using System.Collections.Generic;
using System.Linq;

namespace project2
{
    class Program
    {
        public static List<User> users = new List<User>()
        {
            new User { id = 1, username = "amit", password = "12345", pin = "1234", account = "11111" },
            new User { id = 2, username = "arif", password = "12345", pin = "1234", account = "22222" },
            new User { id = 3, username = "sumit", password = "12345", pin = "1234", account = "33333" },
            new User { id = 4, username = "arshad", password = "12345", pin = "1234", account = "44444" },
            new User { id = 5, username = "pooja", password = "12345", pin = "1234", account = "55555" },
        };
        public static void get()
        {
        start:
            Console.WriteLine("enter your username.");
            string username = Console.ReadLine();
            Console.WriteLine("enter password.");
            string pass = Console.ReadLine();

            var user = Program.users.Single(s => s.username == username && s.password == pass);

            if (user != null)
            {
            recycle:
                Console.WriteLine("enter 1 for check account balance");
                Console.WriteLine("enter 2 for cash withdrawal");
                Console.WriteLine("enter 3 for add cash");
                Console.WriteLine("enter 4 for cash transfer");
                Console.WriteLine("enter 5 for exit");

                int enr = int.Parse(Console.ReadLine());

                switch (enr)
                {
                    case 1:
                        Console.WriteLine("total balance is {0}", user.balance);
                        goto recycle;
                    case 2:
                        Console.WriteLine("enter your withdrawal balance");
                        int withd = int.Parse(Console.ReadLine());
                        if(withd > user.balance)
                        {
                            Console.WriteLine("Your balance is low");
                            goto recycle;
                        }
                        user.balance = user.balance - withd;



                        Console.WriteLine("STATE BANK OF INDIA");
                        Console.WriteLine("BRANCH");
                        Console.WriteLine("ACOUNT NUMBER = {0}", user.account);
                        Console.WriteLine("YOUR WITHDRAWAL AMOUNT {0}", withd);
                        Console.WriteLine("your balance is {0}", user.balance);
                        goto recycle;
                    case 3:
                        Console.WriteLine("enter adding amount");
                        int add = int.Parse(Console.ReadLine());

                        user.balance = user.balance + add;
                        Console.WriteLine("STATE BANK OF INDIA");
                        Console.WriteLine("BRANCH");
                        Console.WriteLine("ACOUNT NUMBER = {0}", user.account);
                        Console.WriteLine("YOUR ADDING AMOUNT {0}", add);
                        Console.WriteLine("your balance is {0}", user.balance);
                        goto recycle;

                    case 4:
                        string _acc = "";
                        while (true)
                        {
                            Console.WriteLine("enter account number");
                            _acc = Console.ReadLine();
                            if(_acc == user.account)
                            {
                                Console.WriteLine("can not transfer to same account");
                                continue;
                            }
                            var isAccountExist = users.Any(s => s.account == _acc);
                            if(isAccountExist)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("account number not exist");
                            }
                        }

                        Console.WriteLine("enter adding amount");
                        int _add = int.Parse(Console.ReadLine());

                        if(user.balance < _add)
                        {
                            Console.WriteLine("balance low");
                            goto recycle;
                        }

                        var _ben_user = users.Single(s => s.account == _acc);

                        _ben_user.balance = _ben_user.balance + _add;
                        user.balance = user.balance - _add;

                        Console.WriteLine("STATE BANK OF INDIA");
                        Console.WriteLine("BRANCH");
                        Console.WriteLine("BEN ACOUNT NUMBER = {0}", _ben_user.account);
                        Console.WriteLine("YOUR TRANSFER AMOUNT {0}", _add);
                        Console.WriteLine("your balance is {0}", user.balance);
                        goto recycle;

                    case 5:
                        goto start;



                    default:
                        Console.WriteLine("please enter valid no.........!");
                        goto recycle;
                }
            }
            else
            {
                Console.WriteLine("INVALIDE ACCOUNT NO. AND PIN NO. .....");
                Console.WriteLine("PLEASE ENTER VALID ACCOUNT NO. AND PIN . .....");
            }
        }


        static void Main(string[] args)
        {
            //Program.AddUser("amit", "12345", "1234", "1234567890");
            Program.get();
        }

    }

    class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string pin { get; set; }
        public string account { get; set; }
        public int balance { get; set; } = 0;
    }

}
