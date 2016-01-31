using UnityEngine;
using System.Collections;

public class GameGod : MonoBehaviour {
	GameState gameState;
	Player player;
	FPSWalker walker;

	public const int MinWarning = 30;
	public const int MaxWarning = 60;

	public AudioClip[] godSoundPreGame;
	public AudioClip[] godSoundTutorial1;
	public AudioClip[] godSoundTutorial2;
	public AudioClip[] godSoundCallingTut2;
	public AudioClip[] warningSound;
	public AudioClip[] finishSound;
	public AudioClip[] godbaseSound;
	public AudioClip[] mainTutorial;
	public AudioSource godSource;
	public AudioSource marcoSource;

	bool GameTalk = true;
	bool GameStart = false;
	public bool timerStart = false;
	bool oneMinuteWarning = false;
	bool fiveMinutesWarning = false;
	bool finishTalk = true;

	float timer = 0;
	float minutes = 0;
	//int isTalkingPreGame = 1;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		gameState  = player.gameState;
		walker = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSWalker>();
	
	}
	
	// Update is called once per frame
	void Update () {
		switch(gameState){
		case GameState.Pregame:
				StartCoroutine(PregameSound());
			break;
		case GameState.Tutorial:
			StartCoroutine(Tutorial());
			break;
		case GameState.Tutorial2:
			Tutorial2();
			break;
		case GameState.Play:
			StartCoroutine(MainGame());
			break;
		}
	
	}

	IEnumerator PregameSound(){
		if(GameTalk == true){
		GameTalk = false;
		godSource.clip = godSoundPreGame[0];
		godSource.Play();
		//Debug.Log(GameTalk);
		yield return new WaitForSeconds(godSoundPreGame[0].length+1);
			godSource.clip = godSoundPreGame[1];
			godSource.Play();
			yield return new WaitForSeconds(godSoundPreGame[1].length+2);
		GameTalk = true;
		}
	}

	IEnumerator MainGame(){
		if(GameTalk){
			GameTalk = false;
			timerStart= true;
			godSource.clip = mainTutorial[0];
			godSource.Play ();
			yield return new WaitForSeconds(mainTutorial[0].length);
			godSource.clip = mainTutorial[1];
			godSource.Play ();
			yield return new WaitForSeconds(mainTutorial[1].length);
			godSource.clip = mainTutorial[2];
			godSource.Play ();
			yield return new WaitForSeconds(mainTutorial[2].length);
			godSource.clip = mainTutorial[3];
			godSource.Play ();
			yield return new WaitForSeconds(mainTutorial[3].length);
			godSource.clip = mainTutorial[4];
			godSource.Play ();
			yield return new WaitForSeconds(mainTutorial[4].length);
		}

		if(timerStart){
			timer += Time.deltaTime;
			minutes = timer/60;
			//Debug.Log((int)minutes+","+(int)timer);
			switch((int)timer){
			case 30:
				StartCoroutine(OneMinuteWarning());
				break;
			case 60:
				StartCoroutine(FiveMinuteWarning());
				break;
			}
		}
		if(player.isFinished){
			player.isFinished = false;
			timerStart = false;
			if((int)minutes > 5){
				StartCoroutine(LateFinishGreet());
			}
			else if((int)minutes <= 5){
				StartCoroutine(EarlyFinishGreet());
			}
			else if((int)minutes < 1){
				StartCoroutine(FastFinishGreet());
			}
		}

	}

	IEnumerator Tutorial(){
		if(GameTalk){
			GameTalk = false;
			player.enabled = false;
			walker.enabled = false;
			godSource.clip = godSoundTutorial1[0];
			godSource.Play ();
			yield return new WaitForSeconds(godSoundTutorial1[0].length);
			godSource.clip = godSoundTutorial1[1];
			godSource.Play ();
			yield return new WaitForSeconds(godSoundTutorial1[1].length);
			godSource.clip = godSoundTutorial1[2];
			godSource.Play ();
			yield return new WaitForSeconds(godSoundTutorial1[2].length);
			godSource.clip = godSoundTutorial1[3];
			godSource.Play ();
			yield return new WaitForSeconds(godSoundTutorial1[3].length);
			GameStart = true;
			if(GameStart){
				Debug.Log("bisa jalan");
				player.enabled = true;
				player.mouseClickDisable = false;
				GameStart = false;
				timerStart = true;
				walker.enabled = true;
				godSource.clip = godSoundTutorial1[4];
				godSource.Play ();
				yield return new WaitForSeconds(godSoundTutorial1[4].length);
				godSource.Stop ();
			}
		}
		if(timerStart){
			timer += Time.deltaTime;
			minutes = timer/60;
			//Debug.Log((int)minutes+","+(int)timer);
			switch((int)timer){
			case MinWarning:
				StartCoroutine(OneMinuteWarning());
				break;
			case MaxWarning:
				StartCoroutine(FiveMinuteWarning());
				break;
			}
		}
		if(player.isFinished){
			player.isFinished = false;
			timerStart = false;
			if((int)minutes > 5){
				StartCoroutine(LateFinishGreet());
			}
			else if((int)minutes <= 5){
				StartCoroutine(EarlyFinishGreet());
			}
			else if((int)minutes < 1){
				StartCoroutine(FastFinishGreet());
			}
		}
	}

	void Tutorial2(){
		if(timerStart){
			timer += Time.deltaTime;
			minutes = timer/60;
			//Debug.Log((int)minutes+","+(int)timer);
			switch((int)timer){
			case 30:
				StartCoroutine(OneMinuteWarning());
				break;
			case 60:
				StartCoroutine(FiveMinuteWarning());
				break;
			}
		}
		if(player.isFinished){
			player.isFinished = false;
			timerStart = false;
			if((int)minutes > 5){
				StartCoroutine(LateFinishGreet());
			}
			else if((int)minutes <= 5){
				StartCoroutine(EarlyFinishGreet());
			}
			else if((int)minutes < 1){
				StartCoroutine(FastFinishGreet());
			}
		}
	}


	IEnumerator OneMinuteWarning(){
		if(!oneMinuteWarning){
			Debug.Log("warning 1 menit");
			oneMinuteWarning = true;
			godSource.clip = warningSound[0];
			godSource.Play();
			yield return new WaitForSeconds(warningSound[0].length);
			godSource.Stop();
		}
	}
	
	IEnumerator FiveMinuteWarning(){
		if(!fiveMinutesWarning){
			Debug.Log("warning 5 menit");
			fiveMinutesWarning = true;
			godSource.clip = warningSound[1];
			godSource.Play();
			yield return new WaitForSeconds(warningSound[1].length);
			godSource.Stop();
		}
	}
	
	IEnumerator FastFinishGreet(){
		if(finishTalk){
			finishTalk = false;
			godSource.clip = finishSound[0];
			godSource.Play ();
			Debug.Log("fast");
			yield return new WaitForSeconds(finishSound[0].length);
			godSource.Stop();
			Application.LoadLevel(player.nextLevel);
			//load new level
		}
	}
	
	IEnumerator EarlyFinishGreet(){
		if(finishTalk){
			finishTalk = false;
			godSource.clip = finishSound[1];
			godSource.Play ();
			Debug.Log("early");
			yield return new WaitForSeconds(finishSound[1].length);
			godSource.Stop();
			Application.LoadLevel(player.nextLevel);
			//load new level
		}
	}
	
	IEnumerator LateFinishGreet(){
		if(finishTalk){
			finishTalk = false;
			godSource.clip = finishSound[2];
			godSource.Play ();
			Debug.Log("late");
			yield return new WaitForSeconds(finishSound[2].length);
			godSource.Stop();
			Application.LoadLevel(player.nextLevel);
			//load new level
		}
	}

}
