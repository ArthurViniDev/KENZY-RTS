using TMPro;
using UnityEngine;

[System.Serializable]
public struct Resources
{
    public int wood;
    public int stone;
    public int food;

    public Resources(int wood, int stone, int food)
    {
        this.wood = wood;
        this.stone = stone;
        this.food = food;
    }
}

public class PlayerManager : MonoBehaviour
{
    // Singleton pattern
    public static PlayerManager instance;

    [Header("Player Stats")]
    public int peasantPoints = 1;
    public int windowsOpened = 0;
    //private int lastWood, lastStone, lastFood;

    [Header("Player Resource Stats")]
    public int woodAmount, stoneAmount, foodAmount;

    [Header("Resource UI")]
    public TextMeshProUGUI woodText;
    public TextMeshProUGUI stoneText;
    public TextMeshProUGUI foodText;

    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(gameObject);
    }

    public Resources playerResources;
    private Resources lastResources;

    private void Update()
    {
        if (lastResources.wood == playerResources.wood &&
            lastResources.stone == playerResources.stone &&
            lastResources.food == playerResources.food) return;

        UpdateResourcesUI();
        lastResources = playerResources;
    }

    private void UpdateResourcesUI()
    {
        woodText.text = $"Woods: {playerResources.wood}";
        stoneText.text = $"Stones: {playerResources.stone}";
        foodText.text = $"Foods: {playerResources.food}";
    }

    public bool HasEnoughResources(Resources cost)
    {
        return playerResources.wood >= cost.wood &&
                playerResources.stone >= cost.stone &&
                playerResources.food >= cost.food;
    }
    public void SpendResources(Resources cost)
    {
        playerResources.wood -= cost.wood;
        playerResources.stone -= cost.stone;
        playerResources.food -= cost.food;
    }
}