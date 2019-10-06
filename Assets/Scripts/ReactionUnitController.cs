using UnityEngine;

public class ReactionUnitController : MonoBehaviour
{
    private Animator animator;

    private int index;
    private ChallengeController _challengeController;

    public float StartTime;
    public float Duration = 2;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void OnMouseDown()
    {
        var time = Time.realtimeSinceStartup;
        this.gameObject.SetActive(false);
        _challengeController.React(index, time);
    }

    public void Initialize(ChallengeController challengeController, int i, float startTime)
    {
        index = i;
        _challengeController = challengeController;
        StartTime = startTime;
    }
}