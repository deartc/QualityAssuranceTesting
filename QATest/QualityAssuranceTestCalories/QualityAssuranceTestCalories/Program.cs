using System;
using System.Diagnostics;

namespace QualityAssuranceTestCalories
{ }

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
class Calculation
{
    private const string Value = "\nThanks for Using Calorie Calculator...";

    static void Main(string[] args)
    {
        GenderCheck();
        WeightCheck();
        CalorieCalc();
        GetUserMacros();
        Console.Write(Value);

    }

    public static int weight, multiplier, numCalories;

   
    private static void GenderCheck(bool onlyLetters = false)
    {
        Console.Write("Do you identify as a man or a woman?\n");
        string gender = Console.ReadLine();

        for (int i = 0; i < gender.Length; i++)
        {
            if (gender == "Male" || gender == "male" || gender == "Female" || gender == "female")
            {
                onlyLetters = true;
                Console.WriteLine("You identify as a  " + gender.ToLower() + ".\n");
                break;
            }
            else
            {
                onlyLetters = false;
            }
        }

        if (onlyLetters == false)
        {
            Console.WriteLine("Please enter the gender you identify as.\n");
            GenderCheck();
        }
    }

    //Ideal weight needs to be entered
    private static void WeightCheck()
    {

        Console.Write("Enter you ideal weight in lbs.\n");
        string lbs = Console.ReadLine();

        int.TryParse(lbs, out weight);

        Console.Write("Your ideal is " + weight + " lbs.\n");

    }

    //Calculates macros of the user
    private static void CalorieCalc()
    {
        Console.Write("\nDetermine specific diet desired.\n");
        Console.Write("\nDetermine a calorie multiplier between 10 and 20:\n");

        string multSelect = Console.ReadLine();

        //Converts multiplier to integer
        int.TryParse(multSelect, out multiplier);

        Console.Write("Your multiplier is " + multiplier + ".\n");

        numCalories = weight * multiplier;

        Console.Write("\nYour Calorie consumption should be" + numCalories + " calories per day.\n");

        Console.Write("\nEnter the percentages of each nutriet category (must add up to 100%).\n");
    }

    private static void GetUserMacros()
    {

        //Gets protein percentage from user
        Console.Write("Protein: ");
        string ProteinNumber = Console.ReadLine();

        float ProteinPercent;
        float.TryParse(ProteinNumber, out ProteinPercent);

        //Gets the carb percentage from user
        Console.Write("\nCarbohydrates: ");
        string carbNumber = Console.ReadLine();

        float CarbPercent;
       
       bool v2 = float.TryParse(CalculationHelpers.GetCarbNumber4(), out CarbPercent);
        bool v1 = v2;
        bool v = v1;


        //Gets the fat percentage from user
        Console.Write("\nFat: ");
        string FatNumber = Console.ReadLine();

        float FatPercent;
        float.TryParse(FatNumber, out FatPercent);

        //Verifies user input adds up to 100%
        if (ProteinPercent + CarbPercent + FatPercent != 100)
        {
            Console.Write("\nSorry! Your selected percentages must add up to 100%. Please try again.\n");
            GetUserMacros();
        }
        else
        {
            //Calculate Protein Numbers
            float proteinCalories = numCalories * (ProteinPercent / 100);
            float proteinGrams = proteinCalories / 4;


            //Calculate Carb Numbers
            float carbCalories = numCalories * (CarbPercent / 100);
            float carbGrams = carbCalories / 4;


            //Calculate Fat Numbers
            float fatCalories = numCalories * (FatPercent / 100);
            float fatGrams = fatCalories / 9;


            Console.Write("\nYour recommended macronutrient distribution:\n\n");
            Console.Write("Protein: " + proteinCalories + " calories (" + proteinGrams.ToString("#.##") + "g)\n");
            Console.Write("Carbs: " + carbCalories + " calories (" + carbGrams.ToString("#.##") + "g)\n");
            Console.Write("Fat: " + fatCalories + " calories (" + fatGrams.ToString("#.##") + "g)\n");
        }
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
}