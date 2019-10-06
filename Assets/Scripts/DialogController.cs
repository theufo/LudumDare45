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

    private bool firstTime = true;

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
        if (firstTime)
        {
            var gameController = GameObject.FindGameObjectWithTag("GameGO").GetComponent<GameController>();
            gameController.StoryController.SetStoryText("Since this is your first tournament, let me explain the rules.\n During the whole play, sometimes when your opponent will try to cast spell the magic fluent will appear. If you would be lucky enough to click on that fluent, your chance to win will be higher.");
            firstTime = false;
        }
        else
            GameController.ChallengeController.StartChallenge();
    }

    public void CloseDialog()
    {
        Canvas.gameObject.SetActive(false);
    }
}