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
    public int woodAmount;
    public int stoneAmount;
    public int foodAmount;

    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(gameObject);
    }

    private void Update()
    {
        resourcesText.woodText.text = "Woods: " + woodAmount.ToString();
        resourcesText.stoneText.text = "Stones: " + stoneAmount.ToString();
        resourcesText.foodText.text = "Foods: " + foodAmount.ToString();
    }
}
