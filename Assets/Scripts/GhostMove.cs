using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostMove : MonoBehaviour
{
    public Transform waypointParent;
    public float speed = 0.3f;
    private Transform[] waypoints;
    private int currentPoint = 0;

    private void Start()
    {
        int childCount = waypointParent.childCount;
        waypoints = new Transform[childCount];
        for (int i = 0; i < childCount; i++)
        {
            waypoints[i] = waypointParent.GetChild(i);
        }
    }

    bool Approximately(Vector2 a, Vector2 b)
    {
        return Mathf.Approximately(a.x, b.x) &&
               Mathf.Approximately(a.y, b.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Waypoint not reached yet? Then move closer
        Vector3 ghostPos = transform.position;
        Vector3 waypointPos = waypoints[currentPoint].position;

        if (!Approximately(ghostPos, waypointPos))
        {
            Vector2 position = Vector2.MoveTowards(ghostPos, waypointPos, speed);
            GetComponent<Rigidbody2D>().MovePosition(position);
        }

        // Waypoint has been reached, select the next one
        else currentPoint = (currentPoint + 1) % waypoints.Length;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name == "pacman")
        {
            Pacdot.pacdotsCollected = 0;
            Destroy(col.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
