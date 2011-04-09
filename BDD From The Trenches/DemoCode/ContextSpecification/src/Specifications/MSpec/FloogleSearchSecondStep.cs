using BddDemo.Framework.Presentation;
using BddDemo.Framework.Presentation.Data;
using BddDemo.Framework.Presentation.UI;
using Machine.Specifications;
using Rhino.Mocks;

namespace BddDemo.Specifications.MSpec
{
    [Subject("Floogle Search")]
    public class When_loading_the_foogle_search_page_2
    {
        protected static IFloogleLocatorView _view;
        protected static IFloogleRepository _repository;
        protected static FloogleLocatorPresenter _presenter;

        Establish context = () =>
            {
                _view = MockRepository.GenerateMock<IFloogleLocatorView>();
                _repository = MockRepository.GenerateMock<IFloogleRepository>();
                _presenter = new FloogleLocatorPresenter(_repository) { View = _view };
            };

        Because of = () => _presenter.InitializeView();

        It should_load_empty_floogle_search_form = () =>
            _view.AssertWasCalled(view => view.PartNumber = string.Empty);
    }
}