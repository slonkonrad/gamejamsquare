using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SoundController : MonoBehaviour
{   
    [SerializeField]
    private List<AudioSource> backgrounds;

    [SerializeField]
    private List<AudioSource> soundEffects;

    [SerializeField]
    private AudioSource engineSoundPlayer1;

        [SerializeField]
    private AudioSource engineSoundPlayer2;

    [SerializeField]
    private List<AudioSource> screams;

    private List<AudioSource> allSounds;

    private  void Start()
    {
        allSounds = new List<AudioSource>();
        allSounds.AddRange(backgrounds);
        allSounds.AddRange(soundEffects);
    }

    public void updateCarEngineSound(float velocityMagnitudePlayer1, float velocityMagnitudePlayer2)
    {
        float value1 = Mathf.Log(velocityMagnitudePlayer1, 50);
        float value2 = Mathf.Log(velocityMagnitudePlayer2, 50);
        Debug.Log("Magnitude 1 "+velocityMagnitudePlayer1);
        Debug.Log("Magnitude 2 "+velocityMagnitudePlayer2);
            engineSoundPlayer1.pitch = Mathf.Clamp(value1, 0.4f, 1f);
            engineSoundPlayer1.volume = Mathf.Clamp(value1, 0.5f, 1f);
            engineSoundPlayer1.spatialBlend = 0.5f - Mathf.Clamp(value1, 0, 0.5f);
            engineSoundPlayer2.pitch = Mathf.Clamp(value2, 0.4f, 1f);

        if(!engineSoundPlayer1.isPlaying)
        {
            engineSoundPlayer1.Play();
            engineSoundPlayer1.loop = true;
        }
               
        if(!engineSoundPlayer2.isPlaying)
        {
            engineSoundPlayer2.Play();
            engineSoundPlayer2.loop = true;
        }
        
    }

    public void playScream()
    {
        AudioSource chosenSound = screams[Random.Range(0, screams.Count)];
        if(chosenSound)
            chosenSound.Play();
    }
    public void playSound(string name)
    {
        AudioSource chosenSound = getSoundByName(name);
        if(chosenSound)
            chosenSound.Play();
    }

    public void stopSound(string name)
    {
        AudioSource chosenSound = getSoundByName(name);
        if(chosenSound)
            chosenSound.Stop();
    }

    private AudioSource getSoundByName(string name) 
    {
        return allSounds.FirstOrDefault(x => x.gameObject.name == name);
    }    
}
