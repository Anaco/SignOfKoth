using Microsoft.Xna.Framework;
using SadConsole;
using System;
using System.Runtime.CompilerServices;
using Console = SadConsole.Console;

namespace SignOfKoth.Consoles
{
    public class GUIConsole: Console
    {
        public GUIConsole(string title, int width, int height) : base(width, height)
        {
            Fill(Color.White, Color.Black, 146);
            Print(0, 0, title.Align(HorizontalAlignment.Center, width), Color.Black, Color.Yellow);
        }
    }
}