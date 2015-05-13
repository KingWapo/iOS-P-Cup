using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

// Publicly accessible enums
public enum Chemicals
{
    Leukocytes = 0,
    Nitrite,
    Urobilinogen,
    Protein,
    pH,
    Haemoglobin,
    SpecGrav,
    Ketone,
    Bilirubin,
    Glucose
}

public enum UrineColor
{
    Yellow = 0,     // Normal

    Red,            // Food: Beets, blackberries, rhubarb
                    // Meds: Propofol, chloropromazine, thioridazine, Ex-lax
                    // Cond: UTI, nephrolithiasis, hemoglobinuria, porphyrias

    Orange,         // Fppd: Carrot, vitamin C
                    // Meds: Rifampin, phenazopyridine
    
    Green,          // Food: Asparagus
                    // Meds: Vitamin B, methylene blue, propofol, amitriptyline
                    // Cond: UTI

    Blue,           // Meds: Methylene blue, indomethacin, amitriptyline, triamterene,
                    //       cimetidine, promethazine.
                    // Cond: Blue diaper syndrome

    Purple,         // Cond: Bacteriuria in patients with urinary catheters

    Brown,          // Food: Fava beans
                    // Meds: Levodopa, metronidazole, nitrofurantoin, primaquine, chloroquine,
                    //       methocarbamol, senna
                    // Cond: Glibert syndrome, tyrosinemia, hepatobiliary disease
    
    Black,          // Cond: Alkaptonuria, malignant melanoma

    White           // Meds: Propofol
                    // Cond: Chyluria, pyuria, phosphate crystals
}

public enum DiseaseType
{
    Type1Diabetes, 
    Type2Diabetes, 
    Proteinuria, 
    MAX
}

public struct Disease{

    // Disease information
    public string Name;
    public string Symptoms;

    // Visual information
    public UrineColor color;
	
    // Chemical information
	public bool LeukValue;
	public bool NitrValue;
	public float UrobValue;
	public float ProtValue;
	public float pHValue;
	public float HaemValue;
	public float SpecValue;
	public float KetoValue;
	public bool BiliValue;
	public float GlucValue;

    // Microbial information
    public int RedBloodCells;   // Measured by RBCs/hpf
    public int WhiteBloodCells; // Measure by WBCs/hpf
    public int Crystals;        // Kidney Stones
    public int Bacteria;        // UTI
    public int Yeast;           // Yeast infection

	public void init(){
        Name = "";
        Symptoms = "";

        color = UrineColor.Yellow;

		LeukValue = false;
		NitrValue = false;
		UrobValue = 0.02f;
		ProtValue = 0.02f;
		pHValue = 0.02f;
		HaemValue = 0.02f;
		SpecValue = 0.02f;
		KetoValue = 0.0f;
		BiliValue = false;
		GlucValue = 0.02f;

        RedBloodCells = 2;
        WhiteBloodCells = 2;
        Crystals = 0;
        Bacteria = 0;
        Yeast = 0;
	}

	public void random(){
        Name = "Random";
        Symptoms = "";

        LeukValue = Random.Range(0,2) == 0 ? false : true;
        NitrValue = Random.Range(0, 2) == 0 ? false : true;
		UrobValue = Random.Range(0.5f, 1.0f);
		ProtValue = Random.Range(0.0f, 0.57f);
		pHValue = Random.Range(0.375f, .67f);
		HaemValue = Random.Range(0.0f, 0.3f);
		SpecValue = Random.Range(0.5f, 1.0f);
		KetoValue = Random.Range(0.0f, 1.0f);
        BiliValue = Random.Range(0, 2) == 0 ? false : true;
		GlucValue = Random.Range(0.02f, 1.0f);

        RedBloodCells = Random.Range(0, 10);
        WhiteBloodCells = Random.Range(0, 10);
        Crystals = Random.Range(0, 10);
        Bacteria = Random.Range(0, 10);
        Yeast = Random.Range(0, 10);
	}

