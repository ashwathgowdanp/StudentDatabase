// Student database Lab

// Array Definition

using System.Data;
using System.Diagnostics;
using System.Reflection.Emit;
using StudentDatabaseLab;

string[] Name    = new string[9];
string[] Hometown = new string[9];
string[] FavoriteFood = new string[9];

// Fill the information to Array

StudentDatabaseMethod.fillStudentDatabase(Name, Hometown, FavoriteFood);

Console.Write("Welcome! Would you like to see a list of all students? Enter 'y' or 'n': ");
String? ListOfStudents = Console.ReadLine();
if (ListOfStudents != null)
{
    if (ListOfStudents.ToLower() == "y")
    {
        Console.WriteLine("Please find below the list of students:");
        for (int i = 0; i < Name.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Name[i]}");
        }
    }
}
   

bool TryAgain = true;
do
{
    int UserEnteredNumber = 0;
    bool SearchOption = false;
    bool ValidOption = false;

    
    if (ListOfStudents != null)    {
        
            Console.Write("Would you like to search for the student by name or number ? Enter 'y' for name or 'n' for number: ");
            String? SearchStudent = Console.ReadLine();
            if (SearchStudent.ToLower() == "y")
            {
                SearchOption = true;
                Console.Write("Please enter the Name: ");
                String? StudentName = Console.ReadLine();
                for (int i = 0;i < Name.Length; i++)
                {
                    if (StudentName.ToLower() == Name[i].ToLower())
                    {
                        UserEnteredNumber = i + 1;                        
                        ValidOption = true;
                    break;
                        
                    }
                    
                }

            }
        
    }
    if (!SearchOption)
    {
        Console.Write("Which student would you like to learn more about? Enter a number 1-9:");
        string? UserOption = Console.ReadLine();
        ValidOption = int.TryParse(UserOption, out UserEnteredNumber);
    }
    if (!ValidOption || UserEnteredNumber > Name.Length)
    {
        Console.WriteLine("Please enter a valid Option: Would you like to try again? (y/n) ");
        String? UserAnswer = Console.ReadLine();
        if (UserAnswer.ToLower() == "n")
            break;
        else
            continue;       
    }
    else
    {
        bool ValidAnswer = true;        
        Console.WriteLine($"Student {UserEnteredNumber} is {Name[UserEnteredNumber - 1]}:  What would you like to know? Enter 'hometown' or 'favorite food':");
        
        do
        {
            string? UserAnswer = Console.ReadLine();
            if (String.IsNullOrEmpty(UserAnswer) && String.IsNullOrWhiteSpace(UserAnswer) && UserAnswer != "hometown" && UserAnswer != "favorite food")
            {
                Console.Write("That category does not exist. Please try again. Enter 'hometown' or 'favorite food': ");
                ValidAnswer = false;

            } 
        
           
           switch (UserAnswer.ToLower())
            {

            case "hometown":
                {
                    Console.WriteLine($"{Name[UserEnteredNumber - 1]} is from {Hometown[UserEnteredNumber - 1]}:");
                        ValidAnswer = true;
                        break;
                }
            case "favorite food":
                {
                    Console.WriteLine($"{Name[UserEnteredNumber - 1]} Favorite food is {FavoriteFood[UserEnteredNumber - 1]}:");
                        ValidAnswer = true;
                        break;
                }
            default:
                {
                    Console.WriteLine("That category does not exist. Please try again.Enter 'hometown' or 'favorite food':");
                        ValidAnswer = false;
                        break;
                }
        } 
        } while (!ValidAnswer);

        Console.Write("Would you like to learn about another student? Enter 'y' or 'n': ");
        string? Answer = Console.ReadLine();
        if (Answer != null)
        {
            if (Answer.ToLower() == "n")
                TryAgain = false;
            else TryAgain = true;
        }
        else
        {
            Console.WriteLine("Please try again Later:");
            TryAgain= false;
        }

    }


}while (TryAgain);
