using BddDemo.Framework.Presentation;
using BddDemo.Framework.Presentation.Data;
using BddDemo.Framework.Presentation.UI;
using NUnit.Framework;
using Rhino.Mocks;

namespace BddDemo.Specifications.NUnit
{
    [TestFixture]
    public class When_loading_the_foogle_search_page_3
    {
        IFloogleLocatorView _view;
        IFloogleRepository _repository;
        FloogleLocatorPresenter _presenter;

        [SetUp]
        public void Context()
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

    [TestFixture]
    public class When_searching_for_floogles_3
    {
        IFloogleLocatorView _view;
        IFloogleRepository _repository;
        FloogleLocatorPresenter _presenter;

        [SetUp]
        public void Context()
        {
            _view = MockRepository.GenerateMock<IFloogleLocatorView>();
            _repository = MockRepository.GenerateMock<IFloogleRepository>();
            _presenter = new FloogleLocatorPresenter(_repository) { View = _view };
            Action();
        }

        public void Action() 
        {
            _presenter.Search(); 
        }

        [Test]
        public void It_should_get_part_number_to_search_with()
        {
            _view.AssertWasCalled(view => { var dummy = view.PartNumber; });
        }

        [Test]
        public void It_should_search_the_floogle_inventory_by_part_number()
        {
            _repository.AssertWasCalled(repo => repo.Search(_view.PartNumber));
        }

        [Test]
        public void It_should_return_a_list_of_matching_floogles()
        {
            _view.AssertWasCalled(view => view.Floogles = _repository.Search(_view.PartNumber));
        }
    }
}