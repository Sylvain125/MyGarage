// See https://aka.ms/new-console-template for more information
using ExoGarage.InterfaceConsole;
using ExoGarage.Model;
using ExoGarage.Program;

internal class MyGarageApp
{
    public MyGarageApp()
    {
    }

    /// <summary>
    /// Le Run, lance un reader et un writer pour lire les inputs des utilisateurs
    /// et ecrire dans la console.
    /// Ensuite il lance un garage avec sa liste de vehicules.
    /// Puis il lance le Menu principale du garage en boucle.
    /// </summary>
    public void Run()
    {
        var consoleReader = new ConsoleReader();
        var consoleWriter = new ConsoleWriter();

        var garage = new Garage( consoleReader, consoleWriter);
        var mainMenu = new Menu(consoleReader, consoleWriter, garage);

        bool weContinue = true;
        do
        {
            mainMenu.ShowMainMenu();

        } while (weContinue);
    }
}