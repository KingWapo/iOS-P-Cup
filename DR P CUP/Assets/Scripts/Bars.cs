using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public struct Disease{

    public string Name;
	
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

	public void init(){
        Name = "";

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
	}

	public void random(){
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
	}

    public void Normalize() {
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
    }

	public void Diabetes(){
        Name = "Diabetes";
		Normalize();
		KetoValue = 0.7f;
	}
	public void Proteinuria(){
        Name = "Proteinuria";
		Normalize();
		KetoValue = 0.0f;
		ProtValue = 1.0f;
	}


}

public enum Chemicals { Leukocytes = 0,
						Nitrite,
						Urobilinogen,
						Protein,
						pH,
						Haemoglobin,
						SpecGrav,
						Ketone,
						Bilirubin,
						Glucose}

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
        
		if(theDisease == 0){
			currentDisease.Diabetes();
		}
		else if(theDisease == 1){
			currentDisease.Proteinuria();
		}

        return currentDisease;
	}

    public void SetDisease(Disease newDisease)
    {
        switch(newDisease.Name)
        {
            case "Diabetes":
                currentDisease.Diabetes();
                break;
            case "Proteinuria":
                currentDisease.Proteinuria();
                break;
        }
    }

    public void SetBars()
    {
        print("Name: " + currentDisease.Name);
        setScrollbar(currentDisease);
    }
}
