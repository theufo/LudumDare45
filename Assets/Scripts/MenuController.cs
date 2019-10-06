using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Text ClickToStartText; 

    private void Start()
    {
        StartCoroutine(FadeOut());
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            SceneManager.LoadScene("GameScene");
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