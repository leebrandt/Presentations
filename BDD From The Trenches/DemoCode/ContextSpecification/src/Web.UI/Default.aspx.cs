using System;
using System.Collections.Generic;
using BddDemo.Framework.Domain;
using BddDemo.Framework.Presentation;
using BddDemo.Framework.Presentation.UI;

namespace Web.UI
{
    public partial class _Default : WebView<IFloogleLocatorView, FloogleLocatorPresenter>, IFloogleLocatorView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SearchButton.Click += delegate { this.Presenter.Search(); };
        }

        public string PartNumber
        {
            get { return PartNumberInput.Text; }
            set { PartNumberInput.Text = value; }
        }

        public IList<Floogle> Floogles
        {
            set
            {
                FloogleListing.DataSource = value;
                FloogleListing.DataBind();
            }
        }
    }
}