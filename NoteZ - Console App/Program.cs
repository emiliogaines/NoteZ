using System;
using System.Collections.Generic;

namespace NoteZ___Console_App
{
    class Program
    {
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
                new SelectableOption("Ny anteckning"),
                new SelectableOption("Visa anteckningar"),
            };

            View.DrawOptions(optionArray, HandleCallback);
        }

        static void HandleCallback(int index)
        {
            switch (index)
            {
                case 0:
                    View.Reset();
                    View.DrawBorder("Ny anteckning", "F1 - UNDO | F2 - REDO | ESC - Spara och avsluta");
                    View.NoteEditing();
                    DisplayMainMenu();
                    break;
                case 1:
                    var oldData = FileHandler.Load();
                    View.Reset();
                    View.DrawBorder("Anteckningar", "Använd (PIL-UP), (PIL-NED), (ESC) & (Enter) för att navigera");

                    Console.SetCursorPosition(0,0);

                    var selectArray = new List<SelectableOption>();
                    
                    
                    for (int i = 0; i < oldData.Length; i++)
                    {
                        selectArray.Add(new SelectableOption(oldData[i].date));
                    }
                   
                    View.DrawOptions(selectArray.ToArray(), HandleCallbackSelectNote);
                    DisplayMainMenu();
                    break;
                default:
                    DisplayMainMenu();
                    break;
            }
        }

        static void HandleCallbackSelectNote(int index)
        {
            var data = FileHandler.Load();
            View.Reset();
            View.DrawBorder("Ny anteckning", "F1 - UNDO | F2 - REDO | ESC - Spara och avsluta");
            View.NoteEditing(data[index]);
            DisplayMainMenu();
        }
    }
}
