using BddDemo.Framework.Presentation;
using BddDemo.Framework.Presentation.Data;
using BddDemo.Framework.Presentation.UI;
using NUnit.Framework;
using Rhino.Mocks;

namespace BddDemo.Specifications.NUnit
{
    [TestFixture]
    public class When_loading_the_foogle_search_page_2
    {
        IFloogleLocatorView _view;
        IFloogleRepository _repository;
        FloogleLocatorPresenter _presenter;

        [SetUp]
        public void context()
        {
            _view = MockRepository.GenerateMock<IFloogleLocatorView>();
            _repository = MockRepository.GenerateMock<IFloogleRepository>();
            _presenter = new FloogleLocatorPresenter(_repository) { View = _view };
            Action();
        }

        public void Action()
        {
            _presenter.InitializeView();
        }

        [Test]
        public void It_should_load_empty_floogle_search_form()
        {
            _view.AssertWasCalled(view => view.PartNumber = string.Empty);
        }
    }
}