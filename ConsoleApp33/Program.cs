using System.Collections.Generic;
using ConsoleApp33;
#region Task 1
Dictionary<string, DateTime> exams = new();

exams.Add("Math", new DateTime(2025, 6, 1));
exams.Add("English", new DateTime(2025, 6, 3));
exams.Add("History", new DateTime(2025, 6, 5));

foreach (var exam in exams) {
    Console.WriteLine($"{exam.Key} exam is on {exam.Value:dd/MM/yyyy}");
    Console.WriteLine($"There are {(exam.Value.Date - DateTime.Now.Date).TotalDays} days left to exam.");
    Console.WriteLine();
}
#endregion

#region Task 3

Console.WriteLine("\n\n\n");

uint bookLimit;
do {
    Console.Write("Enter book limit: ");
} while (!uint.TryParse(Console.ReadLine(), out bookLimit));

Library library = new(bookLimit);

string? option;
do {
    ShowMenu();
    Console.Write("Enter option: ");
    option = Console.ReadLine();
    switch (option) {
        case "1":
            Console.Write("Enter book name: ");
            string? book = Console.ReadLine();
            try {
                library.AddBook(book);
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            break;
        case "2":
            Console.Write("Enter book name: ");
            book = Console.ReadLine();
            try {
                if (library.RemoveBook(book)) {
                    Console.WriteLine("Book removed");
                }
                else {
                    Console.WriteLine("Book not found");
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            break;
        case "3":
            foreach (string? b in library.books) {
                Console.WriteLine(b);
            }
            break;
        case "4":
            Console.Write("Enter string to search: ");
            string? search;
            do {
                search = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(search));

            foreach (string? b in library.books) {
                if (b.ToLower().Contains(search.ToLower())) {
                    Console.WriteLine(b);
                }
            }
            break;
        case "0":
            Console.WriteLine("Exiting...");
            break;
        default:
            Console.WriteLine("Invalid option");
            break;
    }

} while (option != "0");

static void ShowMenu() {
    Console.WriteLine("1. Add book");
    Console.WriteLine("2. Remove book");
    Console.WriteLine("3. Show books");
    Console.WriteLine("4. Shearch book");
    Console.WriteLine("0. Exit");
}
#endregion