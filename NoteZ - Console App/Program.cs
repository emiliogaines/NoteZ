using System;
using System.Collections.Generic;

namespace NoteZ___Console_App
{
    class Program
    {
        private List<Note> noteList = new List<Note>();
        static void Main(string[] args)
        {
            View.Initialize();
            DisplayMainMenu();
            Console.ReadKey();
        }

        static void DisplayMainMenu()
        {
            View.Reset();
            View.DrawBorder("NoteZ - En app för anteckningar", "Använd (PIL-UP), (PIL-NED) & (Enter) för att navigera");

            SelectableOption[] optionArray = new SelectableOption[] {
                new SelectableOption("Ny anteckning", 0, 0),
                new SelectableOption("Visa anteckningar", 0, 0),
            };

            View.DrawOptions(optionArray, HandleCallback);
        }

        static void HandleCallback(int index)
        {
            switch (index)
            {
                case 0:
                    View.Reset();
                    View.DrawBorder("Ny anteckning", "Använd (ESC) för att spara och gå ur anteckningen");
                    View.GetInput();
                    break;
                case 1:
                    View.Reset();
                    View.DrawBorder("Anteckningar", "Använd (PIL-UP), (PIL-NED), (ESC) & (Enter) för att navigera");
                    break;
                default:
                    DisplayMainMenu();
                    break;
            }
        }
    }
}
