using System.Windows;
using System.Windows.Documents;

namespace ChorbyModManager.Core
{
    public static class DescriptionParser
    {
        public static FlowDocument Parse(string text)
        {
            FlowDocument doc = new FlowDocument();

            string[] lines = text.Replace("\r\n", "\n").Split('\n');

            foreach (string line in lines)
            {
                if (line.StartsWith("### "))
                {
                    AddHeader(doc, line.Substring(4), 15f);
                    continue;
                }
                else if (line.StartsWith("## "))
                {
                    AddHeader(doc, line.Substring(3), 18f);
                    continue;
                }
                else if (line.StartsWith("# "))
                {
                    AddHeader(doc, line.Substring(2), 22f);
                    continue;
                }
                else if (line.Length >= 3 && line.Substring(1).StartsWith("# "))
                {
                    Run run = new Run(line.Substring(3));
                    switch (line[0])
                    {
                        case 'b': run.FontWeight = FontWeights.Bold; break;
                        case 'i': run.FontStyle = FontStyles.Italic; break;
                        case 'u': run.TextDecorations = TextDecorations.Underline; break;
                        case 's': run.TextDecorations = TextDecorations.Strikethrough; break;
                        default: run = null; break;
                    }

                    if (run != null)
                    {
                        Paragraph paragraph = new Paragraph();
                        paragraph.Inlines.Add(run);
                        doc.Blocks.Add(paragraph);
                    }
                }
                else if (line != string.Empty)
                {
                    Paragraph paragraph = new Paragraph();
                    paragraph.Inlines.Add(new Run(line));
                    doc.Blocks.Add(paragraph);
                }
                else
                {
                    doc.Blocks.Add(new Paragraph(new LineBreak()));
                }
            }

            return doc;
        }

        private static void AddHeader(FlowDocument doc, string text, float fontSize)
        {
            Paragraph paragraph = new Paragraph();
            paragraph.Inlines.Add(new Run(text)
            {
                FontWeight = FontWeights.Bold,
                FontSize = fontSize
            });
            paragraph.Inlines.Add(new LineBreak());
            doc.Blocks.Add(paragraph);
        }
    }
}