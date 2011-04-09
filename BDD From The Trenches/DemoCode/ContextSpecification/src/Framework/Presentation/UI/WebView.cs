using System;
using System.Text;
using System.Web.UI;
using StructureMap;

namespace BddDemo.Framework.Presentation.UI
{
    public class WebView<TView, TPresenter> : Page, IView
        where TPresenter : Presenter<TView>
        where TView : class
    {
        public TPresenter Presenter { get; set; }
        protected WebView()
        {
            try
            {
                Presenter = ObjectFactory.GetInstance<TPresenter>();
                Presenter.View = this as TView;
            }
            catch (Exception ex)
            {
                DisplayException(ex);
            }
        }

        public void DisplayError(string errorMessage)
        {
            DisplayMessage(errorMessage, true);
        }

        public void DisplayStatus(string message)
        {
            DisplayMessage(message, false);
        }

        private void DisplayMessage(string message, bool isError)
        {
            var statusType = isError ? "ATTENTION" : "COMPLETE";
            var script = new StringBuilder();
            script.AppendFormat("alert('{0}:\\n{1}');", statusType, message.Replace("\r\n", "\\n").Replace("'", "\\'"));
            ClientScript.RegisterStartupScript(GetType(), "Statusmessage", script.ToString());
        }
        
        private void DisplayException(Exception ex)
        {
            if (ex.Message.ToLower().Contains("target of an invocation"))
                DisplayException(ex.InnerException);
            else
                DisplayError(ex.Message);
        }
    }
}