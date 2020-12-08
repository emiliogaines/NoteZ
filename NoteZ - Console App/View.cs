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
            Console.BufferWidth = Math.Clamp(consoleWidth, 0, Console.LargestWindowWidth);
            Console.BufferHeight = Math.Clamp(consoleHeight, 0, Console.LargestWindowHeight);
            Console.WindowWidth = Math.Clamp(consoleWidth, 0, Console.LargestWindowWidth);
            Console.WindowHeight = Math.Clamp(consoleHeight, 0, Console.LargestWindowHeight);




            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
        }

        public static void Reset()
        {
            Console.Clear();
        }

        public static void DrawBorder(string title = "", string subtitle = "")
        {
            title = ' ' + title.Trim() + ' ';
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

            if(subtitle.Length > 0)
            {
                Console.SetCursorPosition(0, Console.WindowHeight - 3);
                Console.Write((char)ConsoleChar.WallVerticalLeftThreeWay);
                Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 3);
                Console.Write((char)ConsoleChar.WallVerticalRightThreeWay);
                for (int i = 1; i < Console.WindowWidth - 1; i++)
                {
                    Console.SetCursorPosition(i, Console.WindowHeight - 3);
                    Console.Write((char)ConsoleChar.WallHorizontal);
                }

                Console.SetCursorPosition((Console.WindowWidth / 2) - (subtitle.Length / 2), Console.WindowHeight - 2);
                Console.Write(subtitle);
            }
        }

        public static void DrawOptions(SelectableOption[] options, Action<int> callback)
        {
            int indexX = 3; //Padding to not interfere with borders
            int indexY = 5; //Padding to not interfere with borders
            int maxIndexX = Console.WindowWidth - 2;
            int maxIndexY = Console.WindowHeight - 5;

            int padding = 2;
            foreach (var option in options)
            {
                int positionX = Math.Clamp(option.x, indexX, maxIndexX);
                int positionY = Math.Clamp(option.y, indexY, maxIndexY);
                option.SetRealPosition(positionX, positionY);

                Console.SetCursorPosition(positionX, positionY);
                if(options[0] == option)
                {
                    Console.Write('[' + option.title + ']');
                }
                else
                {
                    Console.Write(option.title);
                }
                

                indexY += padding; // Space out options
            }

            int selectedIndex = 0;
            if(options.Length > 0)
            {
                while (Console.KeyAvailable) Console.ReadKey(true);
                while (true)
                {
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter) break;
                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        if (selectedIndex > 0)
                        {
                            selectedIndex--;
                            foreach (var option in options)
                            {
                                Console.SetCursorPosition(1, option.realPositionY);
                                Console.Write(new string(' ', Console.WindowWidth - 2));
                                Console.SetCursorPosition(option.realPositionX, option.realPositionY);
                                if (options[selectedIndex] == option)
                                {
                                    Console.Write('[' + option.title + ']');
                                }
                                else
                                {
                                    Console.Write(option.title);
                                }
                            }
                        }
                    }
                    if (key.Key == ConsoleKey.DownArrow)
                    {
                        if (selectedIndex < options.Length - 1)
                        {
                            selectedIndex++;
                            foreach (var option in options)
                            {
                                Console.SetCursorPosition(1, option.realPositionY);
                                Console.Write(new string(' ', Console.WindowWidth - 2));
                                Console.SetCursorPosition(option.realPositionX, option.realPositionY);
                                if (options[selectedIndex] == option)
                                {
                                    Console.Write('[' + option.title + ']');
                                }
                                else
                                {
                                    Console.Write(option.title);
                                }
                            }
                        }
                    }
                }
                callback(selectedIndex);
            }
        }

        public static void GetInput()
        {
            List<Keystroke> keystrokeStack = new List<Keystroke>();

            //Padding to not interfere with borders
            int indexX = 3; 
            int maxIndexX = Console.WindowWidth - 3;
            int indexY = 4;
            int maxIndexY = Console.WindowHeight - 5;

            Console.SetCursorPosition(indexX, indexY);
            Console.CursorVisible = true;

            while (Console.KeyAvailable) Console.ReadKey(true);
            while (true) { 
                var key = Console.ReadKey(true);

                if (Char.IsLetterOrDigit(key.KeyChar) || Char.IsWhiteSpace(key.KeyChar))
                {
                    var keyPressed = new Keystroke(key.KeyChar, Console.CursorLeft, Console.CursorTop);
                    for (int i = keystrokeStack.Count; i-- > 0;)
                    {
                        if(keystrokeStack[i].x == keyPressed.x && keystrokeStack[i].y == keyPressed.y && !keystrokeStack[i].isDestroyed && !keystrokeStack[i].isUndoed)
                        {
                            keyPressed.prevCharacter = keystrokeStack[i].character;
                            break;
                        }
                    }
                    keystrokeStack.Add(keyPressed);
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace)
                    {
                        for (int i = keystrokeStack.Count; i-- > 0;)
                        {
                            if (!keystrokeStack[i].isManipulated())
                            {
                                var destroyedKeystroke = new Keystroke(' ', keystrokeStack[i].x, keystrokeStack[i].y);
                                destroyedKeystroke.prevCharacter = keystrokeStack[i].character;
                                destroyedKeystroke.isDestroyed = true;
                                keystrokeStack.Add(destroyedKeystroke);
                                keystrokeStack[i].Destroy();
                                break;
                            }
                        }
                    }


                    if (key.Key == ConsoleKey.F1)
                    {
                        for (int i = keystrokeStack.Count; i-- > 0;)
                        {
                            if (!keystrokeStack[i].isUndoed)
                            {
                                keystrokeStack[i].Undo();
                                break;
                            }
                        }
                    }

                    if (key.Key == ConsoleKey.F2)
                    {
                        for(int i = 0; i < keystrokeStack.Count; i++)
                        {
                            if (keystrokeStack[i].isManipulated())
                            {
                                keystrokeStack[i].Create();
                                break;
                            }
                        }
                    }

                    if(key.Key == ConsoleKey.Enter)
                    {
                        Console.CursorTop += 1;
                        Console.CursorLeft = indexX;
                    }
                }

                if (Console.CursorLeft >= maxIndexX && Console.CursorTop <= maxIndexY)
                {
                    Console.CursorTop += 1;
                    Console.CursorLeft = indexX;
                }

                if (Console.CursorTop > maxIndexY)
                {
                    Console.CursorVisible = false;
                }

                if (Console.CursorLeft < indexX)
                {
                    Console.CursorLeft = indexX;
                }

                if (Console.CursorTop < indexY)
                {
                    Console.CursorTop = indexY;
                }
            }
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
        WallVerticalRightThreeWay = '╣',
        WallVerticalLeftThreeWay = '╠',
        WallThreewayDown = '╦'
    }

