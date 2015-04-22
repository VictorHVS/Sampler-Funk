using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Sequenciador : MonoBehaviour {

	public Hashtable sequencia;
	private float startTime;
	private bool onSequence;

	public AudioSource tocadorDefault;
	
	void Start () {
		sequencia = new Hashtable ();
		onSequence = false;
	}

	void Update(){
	}

	public void startSequence(){
		onSequence = !onSequence;
		startTime = Time.time;
	}

	public void add(AudioSource aud){
		if (onSequence) {

			AudioSource novoAudioSource = Instantiate(tocadorDefault);
			novoAudioSource.clip = aud.clip;

			sequencia.Add (Time.time - startTime, novoAudioSource);
			Debug.Log(sequencia.Count + ": Quantidade");
		}
	}

	public void PlaySequencia(){
		foreach ( DictionaryEntry de in sequencia ){
			Debug.Log(de.Key + " - " + de.Value);
			AudioSource a = (AudioSource)de.Value;
			a.PlayDelayed((float)de.Key);
		}
	}
}
