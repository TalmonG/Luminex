using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningMenu : MonoBehaviour
{
    public Animator animator;
    private bool animationStarted = false;
    private bool sceneLoading = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on the GameObject.");
        }
    }

    void Update()
    {
        if (Input.anyKeyDown && !animationStarted)
        {
            if (animator != null)
            {
                animator.Play("TitleAnimExit");
                animationStarted = true;
                Debug.Log("ANima played fboroo");
            }
            else
            {
                Debug.LogWarning("Animator is not assigned or found.");
            }
        }

        if (animationStarted && !sceneLoading)
        {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.IsName("TitleAnimExit") && stateInfo.normalizedTime >= 1.0f)
            {
                Debug.Log("Animation Complete");
                SceneManager.LoadScene("StartMenu");
                sceneLoading = true;
            }
        }
    }
}
