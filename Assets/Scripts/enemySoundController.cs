using UnityEngine;
using System.Collections;

public class enemySoundController : MonoBehaviour {
	
	public AudioClip marcoSound;
	public AudioSource marcoSpeak;
	public GameObject player;
	Player playerScript;
	//bool marcoSpeaking = false;


	// Use this for initialization
	void Start () {
		playerScript = player.GetComponent<Player>();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	if(Input.GetMouseButtonUp(0)){

				Debug.Log(playerScript.marcoCall);
			if(!marcoSpeak.isPlaying){
				marcoSpeak.clip = marcoSound;
				marcoSpeak.Play();
			}
			else{
				marcoSpeak.Stop();
			}
		}
	}
}
