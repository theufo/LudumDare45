using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            SceneManager.LoadScene("GameScene");
    }
}