using System;

namespace Plover.Demo
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            int tick = 0;
            new WindowBuilder()
                .WithTitle("Plover Demo App")
                .WithSize(600, 400)
                .WithHtml("<html><body>Hello world!</body></html>")
                .Build()
                .Render((window) =>
                {
                    window.Title = $"Tick: {tick++}";
                });
        }
    }
}
