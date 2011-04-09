using System.Collections.Generic;
using System.Linq;
using BddDemo.Framework.Data;
using BddDemo.Framework.Domain;
using BddDemo.Framework.Presentation;
using BddDemo.Framework.Presentation.Data;
using BddDemo.Framework.Presentation.UI;
using NUnit.Framework;
using Rhino.Mocks;

namespace BddDemo.Specifications.NUnit
{
    [TestFixture]
    public class When_loading_the_foogle_search_page : With_a_floogle_inventory
    {
        public override void Action()
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
    public class When_searching_for_floogles : With_a_floogle_inventory
    {

        public override void Action() 
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

    public class With_a_floogle_inventory
    {
        protected IFloogleLocatorView _view;
        protected IFloogleRepository _repository;
        protected FloogleLocatorPresenter _presenter;

        [SetUp]
        public void Context()
        {
            _view = MockRepository.GenerateMock<IFloogleLocatorView>();
            _repository = MockRepository.GenerateMock<IFloogleRepository>();
            _presenter = new FloogleLocatorPresenter(_repository) { View = _view };
            Action();
        }

        public virtual void Action(){}
    }



    public class When_searching_the_floogle_inventory
    {
        static string _partNumber;
        static List<Floogle> _floogles;
        static FloogleRepository _repository;

        public void Context()
        {
            _repository = new FloogleRepository();
            _partNumber = "123";
        }

        public void Action()
        {
            _floogles = _repository.Search(_partNumber).ToList();
        }

        public void It_should_return_floogles_matching_part_number_search()
        {
            _floogles.ForEach(floogle => Assert.IsTrue(floogle.PartNumber.Contains(_partNumber)));
        }
    }
}