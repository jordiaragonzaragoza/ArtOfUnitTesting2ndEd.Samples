using System;

namespace Chapter5.LogAn
{
    public interface IView
    {
        public event Action Loaded;

        public event Action<string> ErrorOccured;

        public void Render(string text);
    }
}