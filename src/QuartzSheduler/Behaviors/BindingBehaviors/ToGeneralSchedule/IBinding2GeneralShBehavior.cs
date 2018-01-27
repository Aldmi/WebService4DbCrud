using System;
using QuartzSheduler.Model;

namespace QuartzSheduler.Behaviors.BindingBehaviors.ToGeneralSchedule
{
    /// <summary>
    /// Интерфейс привязки к главному расписанию.
    /// </summary>
    public interface IBinding2GeneralShBehavior : IBindingBehavior
    {
        //Запись данных. Отправка данных по собсьенному таймеру или через Paging.
        void WriteData(UniversalInputType inData, UniversalInputType defaultInData, Func<UniversalInputType, bool> checkContrains, int? countDataTake = null);
        int? GetCountDataTake();
        bool CheckContrains(UniversalInputType inData);
    }
}