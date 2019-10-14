using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project.Controllers
{

  public class GameController : IGameController
  {
    private GameService _gameService = new GameService();

    bool status = true;
    //NOTE Makes sure everything is called to finish Setup and Starts the Game loop
    public void Run()
    {
      Console.Clear();
      Console.WriteLine(@"You wake up in a well lit room. You know exactly why you are here, and who you are.");
      Console.Write("I am: ");
      string choice = Console.ReadLine();
      _gameService.Setup(choice);

      while (status)
      {
        Print();
        GetUserInput();

      }

    }

    //NOTE this should print your messages for the game.
    private void Print()
    {
      Console.Clear();
      foreach (string message in _gameService.Messages)
      {
        if (message == "victory")
        {
          _gameService.Messages.Clear();
          while (true)
          {
            Console.Clear();
            Console.WriteLine($@"The item has been used! 
You watch as it all unfolds!!!
Everything that you expected, and a few things you might not have expected, are all happening before your very eyes! 
Isn't it just amazing?! 
You Are Victorious!!!
Type (Retry) to start again or (Quit) to close the application.
");


            string winChoice = Console.ReadLine();
            switch (winChoice)
            {
              case "retry":
              case "r":
                Run();
                break;
              case "quit":
              case "q":
                Environment.Exit(0);
                break;
            }

          }

        }
        else if (message == "failure")
        {
          _gameService.Messages.Clear();
          while (true)
          {
            Console.Clear();
            Console.WriteLine($@"It happened... 
You have completely lost it.
You knew that by entering this room, there was no turning back.
Your choices have consequences.
Despite all the knowledge that you've accumulated over your lifetime... 
Despite your absolute understanding of what this room was and how it functioned... 
Somehow...
Someway...
We find ourselves here... 

You have no one else to blame but yourself.......

---GAME OVER-- -
Type (Retry) to start again or (Quit) to close the application.
");
            string failChoice = Console.ReadLine();
            switch (failChoice)
            {
              case "retry":
              case "r":
                Run();
                break;
              case "quit":
              case "q":
                Environment.Exit(0);
                break;
            }
          }
        }
        Console.WriteLine(message);
      }
      _gameService.Messages.Clear();
    }


    //NOTE Gets the user input, calls the appropriate command, and passes on the option if needed.
    public void GetUserInput()
    {
      Console.WriteLine("What would you like to do?");
      string input = Console.ReadLine().ToLower() + " ";
      string command = input.Substring(0, input.IndexOf(" "));
      string option = input.Substring(input.IndexOf(" ") + 1).Trim();
      //NOTE this will take the user input and parse it into a command and option.
      //IE: take silver key => command = "take" option = "silver key"
      switch (command)
      {
        case "go":
          _gameService.Go(option);
          break;
        case "take":
          _gameService.TakeItem(option);
          break;
        case "use":
          _gameService.UseItem(option);
          break;
        case "look":
        case "l":
          _gameService.Look();
          break;
        case "help":
        case "h":
          _gameService.Help();
          break;
        case "inventory":
        case "i":
          _gameService.Inventory();
          break;
        case "quit":
        case "q":
          // _gameService.Quit();
          Console.WriteLine("Would you like to Quit the game or Reset it? (Quit)(Reset) Otherwise, you can press any other key to Cancel?");
          string quitChoice = Console.ReadLine().ToLower();
          switch (quitChoice)
          {
            case "quit":
            case "q":
              Environment.Exit(0);
              break;
            case "reset":
            case "r":
              Run();
              break;
          }
          break;
        case "reset":
        case "r":
          // _gameService.Reset();
          Console.WriteLine("Are you sure you would like to Reset the Game? (Yes)(No)");
          string resetChoice = Console.ReadLine().ToLower();
          switch (resetChoice)
          {
            case "yes":
            case "y":
              Run();
              break;
            case "no":
            case "n":
              break;
          }
          break;
        default:
          Console.Clear();
          Console.Write(@"You sit contemplating your life choices...
That's not something you can do right now and you know it!

Press any key to go back and make a valid choice.");
          Console.ReadKey();
          Console.Clear();
          break;
      }

    }



  }

}

// There are two ways you could travel: West and East. although, you already know which direction you need to go.");