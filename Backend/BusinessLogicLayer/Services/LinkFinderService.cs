using BusinessLogicLayer.Interfaces;
using Markdig;
using Markdig.Renderers.Html;
using Markdig.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class LinkFinderService : ILinkFinderService<int>
    {
        private readonly string _patternForMarkdown;
        public LinkFinderService()
        {
            _patternForMarkdown = @"\[.+\]\(\d+\)";
        }
        public IEnumerable<int> GetLinksFromHTML(string html)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> GetLinksFromMarkdown(string markdown)
        {
            Regex regex = new Regex(_patternForMarkdown, RegexOptions.Multiline | RegexOptions.Compiled);
            var maches = regex.Matches(markdown);
            List<int> links = new List<int>();
            foreach (Match match in maches) 
            {
                //int result = 0;
                int startIndex = match.Value.IndexOf('(');
                int endIndex = match.Value.IndexOf(')')-startIndex-1;
                string number = match.Value.Substring(startIndex+1, endIndex);
                //if(int.TryParse(match.Value.Substring(startIndex, endIndex), out result) )
                    //links.Add(result); 
                links.Add(Convert.ToInt32(number));
            }
            return links;
        }
    }
}
