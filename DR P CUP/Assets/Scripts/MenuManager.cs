using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlayClicked()
    {
        Application.LoadLevel("CupofPee");
    }

    public void CreditsClicked()
    {
        Application.LoadLevel("Credits");
    }

    public void ExitClicked()
    {
        Application.Quit();
    }

    public void BackClicked()
    {
        Application.LoadLevel("MainMenu");
    }
}
