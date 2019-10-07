using UnityEngine;

public class BoosterBackgroundScript : MonoBehaviour
{
    public GameObject Background;
    public GameObject Rotation1;
    public GameObject Rotation2;

    

    void Start()
    {
        
    }


    void Update()
    {
        Rotation1.transform.Rotate(1 * Time.deltaTime, 1 * Time.deltaTime, 1 * Time.deltaTime);
        Rotation2.transform.Rotate(-2 * Time.deltaTime, -2 * Time.deltaTime, -2 * Time.deltaTime);

    }
}
