using System;
using System.Linq;

class Program
{
    static void Main()
    {
        using (var context = new AdsDbContext())
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("1. Show all users");
                Console.WriteLine("2. Show all ads");
                Console.WriteLine("3. Exit");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowUsers(context);
                        break;
                    case "2":
                        ShowAds(context);
                        break;
                    case "3":
                        exit = true;
                        break;
                }
            }
        }
    }

    static void ShowUsers(AdsDbContext context)
    {
        var users = context.Users.ToList();
        foreach (var user in users)
        {
            Console.WriteLine($"{user.ID}: {user.Name}, {user.Email}, {user.Phone}");
        }
    }

    static void ShowAds(AdsDbContext context)
    {
        var ads = context.Ads.ToList();
        foreach (var ad in ads)
        {
            Console.WriteLine($"{ad.Title}: {ad.Price}");
        }
    }
}
