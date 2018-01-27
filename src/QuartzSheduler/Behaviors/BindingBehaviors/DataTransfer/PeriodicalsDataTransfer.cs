using System.Collections.Generic;
using System.Reactive.Subjects;
using QuartzSheduler.Behaviors.BindingBehaviors.DataTransfer;
using QuartzSheduler.Model;

namespace QuartzSheduler.Behaviors.BindingBehaviors.Helpers
{
    public class PeriodicalsDataTransfer : IExternalDataTransfer
    {
        public int CountPage { get; }
        public int CountItemsOnPage { get; }
        public ISubject<PagingList> SendDataRx { get; }

        public void WriteInputBuffer(List<UniversalInputType> buff)
        {
            throw new System.NotImplementedException();
        }

        public void Start()
        {
            throw new System.NotImplementedException();
        }

        public void Stop()
        {
            throw new System.NotImplementedException();
        }
    }
}