namespace Knowledge_Base.Interfaces
{
    public interface IMarkdown
    {
        public string ToHTML(string text);
        public string ToMarkdown(string text);
    }
}
