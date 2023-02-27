using Knowledge_Base.Interfaces;
using Markdig;

namespace Knowledge_Base.Services
{
    public class MarkdownService : IMarkdown
    {
        MarkdownPipelineBuilder pipeline = new MarkdownPipelineBuilder();
        public MarkdownService()
        {
            this.pipeline.UseAbbreviations()
            //.UseAutoIdentifiers()
            .UseCitations()
            .UseCustomContainers()
            .UseDefinitionLists()
            .UseEmphasisExtras()
            .UseFigures()
            .UseFooters()
            .UseFootnotes()
            .UseGridTables()
            .UseMathematics()
            .UseMediaLinks()
            .UsePipeTables()
            .UseListExtras()
            .UseTaskLists()
            .UseDiagrams()
            .UseAutoLinks();
        }

        public string ToHTML(string text)
        {
            string html = Markdown.ToHtml(text, pipeline.Build());
            html = html.Replace("\n", "<br/>");
            return html;
        }

        public string ToMarkdown(string text)
        {
            return Markdown.ToPlainText(text, pipeline.Build());
        }
    }
}
