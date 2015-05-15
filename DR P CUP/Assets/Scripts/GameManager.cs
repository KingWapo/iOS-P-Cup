using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public enum ExamMode { Setup, Visual, Chemical, Microbial }

public class GameManager : MonoBehaviour {

    //Static variables keeping track of Foods and Meds
    public static string[] Foods = { "Beets", "Blackberries", "Rhubarb", "Carrot", "Vitamin C", "Asparagus", "Fava Beans" };
    public static string[] Meds = { "Propofol", "Chloropromazine", "Thioridazine", "Ex-lax", "Rifampin", "Phenazopyridine", "Vitamin B", "Methylene Blue",
                                    "Amitriptyline", "Indomethacin", "Triamterene", "Cimetidine", "Promothazine", "Levodopa", "Metronidazole", "Nitrofurantoin",
                                    "Primaquine", "Chloroquine", "Methocarbamol", "Senna"};

    public List<Sprite> UrineSprites;

    public GameObject Setup;

    // Visual Exam Variables
    public GameObject VisualExam;
    public GameObject AskFood;
    public GameObject AnswerFood;
    public GameObject AnswerDrug;
    public Text PatientAnswer;
    public List<GameObject> Urines;

    public GameObject ChemicalExam;
    public GameObject MicrobialExam;
    public GameObject AfterZoom;

    public GameObject FinalResults;

    public Text ExamText;

    private ExamMode currentExam;
    private Disease currentDisease;

    private Bars bars;

    // Microbial
    private bool zooming;

