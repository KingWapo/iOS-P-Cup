using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum HelpType 
{ 
    Symptoms,
    ChemLeuk,
    ChemNitr,
    ChemUrob,
    ChemProt,
    ChemPH,
    ChemHaem,
    ChemSpec,
    ChemKeto,
    ChemBili,
    ChemGluc,
    Diabetes1,
    Diabetes2,
    Proteinuria,
    KInfection,
    KStones,
    UTI,
    Gout
}

public class PopupHandler : MonoBehaviour {

    public GameObject Popup;

    private Text popupText;
    private GameManager manager;

    private GameObject[] ranges;

	// Use this for initialization
	void Start () {
        popupText = Popup.transform.GetChild(0).gameObject.GetComponent<Text>();
        manager = GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Close()
    {
        Popup.SetActive(false);
        for (int i = 0; i < ranges.Length; i++)
        {
            ranges[i].SetActive(true);
        }
    }

    public void HelpClicked(int halp)
    {
        HelpType halpHalp = (HelpType)halp;

        ranges = GameObject.FindGameObjectsWithTag("Ranges");
        for (int i = 0; i < ranges.Length; i++)
        {
            ranges[i].SetActive(false);
        }

        Popup.SetActive(true);

        switch(halpHalp)
        {
            case HelpType.Symptoms:
                popupText.text = "The patient's symptoms include: " + manager.GetSymptoms();
                break;
            case HelpType.ChemLeuk:
                popupText.text = "There should be no Leukocytes found in the urine. Shows positive if Leukocytes are found.";
                break;
            case HelpType.ChemNitr:
                popupText.text = "There should be no Nitrites found in the urine. Shows positive if Nitrites are found.";
                break;
            case HelpType.ChemUrob:
                popupText.text = "It is normal to find a small amount of Urobilirubin within urine. The normal level is from 0.5-1 mg/dL.";
                break;
            case HelpType.ChemProt:
                popupText.text = "The normal amount of protein found in urine is typically < 150 mg/d. Large amounts of protein found in urine typically point to Proteinuria.";
                break;
            case HelpType.ChemPH:
                popupText.text = "The normal range for pH of urine is 4.5-8.";
                break;
            case HelpType.ChemHaem:
                popupText.text = "Haemoglobin found in urine points to there being blood in the urine. Blood can be there for many reasons, including Kidney Infection, Kidney Stones, and Urinary Tract Infection.";
                break;
            case HelpType.ChemSpec:
                popupText.text = "Specific gravity is a measurement of urine concentration. The typical range is 1.005-1.025.";
                break;
            case HelpType.ChemKeto:
                popupText.text = "Ketones should not be found in urine. The presence of Ketones signifies that the patient most likely has Type 1 Diabetes.";
                break;
            case HelpType.ChemBili:
                popupText.text = "There should be no Bilirubin with the urine. Shows positive if Bilirubin is found.";
                break;
            case HelpType.ChemGluc:
                popupText.text = "The normal level of Glucose is <130 mg/d. Large amounts of Glucose in urine tends to point at Type 2 Diabetes.";
                break;
            case HelpType.Diabetes1:
                popupText.text = "Type 1 Diabetes can be found by discovering high levels of Ketones within the urine. The patient can also be showing the following symptoms: Urinating Often, Very Thirsty, Unintentional Weight Loss,Increased Hunger, Blurry Vision, Fatigue, or Bedwetting";
                break;
            case HelpType.Diabetes2:
                popupText.text = "Type 2 Diabetes can be found by discovering high levels of Glucose within the urine. The patient can also be showing the following symptoms: Very Thirsty, Urinating Often, Increased Hunger, Unintentional Weight Loss, Fatigue, Blurred Vision, Slow-healing sores, Frequent Infections, Darkened Skin Areas";
                break;
            case HelpType.Proteinuria:
                popupText.text = "Proteinuria is the presence of protein in urine. Therefore, it can be found through high levels of protein found in the urine. Proteinuria typically does not have any symptoms.";
                break;
            case HelpType.KInfection:
                popupText.text = "A Kidney Infection can cause the urine to turn red, and can be discovered through a high count of red and white blood cells. Symptoms include Fever, Back Pain, Groin Pain, Abdominal Pain, Frequent Urination, Strong and Persistent Urge to Urinate, Burning Sensation When Urinating, Pus in Urine, Blood in Urine, Cloudy Urine, Strong Smelling Urine";
                break;
            case HelpType.KStones:
                popupText.text = "Kidney stones can cause the urine to turn red or brown and can be discovered by finding crystals in the urine. Symptoms include Severe Pain in Lower Side and Back, Pain That Spreads to the Lower Abdomen and Groin, Pain That Comes in Waves and Fluctuates in Intensity, Painful Urination, Discolored Urine, Cloudy Urine, Strong Smelling Urine, Nausea, Vomiting, Persistent Need to Urinate, Frequent Urination, Short Urination Duration";
                break;
            case HelpType.UTI:
                popupText.text = "A UTI can cause the urine to turn red, and can be discovered by a high level of red blood cells and bacteria being present in the urine. Symptoms include Strong and Persistent Urge to Urinate, Burining Sensation when Urinating, Frequent and Short Urination, Cloudy Urine, Discolored Urine, Strong Smelling Urine, Pelvic Pain, Rectal Pain, Fever, Nausea, Vomiting, Blood in Urine";
                break;
            case HelpType.Gout:
                popupText.text = "Gout can be discoverd by finding crystals in the urine. Symptoms include Intense Joint Pain, Lingering Discomfort, Inflammation and Redness, Limited Range of Motion";
                break;
        }
    }
}
