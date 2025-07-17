// Interface
interface IAnimal 
{
  void AnimalSound(); // interface method (does not have a body)
}

// Pig "implements" the IAnimal interface
class Pig : IAnimal 
{
  public void AnimalSound() 
  {
    // The body of animalSound() is provided here
    Console.WriteLine("The pig says: wee wee");
  }
}

class Program 
{
  static void Main(string[] args) 
  {
    var temporal = args[0]; // Assume the first argument is a path to a temporal file
    Console.WriteLine($"Using temporal file: {temporal}");
    Pig myPig = new();  // Create a Pig object
    myPig.AnimalSound();
  }
}