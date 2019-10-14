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
      Room one = new Room("one", $@"Against all odds, Steve... You decided to go in the opposite direction from where you actually needed to go. Despite the fact that you knew you needed to go East. Some unseen power must have possesed you. Driving you to go in the completly opposite direction.
There is one route for you to take. It is the route directly behind you... 
You know...? 
The one you came from? 
It's East...
");
      Room two = new Room("two", $@"You are standing in a room. It has four walls. It has a floor. It even has a ceiling on top. 
If it had any less than those, one could argue that it would not be a room at all. 
Even still, some would say that a room could have just three walls and still continue being a room. 
Now, we could stand here idly debating the two, however, it may be best that we move on for the time being. 
We will proceed with the understanding that the rooms here have no more or less than four walls.

There are exits to the East and the West. Luckily you should know exactly where to go!
");
      Room three = new Room("three", $@"We find ourselves in yet another room (the four wall variety). 
In the very center of the room stands a very conspicous table. 

There are three exits: North, South, and West. One is correct, one is incorrect, and the other is back the way you came. I recommend picking the correct one.
");
      Room four = new Room("four", $@"Here we are. Everything we've done so far has built up to this very moment. 
On the far wall of this very room; there is a mold that is very obviously and conveniently shaped just like The Object of Extreme Importance. 
There is only one thing to do now, and in spite of your questionable current mental health...
I think you can manage this last task. 
I sure hope you brought The Object!
");
      Room five = new Room("five", $@"The losing room");

      one.Exits.Add("east", two);

      two.Exits.Add("west", one);
      two.Exits.Add("east", three);

      three.Exits.Add("west", two);
      three.Exits.Add("north", four);
      three.Exits.Add("south", five);

      four.Exits.Add("south", three);


      //NOTE Items will go here
      Item importantObj = new Item("The Object of extreme importance", "This is clearly the object that you are going to need to accomplish the task you need to accomplish.");
      three.Items.Add(importantObj);


      //NOTE Starting point
      CurrentRoom = two;

    }

  }
}