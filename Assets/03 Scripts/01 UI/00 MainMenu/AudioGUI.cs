using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class AudioGUI {


	public AudioMixerSnapshot GameMenuAudio;
	public AudioMixerSnapshot CreationMenuAudio;
	public AudioClip[] TransitionAudio;
	private AudioSource TransitionAudioSource;
	public float bpm=128;
	
	private float m_AudioTransitionIn;
	private float m_AudioTransitionOut;
	private float m_quarterNote;

	// Use this for initialization
	void Start () {
		// Audio transition
		m_quarterNote = 60 / bpm;
		m_AudioTransitionIn = m_quarterNote;
		m_AudioTransitionOut = m_quarterNote + 32;

	}

	public void GetAudioObjects (AudioMixerSnapshot C_GameMenuAudio,AudioMixerSnapshot C_CreationMenuAudio,AudioClip[] C_TransitionAudio){
		GameMenuAudio = C_GameMenuAudio;
		CreationMenuAudio = C_CreationMenuAudio;
		TransitionAudio = C_TransitionAudio;
	}

	
	public void  PlayCreationMenuAudio() {
		CreationMenuAudio.TransitionTo (m_AudioTransitionIn);
	}
	
	public void  PlayGameMenuAudio() {
		GameMenuAudio.TransitionTo (m_AudioTransitionOut);
	}
	
	
	public void PlayTransition()
	{
		int randClip = Random.Range (0, TransitionAudio.Length);
		TransitionAudioSource.clip = TransitionAudio[randClip];
		TransitionAudioSource.Play();
	}
}


