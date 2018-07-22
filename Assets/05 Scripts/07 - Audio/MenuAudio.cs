using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class MenuAudio : MonoBehaviour {



	// AUDIO
	public AudioMixerSnapshot StartGameMenuAudio;
	public AudioMixerSnapshot CreationMenuAudio;
    public AudioMixerSnapshot CityAudio;
    public AudioMixerSnapshot MenuInGameAudio;

    public AudioClip[] TransitionAudio = new AudioClip[2];
	public AudioSource TransitionAudioSource;

    public AudioSource StartMenuMusic;
    public AudioSource CreationGameStartMusic;
    public AudioSource PlayInGameMusic;
    public AudioSource MenuInGameMusic;

    public float bpm = 128;
	private float m_AudioTransitionIn;
	private float m_AudioTransitionOut;
	private float m_QuarterNote;
	private bool CreationMusicStarted;
    private bool MenuInGameMusicStarted;


    // Use this for initialization
    void Start () {
	
		// AUDIO
		m_QuarterNote = 60 / bpm;
		m_AudioTransitionIn = m_QuarterNote*4;
		m_AudioTransitionOut = m_QuarterNote * 8;


		CreationMusicStarted = false;
        MenuInGameMusicStarted = false;


    }
    
    void PlayMainTransition(int choice)
    {
        TransitionAudioSource.clip = TransitionAudio[choice];
        TransitionAudioSource.Play();
    }


    public void  PlayCreationMenuAudio() {

		if (CreationMusicStarted == false) {
            CreationGameStartMusic.Play();
            CreationMusicStarted =true; }
			PlayMainTransition (1);
			CreationMenuAudio.TransitionTo (m_AudioTransitionIn);
	}
	
	public void  PlayStartGameMenuAudio() {
        StartGameMenuAudio.TransitionTo (m_AudioTransitionOut);
		PlayMainTransition (0);
	}
	
	

    public void PlayCityAudio()
    {
        CityAudio.TransitionTo(m_AudioTransitionOut);
        PlayMainTransition(0);
    }

    public void PlayMenuInGameAudio()
    {
        if (MenuInGameMusicStarted == false)
        {
            MenuInGameMusic.Play();
            MenuInGameMusicStarted = true;
        }

        MenuInGameAudio.TransitionTo(m_AudioTransitionOut);
        PlayMainTransition(1);
    }



}
