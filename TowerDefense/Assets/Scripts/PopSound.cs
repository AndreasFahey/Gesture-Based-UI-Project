using UnityEngine;

public class PopSound : MonoBehaviour{
    // Variables
    public AudioSource source;
    public AudioClip pop;

    // When Bloon is shot, play pop audio sound
    public void PlayPop(){
        source.PlayOneShot(pop);
    }
}