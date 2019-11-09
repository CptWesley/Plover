using System;
using System.Diagnostics.CodeAnalysis;

namespace Plover.Dom
{
    /// <summary>
    /// Factory for creating html elements.
    /// </summary>
    [SuppressMessage("Microsoft.Maintainability", "CA1506", Justification = "Generated factory method /shrug.")]
    public static class HtmlElementFactory
    {
        /// <summary>
        /// Creates the specified tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <returns>A new HTML element.</returns>
        public static HtmlElement Create(string tag)
        {
            if (tag == null)
            {
                throw new ArgumentNullException(nameof(tag));
            }

            switch (tag.ToUpperInvariant().Trim())
            {
                case "BODY": return new Body();
                case "ADDRESS": return new Address();
                case "ARTICLE": return new Article();
                case "ASIDE": return new Aside();
                case "FOOTER": return new Footer();
                case "HEADER": return new Header();
                case "H1": return new Heading1();
                case "H2": return new Heading2();
                case "H3": return new Heading3();
                case "H4": return new Heading4();
                case "H5": return new Heading5();
                case "H6": return new Heading6();
                case "HGROUP": return new HeadingGroup();
                case "MAIN": return new Main();
                case "NAV": return new Navigation();
                case "SECTION": return new Section();
                case "BLOCKQUOTE": return new BlockQuote();
                case "DD": return new Description();
                case "DIR": return new Directory();
                case "DIV": return new Division();
                case "DL": return new DescriptionList();
                case "DT": return new DescriptionTerm();
                case "FIGCAPTION": return new FigureCaption();
                case "FIGURE": return new Figure();
                case "HR": return new ThematicBreak();
                case "LI": return new ListItem();
                case "OL": return new OrderedList();
                case "P": return new Paragraph();
                case "PRE": return new Preformatted();
                case "UL": return new UnorderedList();
                case "A": return new Anchor();
                case "ABBR": return new Abbreviation();
                case "B": return new Bold();
                case "BDI": return new BidirectionalIsolate();
                case "BDO": return new BidirectionalOverride();
                case "BR": return new Break();
                case "CITE": return new Cite();
                case "CODE": return new Code();
                case "DATA": return new Data();
                case "DFN": return new Definition();
                case "EM": return new Emphasis();
                case "I": return new Italic();
                case "KBD": return new KeyboardInput();
                case "MARK": return new Mark();
                case "Q": return new Quotation();
                case "RB": return new RubyBase();
                case "RP": return new RubyFallback();
                case "RT": return new RubyText();
                case "RTC": return new RubyTextContainer();
                case "RUBY": return new Ruby();
                case "S": return new Strikethrough();
                case "SAMP": return new Sample();
                case "SMALL": return new Small();
                case "SPAN": return new Span();
                case "STRONG": return new Strong();
                case "SUB": return new Subscript();
                case "SUP": return new Superscript();
                case "TIME": return new Time();
                case "TT": return new Teletype();
                case "U": return new Unarticulated();
                case "VAR": return new Variable();
                case "WBR": return new WordBreak();
                case "AREA": return new Area();
                case "AUDIO": return new Audio();
                case "IMG": return new Image();
                case "MAP": return new Map();
                case "TRACK": return new Track();
                case "VIDEO": return new Video();
                case "APPLET": return new Applet();
                case "EMBED": return new Embed();
                case "IFRAME": return new Iframe();
                case "OBJECT": return new ResourceObject();
                case "PARAM": return new ObjectParameter();
                case "PICTURE": return new Picture();
                case "SOURCE": return new Source();
                case "CANVAS": return new Canvas();
                case "NOSCRIPT": return new Noscript();
                case "SCRIPT": return new Script();
                case "DEL": return new Deleted();
                case "INS": return new Inserted();
                case "CAPTION": return new Caption();
                case "COL": return new Column();
                case "COLGROUP": return new ColumnGroup();
                case "TABLE": return new Table();
                case "TBODY": return new TableBody();
                case "TD": return new TableData();
                case "TFOOT": return new TableFooter();
                case "TH": return new TablerHeader();
                case "THEAD": return new TableHeaders();
                case "TR": return new TableRow();
                case "BUTTON": return new Button();
                case "DATALIST": return new DataList();
                case "FIELDSET": return new FieldSet();
                case "FORM": return new Form();
                case "INPUT": return new Input();
                case "LABEL": return new Label();
                case "LEGEND": return new Legend();
                case "METER": return new Meter();
                case "OPTGROUP": return new OptionGroup();
                case "OPTION": return new Option();
                case "OUTPUT": return new Output();
                case "PROGRESS": return new Progress();
                case "SELECT": return new Select();
                case "TEXTAREA": return new TextArea();
                case "DETAILS": return new Details();
                case "DIALOG": return new Dialog();
                case "MENU": return new Menu();
                case "MENUITEM": return new MenuItem();
                case "SUMMARY": return new Summary();
                case "CONTENT": return new Content();
                case "ELEMENT": return new Element();
                case "SHADOW": return new Shadow();
                case "SLOT": return new Slot();
                case "TEMPLATE": return new Template();
                default: return new UnknownElement(tag);
            }
        }

