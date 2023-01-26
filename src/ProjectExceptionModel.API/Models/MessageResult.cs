namespace ProjectExceptionModel.API.Models
{
    public class MessageResult
    {
        public string Code { get; set; }
        public string Description { get; set; }


        public MessageResult(string code, string description)
        {
            Code = code;
            Description = description;
        }
    }
}