    private string currentPatient;
    private string currentSymptoms;

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
            Reset();
        }

        if (zooming)
        {
            MicrobialExam.transform.FindChild("UrineSlide").localScale += new Vector3(15f, 15f, 15f); 
            if (MicrobialExam.transform.FindChild("UrineSlide").localScale.x >= 1200)
            {
                zooming = false;
                GetComponent<SpawnMicros>().Spawn(currentDisease);
                AfterZoom.SetActive(true);
            }
        }
	}

    public void OpenAskFood()
    {
        AskFood.SetActive(true);
        AnswerFood.SetActive(false);
        AnswerDrug.SetActive(false);
    }

    public void OpenAnswerFood()
    {
        AskFood.SetActive(false);
        AnswerFood.SetActive(true);
        AnswerDrug.SetActive(false);
    }

    public void OpenAnswerDrug()
    {
        AskFood.SetActive(false);
        AnswerFood.SetActive(false);
        AnswerDrug.SetActive(true);
    }

    public void AskFoodButton(GameObject button)
    {
        if (currentDisease.UsedFood == button.name)
        {
            PatientAnswer.text = "Patient: Yes";
        }
        else
        {
            PatientAnswer.text = "Patient: No";
        }
    }

    public void SelectFoodAnswer(GameObject button)
    {
        GameObject[] micros = GameObject.FindGameObjectsWithTag("Molecules");
        for (int i = 0; i < micros.Length; i++)
        {
            Destroy(micros[i]);
        }

        Setup.SetActive(false);
        VisualExam.SetActive(false);
        ChemicalExam.SetActive(false);
        MicrobialExam.SetActive(false);
        FinalResults.SetActive(true);

        Text finalResults = FinalResults.transform.GetChild(0).gameObject.GetComponent<Text>();

        if (currentDisease.UsedFood == button.name)
        {
            finalResults.text = "You have correctly identified " + currentPatient + "'s issues.";
        }
        else
        {
            finalResults.text = "You have incorrectly identified " + currentPatient + "'s issues.";
        }
    }

    public void SelectDrugAnswer(GameObject button)
    {
        GameObject[] micros = GameObject.FindGameObjectsWithTag("Molecules");
        for (int i = 0; i < micros.Length; i++)
        {
            Destroy(micros[i]);
        }

        Setup.SetActive(false);
        VisualExam.SetActive(false);
        ChemicalExam.SetActive(false);
        MicrobialExam.SetActive(false);
        FinalResults.SetActive(true);

        Text finalResults = FinalResults.transform.GetChild(0).gameObject.GetComponent<Text>();

        if (currentDisease.UsedMed == button.name)
        {
            finalResults.text = "You have correctly identified " + currentPatient + "'s issues.";
        }
        else
        {
            finalResults.text = "You have incorrectly identified " + currentPatient + "'s issues.";
        }
    }

    public void SelectAnswer(GameObject answer)
    {
        GameObject[] micros = GameObject.FindGameObjectsWithTag("Molecules");
        for (int i = 0; i < micros.Length; i++)
        {
            Destroy(micros[i]);
        }

        Setup.SetActive(false);
        VisualExam.SetActive(false);
        ChemicalExam.SetActive(false);
        MicrobialExam.SetActive(false);
        FinalResults.SetActive(true);

        Text finalResults = FinalResults.transform.GetChild(0).gameObject.GetComponent<Text>();

        if (currentDisease.Name == answer.name)
        {
            finalResults.text = "You have correctly identified " + currentPatient + "'s issues.";
        }
        else
        {
            finalResults.text = "You have incorrectly identified " + currentPatient + "'s issues.";
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

    public void ZoomIn()
    {
        zooming = true;
        MicrobialExam.transform.FindChild("ZoomButton").gameObject.SetActive(false);
    }

    public void Back()
    {
        Application.LoadLevel("MainMenu");
    }

    private void enterSetup()
    {
        Setup.SetActive(true);
        VisualExam.SetActive(false);
        ChemicalExam.SetActive(false);
        MicrobialExam.SetActive(false);
        FinalResults.SetActive(false);
        ExamText.text = "Below is the patient information, your job is to diagnose their issue to the best of your ability.";
        SetInfo();
        for (int i = 0; i < Urines.Count; i++)
        {
            Urines[i].GetComponent<Image>().sprite = UrineSprites[(int)currentDisease.color];
        }
    }

    private void exitSetup()
    {
        Setup.SetActive(false);
    }

    private void enterVisual()
    {
        VisualExam.SetActive(true);
        ExamText.text = "Analyze the coloring of the urine and see if you can determine the patient's issue or if further analysis is required.";

        List<string> foods = new List<string>();
        List<string> meds = new List<string>();

        if (currentDisease.UsedFood != "None")
        {
            foods.Add(currentDisease.UsedFood);
        }
        if (currentDisease.UsedMed != "None")
        {
            meds.Add(currentDisease.UsedMed);
        }

        while (foods.Count < 3)
        {
            string food = Foods[Random.Range(0, Foods.Length)];
            if (food != currentDisease.UsedFood)
            {
                foods.Add(food);
            }
        }
        while (meds.Count < 3)
        {
            string med = Meds[Random.Range(0, Meds.Length)];
            if (med != currentDisease.UsedMed)
            {
                meds.Add(med);
            }
        }

        foods = ShuffleStringList(foods);
        meds = ShuffleStringList(meds);

        for (int i = 0; i < foods.Count; i++)
        {
            AskFood.transform.GetChild(i + 1).gameObject.name = foods[i];
            AskFood.transform.GetChild(i + 1).GetChild(0).gameObject.GetComponent<Text>().text = foods[i];
            AnswerFood.transform.GetChild(i + 1).gameObject.name = foods[i];
            AnswerFood.transform.GetChild(i + 1).GetChild(0).gameObject.GetComponent<Text>().text = foods[i];
            AnswerDrug.transform.GetChild(i + 1).gameObject.name = meds[i];
            AnswerDrug.transform.GetChild(i + 1).GetChild(0).gameObject.GetComponent<Text>().text = meds[i];
        }
    }

    private void exitVisual()
    {
        VisualExam.SetActive(false);
    }

    private void enterChemical()
    {
        ChemicalExam.SetActive(true);
        ExamText.text = "Test the chemical composition by clicking on the cup to insert the urine test strip.";
        bars.SetDisease(currentDisease);
    }

    private void exitChemical()
    {
        ChemicalExam.SetActive(false);
    }

    private void enterMicrobial()
    {
        MicrobialExam.SetActive(true);
        ExamText.text = "Analyze the urine through a microscope to determine the existing microorganisms within. Click on a microorganism to find out more info on it.";
    }

    private void exitMicrobial()
    {
        MicrobialExam.SetActive(false);
    }

    private void SetInfo()
    {
        currentPatient = "Mr. Goobs";
        Text patientText = Setup.transform.GetChild(0).gameObject.GetComponent<Text>();
        patientText.text = "Patient: " + currentPatient + "\n" +
                           "Date: " + System.DateTime.Now.ToShortDateString() + "\n" +
                           "Medication: " + currentDisease.UsedMed + "\n" +
                           "Symptoms: ";

        print("Disease: " + currentDisease.Name);

        int numSym = Random.Range(1, Mathf.Min(currentDisease.Symptoms.Length, 5));
        string[] chosenSym = new string[numSym];
        List<int> indices = new List<int>();
        int index = -1;

        while (indices.Count < numSym)
        {
            int timeout = 100;
            do
            {
                timeout--;
                if (timeout <= 0)
                    break;
                index = Random.Range(0, currentDisease.Symptoms.Length);

            } while (indices.Contains(index));

            if (timeout <= 0)
                break;
            chosenSym[indices.Count] = currentDisease.Symptoms[index];
            indices.Add(index);
        }

        currentSymptoms = "";

        for (int i = 0; i < chosenSym.Length; i++)
        {
            currentSymptoms += chosenSym[i];
            if (i < chosenSym.Length - 1)
            {
                currentSymptoms += ", ";
            }
            else
            {
                currentSymptoms += ".";
            }
        }

        patientText.text += currentSymptoms;
    }

    public static List<string> ShuffleStringList(List<string> list)
    {
        for (var i = list.Count - 1; i > 0; i--)
        {
            var r = Random.Range(0, i);
            var tmp = list[i];
            list[i] = list[r];
            list[r] = tmp;
        }

        return list;
    }

    public void Reset()
    {
        GameObject txt = GameObject.FindGameObjectWithTag("MicroText");
        if (txt)
            txt.GetComponent<Text>().text = "";
        GameObject[] micros = GameObject.FindGameObjectsWithTag("Molecules");
        for (int i = 0; i < micros.Length; i++)
        {
            Destroy(micros[i]);
        }

        currentDisease.init();
        bars.SetDisease(currentDisease);
        bars.SetBars();
        currentDisease = bars.newDisease();
        enterSetup();
        AskFood.SetActive(false);
        AnswerFood.SetActive(false);
        AnswerDrug.SetActive(false);
        zooming = false;
        MicrobialExam.transform.FindChild("UrineSlide").localScale = new Vector3(20, 1, 5);
        MicrobialExam.transform.FindChild("ZoomButton").gameObject.SetActive(true);
        AfterZoom.SetActive(false);
        currentExam = ExamMode.Setup;
    }

    public string GetSymptoms()
    {
        return currentSymptoms;
    }

}
