// This program implemenets a virtual pet simulator
class petSim
{
    static void Main()
    {
        // Validates user input is an integer and returns that integer
        static int getIntInput(int numOptions)
        {
            bool validInput = false;
            int userInput = -1;
            while (validInput == false)
            {
                try
                {
                    userInput = int.Parse(Console.ReadLine());
                    if (userInput < 1 || userInput > numOptions)
                    {
                        Console.WriteLine("Enter a valid input!");
                    }
                    else
                    {
                        validInput = true; // break loop
                    }
                }
                catch
                {
                    Console.WriteLine("Enter a valid input!");
                }
            }
            return userInput;
        }

        float hunger = 5;
        float happiness = 5;
        float health = 5;

        // Program Requirement 1 - Pet Creation
        string[] petTypes = ["Dog", "Cat", "Rabbit"];
        int userInput = -1;
        int numPetTypes = petTypes.Length;
        Console.WriteLine("Choose your type of pet: \n 1 - Dog \n 2 - Cat\n 3 - Rabbit");
        int userPetType = getIntInput(numPetTypes);
        Console.WriteLine("You have chosen {0}! Please enter a name for your {0}:", petTypes[userPetType - 1], petTypes[userPetType - 1]);
        string userPetName = Console.ReadLine();
        Console.WriteLine("Welcome {0}!", userPetName);


    }
}


