using UnityEngine;
using System.Collections;

public class MarcoSpawner : MonoBehaviour {
	public GameObject marco;

	// Use this for initialization
	void Start () {
		Instantiate(marco, new Vector3(Random.Range(60,-60),1,0), Quaternion.identity);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
