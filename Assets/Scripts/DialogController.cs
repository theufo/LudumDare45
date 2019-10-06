using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogController : MonoBehaviour
{
    public GameController GameController;
    private PlayerController playerController;
    private StoryController storyController;
    private MapItemController mapItemController;

    public GameObject FreeDeckButton;
    public Canvas Canvas;

    void Start()
    {
        playerController = GameController.PlayerController;
        storyController = GameController.StoryController;
    }

    public void GetFreeDeck()
    {
        playerController.GetStarterCards();

        FreeDeckButton.gameObject.SetActive(false);

        CloseDialog();
        storyController.SetStoryText("Now you have your first ten cards out of 150 and can challenge in clubs to become the best player! \n Collect them all!");
        GameController.UIMenuController.OpenInventory();
    }

    public void Challenge()
    {
        SceneManager.LoadScene("ChallengeScene");
    }

    public void CloseDialog()
    {
        Canvas.gameObject.SetActive(false);
    }
}