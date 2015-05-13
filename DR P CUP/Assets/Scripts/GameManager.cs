using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum ExamMode { Setup, Visual, Chemical, Microbial }

public class GameManager : MonoBehaviour {

    public GameObject Setup;
    public GameObject VisualExam;
    public GameObject ChemicalExam;
    public GameObject MicrobialExam;

    public Text ExamText;

    private ExamMode currentExam;
    private Disease currentDisease;

    private Bars bars;

	// Use this for initialization
	void Start () {
        bars = GetComponent<Bars>();

        currentExam = ExamMode.Setup;
        currentDisease = bars.newDisease();
        enterSetup();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.R))
        {
            SwitchExamMode();
        }
	}

    public void SelectAnswer(GameObject answer)
    {
        print(currentDisease.Name + " == " + answer.name);
        if (currentDisease.Name == answer.name)
        {
            print("correct");
        }
        else
        {
            print("incorrect");
        }
    }

    public void SwitchExamMode()
    {
        switch(currentExam)
        {
            case ExamMode.Setup:
                exitSetup();
                enterVisual();
                break;
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

    private void enterSetup()
    {
        Setup.SetActive(true);
        ExamText.text = "Below is the patient information, your job is to diagnose their issue to the best of your ability.";
        SetInfo();
    }

    private void exitSetup()
    {
        Setup.SetActive(false);
    }

    private void enterVisual()
    {
        VisualExam.SetActive(true);
        ExamText.text = "Analyze the coloring of the urine and see if you can determine the patient's issue or if further analyzing is required.";
    }

    private void exitVisual()
    {
        VisualExam.SetActive(false);
    }

    private void enterChemical()
    {
        ChemicalExam.SetActive(true);
        ExamText.text = "Test the chemcial composition by clicking on the cup to insert the urine test strip.";
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

    private void SetInfo()
    {
        string patient = "Mr. Goobs";
        Text patientText = Setup.transform.GetChild(0).gameObject.GetComponent<Text>();
        patientText.text = "Patient: " + patient + "\n" +
                           "Date: " + System.DateTime.Now.ToShortDateString() + "\n" +
                           "Medication: None" + "\n" +
                           "Symptoms: " + currentDisease.Symptoms;
    }

}
