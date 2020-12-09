using System;
using System.Collections.Generic;
using System.Text;

namespace NoteZ___Console_App
{
    public class Keystroke
    {
        public char character;
        public char prevCharacter = ' ';
        public int x, y;

        public bool isDestroyed;
        public bool isUndoed;

        public Keystroke(char character, int x, int y)
        {
            this.character = character;
            this.x = x;
            this.y = y;
            Create();
        }

        public void Create()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(character);
            isDestroyed = false;
            isUndoed = false;
        }

        public void Destroy()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
            Console.SetCursorPosition(x, y);
            isDestroyed = true;
        }

        public void Undo()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(prevCharacter);
            Console.SetCursorPosition(x, y);
            if (Char.IsLetterOrDigit(prevCharacter))
            {
                Console.CursorLeft++;
            }
            isUndoed = true;
        }

        public bool IsManipulated()
        {
            return isDestroyed || isUndoed;
        }

    }
}
