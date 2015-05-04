﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public struct Disease{
	
	public float LeukValue;
	public float NitrValue;
	public float UrobValue;
	public float ProtValue;
	public float pHValue;
	public float HaemValue;
	public float SpecValue;
	public float KetoValue;
	public float BiliValue;
	public float GlucValue;

	public void init(){
		LeukValue = 0.02f;
		NitrValue = 0.02f;
		UrobValue = 0.02f;
		ProtValue = 0.02f;
		pHValue = 0.02f;
		HaemValue = 0.02f;
		SpecValue = 0.02f;
		KetoValue = 0.02f;
		BiliValue = 0.02f;
		GlucValue = 0.02f;
	}

	public void random(){
		LeukValue = Random.Range(0.02f, 1.0f);
		NitrValue = Random.Range(0.02f, 1.0f);
		UrobValue = Random.Range(0.02f, 1.0f);
		ProtValue = Random.Range(0.02f, 1.0f);
		pHValue = Random.Range(0.02f, 1.0f);
		HaemValue = Random.Range(0.02f, 1.0f);
		SpecValue = Random.Range(0.02f, 1.0f);
		KetoValue = Random.Range(0.02f, 1.0f);
		BiliValue = Random.Range(0.02f, 1.0f);
		GlucValue = Random.Range(0.02f, 1.0f);
	}
	public void Diabetes(){
		random();
		KetoValue = 1.0f;
	}
	public void Proteinuria(){
		random();
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
		ChemBars[(int)Chemicals.Leukocytes].size = d.LeukValue;
		ChemBars[(int)Chemicals.Nitrite].size = d.NitrValue;
		ChemBars[(int)Chemicals.Urobilinogen].size = d.UrobValue;
		ChemBars[(int)Chemicals.Protein].size = d.ProtValue;
		ChemBars[(int)Chemicals.pH].size = d.pHValue;
		ChemBars[(int)Chemicals.Haemoglobin].size = d.HaemValue;
		ChemBars[(int)Chemicals.SpecGrav].size = d.SpecValue;
		ChemBars[(int)Chemicals.Ketone].size = d.KetoValue;
		ChemBars[(int)Chemicals.Bilirubin].size = d.BiliValue;
		ChemBars[(int)Chemicals.Glucose].size = d.GlucValue;
	}

	public void newDisease(){
		int theDisease;
		theDisease = Random.Range(0, 2);

		if(theDisease == 0){
			currentDisease.Diabetes();
			setScrollbar(currentDisease);
		}
		else if(theDisease == 1){
			currentDisease.Proteinuria();
			setScrollbar(currentDisease);
		}
	}

	/*void updateChem(){
		ChemBars.size = ChemValue / 100f;
	}*/

	/*public void setValue(float value){
		ChemValue += value;
		ChemBars.size = ChemValue / 100f;
	}*/

	/*void (){
		if(Input.GetKeyDown(KeyCode.D)){
		   setValue(20f);
		}
	}*/
}
