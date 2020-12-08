using System;
using System.Collections.Generic;
using System.Text;

namespace NoteZ___Console_App
{
    public class SelectableOption
    {
        public string title;
        public int x, y;
        public int realPositionX, realPositionY;
        public SelectableOption(string title, int x, int y)
        {
            this.title = title;
            this.x = x;
            this.y = y;
        }

        public void SetRealPosition(int x, int y)
        {
            realPositionX = x;
            realPositionY = y;
        }
    }
}
