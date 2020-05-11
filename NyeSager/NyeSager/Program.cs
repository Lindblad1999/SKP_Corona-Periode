using System;

namespace NyeSager
{
    #region Polymorphism
    class Animal
    {
        public void animalSound()
        {
            Console.WriteLine("the animal makes a sound");
        }
    }

    class Pig : Animal
    {
        public void animalSound()
        {
            Console.WriteLine("The pig says: idk");
        }
    }

    class Dog : Animal
    {
        public void animalSound()
        {
            Console.WriteLine("The dog says: wuf");
        }
    }
    #endregion


    class Program
    {
        static void Main(string[] args)
        {
            #region Polymorphism
            Animal myAnimal = new Animal();
            Animal myPig = new Pig();
            Animal myDog = new Dog();

            myAnimal.animalSound();
            myPig.animalSound();
            myDog.animalSound();
            #endregion

            Console.ReadKey();
        }
    }
}
