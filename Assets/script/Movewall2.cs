using UnityEngine;
using System.Collections;

public class Movewall2 : MonoBehaviour {
    public int threshould = 50;
    public int move = 0;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (move >= threshould && move < threshould * 2)
        {
            this.gameObject.transform.Translate(0.05f, 0, 0);
        }
        else
        if (move >= 0 && move < threshould)
        {
            this.gameObject.transform.Translate(-0.05f, 0, 0);
        }
        move++;
        if (move >= threshould * 2)
        {
            move = 0;
        }
    }
}
