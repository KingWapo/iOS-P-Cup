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

public enum DiseaseType
{
    // Visual Diseases
    RedFood,
    RedDrug,
    OrangeFood,
    OrangeDrug,
    GreenFood,
    GreenDrug,
    BlueDrug,
    BrownFood,
    BrownDrug,
    WhiteDrug,

    // Chemical Diseases
    Type1Diabetes,
    Type2Diabetes,
    Proteinuria,

    // Microbial Diseases
    KidneyInfection,
    UTI,
    Gout,
    KidneyStones,

    MAX
}


public enum UrineColor
{
    Yellow = 0,     // Normal

    Red,            // Food: Beets, blackberries, rhubarb
                    // Meds: Propofol, chloropromazine, thioridazine, Ex-lax
                    // Cond: UTI, nephrolithiasis, hemoglobinuria, porphyrias

    Orange,         // Food: Carrot, vitamin C
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

public struct Disease{

    // Disease information
    public string Name;
    public string[] Symptoms;

    // Visual information
    public UrineColor color;

    // Related Foods/Meds
    public string[] RelatedFoods;
    public string[] RelatedMeds;

    public string UsedFood;
    public string UsedMed;
	
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
        Symptoms = new string[]{};

        color = UrineColor.Yellow;

        RelatedFoods = new string[] { };
        RelatedMeds = new string[] { };

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
        Symptoms = new string[] {};

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
        Symptoms = new string[] {"None"};

        color = UrineColor.Yellow;

        RelatedFoods = new string[] { };
        RelatedMeds = new string[] { };

        UsedFood = "None";
        UsedMed = "None";

        LeukValue = false;
        NitrValue = false;
        UrobValue = Random.Range(0.1f, 0.25f);
        ProtValue = Random.Range(100.0f / 300.0f, 0.57f);
        pHValue = Random.Range(4.5f / 12.0f, 8.0f / 12.0f);
        HaemValue = Random.Range(0f, .1f);
        SpecValue = Random.Range(1.005f, 1.025f) / 2.05f;
        KetoValue = 0.0f;
        BiliValue = false;
        GlucValue = Random.Range(100.0f / 260.0f, 0.5f);

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
            // Visual Cases
            case DiseaseType.RedFood:
                RedFood();
                break;
            case DiseaseType.RedDrug:
                RedDrug();
                break;
            case DiseaseType.OrangeFood:
                OrangeFood();
                break;
            case DiseaseType.OrangeDrug:
                OrangeDrug();
                break;
            case DiseaseType.GreenFood:
                GreenFood();
                break;
            case DiseaseType.GreenDrug:
                GreenDrug();
                break;
            case DiseaseType.BlueDrug:
                BlueDrug();
                break;
            case DiseaseType.BrownFood:
                BrownFood();
                break;
            case DiseaseType.BrownDrug:
                BrownDrug();
                break;
            case DiseaseType.WhiteDrug:
                WhiteDrug();
                break;

            // Chemical Cases
            case DiseaseType.Type1Diabetes:
                Type1Diabetes();
                break;
            case DiseaseType.Type2Diabetes:
                Type2Diabetes();
                break;
            case DiseaseType.Proteinuria:
                Proteinuria();
                break;

