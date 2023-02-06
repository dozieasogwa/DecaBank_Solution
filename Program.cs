using DecaBankApp_Week_3_Task_.UI;

namespace DecaBankApp_Week_5_Task_
{
    public class Program 
    {
        static void Main(string[] args)
        {
            var myBank = new UiMenu();
            myBank.StartApp();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();
            //Application.Run(new Program());

        }
    }
}
