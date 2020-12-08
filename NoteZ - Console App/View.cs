using System;
using System.Collections.Generic;
using System.Text;

namespace NoteZ___Console_App
{
    public static class View
    {
        public static void Initialize()
        {
            int consoleWidth = 64; //Lines, not pixels
            int consoleHeight = 32; //Lines, not pixels
            Console.WindowWidth = Math.Clamp(consoleWidth, 0, Console.LargestWindowWidth);
            Console.WindowHeight = Math.Clamp(consoleHeight, 0, Console.LargestWindowHeight);
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;

            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
        }

        public static void DrawBorder(string title = "")
        {
            for(int i = 0; i < Console.WindowWidth; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write((char) ConsoleChar.WallHorizontal);
                Console.SetCursorPosition(i, Console.WindowHeight - 1);
                Console.Write((char) ConsoleChar.WallHorizontal);
            }

            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write((char)ConsoleChar.WallVertical);
                Console.SetCursorPosition(Console.WindowWidth - 1, i);
                Console.Write((char)ConsoleChar.WallVertical);
            }

            Console.SetCursorPosition(0, 0);
            Console.Write((char)ConsoleChar.CornerTopLeft);
            Console.SetCursorPosition(Console.WindowWidth - 1, 0);
            Console.Write((char)ConsoleChar.CornerTopRight);
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.Write((char)ConsoleChar.CornerBottomLeft);
            Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 1);
            Console.Write((char)ConsoleChar.CornerBottomRight);

            if(title.Length > 0)
            {
                int startTextIndex = (Console.WindowWidth / 2) - (title.Length / 2);
                Console.SetCursorPosition(startTextIndex, 1);
                Console.Write(title);

                Console.SetCursorPosition(startTextIndex - 1, 0);
                Console.Write((char)ConsoleChar.WallThreewayDown);
                Console.SetCursorPosition(startTextIndex - 1, 1);
                Console.Write((char)ConsoleChar.WallVertical);
                Console.SetCursorPosition(startTextIndex - 1, 2);
                Console.Write((char)ConsoleChar.CornerBottomLeft);

                Console.SetCursorPosition(startTextIndex + title.Length, 0);
                Console.Write((char)ConsoleChar.WallThreewayDown);
                Console.SetCursorPosition(startTextIndex + title.Length, 1);
                Console.Write((char)ConsoleChar.WallVertical);
                Console.SetCursorPosition(startTextIndex + title.Length, 2);
                Console.Write((char)ConsoleChar.CornerBottomRight);

                for(int i = 0; i < title.Length; i++)
                {
                    Console.SetCursorPosition(startTextIndex + i, 2);
                    Console.Write((char)ConsoleChar.WallHorizontal);
                    Console.SetCursorPosition(startTextIndex + i, 0);
                    Console.Write((char)ConsoleChar.WallHorizontal);
                }
            }
        }

        public static void DrawOptions(SelectableOption[] options)
        {
            int indexX = 3;
            int indexY = 5;
            int maxIndexX = Console.WindowWidth - 2;
            int maxIndexY = Console.WindowHeight - 2;

            int padding = 2;
            foreach (var option in options)
            {
                int positionX = Math.Clamp(option.x, indexX, maxIndexX);
                int positionY = Math.Clamp(option.y, indexY, maxIndexY);

                Console.SetCursorPosition(positionX, positionY);
                if(options[0] == option)
                {
                    Console.Write('[' + option.title + ']');
                }
                else
                {
                    Console.Write(option.title);
                }
                

                indexY += padding;
            }

            int selectedIndex = 0;
            if(options.Length > 0)
            {

            }
        }
    }

    enum ConsoleChar
    {
        CornerTopLeft = '╔',
        CornerTopRight = '╗',
        CornerBottomRight = '╝',
        CornerBottomLeft = '╚',
        WallHorizontal = '═',
        WallVertical = '║',
        WallThreewayDown = '╦'
    }
}
