using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_Camera : MonoBehaviour {

    public Camera MainMenuCamera;

    private Vector3 offset ;
    private bool IForgot;
    // Update is called once per frame

    void Start()
    {
        //offset = new Vector3(-0.2f * Time.deltaTime, 0, 0);




    }
    void Update () {
        MainMenuCamera.transform.Rotate(0, -1 * Time.deltaTime, 0);
        MainMenuCamera.transform.position = MainMenuCamera.transform.position - offset;
	}
}
