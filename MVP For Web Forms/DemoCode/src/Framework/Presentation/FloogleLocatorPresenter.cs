using BddDemo.Framework.Presentation.Data;
using BddDemo.Framework.Presentation.UI;

namespace BddDemo.Framework.Presentation
{
    public class FloogleLocatorPresenter : Presenter<IFloogleLocatorView>
    {
        private IFloogleRepository _repository;

        public FloogleLocatorPresenter(IFloogleRepository repository)
        {
            _repository = repository;
        }

        public void InitializeView()
        {
            View.PartNumber = string.Empty;
        }

        public void Search()
        {
            View.Floogles = _repository.Search(View.PartNumber);
        }
    }
}