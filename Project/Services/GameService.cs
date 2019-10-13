using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project
{
  public class GameService : IGameService
  {
    private IGame _game { get; set; }
    public List<string> Messages { get; set; }



    public GameService()
    {
      _game = new Game();
      Messages = new List<string>();
    }

    public void Go(string direction)
    {
      switch (direction)
      {
        case "n":
          direction = "north";
          break;
        case "s":
          direction = "south";
          break;
        case "e":
          direction = "east";
          break;
        case "w":
          direction = "west";
          break;

      }
      // string currentName = _game.CurrentRoom.Name;
      string from = _game.CurrentRoom.Name;
      _game.CurrentRoom = _game.CurrentRoom.Go(direction);
      string to = _game.CurrentRoom.Name;
      if (from != to)
      {
        Look();

      }
      else if (direction == "north" || direction == "south" || direction == "east" || direction == "west")
      {
        Messages.Add($@"You attempt to go {direction}, however you quickly realize that there is no {direction} to go. 
Obstructing your path is just a plain old wall with a very simple existence: keeping you from going past it. 
Maybe try a different route?");
      }
      else
      {
        Messages.Add($@"If you're not going North, South, East, or West... You're not going anywhere!");
      }

      if (_game.CurrentRoom.Name == "five")
      {
        Messages.Clear();
        Messages.Add(_game.CurrentRoom.Description);
        // Reset();
      }


      // switch (direction)
      // {
      //   case "north":
      //   case "n":
      //     Messages.Add(@"That's a wall...");
      //     break;
      //   case "south":
      //   case "s":
      //     Messages.Add(@"You can't go that way.");

      //     break;
      //   case "east":
      //   case "e":
      //     _game.CurrentRoom = _game.CurrentRoom.Go("two");
      //     break;
      //   case "west":
      //   case "w":
      //     Messages.Add(@"You attempt to go West, however, you quickly realize that there is no West to go.");

      //     break;
      //   default:
      //     Messages.Add(@"If you're not going North, South, East, or West... You're not going anywhere!");
      //     break;
      // }

      // else if (_game.CurrentRoom.Name == "two")
      // {
      //   switch (direction)
      //   {
      //     case "north":
      //     case "n":
      //       Messages.Add(@"That's a wall...");
      //       break;
      //     case "south":
      //     case "s":
      //       Messages.Add(@"You can't go that way.");

      //       break;
      //     case "east":
      //     case "e":
      //       _game.CurrentRoom = _game.CurrentRoom.Go("three");
      //       break;
      //     case "west":
      //     case "w":
      //       _game.CurrentRoom = _game.CurrentRoom.Go("four");
      //       break;
      //     default:
      //       Messages.Add(@"If you're not going North, South, East, or West... You're not going anywhere!");
      //       break;
      //   }
      // }
    }

    public void Help()
    {
      //NOTE done
      Messages.Add(@"Oh... 
I see... 
I'm not sure how you could possibly forget something that you have been doing all of your life, but I guess I can spell it out for you once more...?


You can use the following commands to interact with your surroundings:

(Look): This command reminds you to use your eyes, 'cause let's face it! you're not really great at focussing.

(Go (N)(S)(E)(W)): This command allows your legs to do their thing! It gets you places. 
                   Specifically, the places that you tell them to take you.

(Take (Item Name)): This command allows you to pick up items. 
                    Due to that unspeakably tragic incident when you were young; 
                    you must always specify the item that you are taking. 
                    Otherwise, your hands don't know what to do with themselves.

(Inventory): This command allows you to open your inventory... 
             *Spoiler* It's full of JUNK!

(Use (Item Name)): This command allows you to put to use all the junk you've been collecting. 
                   Always be sure to state the item you are using (yet another result of the incident mentioned in the 'Take' section).

(Help): Ummmm.... How are you even here right now...?

(Quit): This command makes it known to everyone that you're a quitter and life is just too hard for you! OWN IT!

(Reset): This command let's you start over. 
         This is for those that love to torture themselves by removing all progress and starting from scratch... 
         Who does that?!");
    }

    public void Inventory()
    {
      Messages.Add("Inventory:");
      for (int i = 0; i < _game.CurrentPlayer.Inventory.Count; i++)
      {
        Messages.Add($"{_game.CurrentPlayer.Inventory[i].Name}");
      }

    }

    public void Look()
    {
      Messages.Add(_game.CurrentRoom.Description);
      foreach (Item i in _game.CurrentRoom.Items)
      {
        Messages.Add($"{i.Name}");
      }
      // Messages.Add("You are well aware of the necessity of this item in completing your journey.");
    }

    public void Quit()
    {
      Environment.Exit(0);
    }

    ///<summary>
    ///Restarts the game 
    ///</summary>
    public void Reset()
    {
      throw new System.NotImplementedException();
    }

    //NOTE done
    public void Setup(string playerName)
    {
      Player player = new Player(playerName);
      _game.CurrentPlayer = player;
      if (playerName.ToLower() != "steve")
      {
        Messages.Add($@"Knowing full well that your name is Steve, you decide to announce that your name is {playerName} to nobody in particular...
I'm not sure what would possess you to do that...?
Alright Steve (definitely not {playerName}).
You have a few options that you can type (help) to see.
I know your completely aware of them and will have no need to, so we won't worry about that too much.");
      }
      else
      {
        Messages.Add($@"Although you are completely alone, you decided to announce that your name is {playerName} to nobody in particular...
I'm not sure what would possess you to do that...?
Alright Steve.
You have a few options that you can type (help) to see. 
I know your completely aware of them and will have no need to, so we won't worry too much about that.");
      }
      _game.Setup();



    }

    ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
    public void TakeItem(string itemName)
    {
      Item item = new Item(null, null);
      for (int i = 0; i < _game.CurrentRoom.Items.Count; i++)
      {
        if (_game.CurrentRoom.Items[i].Name.ToLower() == itemName)
        {
          item = _game.CurrentRoom.Items[i];
        }
      }
      if (item.Name != null)
      {
        _game.CurrentRoom.Items.Remove(item);
        _game.CurrentPlayer.Inventory.Add(item);
        Messages.Add($@"You have successfuly used your hands to pocket the object.");
      }
      else
      {
        Messages.Add($@"That is not an item you can take from this room.");
      }
    }

    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    public void UseItem(string itemName)
    {


      if (_game.CurrentPlayer.Inventory.Count > 0)
      {
        for (int i = 0; i < _game.CurrentPlayer.Inventory.Count; i++)
        {

          if (_game.CurrentPlayer.Inventory[i].Name.ToLower() == itemName)
          {
            if (_game.CurrentRoom.Name == "four")
            {
              Messages.Add($@"The item has been used! You are victorious!!!
Type (Retry) to start again or (Quit) to close the application.");
            }
            else
            {
              Messages.Add($@"What are you doing?! You know that this is neither the time nor the place to be using that!");
            }
          }
          else
          {
            //FIXME This is not printing due to the for loop not running because 0 !< 0
            Messages.Add($@"You don't have that item.");
          }

        }
      }
      else
      {
        //FIXME This is not printing due to the for loop not running because 0 !< 0
        Messages.Add($@"You don't have that item.");
      }



    }
  }
}