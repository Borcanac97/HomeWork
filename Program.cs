
using HomeWork;
using System.ComponentModel;

public class Program
{
    public static void Main(string[] args)
    {
        //1.
        try
        {
            Console.WriteLine("Input number: ");
            string inputString = Console.ReadLine();
            int number = Int32.Parse(inputString);
            if (IsPalindrome(number))
            {
                Console.WriteLine("Number is palindrome");
            }
            else
            {
                Console.WriteLine("Number is not palindrome");
            }
        }
        catch (FormatException exception)
        {
            Console.WriteLine("Unable to parse");
        }

        //2.
        Console.WriteLine("Input string :");
        string word = Console.ReadLine();
        Console.WriteLine("Perfect strings: " + NumberOfPerfectString(word));

        //3.
        Console.WriteLine("Input pangram string: ");
        string pangram = Console.ReadLine();

        if (IsPangram(pangram))
        {
            Console.WriteLine("String is pangram");
        }
        else
        {
            Console.WriteLine("String is not pangram");
        }

        //4.
        Console.WriteLine("Input substring string: ");
        string substring = Console.ReadLine();
        Console.WriteLine("Input primary string string: ");
        string primString = Console.ReadLine();
        if (IsSubString(substring, primString))        {
            Console.WriteLine("String is substring");
        }
        else
        {
            Console.WriteLine("String is not substring");
        }
    }
    public static bool IsPalindrome(int number)
    {
        string inputNumber = number.ToString();
        for (int i = 0; i < inputNumber.Length / 2; i++)
        {
            if (inputNumber[i] != inputNumber[inputNumber.Length - 1 - i])
            {
                return false;
            }
        }
        return true;
    }

    public static int NumberOfPerfectString(string word)
    {
        int numberOfR = 0;
        int numberOfS = 0;
        int numberOfPerfectString = 0;
        bool readingR = true;
        bool readingS = false;
        for (int i = 0; i < word.Length; i++)
        {
            if (word[i] == 'R')
            {
                numberOfR++;
                if (!readingR && readingS)
                {
                    if (numberOfR == numberOfS)
                    {
                        readingR = true;
                        numberOfPerfectString++;
                        numberOfR = 0;
                        numberOfS = 0;
                    }

                    readingR = true;
                    readingS = false;
                }

            }
            else if (word[i] == 'S')
            {
                numberOfS++;
                readingR = false;
                readingS = true;
            }
            else
            {
                return numberOfPerfectString;
            }
            if (numberOfR == numberOfS)
            {
                numberOfPerfectString++;
                numberOfR = 0;
                numberOfS = 0;
            }

        }
        return numberOfPerfectString;
    }


    public static bool IsPangram(string pangram)
    {
        if (pangram.Length < 1 || pangram.Length > 1000)
        {
            Console.WriteLine("string length must be between 1 and 1000");
            return false;
        }
        bool[] alphabet = new bool[26];
        for (int i = 0; i < pangram.Length; i++)
        {
            alphabet[pangram[i] -'a'] = true;
        }
        
        for(int i = 0; i < alphabet.Length; i++)
        {
            if (!alphabet[i])
            {
                return false;
            }
        }
        return true;    
    }


    public static bool IsSubString(string subString, string primString)
    {
        if (subString.Length < 0 || subString.Length > 100)
        {
            Console.WriteLine("subString length must be between 1 and 100");
            return false;
        }
        else if (primString.Length < 0 || primString.Length > 100)
        {
            Console.WriteLine("primString length must be between 1 and 100");
            return false;
        }

        bool found = false;

        for (int i = 0; i < subString.Length; i++)
        {
            for (int j = 0; j < primString.Length; j++)
            {
                if (primString[j] == subString[i])
                {
                    found = true;
                    break;
                }

            }
            if (!found)
            {
                return false;
            }
            else found = false;
        }
        return true;
    }
}













