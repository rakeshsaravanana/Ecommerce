using System;
namespace Ecommerce;
public class Program 
{
    public static void Main(string[] args)
    {
        FileHandling.Create();
        //Operations.DefaultData();
        FileHandling.ReadfromCSV();
        Operations.MainMenu();
        FileHandling.WritetoCSV();
    }
}