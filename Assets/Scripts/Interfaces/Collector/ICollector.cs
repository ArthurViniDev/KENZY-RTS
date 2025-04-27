public interface ICollector
{
    public int woodAmount { get; set; }
    public int stoneAmount { get; set; }
    public int foodAmount { get; set; }

    public void AddResource(ResourceType resourceType, int amount);
}
