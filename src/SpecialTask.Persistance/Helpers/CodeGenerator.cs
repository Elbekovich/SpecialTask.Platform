namespace SpecialTask.Persistance.Helpers;
public class CodeGenerator
{
    public static int GenerateRandomNumber()
    {
        Random rand = new Random();
        return rand.Next(1000,9999);
    }
}
