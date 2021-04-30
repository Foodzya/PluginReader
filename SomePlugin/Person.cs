using System;

namespace SomePlugin
{
    public class Person : IInfoReadable
    {
        private string Name { get; set; }
        private byte Age { get; set; }
        private string Nationality { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        public Person(string name, byte age, string nationality)
        {
            Name = name;
            Age = age;
            Nationality = nationality;
        }

        public void GetBiography()
        {
            Console.WriteLine($"Name: {Name}\n" +
                $"Age: {Age}\n" +
                $"Nationality: {Nationality}");
        }

        public void GetNameAndStuff(string newName)
        {
            Console.WriteLine($"You got a new name? Perfect {newName}\n" +
                $"Where were you born?\n" +
                $"Hehehehe");
        }
    }
}
