using System.Threading.Channels;
using ConsoleTables;
using Hotel.IRepositories;
using Hotel.Models;
using Hotel.Repostories;

IUserRepository userRepository = new UserRepository();

var whileCondition = true;

while (whileCondition)
{
    Console.WriteLine("1. Create\n2. Delete\n3. Update\n4. Get\n5. GetAll\n6. Exit");
    var inputStep = (EUserStep)int.Parse(Console.ReadLine());

    switch (inputStep)
    {
        case EUserStep.Create:
            {
                {
                    Console.Write("First name: ");
                    var fName = Console.ReadLine();

                    Console.Write("Last name: ");
                    var lName = Console.ReadLine();

                    Console.Write("Age: ");
                    var age = int.Parse(Console.ReadLine());

                    var user = new User()
                    {
                        FirstName = fName,
                        LastName = lName,
                        Age = age
                    };

                    userRepository.Create(user)
    ;
                }
                break;
            }
        case EUserStep.Delete:
            {
                Console.Write("Id: ");
                var inputId = int.Parse(Console.ReadLine());

                userRepository.Delete(inputId);
            }
            break;

        case EUserStep.Update:
            {
                Console.Write("Id: ");
                var inputId = int.Parse(Console.ReadLine());
                Console.WriteLine();


                Console.Write("First name: ");
                var fName = Console.ReadLine();

                Console.Write("Last name: ");
                var lName = Console.ReadLine();

                Console.Write("Age: ");
                var age = int.Parse(Console.ReadLine());

                var user = new User()
                {
                    FirstName = fName,
                    LastName = lName,
                    Age = age
                };

                userRepository.Update(user, inputId);
            }
            break;

        case EUserStep.Get:
            {
                Console.Write("Id: ");
                var inputId = int.Parse(Console.ReadLine());

                var user = userRepository.Get(inputId);

                if (user == null)
                    Console.WriteLine("Invalid user!");
                else
                {
                    var table = new ConsoleTable("Id", "First name", "Last name", "Age");
                    table.AddRow(user.Id, user.FirstName, user.LastName, user.Age);
                    table.Write();
                }


            }
            break;
        case EUserStep.GetAll:
            {
                var users = userRepository.GetAll();

                if (users != null)
                {
                    foreach (var user in users)
                    {
                        Console.WriteLine(user.FirstName + " " + user.LastName);
                    }
                }
                else
                {
                    Console.WriteLine("\nNot users!\n");
                }

            }break;

        case EUserStep.Exit: whileCondition = false;
            break;
    }
}