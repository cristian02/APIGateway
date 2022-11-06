namespace GlobalErrorApi.Exceptions
{
    public class UnauhorizedAccessException : Exception
    {
        public UnauhorizedAccessException(string msg) : base(msg)
        {
            
        }
        
    }
}