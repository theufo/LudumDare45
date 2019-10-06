using UnityEngine;
using UnityEngine.UI;

public class StoryController : MonoBehaviour
{
    public Canvas Canvas;
    public Text Text;

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
            CloseStory();
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