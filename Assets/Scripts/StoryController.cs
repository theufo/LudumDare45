using UnityEngine;
using UnityEngine.UI;

public class StoryController : MonoBehaviour
{
    public Canvas Canvas;
    public Text Text;

    void Awake()
    {
    }

    public void SetStoryText(string text)
    {
        Text.text = text;
        Canvas.gameObject.SetActive(true);
    }

    public void CloseStory()
    {
        Canvas.gameObject.SetActive(false);
    }
}