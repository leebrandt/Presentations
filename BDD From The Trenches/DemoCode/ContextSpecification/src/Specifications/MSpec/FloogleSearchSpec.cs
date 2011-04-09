using System.Collections.Generic;
using System.Linq;
using BddDemo.Framework.Data;
using BddDemo.Framework.Domain;
using BddDemo.Framework.Presentation;
using BddDemo.Framework.Presentation.Data;
using BddDemo.Framework.Presentation.UI;
using Machine.Specifications;
using Rhino.Mocks;

namespace BddDemo.Specifications.MSpec
{
    [Subject("Floogle Search")]
    public class When_loading_the_foogle_search_page : With_a_floogle_inventory
    {
        Because of = () => _presenter.InitializeView();

        It should_load_empty_floogle_search_form = () =>
            _view.AssertWasCalled(view => view.PartNumber = string.Empty);
    }

    [Subject("Floogle Search")]
    public class When_a_user_searches_for_floogles : With_a_floogle_inventory
    {
        Because of = () => _presenter.Search();

        It should_get_part_number_to_search_with = () =>
            _view.AssertWasCalled(view => { var dummy = view.PartNumber; });

        It should_search_the_floogle_inventory_by_part_number = () =>
            _repository.AssertWasCalled(repo => repo.Search(_view.PartNumber));

        It should_return_a_list_of_matching_floogles = () =>
            _view.AssertWasCalled(view => view.Floogles = _repository.Search(_view.PartNumber));

    }

    [Subject("Floogle Search")]
    public class With_a_floogle_inventory
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
    }

    [Subject("Floogle Search")]
    public class When_searching_the_floogle_inventory
    {
        static string _partNumber;
        static List<Floogle> _floogles;
        static FloogleRepository _repository;

        Establish context = () =>
        {
            _repository = new FloogleRepository();
            _partNumber = "123";
        };

        Because of = () => _floogles = _repository.Search(_partNumber).ToList();

        It should_return_floogles_matching_part_number_search = () =>
            _floogles.ForEach(floogle => floogle.PartNumber.ShouldContain(_partNumber));
    }
}