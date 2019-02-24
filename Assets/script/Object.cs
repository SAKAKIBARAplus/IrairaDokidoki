using UnityEngine;
using System.Collections;

public class Object : MonoBehaviour {
    public GameObject Arduino;
    public float offset;
    Color alpha = new Color(0, 0, 0, 0.01f);
    public float alphavalue = 0.01f;
    public static float Rvalue;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Rvalue = Arduino.GetComponent<StockData>().RValue/1024;
//        Debug.LogWarning(Rvalue);
        alphavalue = 1.0f-Rvalue-offset;
        this.GetComponent<MeshRenderer>().material.color = new Color(5, 0, 0, alphavalue);
//        Debug.LogWarning(alphavalue);
//        if (alphavalue >= 0 && alphavalue <= 1)
//        {
//            alphavalue += 0.001f;
//        }else
//        {
//            alphavalue = 0.0f;
//        }
    }
}
