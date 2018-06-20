using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Wumbo_Animation : MonoBehaviour {

    public Animator animator;
    public int LevelIndex;
    public AudioSource Wumbo1;
    public AudioSource Wumbo2;
    public AudioSource Wumbo3;
    public AudioSource Wumbo4; 

    Resolution[] resolutions;
	// Update is called once per frame
    void Start()
    {
        resolutions = Screen.resolutions;

        for (int i = 0; i < resolutions.Length; i++)
		{

            if (i == resolutions.Length - 1)
                Screen.SetResolution(1920, 1080, true);

        }
    }

    public void FadeToLevel (int levelIndex)
    {
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete ()
    {
        SceneManager.LoadScene(LevelIndex);
    }
    
    public void MoveToWumboSign()
    {
        animator.SetTrigger("WumboSign");
    }

    public void PlayWumbo(int pick)
    {
        if (pick == 1)
            Wumbo1.Play();
        if (pick == 2)
            Wumbo2.Play();
        if (pick == 3)
            Wumbo3.Play();
        if (pick == 4)
            Wumbo4.Play();
    }
}
