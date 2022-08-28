namespace Chapter5.LogAn
{
    public interface IWebService
    {
        public void Write(string message);

        public void Write(ErrorInfo message);
    }
}
