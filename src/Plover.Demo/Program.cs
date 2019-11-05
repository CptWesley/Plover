using Plover.Dom;
using System;

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
                .FromHtml("<html><body><h1 id=\"t1\">Hello world!</h1></body></html>")
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

                    HtmlElement b2 = window.Document.GetElementById("karel");
                    Console.WriteLine($"Equality of elements: {b == b2}");

                    Console.WriteLine(window.Document.GetElementById("t1").InnerHtml);
                    int cntr = 0;
                    b.OnClick += (s, e) =>
                    {
                        b.InnerHtml = $"[{++cntr}] Alt was pressed: {e.AltKey}";
                    };
                    b.OnContextMenu += (s, e) => Console.WriteLine("Sorry no contect menu :(");
                });
        }
    }
}
