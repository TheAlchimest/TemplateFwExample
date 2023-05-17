namespace UnifiedPortalIntegerationPoc.Model
{
    public class ResultModel<T>
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
