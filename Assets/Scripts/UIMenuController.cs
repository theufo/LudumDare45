using UnityEngine;
using UnityEngine.UI;

public class UIMenuController : MonoBehaviour
{
    public Canvas UICanvas;
    public Canvas GameMenuCanvas;
    public Canvas DialogCanvas;
    public Canvas Inventory;
    public GameObject CardDex;

    public Text PlayerLevelText;  
    public Text DeckLevelText;
    public Text MusicButtonText;

    public GameController GameController;

    void Start()
    {
        UpdatePlayerLevel(1);
        UpdateDeckLevel(0);

        DontDestroyOnLoad(this);
    }

    public void OpenInventory()
    {
        Inventory.gameObject.SetActive(true);
        UICanvas.gameObject.SetActive(false);
    }

    public void CloseInventory()
    {
        Inventory.gameObject.SetActive(false);
        UICanvas.gameObject.SetActive(true);
    }
    public void OpenCardDex()
    {
        CardDex.gameObject.SetActive(true);
        UICanvas.gameObject.SetActive(false);
    }

    public void CloseCardDex()
    {
        CardDex.gameObject.SetActive(false);
        UICanvas.gameObject.SetActive(true);
    }

    public void OpenGameMenu()
    {
        UICanvas.gameObject.SetActive(false);
        GameMenuCanvas.gameObject.SetActive(true);
    }

    public void CloseGameMenu()
    {
        UICanvas.gameObject.SetActive(true);
        GameMenuCanvas.gameObject.SetActive(false);
    }

    public void Credits()
    {
        GameController.StoryController.SetStoryText("Idea, programming \n Alex \"theufo\" Mironov \n\n" +
                                                    "Idea, graphics \n Anastasiia \"marmeladki\" Mironova \n\n " +
                                                    "Additional programming, music \n Stefan \"steve_procore\" Prokopenko \n\n " +
                                                    "Additional graphics \n Alexandra \"sasha_sanny\" Mironova \n\n ");
    }

    public void UpdatePlayerLevel(int level)
    {
        PlayerLevelText.text = "Player xp: " + level.ToString();
    }

    public void SwitchMusic(int level)
    {
        var audioSource = GameController.GetComponent<AudioSource>();
        audioSource.mute = !audioSource.mute;
        if (audioSource.mute)
            MusicButtonText.text = "music on";
        else
            MusicButtonText.text = "music off";
    }

    public void UpdateDeckLevel(int level)
    {
        DeckLevelText.text = "Deck level: " + level.ToString();
    }
}