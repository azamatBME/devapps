using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant
{//it was created to present kazakh national food restraunt. You could google names of meal, if you don't know them 
    class Program
    {
        static void Main(string[] args)
        {
            //hard-coded fault parameters to avoid DB connection process
            //dynamic dictionary for reservation
            var Booking = new Dictionary<int, dynamic>();
            DateTime time1 = new DateTime(2020, 4, 12, 18, 30, 00);
            DateTime time2 = new DateTime(2020, 10, 12, 19, 30, 00);
            DateTime time3 = new DateTime(2020, 2, 12, 19, 30, 00);
            Booking[1] = new { TableName = "Dastarkhan", DateT = time1, bookedBy = "Elena", num = 12 };
            Booking[2] = new { TableName = "Trestle-bed", DateT = time2, bookedBy = "Toktar", num = 4 };
            Booking[3] = new { TableName = "Carpet-table", DateT = time3, bookedBy = "Aizhan", num = 7 };

            //dynamic dictionary for menu        
            var menu = new Dictionary<String, dynamic>();
            menu["Dastarkhan"] = new { meal = "Beshparmak", soup = "Sorpa", salad = "Pickles" };
            menu["Trestle-bed"] = new { meal = "Kuyrdak", soup = "Kozhe", salad = "Ogonek" };
            menu["Carpet-table"] = new { meal = "Fishparmak", soup = "Kazakh tea", salad = "Vegetable salad" };
           
            //getting name for reservation                          
            Console.WriteLine("\nWelcome to 'Nauryz' Restaurant of kazakh national food! Please, insert your name: ");
            var name = Console.ReadLine();
            //getting date and time for reservation  
            Console.Write("Please, insert date when you want to make reservation (DD/MM/YYYY HH:MM): ");
            DateTime IDate = DateTime.Parse(Console.ReadLine());
            //checking for availability of tables by datetime
            foreach (int i in Booking.Keys)
            {
                if (DateTime.Compare(IDate.Date, Booking[i].DateT.Date) == 0)
                {
                    Booking.Remove(i); //removing booked tables from list for client
                }
            }

            if (Booking.Count == 0)
            { //there is no available places for certain time
                Console.WriteLine("We' re sorry. For this time, restraunt is full. Please, call us later");
            }
            else
            {//if there are available places for guests
                Console.WriteLine("\nFor this date and time, we have following tables: ");
                foreach (var k in Booking.Keys)
                {
                    Console.WriteLine("For now, {0} available for {1} people\t", Booking[k].TableName, Booking[k].num);
                }
                //getting name of preferred table
                Console.WriteLine("\nPlease, write down table that you prefer to book: ");
                var tableNum = Console.ReadLine();
                //getting the number of waiting guests
                Console.WriteLine("\nPlease, write down number of people: ");
                int numP = Convert.ToInt32(Console.ReadLine());
                //creating new element of dictionary by provided information
                int i = Booking.Keys.Max();
                Booking[i + 1] = new { tableNum = tableNum, DateT = IDate, bookedBy = name, num = numP };
                //presenting menu for certain national table
                Console.WriteLine($"\nFor booked table, the following meal will be provided: {menu[Booking[i + 1].tableNum].meal}, {menu[Booking[i + 1].tableNum].soup}, {menu[Booking[i + 1].tableNum].salad}");
                //confirmation of booking
                Console.WriteLine($"\n{Booking[i + 1].bookedBy}, you made a booking of {Booking[i + 1].tableNum} for {Booking[i + 1].num} guests ");

                
                
            }
        }
    }
}