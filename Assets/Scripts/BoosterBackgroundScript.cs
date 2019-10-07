using System.Collections;
using UnityEngine;

public class BoosterBackgroundScript : MonoBehaviour
{
    public GameObject Background;
    public GameObject Rotation1;
    public GameObject Rotation2;

    void Start()
    {
        StartCoroutine(MoveBackground());
    }

    void Update()
    {
        Rotation1.transform.Rotate(0, 0, 10 * Time.deltaTime);
        Rotation2.transform.Rotate(0, 0, -20 * Time.deltaTime);
    }

    IEnumerator MoveBackground()
    {
        while (true)
        {
            while (Background.transform.position.x < 1)
            {
                Background.transform.Translate(Vector3.right * Time.deltaTime);
                yield return null;
            }
            while (Background.transform.position.x > 0)
            {
                Background.transform.Translate(Vector3.left * Time.deltaTime);
                yield return null;
            }
        }
    }
}