namespace QuartzSheduler.Behaviors.BindingBehaviors
{
    public interface IBindingBehavior
    {
        string GetDeviceName { get; }
        int GetDeviceId { get; }
        //DeviceSetting GetDeviceSetting { get; }
    }
}