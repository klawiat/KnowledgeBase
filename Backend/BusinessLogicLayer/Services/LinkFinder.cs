using BusinessLogicLayer.Interfaces;
using Markdig;
using Markdig.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class LinkFinder : ILinkFinder<string>
    {
        private readonly string _pattern;
        /// <summary>
        /// Конструктор класса для поиска ссылок по документу
        /// </summary>
        /// <param name="pattern">Паттерн для RegEx</param>
        public LinkFinder(string pattern=@"\[(a-zA-Z0-9)\]")
        {
            this._pattern = pattern;
        }
        public IEnumerable<string> GetLinksFromHTML(string html)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetLinksFromMarkdown(string markdown)
        {
            /*Regex regex = new Regex(this._pattern,RegexOptions.Multiline | RegexOptions.Compiled);
            return regex.Matches(markdown).Select(x=>int.Parse(x.Value)).ToList();*/
            var document=Markdown.Parse(markdown);
            return document.Select(x=>x as LinkReferenceDefinition).Where(x => x != null).Select(x=>x.Inline.FirstChild.ToString()).ToList();

        }
    }
}
