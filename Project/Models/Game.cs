using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Game : IGame
  {
    public IRoom CurrentRoom { get; set; }
    public IPlayer CurrentPlayer { get; set; }

    //NOTE Make yo rooms here...
    public void Setup()
    {
      Room one = new Room("one", "Against all odds, Steve; you decided to go in the opposite direction from where you actually needed to go. Despite the fact that you knew you needed to go East. Some unseen power must have possesed you. Driving you to go in the complete opposite direction.");
      Room two = new Room("two", "Test text for room 2.");
      Room three = new Room("three", $@"Test text for room 3. It has ");
      Room four = new Room("four", "Test text for room 4.");
      Room five = new Room("five", $@"It happened... 
You've completely lost it. 
You knew that by entering this room, there was no turning back. 
Your choices have consequences. 
Despite all the knowledge that you've accumulated over your lifetime... 
Despite your absolute understanding of what this room was and how it functioned... 
Somehow...
Someway...
We find ourselves here... 

You have no one else to blame but yourself.

---GAME OVER---");

      one.Exits.Add("east", two);

      two.Exits.Add("west", one);
      two.Exits.Add("east", three);

      three.Exits.Add("west", two);
      three.Exits.Add("north", four);
      three.Exits.Add("south", five);

      four.Exits.Add("south", three);

      five.Exits.Add("north", three);


      //NOTE Items will go here
      Item importantObj = new Item("The Object of extreme importance", "This is clearly the object that you are going to need to accomplish the task you need to accomplish.");
      three.Items.Add(importantObj);


      //NOTE Starting point
      CurrentRoom = two;

    }

  }
}