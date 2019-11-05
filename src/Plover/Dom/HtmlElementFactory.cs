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
    }
}
