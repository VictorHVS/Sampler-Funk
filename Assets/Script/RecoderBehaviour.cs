using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RecoderBehaviour : MonoBehaviour {
	public AudioSource aud;
	public Text console;

	
	public void Recorder () {
		if (Microphone.IsRecording ("DarthVader")) {
			Microphone.End("DarthVader");
			Debug.Log("terminei de gravar");
			console.text = "Terminei a gravaçao...";
		} else {
			aud.Stop();
			aud.clip = Microphone.Start("DarthVader", true, 10, 44100);
			Debug.Log("começei a gravar");
			console.text = "comecei a gravaçao...";
		}
	}
}