            // Microbial Cases
            case DiseaseType.KidneyInfection:
                KidneyInfection();
                break;
            case DiseaseType.UTI:
                UTI();
                break;
            case DiseaseType.Gout:
                Gout();
                break;
            case DiseaseType.KidneyStones:
                KidneyStones();
                break;
        }
    }

    /*
     * public void Disease()
     * {
     *      Name = "Name";
     *      Symptoms = "List of Symptoms";
     *      
     *      color = UrineColor.Color;
     *      
     *      RelatedFoods = { Food1, Food2 };
     *      RelatedDrugs = { Drug1, Drug2 };
     *      
     *      Chem Values beyond normal
     *      
     *      Microbial Values beyond normal
     * }
    */

    /* ------------- Visual Detection Diseases ------------- */

    public void RedFood()
    {
        Name = "Food";
        Symptoms = new string[] { "Discolored Urine" };
        
        color = UrineColor.Red;

        RelatedFoods = new string[] { "Beets", "Blackberries", "Rhubarb" };
        RelatedMeds = new string[] { "Propofol", "Chlorpromazine", "Thioridazine", "Ex-lax" };
        UsedFood = RelatedFoods[Random.Range(0, RelatedFoods.Length)];
    }

    public void RedDrug()
    {
        Name = "Drug";
        Symptoms = new string[] {"Discolored Urine"};

        color = UrineColor.Red;

        RelatedFoods = new string[] { "Beets", "Blackberries", "Rhubarb" };
        RelatedMeds = new string[] { "Propofol", "Chlorpromazine", "Thioridazine", "Ex-lax" };
        UsedMed = RelatedMeds[Random.Range(0, RelatedMeds.Length)];
    }

    public void OrangeFood()
    {
        Name = "Food";
        Symptoms = new string[] { "Discolored Urine" };

        color = UrineColor.Orange;

        RelatedFoods = new string[] { "Carrot", "Vitamin C" };
        RelatedMeds = new string[] { "Rifampin", "Phenazopyridine" };
        UsedFood = RelatedFoods[Random.Range(0, RelatedFoods.Length)];
    }

    public void OrangeDrug()
    {
        Name = "Drug";
        Symptoms = new string[] { "Discolored Urine" };

        color = UrineColor.Orange;

        RelatedFoods = new string[] { "Carrot", "Vitamin C" };
        RelatedMeds = new string[] { "Rifampin", "Phenazopyridine" };
        UsedMed = RelatedMeds[Random.Range(0, RelatedMeds.Length)];
    }

    public void GreenFood()
    {
        Name = "Food";
        Symptoms = new string[] { "Discolored Urine" };

        color = UrineColor.Green;

        RelatedFoods = new string[] { "Asparagus" };
        RelatedMeds = new string[] { "Vitamin B", "Methylene Blue", "Propofol", "Amitriptyline" };
        UsedFood = RelatedFoods[Random.Range(0, RelatedFoods.Length)];
    }

    public void GreenDrug()
    {
        Name = "Drug";
        Symptoms = new string[] { "Discolored Urine" };

        color = UrineColor.Green;

        RelatedFoods = new string[] { "Asparagus" };
        RelatedMeds = new string[] { "Vitamin B", "Methylene Blue", "Propofol", "Amitriptyline" };
        UsedMed = RelatedMeds[Random.Range(0, RelatedMeds.Length)];
    }

    public void BlueDrug()
    {
        Name = "Drug";
        Symptoms = new string[] { "Discolored Urine" };

        color = UrineColor.Blue;

        RelatedMeds = new string[] { "Methylene Blue", "Indomethacin", "Amitriptyline", "Triamterene", "Cimetidine", "Promethazine" };
        UsedMed = RelatedMeds[Random.Range(0, RelatedMeds.Length)];
    }

    public void BrownFood()
    {
        Name = "Food";
        Symptoms = new string[] { "Discolored Urine" };

        color = UrineColor.Brown;

        RelatedFoods = new string[] { "Fava beans" };
        RelatedMeds = new string[] { "Levodopa", "Metronidazole", "Nitrofurantoin", "Primaquine", "Chloroquine", "Methocarbamol", "Senna" };
        UsedFood = RelatedFoods[Random.Range(0, RelatedFoods.Length)];
    }

    public void BrownDrug()
    {
        Name = "Drug";
        Symptoms = new string[] { "Discolored Urine" };

        color = UrineColor.Brown;

        RelatedFoods = new string[] { "Fava beans" };
        RelatedMeds = new string[] { "Levodopa", "Metronidazole", "Nitrofurantoin", "Primaquine", "Chloroquine", "Methocarbamol", "Senna" };
        UsedMed = RelatedMeds[Random.Range(0, RelatedMeds.Length)];
    }

    public void WhiteDrug()
    {
        Name = "Drug";
        Symptoms = new string[] { "Discolored Urine" };

        color = UrineColor.White;

        RelatedMeds = new string[] { "Propofol" };
        UsedMed = RelatedMeds[Random.Range(0, RelatedMeds.Length)];
    }

    /*
     * public void Disease()
     * {
     *      Name = "Name";
     *      Symptoms = "List of Symptoms";
     *      
     *      color = UrineColor.Color;
     *      
     *      RelatedFoods = { Food1, Food2 };
     *      RelatedDrugs = { Drug1, Drug2 };
     *      
     *      Chem Values beyond normal
     *      
     *      Microbial Values beyond normal
     * }
    */

    /* ------------ Chemical Detection Diseases ------------ */

    public void Type1Diabetes()
    {
        Name = "Type 1 Diabetes";
        Symptoms = new string[] { "Urinating Often", "Very Thirsty", "Unintentional Weight Loss",
                                  "Increased Hunger", "Blurry Vision", "Fatigue", "Bedwetting"};

        KetoValue = Random.Range(0.3f, 1.0f);
    }

    public void Type2Diabetes()
    {
        Name = "Type 2 Diabetes";
        Symptoms = new string[] { "Very Thirsty", "Urinating Often", "Increased Hunger",
                                  "Unintentional Weight Loss", "Fatigue", "Blurred Vision",
                                  "Slow-healing sores", "Frequent Infections", "Darkened Skin Areas"};
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
        Symptoms = new string[] { "Fever", "Back Pain", "Groin Pain", "Abdominal Pain",
                                  "Frequent Urination", "Strong and Persistent Urge to Urinate",
                                  "Burning Sensation When Urinating", "Pus in Urine",
                                  "Blood in Urine", "Cloudy Urine", "Strong Smelling Urine"};

        // Red or Yellow Urine. 
        color = Random.Range(0, 2) == 0 ? UrineColor.Yellow : UrineColor.Red;

        WhiteBloodCells = Random.Range(6, 10);
        RedBloodCells = Random.Range(3, 10);
    }

    // Urinary Tract Infection
    public void UTI()
    {
        Name = "Urinary Tract Infection";
        Symptoms = new string[] { "Strong and Persistent Urge to Urinate", "Burining Sensation when Urinating",
                                  "Frequent and Short Urination", "Cloudy Urine", "Discolored Urine", "Strong Smelling Urine",
                                  "Pelvic Pain", "Rectal Pain", "Fever", "Nausea", "Vomiting",
                                  "Blood in Urine"};
        // Red or Yellow Urine. 
        color = Random.Range(0, 2) == 0 ? UrineColor.Yellow : UrineColor.Red;

        RedBloodCells = Random.Range(3, 10);
    }

    public void Gout()
    {
        Name = "Gout";
        Symptoms = new string[] { "Intense Joint Pain", "Lingering Discomfort",
                                  "Inflammation and Redness", "Limited Range of Motion"};

        Crystals = Random.Range(1, 5);
    }

    public void KidneyStones()
    {
        Name = "Kidney Stones";
        Symptoms = new string[] { "Severe Pain in Lower Side and Back", "Pain That Spreads to the Lower Abdomen and Groin",
                                  "Pain That Comes in Waves and Fluctuates in Intensity", "Painful Urination",
                                  "Discolored Urine", "Cloudy Urine", "Strong Smelling Urine", "Nausea", "Vomiting",
                                  "Persistent Need to Urinate", "Frequent Urination", "Short Urination Duration"};
        // Red or brown urine.
        int col = Random.Range(0, 3);
        if (col == 0)
            color = UrineColor.Yellow;
        else if (col == 1)
            color = UrineColor.Red;
        else
            color = UrineColor.Brown;

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
