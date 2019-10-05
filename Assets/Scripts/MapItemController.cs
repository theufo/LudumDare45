using UnityEngine;
using UnityEngine.UI;

public class MapItemController : MonoBehaviour
{
    private Text Text;

    public string Name;
    public int RequiredPlayerLevel;
    public int RequiredDeckLevel;

    public GameController GameController;
    public PlayerController PlayerController;
    public Sprite CardSprite;

    void Start()
    {
        Text = GetComponent<Text>();
        GameController = GameObject.FindGameObjectWithTag("GameGO").GetComponent<GameController>();
        PlayerController = GameObject.FindGameObjectWithTag("PlayerGO").GetComponent<PlayerController>();
    }

    public void Initialized(string name, int requiredPlayerLevel, int requiredDeckLevel)
    {
        Name = name;
        RequiredPlayerLevel = requiredPlayerLevel;
        RequiredDeckLevel = requiredDeckLevel;
    }
}