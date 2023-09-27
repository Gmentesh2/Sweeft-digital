//- task 1 
Console.WriteLine(IsPalindrome("2002"));

bool IsPalindrome(string text)
{
    //ცარიელი ადგილების წაშლა და პატარა ასოებში გადაყვანა\\
    string cleanedText = new string(text.Where(char.IsLetterOrDigit).ToArray()).ToLower();
    //შედარება\\
    return cleanedText == new string(cleanedText.Reverse().ToArray());

}
//-- task 2 
Console.WriteLine(MinSplit(120));

int MinSplit(int amount)
{

    int oneCent = 1;
    int fiveCent = 5;
    int tenCent = 10;
    int twentyCent = 20;
    int fiftyCent = 50;

    int tempAmmount = 0;
    int index = 0;
    // 
    while (tempAmmount < amount)
    {
        if (amount - tempAmmount >= fiftyCent)
        {
            tempAmmount += fiftyCent;
            index++;
        }
        else if (amount - tempAmmount >= twentyCent)
        {
            tempAmmount += twentyCent;
            index++;
        }
        else if (amount - tempAmmount >= tenCent)
        {
            tempAmmount += tenCent;
            index++;
        }
        else if (amount - tempAmmount >= fiveCent)
        {
            tempAmmount += fiveCent;
            index++;
        }
        else if (amount - tempAmmount >= oneCent)
        {
            tempAmmount += oneCent;
            index++;
        }
    }
    return index;
}
// task 3 
int[] Array = { 8, 4, 11, 5, 1, 2 ,3, 6 };
int[] Array2 = { 6, 4, 11, 5 ,2 ,1 };

int NotContains(int[] array)
{
    int result = 1;

    for (int i = 0; i < array.Length; i++)
    {
        for (int j = 0; j < array.Length; j++)
        {
            if (result == array[j])
            {
                result++;
            }
        }
    }
    return result;

}

Console.WriteLine(NotContains(Array));


//  task 4 
bool isProperty(string sequence)
{
    int temp = 0;
    for (int i = 0; i < sequence.Length; i++)
    {
        if (sequence[i] == ')')
            temp--;

        if (sequence[i] == '(')
            temp++;

        if (temp < 0)
            return false;
    }

    if (temp == 0)
    {
        return true;
    }

    return false;
}



Console.WriteLine("Property: " + isProperty("()"));

// task 5

int countVariants(int stairCount)
{
    return countVariantsTmp(stairCount, 0, 0);
}



int countVariantsTmp(int stairCount, int curr, int stepN)
{
    if (curr + stepN > stairCount)
        return 0;
    if (curr + stepN == stairCount)
        return 1;

    int variants = 0;

    if (curr + stepN < stairCount)
    {
        variants += countVariantsTmp(stairCount, curr + stepN, 1);
        variants += countVariantsTmp(stairCount, curr + stepN, 2);
    }
    return variants;
}

Console.WriteLine("Count: " + countVariants(3));