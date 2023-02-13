using assignment_rpg.Heroes;

namespace assignment_rpg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            MageHero mage = new MageHero("Petter");
            Console.WriteLine(mage.LevelAttributes.Intelligence);
        }
    }
}