    public void Normalize() {
        Name = "Normal";
        Symptoms = "None";

        color = UrineColor.Yellow;

        LeukValue = false;
        NitrValue = false;
        UrobValue = 0.5f;
        ProtValue = 0.57f;
        pHValue = 0.375f;
        HaemValue = 0.3f;
        SpecValue = 0.5028f;
        KetoValue = 0.0f;
        BiliValue = false;
        GlucValue = 0.5f;

        RedBloodCells = Random.Range(0, 2);
        WhiteBloodCells = Random.Range(0, 5);
        Crystals = 0;
        Bacteria = 0;
        Yeast = 0;
    }

    public void SetDisease(DiseaseType dType)
    {
        Normalize();
        switch(dType)
        {
            case DiseaseType.Type1Diabetes:
                Type1Diabetes();
                break;
            case DiseaseType.Type2Diabetes:
                Type2Diabetes();
                break;
            case DiseaseType.Proteinuria:
                Proteinuria();
                break;
        }
    }

    /* ------------- Visual Detection Diseases ------------- */

    

    /* ------------ Chemical Detection Diseases ------------ */

    public void Type1Diabetes()
    {
        Name = "Type 1 Diabetes";
        KetoValue = Random.Range(0.3f, 1.0f);
    }

    public void Type2Diabetes()
    {
        Name = "Type 2 Diabetes";
        GlucValue = Random.Range(200.0f, 260.0f) / 260.0f;
    }

    public void Proteinuria()
    {
        Name = "Proteinuria";
        KetoValue = 0.0f;
        ProtValue = 1.0f;
    }

    /* -------------- Micro Detection Diseases -------------- */

    public void KidneyInfection()
    {
        Name = "Kidney Infection";

        WhiteBloodCells = Random.Range(6, 10);
        RedBloodCells = Random.Range(3, 10);
    }

    // Urinary Tract Infection
    public void UTI()
    {
        Name = "Urinary Tract Infection";

        RedBloodCells = Random.Range(3, 10);
    }

    public void Gaut()
    {
        Name = "Gaut";

        Crystals = Random.Range(1, 5);
    }

    public void KidneyStones()
    {
        Name = "Kidney Stones";

        Crystals = Random.Range(1, 10);
    }
}

public class Bars : MonoBehaviour {

    public static int MAXDISEASES = 2;

	public List<Scrollbar> ChemBars;
	
	private Disease currentDisease;

	void Start(){
		currentDisease.init();
		setScrollbar(currentDisease);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			ChemBars[(int)Chemicals.Nitrite].size = 1.0f;
		}
	}

	void setScrollbar(Disease d){
        ChemBars[(int)Chemicals.Leukocytes].transform.GetChild(1).gameObject.GetComponent<Text>().text = d.LeukValue ? "+" : "-";
        ChemBars[(int)Chemicals.Nitrite].transform.GetChild(1).gameObject.GetComponent<Text>().text = d.NitrValue ? "+" : "-";
		ChemBars[(int)Chemicals.Urobilinogen].size = d.UrobValue;
		ChemBars[(int)Chemicals.Protein].size = d.ProtValue;
		ChemBars[(int)Chemicals.pH].size = d.pHValue;
		ChemBars[(int)Chemicals.Haemoglobin].size = d.HaemValue;
		ChemBars[(int)Chemicals.SpecGrav].size = d.SpecValue;
		ChemBars[(int)Chemicals.Ketone].size = d.KetoValue;
        ChemBars[(int)Chemicals.Bilirubin].transform.GetChild(1).gameObject.GetComponent<Text>().text = d.BiliValue ? "+" : "-";
		ChemBars[(int)Chemicals.Glucose].size = d.GlucValue;
	}

	public Disease newDisease(){
        int theDisease = Random.Range(0, MAXDISEASES);

        currentDisease.SetDisease((DiseaseType)Random.Range(0, (int)DiseaseType.MAX));

        return currentDisease;
	}

    public void SetDisease(Disease newDisease)
    {
        currentDisease = newDisease;
    }

    public void SetBars()
    {
        print("Name: " + currentDisease.Name);
        setScrollbar(currentDisease);
    }
}
