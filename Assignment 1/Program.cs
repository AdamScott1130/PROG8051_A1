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
        static double[] feedPet(double[] status)
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

            return result;
        }
        static double[] playPet(double[] status)
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
            return result;
        }
        static double[] restPet(double[] status)
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

            return result;
        }
        void displayStatus(double[]status)
        {
            Console.WriteLine(" Hunger: {0}\n Happiness: {1}\n Health: {2}", status[0], status[1], status[2]);
        }
            // Program Requirement 1 - Pet Creation
            string[] petTypes = ["Dog", "Cat", "Rabbit"];

            int numPetTypes = petTypes.Length;
            Console.WriteLine("Choose your type of pet: \n 1 - Dog \n 2 - Cat\n 3 - Rabbit");
            int userPetType = getIntInput(numPetTypes);
            Console.WriteLine("You have chosen {0}! Please enter a name for your {0}:", petTypes[userPetType - 1], petTypes[userPetType - 1]);
            string userPetName = Console.ReadLine();
            Console.WriteLine("Welcome {0}!", userPetName);

            // Program Requirement 2 - Pet Care Actions

            double[] petStatus = [5.0, 5.0, 5.0]; // [0] = Hunger, [1] = Happiness, [2] = Health

            // Main loop

            int currInput = -1;
            int numOptions = 5;
            while (currInput != 5)
            {
                Console.WriteLine("What would you like to do with {0}?\n 1 - Feed {0}\n 2 - Play with {0}\n 3 - Let {0} rest\n" +
                    " 4 - Check {0}'s status \n 5 - Exit", userPetName);
                currInput = getIntInput(numOptions);
                switch (currInput)
                {
                    case 1:
                        //Feed the pet
                        petStatus = feedPet(petStatus);
                        //Console.WriteLine("You fed {0}")
                        break;
                    case 2:
                        // Play with the pet
                        petStatus = playPet(petStatus);
                        break;
                    case 3:
                        // Let the pet rest
                        petStatus = restPet(petStatus);
                        break;
                    case 4:
                        // Display pet's status
                        displayStatus(petStatus);
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


