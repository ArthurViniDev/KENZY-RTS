using TMPro;
using UnityEngine;

[System.Serializable]
public class ResourcesText
{
    public TextMeshProUGUI woodText;
    public TextMeshProUGUI stoneText;
    public TextMeshProUGUI foodText;
}

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public ResourcesText resourcesText;

    [Header("Player Stats")]
    public int woodAmount, stoneAmount, foodAmount;
    private int lastWood, lastStone, lastFood;

    public int peasantPoints = 1;
    public int windowsOpened = 0;

    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(gameObject);
    }

    private void Update()
    {
        if (lastWood == woodAmount && lastStone == stoneAmount && lastFood == foodAmount) return;
        UpdateResourcesUI();
        lastWood = woodAmount;
        lastStone = stoneAmount;
        lastFood = foodAmount;
    }

    private void UpdateResourcesUI()
    {
        resourcesText.woodText.text = "Woods: " + woodAmount.ToString();
        resourcesText.stoneText.text = "Stones: " + stoneAmount.ToString();
        resourcesText.foodText.text = "Foods: " + foodAmount.ToString();
    }
}
