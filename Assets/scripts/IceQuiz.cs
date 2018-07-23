using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceQuiz : MonoBehaviour {

    private int success = 0;
    private Animator animator;
    // Use this for initialization
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (success >= 7)
        {
            animator.SetTrigger("reward");
        }
    }

    public void AddSuccess()
    {
        success++;
        Debug.Log(success.ToString());
    }

    private void OnMouseDown()
    {
        if (success >= 7)
        {
            
        }
    }
