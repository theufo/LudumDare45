using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StoryController : MonoBehaviour
{
    public Canvas Canvas;
    public Text Text;
    public Text ClickToStartText;

    private void Start()
    {
        StartCoroutine(FadeOut());    
    }

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

    IEnumerator FadeOut()
    {
        while (true)
        {
            while (ClickToStartText.color.a > 0)
            {
                var tempColor = ClickToStartText.color;
                tempColor.a -= Time.deltaTime;
                ClickToStartText.color = tempColor;
                yield return null;
            }

            while (ClickToStartText.color.a < 1)
            {
                var tempColor = ClickToStartText.color;
                tempColor.a += Time.deltaTime;
                ClickToStartText.color = tempColor;
                yield return null;
            }
        }
    }
}