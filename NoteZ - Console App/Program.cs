using System;

namespace NoteZ___Console_App
{
    class Program
    {
        static void Main(string[] args)
        {
            View.Initialize();
            View.DrawBorder(" NoteZ - En app för anteckningar ");

            SelectableOption[] optionArray = new SelectableOption[] {
                new SelectableOption("Ny anteckning", 0, 0),
                new SelectableOption("Visa anteckningar", 0, 0),
            };
            View.DrawOptions(optionArray);



            Console.ReadKey();
        }
    }
}
