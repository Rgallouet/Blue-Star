using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class MenuAudio : MonoBehaviour {


	// AUDIO
	public AudioMixerSnapshot GameMenuAudio;
	public AudioMixerSnapshot CreationMenuAudio;
	public AudioClip[] TransitionAudio = new AudioClip[2];
	private AudioSource TransitionAudioSource;
	private AudioSource CreationGameStartMusic;
	public float bpm = 128;
	private float m_AudioTransitionIn;
	private float m_AudioTransitionOut;
	private float m_QuarterNote;
	private bool CreationMusicStarted;


	// Use this for initialization
	void Start () {
	
		// AUDIO
		m_QuarterNote = 60 / bpm;
		m_AudioTransitionIn = m_QuarterNote*4;
		m_AudioTransitionOut = m_QuarterNote * 8;
		CreationMusicStarted = false;

		TransitionAudioSource = this.gameObject.GetComponents<AudioSource> () [2];
		CreationGameStartMusic = this.gameObject.GetComponents<AudioSource> () [0];


	}
	
	public void  PlayCreationMenuAudio() {

		if (CreationMusicStarted == false) {
			CreationGameStartMusic.Play();
			CreationMusicStarted=true;
		}
			PlayMainTransition (1);
			CreationMenuAudio.TransitionTo (m_AudioTransitionIn);
	}
	
	public void  PlayGameMenuAudio() {
		GameMenuAudio.TransitionTo (m_AudioTransitionOut);
		PlayMainTransition (0);
	}
	
	
	void PlayMainTransition(int choice)
	{
		TransitionAudioSource.clip = TransitionAudio[choice];
		TransitionAudioSource.Play();
	}
}
