using Knowledge_Base.Interfaces;
using Markdig;

namespace Knowledge_Base.Services
{
    public class MarkdownService : IMarkdown
    {
        MarkdownPipelineBuilder pipeline = new MarkdownPipelineBuilder();
        /// <summary>
        /// В конструктороке происходит установка параметров обработки markdown-а
        /// </summary>
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
        /// <summary>
        /// Преобразует mardown в HTML документ
        /// </summary>
        /// <param name="text">Код</param>
        /// <returns>HTML документ</returns>
        public string ToHTML(string text)
        {
            string html = Markdown.ToHtml(text, pipeline.Build());
            html = html.Replace("\n", "<br/>");
            return html;
        }
        /// <summary>
        /// Преобразует HTML документ в mardown
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Mardown документ</returns>
        public string ToMarkdown(string text)
        {
            return Markdown.ToPlainText(text, pipeline.Build());
        }
    }
}
