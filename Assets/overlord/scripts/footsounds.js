#pragma strict

var myAudioSource : AudioSource;
var sounds : AudioClip[];




function OnCollisionEnter(collision : Collision) 
{
	
	if (!GetComponent.<AudioSource>().isPlaying)
	{
		GetComponent.<AudioSource>().clip = sounds[Random.Range(0,sounds.Length)];
		GetComponent.<AudioSource>().Play();
	}
}