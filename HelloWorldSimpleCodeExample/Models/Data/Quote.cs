namespace HelloWorldSimpleCodeExample.Models.Data
{
    public partial class Quote
    {
        public int QuoteId { get; set; }
        public string QuoteText { get; set; }
        public string Author { get; internal set; }
        public int QuoteIndex { get; set; }
        public string DayOfWeek { get; set; }
    }
}