namespace AuthECAPI.Utilities
{
    public class ReturnResponse<T>
    {
        public bool Success { get; set; }
        public T Error { get; set; }
        public T Response { get; set; }
    }
}
