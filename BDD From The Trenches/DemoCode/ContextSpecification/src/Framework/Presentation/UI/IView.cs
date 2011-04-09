namespace BddDemo.Framework.Presentation.UI
{
    public interface IView
    {
        void DisplayError(string errorMessage);
        void DisplayStatus(string message);
    }
}