// This program implemenets a virtual pet simulator
class petSim
{
    // Global variable initialization
    static string[] petTypes = ["Dog", "Cat", "Rabbit"];
    static int numPetTypes = petTypes.Length;
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
                // Input must be between 1 and numOptions
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

    // 2.2 - Modify pet stats and display a message describing each action's effect
    static double[] feedPet(double[] status, string name)
    {
        double[] result = [-1, -1, -1];
        if ((status[0] - 1) < 0)
        {
            result[0] = 0;
        }
        else
        {
            result[0] = status[0] - 1;
        }

        result[1] = status[1];

        if ((status[2] + 1) > 10)
        {
            result[2] = 10;
        }
        else
        {
            result[2] = status[2] + 1;
        }
        Console.WriteLine("You fed {0}, who is now happier and less hungry!", name);
        return result;
    }
    static double[] playPet(double[] status, string name)
    {
        double[] result = [-1, -1, -1];
        if ((status[0] + 1) > 10)
        {
            result[0] = 10;
        }
        else
        {
            result[0] = status[0] + 1;
        }

        if ((status[1] + 1) > 10)
        {
            result[1] = 10;
        }
        else
        {
            result[1] = status[1] + 1;
        }
        result[2] = status[2];
        Console.WriteLine("You played with {0}, who is now happier, but also a bit hungrier.", name);
        return result;
    }
    static double[] restPet(double[] status, string name)
    {
        double[] result = [-1, -1, -1];
        result[0] = status[0];
        if ((status[1] - 1) < 0)
        {
            result[1] = 0;
        }
        else
        {
            result[1] = status[1] - 1;
        }

        if ((status[2] + 1) > 10)
        {
            result[2] = 10;
        }
        else
        {
            result[2] = status[2] + 1;
        }
        Console.WriteLine("You played with {0}, who is now healthier, but also a bit less happy.", name);
        return result;
    }
    // 3.1 - Display pet's stats
    static void displayStatus(double[] status, string name)
    {
        Console.WriteLine(" Hunger: {0}\n Happiness: {1}\n Health: {2}", status[0], status[1], status[2]);
    }

    // 3.2 - Status check that warns user if any stat is critical
    static void displayWarnings(double[] status, int type, string name)
    {
        // High hunger
        if (status[0] > 7)
        {
            Console.WriteLine("Your {0} is hungry, try feeding {1}!", petTypes[type], name);
        }
        if (status[1] < 3)
        {
            Console.WriteLine("Your {0} is unhappy, try playing with {1}!", petTypes[type], name);
        }
        if (status[2] < 3)
        {
            Console.WriteLine("Your {0} is unhealthy, try letting {1} rest!", petTypes[type], name);
        }
        return;
    }
    static void Main()
    {
        
        // Program Requirement 1.1 - Choose a pet type and give it a name
        string[] petTypes = ["Dog", "Cat", "Rabbit"];

        int numPetTypes = petTypes.Length;
        Console.WriteLine("Choose your type of pet: \n 1 - Dog \n 2 - Cat\n 3 - Rabbit");
        int userPetType = getIntInput(numPetTypes) - 1;
        Console.WriteLine("You have chosen {0}! Please enter a name for your {0}:", petTypes[userPetType], petTypes[userPetType]);
        string userPetName = Console.ReadLine();

        // 1.2 - Display a welcome message that includes the pet's name and type
        Console.WriteLine("Welcome, {0} the {1}!", userPetName, petTypes[userPetType]);

        // 3.1 - Track pet's stats on a scale from 1 to 10
        double[] petStatus = [5.0, 5.0, 5.0]; // [0] = Hunger, [1] = Happiness, [2] = Health

        // 2.1 - Pet Care Actions

        int currInput = -1;
        int numOptions = 5;
        while (currInput != 5)
        {
            // Program Requirement 3.2 - Status check and display warnings
            displayWarnings(petStatus, userPetType, userPetName);

            Console.WriteLine("What would you like to do with {0}?\n 1 - Feed {0}\n 2 - Play with {0}\n 3 - Let {0} rest\n" +
                " 4 - Check {0}'s status \n 5 - Exit", userPetName);
            currInput = getIntInput(numOptions);
            switch (currInput)
            {
                case 1:
                    // 2.1.1 - Feed the pet
                    petStatus = feedPet(petStatus, userPetName);
                    //Console.WriteLine("You fed {0}")
                    break;
                case 2:
                    // 2.1.2 - Play with the pet
                    petStatus = playPet(petStatus, userPetName);
                    break;
                case 3:
                    // 2.1.3 - Let the pet rest
                    petStatus = restPet(petStatus, userPetName);
                    break;
                case 4:
                    // Display pet's status
                    displayStatus(petStatus, userPetName);
                    break;
                case 5:
                    //Exit
                    break;
                default:
                    Console.WriteLine("Unexpected Behaviour"); // Should never reach here with input validation done
                    break;
            }
        }
    }
}
