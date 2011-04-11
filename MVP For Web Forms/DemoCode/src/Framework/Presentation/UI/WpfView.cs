using System;
using System.Windows;
using System.Windows.Controls;
using BddDemo.Framework.Dependencies;
using StructureMap;

namespace BddDemo.Framework.Presentation.UI
{
    public class WpfView<TView, TPresenter> : 
        UserControl where TPresenter : 
        Presenter<TView> where TView : class
    {
        public TPresenter Presenter { get; set; }
        protected void InitializeView()
        {
            try
            {
                Presenter = ObjectFactory.GetInstance<TPresenter>();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Presenter Creation Error");
            }
            Presenter.View = this as TView;
        }

        public void DisplayError(string errorMessage)
        {
            MessageBox.Show(errorMessage, "ERROR");
        }

        public void DisplayStatus(string message)
        {
            MessageBox.Show(message, "Information");
        }
    }
}