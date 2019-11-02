using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
	public static AudioManager instance {get; private set;}
	private  AudioSource[]	allSources;
	private  AudioSource	levelSource;
	private  AudioSource	genericSource;
	public  AudioClip	audioLevel;
	void Awake () {
		instance = this;
		allSources = GetComponents<AudioSource>();
		levelSource = allSources[0];
		genericSource = allSources[1];
	}
	public void StopMusic() {
		levelSource.Stop();
	}
	public void Play(AudioClip clip, bool loop, bool playAwake, float vol) {
		genericSource.clip = clip;
		genericSource.loop = loop;
		genericSource.playOnAwake = playAwake;
		genericSource.volume = vol;
		genericSource.Play();
	}
	public void PlayPool(AudioClip[] clips) {
		Play(clips[Random.Range(0, clips.Length)], false, false, 1f);
	}
}
