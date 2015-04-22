using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioClickBehaviour : MonoBehaviour {
	private AudioSource sound;
	public Button button;
	public Sprite newsprite;
	
	void Start () {
		sound = GetComponent<AudioSource> ();
	}

	public void ClickLoop() {
		if (!sound.isPlaying) {
			sound.Play ();
			sound.loop = true;
			button.image.overrideSprite = newsprite;

		} else {
			button.image.overrideSprite = null;
			sound.Stop();
		}
	}
	public void ClickFx() {
		sound.Play ();
	}
}
