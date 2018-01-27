using System;
using QuartzSheduler.Behaviors.BindingBehaviors.DataTransfer;
using QuartzSheduler.Model;

namespace QuartzSheduler.Behaviors.BindingBehaviors.ToGeneralSchedule
{
    public class BindingDevice2GeneralShBehavior : IBinding2GeneralShBehavior
    {
        private readonly IExternalDataTransfer _edt; // Внешняя система определяет периодичность отправки данных
        public string GetDeviceName { get; }
        public int GetDeviceId { get; }




        public BindingDevice2GeneralShBehavior(IExternalDataTransfer edt)
        {
            _edt = edt;
        }




        public void WriteData(UniversalInputType inData, UniversalInputType defaultInData, Func<UniversalInputType, bool> checkContrains, int? countDataTake = null)
        {
            throw new NotImplementedException();
        }

        public int? GetCountDataTake()
        {
            throw new NotImplementedException();
        }

        public bool CheckContrains(UniversalInputType inData)
        {
            throw new NotImplementedException();
        }
    }
}