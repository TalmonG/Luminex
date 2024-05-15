using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuanimationPlayer : MonoBehaviour
{

    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on the GameObject.");
        }
        animator.Play("StartMenuAnim");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
