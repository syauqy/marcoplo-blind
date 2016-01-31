using UnityEngine;
using System.Collections;

public enum GameState{Pregame, Tutorial, Tutorial2, Play, Finish}

public class Player : MonoBehaviour {
	public GameState gameState;
	public string nextLevel;
	public int marcoCall = 0;
	public float timer = 0;

	GameGod game;

	public bool isFinished = false;
	public bool mouseClickDisable = false;
	public bool hitWood = false;
	public bool hitMetal = false;
	public bool hitGrass = false;
	public bool hitConcrete = false;

	bool marcoSpeaking =  false;

	public AudioClip marcoSound;
	public AudioSource marcoSpeak;

	AudioSource speakerMain;

	// Use this for initialization
	void Start () {
		game = GameObject.Find("GameGod").GetComponent<GameGod>();
		mouseClickDisable = true;

	
	}
	
	// Update is called once per frame
	void Update () {
		switch(gameState){
		case GameState.Pregame:
			PreGame();
			break;
		case GameState.Tutorial:
			StartCoroutine(GetSourceSound());
			break;
		case GameState.Tutorial2:
			StartCoroutine(GetSourceSound());
			break;
		case GameState.Play:
			mouseClickDisable = false;
			StartCoroutine(GetSourceSound());
			break;
		case GameState.Finish:
			break;
		}
	}

	IEnumerator GetSourceSound(){
		if(marcoSpeaking){

			marcoSpeaking = false;
			if(gameState == GameState.Tutorial && !game.marcoSource.isPlaying){

				/*marcoSpeak.clip = marcoSound;
				marcoSpeak.Play ();
				Debug.Log("marco speaking");
				yield return new WaitForSeconds(marcoSound.length);
				marcoSpeak.Stop ();*/
				if(!marcoSpeak.isPlaying){
					marcoSpeak.clip = game.godSoundCallingTut2[Random.Range(0,game.godSoundCallingTut2.Length)];
					marcoSpeak.Play ();
					yield return new WaitForSeconds(marcoSpeak.clip.length);
					marcoSpeak.Stop ();
				}
			}
			else if(gameState == GameState.Tutorial2 && !game.marcoSource.isPlaying){
			}
			if(hitMetal){
				game.marcoSource.clip = game.godSoundCallingTut2[Random.Range(0,game.godSoundCallingTut2.Length)];
					game.marcoSource.Play ();
					yield return new WaitForSeconds(game.marcoSource.clip.length);
					game.marcoSource.Stop ();
			}

			else if(gameState == GameState.Play ){
				speakerMain = GameObject.Find("speaker main(Clone)").GetComponent<AudioSource>();
				if(!speakerMain.isPlaying){
					speakerMain.clip = game.godSoundCallingTut2[Random.Range(0,game.godSoundCallingTut2.Length)];
				speakerMain.Play ();
					yield return new WaitForSeconds(speakerMain.clip.length);
				speakerMain.Stop ();
				}
			}
		}

	}
	
	void FixedUpdate () {
		if(Input.GetMouseButtonDown(0) && !mouseClickDisable){
			if(!marcoSpeaking)
			Debug.Log("mouse pressed");
			marcoSpeaking = true;
		}
	}
	

	void OnControllerColliderHit(ControllerColliderHit c){
		if(gameState == GameState.Tutorial2 && !game.godSource.isPlaying){

			if(c.gameObject.tag == "Wood"){
				if(!hitWood){
					StartCoroutine(HitWood());
				}
			}
			else if(c.gameObject.tag == "Concrete"){
				if(!hitConcrete){
					StartCoroutine(HitConcrete());
				}
			}
			else if(c.gameObject.tag == "Grass"){
				if(!hitGrass){
					StartCoroutine(HitGrass());
				}
			}
			else if(c.gameObject.tag == "Metal"){
				if(!hitMetal){

					StartCoroutine(HitMetal());
				}
			}
		}
	}

	IEnumerator HitConcrete(){
		if(!hitConcrete){
			hitConcrete = true;
			game.godSource.clip = game.godSoundTutorial2[0];
			game.godSource.Play ();
			yield return new WaitForSeconds(game.godSoundTutorial2[0].length);
			game.godSource.clip = game.godSoundTutorial2[1];
			game.godSource.Play ();
			yield return new WaitForSeconds(game.godSoundTutorial2[1].length);
			game.godSource.clip = game.godSoundTutorial2[2];
			game.godSource.Play ();
			yield return new WaitForSeconds(game.godSoundTutorial2[2].length);
			game.godSource.clip = game.godSoundTutorial2[3];
			game.godSource.Play ();
			yield return new WaitForSeconds(game.godSoundTutorial2[3].length);
			game.godSource.clip = game.godSoundTutorial2[4];
			game.godSource.Play ();
			yield return new WaitForSeconds(game.godSoundTutorial2[4].length);
			game.godSource.clip = game.godbaseSound[0];
			game.godSource.Play ();
			yield return new WaitForSeconds(game.godbaseSound[0].length);
			game.godSource.Stop ();
			game.timerStart = true;
		}
	}

	IEnumerator HitMetal(){
		hitMetal = true;
		mouseClickDisable = false;
		game.godSource.clip = game.godbaseSound[3];
		game.godSource.Play ();
		yield return new WaitForSeconds(game.godbaseSound[3].length);
	}

	IEnumerator HitGrass(){
		hitGrass = true;
		game.godSource.clip = game.godbaseSound[1];
		game.godSource.Play ();
		yield return new WaitForSeconds(game.godbaseSound[1].length);

	}

	IEnumerator HitWood(){
		hitWood = true;
		game.godSource.clip = game.godbaseSound[2];
		game.godSource.Play ();
		yield return new WaitForSeconds(game.godbaseSound[2].length);
	}
	
	
	void OnTriggerEnter(Collider c){
			if(c.gameObject.tag == "Source"){
				//suara menang
				isFinished = true;
				//Debug.Log("menang");
			}

	}

	void PreGame(){
		if(Input.GetKeyUp(KeyCode.Space)){
			//Debug.Log("pindah level");
			Application.LoadLevel("tutorial1");
		}
	}

	void Tutorial(){

	}

}
