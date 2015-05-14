using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnMicros : MonoBehaviour {

    public enum Micros { RBC, WBC, Crystals, Bacteria, Yeast }

    public List<GameObject> MicroPrefabs;

    private float x = 7.17f;
    private float yMax = 4.67f;
    private float yMin = -3.14f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Spawn(Disease dis)
    {
        float xPos, yPos;
        
        // Spawn RBC
        for (int i = 0; i < dis.RedBloodCells; i++)
        {
            xPos = Random.Range(-x, x);
            yPos = Random.Range(yMin, yMax);
            GameObject obj = (GameObject)Instantiate(MicroPrefabs[(int)Micros.RBC]);
            obj.GetComponent<MicroBehavior>().Type = Micros.RBC;
            obj.transform.position = new Vector3(xPos, yPos, 0.0f);
        }

        // Spawn WBC
        for (int i = 0; i < dis.WhiteBloodCells; i++)
        {
            xPos = Random.Range(-x, x);
            yPos = Random.Range(yMin, yMax);
            GameObject obj = (GameObject)Instantiate(MicroPrefabs[(int)Micros.WBC]);
            obj.GetComponent<MicroBehavior>().Type = Micros.WBC;
            obj.transform.position = new Vector3(xPos, yPos, 0.0f);
        }

        // Spawn Crystal
        for (int i = 0; i < dis.Crystals; i++)
        {
            xPos = Random.Range(-x, x);
            yPos = Random.Range(yMin, yMax);
            GameObject obj = (GameObject)Instantiate(MicroPrefabs[(int)Micros.Crystals]);
            obj.GetComponent<MicroBehavior>().Type = Micros.Crystals;
            obj.transform.position = new Vector3(xPos, yPos, 0.0f);
        }

        // Spawn Bacteria
        for (int i = 0; i < dis.Bacteria; i++)
        {
            xPos = Random.Range(-x, x);
            yPos = Random.Range(yMin, yMax);
            GameObject obj = (GameObject)Instantiate(MicroPrefabs[(int)Micros.Bacteria]);
            obj.GetComponent<MicroBehavior>().Type = Micros.Bacteria;
            obj.transform.position = new Vector3(xPos, yPos, 0.0f);
        }

        // Spawn Yeast
        for (int i = 0; i < dis.Yeast; i++)
        {
            xPos = Random.Range(-x, x);
            yPos = Random.Range(yMin, yMax);
            GameObject obj = (GameObject)Instantiate(MicroPrefabs[(int)Micros.Yeast]);
            obj.GetComponent<MicroBehavior>().Type = Micros.Yeast;
            obj.transform.position = new Vector3(xPos, yPos, 0.0f);
        }
    }
}
