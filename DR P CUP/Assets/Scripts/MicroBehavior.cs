using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MicroBehavior : MonoBehaviour {

    public static string[] microTextInfo =
    {
        "Red Blood Cell (RBC): It is normal for there to be 0-2 RBCs / hpf. High amounts of RBCs can indicate Kidney Infection, UTI, or Kidney Stones.",
        "White Blood Cell (WBC): It is normal for there to be 0-5 WBCs / hpf. High amounts of WBCs can indicate Kidney Infection.",
        "Crystals: Crystals can occasionally appear in urine. They tend to indicate Gout or Kidney Stones.",
        "Bacteria: There should be no bacteria in urine. Bacteria indicates a UTI is present.",
        "Yeast: Yeast should not be present in urine. It indicates that the patient has a Yeast Infection."
    };

    public SpawnMicros.Micros Type;

    private float x = 7.17f;
    private float yMax = 4.67f;
    private float yMin = -3.14f;

    private Vector3 goal;

    private Text microText;

	// Use this for initialization
	void Start () {
        UpdateGoal();

        microText = GameObject.FindGameObjectWithTag("MicroText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	    
        if (transform.position == goal)
        {
            UpdateGoal();
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, goal, 1 / (300 * Vector3.Distance(transform.position, goal)));
        }

	}

    void OnMouseDown()
    {
        microText.text = microTextInfo[(int)Type];
    }

    private void UpdateGoal()
    {
        goal = new Vector3(Random.Range(-x, x), Random.Range(yMin, yMax), 0);
    }
}
