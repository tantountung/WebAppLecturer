public class FeverCheck
{
    public static string FeverCheck1(int temp)
    {
        string message;
        int cutOff = 38;


        if (temp > cutOff)
        {
            message = "You have fever";
        }
        else
        {
            message = "You dont have fever";
        }

        return message;
    }
}