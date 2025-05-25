using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Singleton pattern
    public static PlayerManager instance;

    [Header("Player Stats")]
    public int woodAmount, stoneAmount, foodAmount;
    public int peasantPoints = 1;
    public int windowsOpened = 0;
    private int lastWood, lastStone, lastFood;

    [Header("Resource UI")]
    public TextMeshProUGUI woodText;
    public TextMeshProUGUI stoneText;
    public TextMeshProUGUI foodText;

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
        woodText.text = "Woods: " + woodAmount.ToString();
        stoneText.text = "Stones: " + stoneAmount.ToString();
        foodText.text = "Foods: " + foodAmount.ToString();
    }
}
