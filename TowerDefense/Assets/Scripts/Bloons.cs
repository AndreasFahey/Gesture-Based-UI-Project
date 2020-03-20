using System;
using UnityEngine;

public class Bloons : MonoBehaviour{

    // Variables
    //public GameObject popSound;
    //public GameObject bloonCountDisplay;
    public GameObject[] wayPoints;
    //public GameObject[] wayPoints2;
    private int nextWayPointIndex = 0;
    public int health = 1;
    public float speed = 1;
   // private Material m_Material;
   /* int CompareObNames(GameObject x, GameObject y){
        return x.name.CompareTo(y.name);
    }

    private void Start(){
        var random = UnityEngine.Random.Range(0, 2);
        if(random == 0){
            wayPoints = GameObject.FindGameObjectsWithTag("Waypoints");
            Array.Sort(wayPoints, CompareObNames);
        }
        else{
            wayPoints = GameObject.FindGameObjectsWithTag("Waypoints2");
            Array.Sort(wayPoints, CompareObNames);
        }
        m_Material = GetComponent<Renderer>().material;

        // Get the sound component
        popSound = GameObject.FindGameObjectWithTag("PopSound");

        // Get bloonCountDisplay
        bloonCountDisplay = GameObject.FindGameObjectWithTag("BloonCountDisplay");
    } */

    // Call Update Once Per Frame
    void Update(){
        MoveBloon();
        //ColorBloons();
    }

  /*  private void ColorBloons(){
        if (health == 3){
            m_Material.color = ColorBloons.red;
        }
        else if (health == 2){
            m_Material.color = Color.blue;
        }
        else if (health == 1){
            m_Material.color = Color.green; 
        }
    }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Dart"))
        {
            health--;
            bloonCountDisplay.GetComponent<DisplayText>().BloonPopIncrease();
            popSound.GetComponent<PopSound>().PlayPop();
            if (health <= 0){
                Destroy(this.gameObject);
            }
        }
    }*/

    private void MoveBloon(){
        var lastWayPointIndex = wayPoints.Length -1;
        Vector3 lastWayPoint = wayPoints[lastWayPointIndex].transform.position + new Vector3(0,2,0);
        Vector3 nextWayPoint = wayPoints[nextWayPointIndex].transform.position + new Vector3(0,2,0);
        Vector3 direction = nextWayPoint - transform.position;

        // If Bloon is more than 0.10 meters from the last waypoint
        if (Vector3.Distance(transform.position, lastWayPoint) > 0.1f)
        {
            // Move to next waypoint
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }

        // If the Bloon reaches one waypoint increase index
        if (Vector3.Distance(transform.position, nextWayPoint) < 0.5f && nextWayPointIndex < lastWayPointIndex){
            nextWayPointIndex++;
        }

        // Bloon at the Finish
        if (nextWayPointIndex == lastWayPointIndex && Vector3.Distance(transform.position, lastWayPoint) < 0.5f){
            //bloonCountDisplay.GetComponent<DisplayText>().LivesDecrease();
            Destroy(this.gameObject);
        }
    }
}