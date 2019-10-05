using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Text ClickToStartText; 
    private float fadeTime = 1f;
    private bool fade = true;
    private Color white = Color.white;
    private Color black = Color.black;

    private void Start()
    {
        //StartCoroutine(FadeOut());
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            SceneManager.LoadScene("GameScene");
    }

    //IEnumerator FadeOut()
    //{
    //    while (ClickToStartText.color != white)
    //    {
    //        ClickToStartText.CrossFadeColor(white, fadeTime, true, true);
    //        yield return null;
    //    }

    //    while (ClickToStartText.color.a < 0)
    //    {
    //        ClickToStartText.color = Color.Lerp(white, black, fadeTime * Time.deltaTime);
    //        yield return null;
    //    }
    //}
}