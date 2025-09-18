// This program implemenets a virtual pet simulator
class petSim
{
    static string[] petTypes = ["Dog", "Cat", "Rabbit"];
    static int numPetTypes = petTypes.Length;
    // Validates user input is an integer and returns that integer
    static int GetIntInput(int numOptions)
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
    static int[] FeedPet(int[] status, string name)
    {
        int[] result = [-1, -1, -1];
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
    static int[] PlayPet(int[] status, string name)
    {
        int[] result = [-1, -1, -1];
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
    static int[] RestPet(int[] status, string name)
    {
        int[] result = [-1, -1, -1];
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
        Console.WriteLine("{0} rested, and is now healthier, but also a bit less happy.", name);
        return result;
    }
    // 3.1 - Display pet's stats
    static void DisplayStatus(int[] status, string name)
    {
        Console.WriteLine(" Hunger: {0}\n Happiness: {1}\n Health: {2}", status[0], status[1], status[2]);
    }

    // 3.2 - Status check that warns user if any stat is critical
    static void DisplayWarnings(int[] status, int type, string name)
    {
        // High hunger
        if (status[0] > 7)
        {
            Console.WriteLine("Your {0} is hungry, try feeding {1}!", petTypes[type], name);
        }
        // Low happiness
        if (status[1] < 3)
        {
            Console.WriteLine("Your {0} is unhappy, try playing with {1}!", petTypes[type], name);
        }
        // Low health
        if (status[2] < 3)
        {
            Console.WriteLine("Your {0} is unhealthy, try letting {1} rest!", petTypes[type], name);
        }
        return;
    }
    // 4.1 - Implement time-based changes
    static int PassTime(int time, int hours = 1)
    {
        return time + hours;
    }
    static void DisplayTime(int time)
    {
        Console.WriteLine("Day {0} -- Time {1:D2}:00", (time / 24) + 1, time % 24);
    }
    static void Main()
    {
        // Program Requirement 1.1 - Choose a pet type and give it a name
        string[] petTypes = ["Dog", "Cat", "Rabbit"];

        int numPetTypes = petTypes.Length;
        Console.WriteLine("Choose your type of pet: \n 1 - Dog \n 2 - Cat\n 3 - Rabbit");
        int userPetType = GetIntInput(numPetTypes) - 1;
        Console.WriteLine("You have chosen {0}! Please enter a name for your {0}:", petTypes[userPetType], petTypes[userPetType]);
        string userPetName = Console.ReadLine();

        // 1.2 - Display a welcome message that includes the pet's name and type
        Console.WriteLine("Welcome, {0} the {1}!", userPetName, petTypes[userPetType]);

        // 3.1 - Track pet's stats on a scale from 1 to 10
        int[] petStatus = [5, 5, 5]; // [0] = Hunger, [1] = Happiness, [2] = Health

        // 2.1 - Pet Care Actions

        int currInput = -1;
        int numOptions = 5;
        int currTime = 0;
        while (currInput != 5)
        {
            DisplayTime(currTime);
            // 3.2 - Status check and display warnings
            DisplayWarnings(petStatus, userPetType, userPetName);
            // 6.1 / 6.2 - Give user instruction on how to interact with console interface
            Console.WriteLine("What would you like to do with {0}?\n 1 - Feed {0}\n 2 - Play with {0}\n 3 - Let {0} rest\n" +
                " 4 - Check {0}'s status \n 5 - Exit", userPetName);
            currInput = GetIntInput(numOptions);
            switch (currInput)
            {
                case 1:
                    // 2.1.1 - Feed the pet
                    petStatus = FeedPet(petStatus, userPetName);
                    //Console.WriteLine("You fed {0}!")
                    break;
                case 2:
                    // 5.1 / 5.2 - Special event - refuse to play if too hungry
                    if (petStatus[0] == 10)
                    {
                        Console.WriteLine("{0} is too hunrgy to play, and instead knocked over your garbage can to find food!", userPetName);
                        Console.WriteLine("{0}'s hunger went down, but {0} also got sick, significantly impacting health.", userPetName);
                        petStatus[0] -= 2;
                        petStatus[2] -= 3;
                        if (petStatus[2] > 10)
                        {
                            petStatus[2] = 10;
                        }
                    }
                    else
                    {
                        // 2.1.2 - Play with the pet
                        petStatus = PlayPet(petStatus, userPetName);
                    }
                    break;
                case 3:
                    // 5.1 / 5.2 - Special event - refuse to rest if too unhappy
                    if (petStatus[0] == 10)
                    {
                        Console.WriteLine("{0} ran away because of low happiness!", userPetName);
                        Console.WriteLine("{0} came back from their adventure happier, but also got in a fight with a stray, significantly impacting health.", userPetName);
                        petStatus[1] += 2;
                        petStatus[2] -= 3;
                        if (petStatus[2] > 10)
                        {
                            petStatus[2] = 10;
                        }
                    }
                    else
                    {
                        // 2.1.3 - Let the pet rest
                        petStatus = RestPet(petStatus, userPetName);
                    }
                    break;
                case 4:
                    // Display pet's status
                    DisplayStatus(petStatus, userPetName);
                    // Subtract an hour so time does not pass from checking status
                    currTime = PassTime(currTime, -1);
                    break;
                case 5:
                    //Exit
                    break;
                default:
                    Console.WriteLine("Unexpected Behaviour"); // Should never reach here with input validation done
                    break;
            }
            currTime = PassTime(currTime);
        }
    }
}