using System.Collections.Generic;
using System.Reactive.Subjects;
using QuartzSheduler.Behaviors.BindingBehaviors.Helpers;
using QuartzSheduler.Model;

namespace QuartzSheduler.Behaviors.BindingBehaviors.DataTransfer
{
    public interface IExternalDataTransfer
    {
        int CountPage { get; } // кол-во страниц. 
        int CountItemsOnPage { get; } // кол-во элементов на странице.    
        ISubject<PagingList> SendDataRx { get; } //Событие отправки пагинированных данных

        void WriteInputBuffer(List<UniversalInputType> buff); //Заполнение входного буффера

        void Start();
        void Stop();
    }
}