        /// <summary>
        /// Gets the tag of a given html element type.
        /// </summary>
        /// <typeparam name="T">The HTML element type to get the tag from.</typeparam>
        /// <returns>An HTML tag.</returns>
        public static string GetTag<T>()
            where T : HtmlElement
        {
            Type t = typeof(T);

            if (t == typeof(Body))
            {
                return "body";
            }
            else if (t == typeof(Address))
            {
                return "address";
            }
            else if (t == typeof(Article))
            {
                return "article";
            }
            else if (t == typeof(Aside))
            {
                return "aside";
            }
            else if (t == typeof(Footer))
            {
                return "footer";
            }
            else if (t == typeof(Header))
            {
                return "header";
            }
            else if (t == typeof(Heading1))
            {
                return "h1";
            }
            else if (t == typeof(Heading2))
            {
                return "h2";
            }
            else if (t == typeof(Heading3))
            {
                return "h3";
            }
            else if (t == typeof(Heading4))
            {
                return "h4";
            }
            else if (t == typeof(Heading5))
            {
                return "h5";
            }
            else if (t == typeof(Heading6))
            {
                return "h6";
            }
            else if (t == typeof(HeadingGroup))
            {
                return "hgroup";
            }
            else if (t == typeof(Main))
            {
                return "main";
            }
            else if (t == typeof(Navigation))
            {
                return "nav";
            }
            else if (t == typeof(Section))
            {
                return "section";
            }
            else if (t == typeof(BlockQuote))
            {
                return "blockquote";
            }
            else if (t == typeof(Description))
            {
                return "dd";
            }
            else if (t == typeof(Directory))
            {
                return "dir";
            }
            else if (t == typeof(Division))
            {
                return "div";
            }
            else if (t == typeof(DescriptionList))
            {
                return "dl";
            }
            else if (t == typeof(DescriptionTerm))
            {
                return "dt";
            }
            else if (t == typeof(FigureCaption))
            {
                return "figcaption";
            }
            else if (t == typeof(Figure))
            {
                return "figure";
            }
            else if (t == typeof(ThematicBreak))
            {
                return "hr";
            }
            else if (t == typeof(ListItem))
            {
                return "li";
            }
            else if (t == typeof(OrderedList))
            {
                return "ol";
            }
            else if (t == typeof(Paragraph))
            {
                return "p";
            }
            else if (t == typeof(Preformatted))
            {
                return "pre";
            }
            else if (t == typeof(UnorderedList))
            {
                return "ul";
            }
            else if (t == typeof(Anchor))
            {
                return "a";
            }
            else if (t == typeof(Abbreviation))
            {
                return "abbr";
            }
            else if (t == typeof(Bold))
            {
                return "b";
            }
            else if (t == typeof(BidirectionalIsolate))
            {
                return "bdi";
            }
            else if (t == typeof(BidirectionalOverride))
            {
                return "bdo";
            }
            else if (t == typeof(Break))
            {
                return "br";
            }
            else if (t == typeof(Cite))
            {
                return "cite";
            }
            else if (t == typeof(Code))
            {
                return "code";
            }
            else if (t == typeof(Data))
            {
                return "data";
            }
            else if (t == typeof(Definition))
            {
                return "dfn";
            }
            else if (t == typeof(Emphasis))
            {
                return "em";
            }
            else if (t == typeof(Italic))
            {
                return "i";
            }
            else if (t == typeof(KeyboardInput))
            {
                return "kbd";
            }
            else if (t == typeof(Mark))
            {
                return "mark";
            }
            else if (t == typeof(Quotation))
            {
                return "q";
            }
            else if (t == typeof(RubyBase))
            {
                return "rb";
            }
            else if (t == typeof(RubyFallback))
            {
                return "rp";
            }
            else if (t == typeof(RubyText))
            {
                return "rt";
            }
            else if (t == typeof(RubyTextContainer))
            {
                return "rtc";
            }
            else if (t == typeof(Ruby))
            {
                return "ruby";
            }
            else if (t == typeof(Strikethrough))
            {
                return "s";
            }
            else if (t == typeof(Sample))
            {
                return "samp";
            }
            else if (t == typeof(Small))
            {
                return "small";
            }
            else if (t == typeof(Span))
            {
                return "span";
            }
            else if (t == typeof(Strong))
            {
                return "strong";
            }
            else if (t == typeof(Subscript))
            {
                return "sub";
            }
            else if (t == typeof(Superscript))
            {
                return "sup";
            }
            else if (t == typeof(Time))
            {
                return "time";
            }
            else if (t == typeof(Teletype))
            {
                return "tt";
            }
            else if (t == typeof(Unarticulated))
            {
                return "u";
            }
            else if (t == typeof(Variable))
            {
                return "var";
            }
            else if (t == typeof(WordBreak))
            {
                return "wbr";
            }
            else if (t == typeof(Area))
            {
                return "area";
            }
            else if (t == typeof(Audio))
            {
                return "audio";
            }
            else if (t == typeof(Image))
            {
                return "img";
            }
            else if (t == typeof(Map))
            {
                return "map";
            }
            else if (t == typeof(Track))
            {
                return "track";
            }
            else if (t == typeof(Video))
            {
                return "video";
            }
            else if (t == typeof(Applet))
            {
                return "applet";
            }
            else if (t == typeof(Embed))
            {
                return "embed";
            }
            else if (t == typeof(Iframe))
            {
                return "iframe";
            }
            else if (t == typeof(ResourceObject))
            {
                return "object";
            }
            else if (t == typeof(ObjectParameter))
            {
                return "param";
            }
            else if (t == typeof(Picture))
            {
                return "picture";
            }
            else if (t == typeof(Source))
            {
                return "source";
            }
            else if (t == typeof(Canvas))
            {
                return "canvas";
            }
            else if (t == typeof(Noscript))
            {
                return "noscript";
            }
            else if (t == typeof(Script))
            {
                return "script";
            }
            else if (t == typeof(Deleted))
            {
                return "del";
            }
            else if (t == typeof(Inserted))
            {
                return "ins";
            }
            else if (t == typeof(Caption))
            {
                return "caption";
            }
            else if (t == typeof(Column))
            {
                return "col";
            }
            else if (t == typeof(ColumnGroup))
            {
                return "colgroup";
            }
            else if (t == typeof(Table))
            {
                return "table";
            }
            else if (t == typeof(TableBody))
            {
                return "tbody";
            }
            else if (t == typeof(TableData))
            {
                return "td";
            }
            else if (t == typeof(TableFooter))
            {
                return "tfoot";
            }
            else if (t == typeof(TablerHeader))
            {
                return "th";
            }
            else if (t == typeof(TableHeaders))
            {
                return "thead";
            }
            else if (t == typeof(TableRow))
            {
                return "tr";
            }
            else if (t == typeof(Button))
            {
                return "button";
            }
            else if (t == typeof(DataList))
            {
                return "datalist";
            }
            else if (t == typeof(FieldSet))
            {
                return "fieldset";
            }
            else if (t == typeof(Form))
            {
                return "form";
            }
            else if (t == typeof(Input))
            {
                return "input";
            }
            else if (t == typeof(Label))
            {
                return "label";
            }
            else if (t == typeof(Legend))
            {
                return "legend";
            }
            else if (t == typeof(Meter))
            {
                return "meter";
            }
            else if (t == typeof(OptionGroup))
            {
                return "optgroup";
            }
            else if (t == typeof(Option))
            {
                return "option";
            }
            else if (t == typeof(Output))
            {
                return "output";
            }
            else if (t == typeof(Progress))
            {
                return "progress";
            }
            else if (t == typeof(Select))
            {
                return "select";
            }
            else if (t == typeof(TextArea))
            {
                return "textarea";
            }
            else if (t == typeof(Details))
            {
                return "details";
            }
            else if (t == typeof(Dialog))
            {
                return "dialog";
            }
            else if (t == typeof(Menu))
            {
                return "menu";
            }
            else if (t == typeof(MenuItem))
            {
                return "menuitem";
            }
            else if (t == typeof(Summary))
            {
                return "summary";
            }
            else if (t == typeof(Content))
            {
                return "content";
            }
            else if (t == typeof(Element))
            {
                return "element";
            }
            else if (t == typeof(Shadow))
            {
                return "shadow";
            }
            else if (t == typeof(Slot))
            {
                return "slot";
            }
            else if (t == typeof(Template))
            {
                return "template";
            }

            return null;
        }
    }
}
