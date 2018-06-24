using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimation : MonoBehaviour {

    public GameObject StartButton;
    public Animator animate;

    void Update()
    {
        if(Input.GetButtonDown("Submit") || Input.GetKeyDown("enter"))
        {
            animate.SetTrigger("StartTrigger");
            Debug.Log("Start");
        }
    }

	public void EnableStartObject()
    {
        StartButton.SetActive(true);
    }

    public void DisableStartObject()
    {
        StartButton.SetActive(false);
    }
}
