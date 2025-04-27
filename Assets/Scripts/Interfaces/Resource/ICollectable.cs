public interface ICollectable
{
    public int Amount { get; }
    public void OnCollect(ICollector unitFarming);
}