using UnityEngine;

public class DartGun : MonoBehaviour
{
    // Variables
    public GameObject dartPrefab;
    public Transform FirePoint;
    public float shotPower = 1000f;

    void Update ()
    {
        // Test if the player is pulling the trigger
        if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            Shoot();
        }
    }

    void Shoot(){
            // New Dart at FirePoint
            var dart = Instantiate(dartPrefab, FirePoint.position, FirePoint.transform.rotation);

            // Add force to the Dart rigidbody
            dart.GetComponent<Rigidbody>().AddForce(FirePoint.forward * Time.deltaTime * shotPower );

            // Spin Dart
            dart.transform.eulerAngles += new Vector3(0, 90, 90);

            // After X amount of seconds, Destroy The Dart
            Destroy(dart, 3f);
    }
}