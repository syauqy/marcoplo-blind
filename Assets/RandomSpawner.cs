using UnityEngine;
using System.Collections;

public class RandomSpawner : MonoBehaviour {
	public Transform[] spawner;
	public GameObject speaker;
	// Use this for initialization

	void Awake(){
		Instantiate(speaker, spawner[Random.Range(0,spawner.Length)].position, Quaternion.identity);
	}
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
