using Plover.Dom;
using System;
using System.Linq;

namespace Plover.Demo
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            new WindowBuilder()
                .WithTitle("Plover Demo App")
                .WithSize(600, 400)
                .FromHtml("<html><body><h1 id=\"t1\">Hello world!</h1><button>Useless button</button><button>Useless button 2</button></body></html>")
                .Build()
                .Render((window) =>
                {
                    Console.WriteLine(window.JavaScript.Execute<string>("document.body.innerHTML"));
                    window.JavaScript.Execute("x = 'does this work?';");
                    Console.WriteLine(window.JavaScript.Execute<string>("x"));

                    Button b = window.Document.CreateElement<Button>();
                    b.InnerHtml = "Hello!";
                    b.Id = "karel";
                    window.Document.Body.AppendChild(b);

                    Button b2 = window.Document.CreateElement<Button>();
                    b2.InnerHtml = "Hello2!";
                    b2.Id = "karel2";
                    window.Document.Body.AppendChild(b2);

                    HtmlElement possibleButton = window.Document.GetElementById("karel");
                    Console.WriteLine($"Equality of elements: {b == possibleButton}");

                    Console.WriteLine(window.Document.GetElementById("t1").InnerHtml);
                    int cntr = 0;
                    b.OnClick += (s, e) =>
                    {
                        b.InnerHtml = $"[{++cntr}] Alt was pressed: {e.AltKey}";
                    };
                    b.OnContextMenu += (s, e) => Console.WriteLine("Sorry no context menu :(");

                    HtmlCollection<Button> buttons = window.Document.GetElementsByTagName<Button>();

                    Console.WriteLine($"Buttons:\n{string.Join("\n", buttons.Select(x => x.InnerHtml))}");

                    Console.WriteLine($"Button b: {buttons[b.Id]}");
                });
        }
    }
}
