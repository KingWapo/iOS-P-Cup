using UnityEngine;
using System.Collections;

public enum ExamMode { Visual, Chemical, Microbial }

public class GameManager : MonoBehaviour {

    public GameObject VisualExam;
    public GameObject ChemicalExam;
    public GameObject MicrobialExam;

    private ExamMode currentExam;
    private Disease currentDisease;

    private Bars bars;

	// Use this for initialization
	/*void Start () {
        bars = GetComponent<Bars>();

        enterVisual();
        currentExam = ExamMode.Visual;
        currentDisease = bars.newDisease();
	}*/
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.R))
        {
            SwitchExamMode();
        }
	}

    public void SwitchExamMode()
    {
        switch(currentExam)
        {
            case ExamMode.Visual:
                exitVisual();
                enterChemical();
                break;
            case ExamMode.Chemical:
                exitChemical();
                enterMicrobial();
                break;
            case ExamMode.Microbial:
                exitMicrobial();
                break;
        }

        currentExam = (ExamMode)((int)currentExam + 1);
    }

    private void enterVisual()
    {
        VisualExam.SetActive(true);
    }

    private void exitVisual()
    {
        VisualExam.SetActive(false);
    }

    private void enterChemical()
    {
        ChemicalExam.SetActive(true);
        bars.SetDisease(currentDisease);
    }

    private void exitChemical()
    {
        ChemicalExam.SetActive(false);
    }

    private void enterMicrobial()
    {
        MicrobialExam.SetActive(true);
    }

    private void exitMicrobial()
    {
        MicrobialExam.SetActive(false);
    }

}
