namespace Chapter5.LogAn
{
    public class Presenter
    {
        private readonly IView _view;
        private readonly ILogger _log;

        public Presenter(IView view, ILogger log)
        {
            _view = view;
            _log = log;
            this._view.Loaded += OnLoaded;
            this._view.ErrorOccured += OnError;

        }

        private void OnError(string text)
        {
            _log.LogError(text);
        }

        private void OnLoaded()
        {
            _view.Render("Hello World");
        }
    }
}