namespace RequestTrakerModelLibrary
{
    public class Request
    {
        public int Id { get; set; }
        public string RequestText { get; set; }
        public string Raised_By { get; set; }
        public bool Status { get; set; }

        public override string ToString()
        {
            return $"Request Id: {Id}, Request: {RequestText}, Raised By: {Raised_By}, Status: {Status}";
        }

        public override bool Equals(object? obj)
        {
            return this.RequestText.Equals((obj as Request)?.RequestText);
        }
    }
}
