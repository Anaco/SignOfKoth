using System;
using SadConsole;
using Microsoft.Xna.Framework;
using SignOfKoth.Consoles;
using Console = SadConsole.Console;

namespace SignOfKoth
{
    internal class Program
    {
        private static Console _rootDynamicConsole;
        public static void Main(string[] args)
        {
            SadConsole.Game.Create(80,50);
            SadConsole.Game.OnInitialize = OnInitialize;
            
            SadConsole.Game.Instance.Run();
            SadConsole.Game.Instance.Dispose();

            
        }

        private static void OnWindowResized(object sender, EventArgs e)
        {
            _rootDynamicConsole.Resize(Global.WindowWidth/ _rootDynamicConsole.Font.Size.X,
                Global.WindowWidth/ _rootDynamicConsole.Font.Size.Y,false);
            PrintHeader();
        }

        private static void OnInitialize()
        {
            //Handle resizing of window event
            Settings.ResizeMode = Settings.WindowResizeOptions.None;
            ((SadConsole.Game)SadConsole.Game.Instance).WindowResized += OnWindowResized;
            
            _rootDynamicConsole = new Console(80,50);
            SadConsole.Global.CurrentScreen = _rootDynamicConsole;
            _rootDynamicConsole.Children.Add(new GUIConsole("Stats",40,20));
            PrintHeader();
        }
        
        private static void PrintHeader()
        {
            int counter = 0;
            var startingColor = Color.Black.GetRandomColor(SadConsole.Global.Random);
            var color = startingColor;
            for (int x = 0; x < _rootDynamicConsole.Width; x++)
            {
                _rootDynamicConsole[x].Glyph = counter.ToString()[0];
                _rootDynamicConsole[x].Foreground = color;
                
                counter++;

                if (counter == 10)
                {
                    counter = 0;
                    color = color.GetRandomColor(SadConsole.Global.Random);
                }
            }

            counter = 0;
            color = startingColor;
            for (int y = 0; y < _rootDynamicConsole.Height; y++)
            {
                _rootDynamicConsole[0, y].Glyph = counter.ToString()[0];
                _rootDynamicConsole[0, y].Foreground = color;

                counter++;

                if (counter == 10)
                {
                    counter = 0;
                    color = color.GetRandomColor(SadConsole.Global.Random);
                }
            }

            // Display console size
            _rootDynamicConsole.Print(4, 2, "Console Size");
            _rootDynamicConsole.Print(4, 3, "                         ");
            _rootDynamicConsole.Print(4, 3, $"{_rootDynamicConsole.Width} {_rootDynamicConsole.Height}");
        }
    }
}