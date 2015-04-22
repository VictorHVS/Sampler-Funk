using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Sequenciador : MonoBehaviour {

	public Hashtable sequencia;
	private float startTime;
	private bool onSequence;
	private bool isPlaying;
	public Text console;

	void Start () {
		sequencia = new Hashtable ();
		onSequence = false;
		isPlaying = false;
	}

	public void startSequence(){
		onSequence = !onSequence;
		startTime = Time.time;

		if (onSequence) {
			console.text = "Sequenciador iniciado...";
		} else {
			console.text = "Sequenciador finalizado...";
		}
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
			console.text = "Tocando sequenciador";
			foreach (DictionaryEntry de in sequencia) {

				Debug.Log (de.Key + " - " + de.Value);

				AudioSource a = (AudioSource)de.Value;
				StartCoroutine (SomeCoroutine (a, (float)de.Key));
			}
		} else {
			console.text = "Tocando parado";
			sequencia.Clear();
		}
	}

	IEnumerator SomeCoroutine (AudioSource sound, float time) {
		yield return new WaitForSeconds (time);
		if (sound.loop) {
			sound.GetComponent<AudioClickBehaviour> ().ClickLoop ();
		} else {
			sound.GetComponent<AudioClickBehaviour> ().ClickFx ();
		}
	}
}
