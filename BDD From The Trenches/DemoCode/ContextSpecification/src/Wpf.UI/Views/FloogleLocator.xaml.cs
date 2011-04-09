using System.Collections.Generic;
using BddDemo.Framework.Domain;
using BddDemo.Framework.Presentation;
using BddDemo.Framework.Presentation.UI;

namespace BddDemo.Wpf.UI.Views
{
    /// <summary>
    /// Interaction logic for FloogleLocator.xaml
    /// </summary>
    public partial class FloogleLocator : WpfView<IFloogleLocatorView, FloogleLocatorPresenter>, IFloogleLocatorView
    {
        public FloogleLocator()
        {
            InitializeComponent();
            InitializeView();
            Presenter.InitializeView();
            SearchButton.Click += delegate { Presenter.Search(); };
        }

        public string PartNumber
        {
            get { return PartNumberInput.Text; }
            set { PartNumberInput.Text = value; }
        }

        public IList<Floogle> Floogles
        {
            set { FlooglesFoundList.ItemsSource = value; }
        }
    }
}
