using UnityEngine;
using System.Collections;

public class Movewall3 : MonoBehaviour {
    public int threshould = 50;
    public int move = 0;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 0, 0.2f));
        this.gameObject.transform.Translate(0, 0, 0);
    }

}
