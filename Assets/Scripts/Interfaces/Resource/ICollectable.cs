public interface ICollectable
{
    public int Amount { get; }
    public ICollector thisUnitFarming { get; set; }
    public void OnCollect(ICollector unitFarming);
    public void StopCollecting();
}