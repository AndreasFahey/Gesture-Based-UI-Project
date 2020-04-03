using UnityEngine;

public class FireSound : MonoBehaviour{
    // Variables
    public AudioSource source;
    public AudioClip fire;

    // When Dart Gun is Fired plays PewGunSound
    public void PlayFire(){
        source.PlayOneShot(fire);
    }
}