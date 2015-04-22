using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Sequenciador : MonoBehaviour {

	public Hashtable sequencia;
	private float startTime;
	private bool onSequence;
	private bool isPlaying;

	//public AudioSource tocadorDefault;
	
	void Start () {
		sequencia = new Hashtable ();
		onSequence = false;
		isPlaying = false;
	}

	void Update(){
	}

	public void startSequence(){
		onSequence = !onSequence;
		startTime = Time.time;
	}

	public void add(AudioSource aud){
		if (onSequence) {
			sequencia.Add (Time.time - startTime, aud);
			Debug.Log(sequencia.Count + ": Quantidade");
		}
	}

	public void PlaySequencia(){
		isPlaying = !isPlaying;
		if (isPlaying) {
			foreach ( DictionaryEntry de in sequencia ){

				Debug.Log(de.Key + " - " + de.Value);

				AudioSource a = (AudioSource)de.Value;
				StartCoroutine (SomeCoroutine(a, (float)de.Key));
			}
		}
	}

	IEnumerator SomeCoroutine (AudioSource sound, float time) {
		yield return new WaitForSeconds (time);

		if (sound.isPlaying)
			sound.Stop ();
		sound.Play();
	}
}
