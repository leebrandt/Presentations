using BddDemo.Framework.Presentation;
using BddDemo.Framework.Presentation.Data;
using BddDemo.Framework.Presentation.UI;
using Machine.Specifications;
using Rhino.Mocks;

namespace BddDemo.Specifications.MSpec
{
    [Subject("Floogle Search")]
    public class When_loading_the_foogle_search_page_3
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

    public class When_searching_for_floogles_3
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

        Because of = () => _presenter.Search();

        It Should_get_part_number_to_search_with = () => 
            _view.AssertWasCalled(view => { var dummy = view.PartNumber; });

        It Should_search_the_floogle_inventory_by_part_number = () => 
            _repository.AssertWasCalled(repo => repo.Search(_view.PartNumber));

        It Should_return_a_list_of_matching_floogles = () => 
            _view.AssertWasCalled(view => view.Floogles = _repository.Search(_view.PartNumber));
    }
}