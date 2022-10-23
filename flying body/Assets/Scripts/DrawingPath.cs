using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody),typeof(LineRenderer))]
public class DrawingPath : MonoBehaviour
{
    Rigidbody rigidbody;
    LineRenderer lineRenderer;
    public float TimeForNextRay,moveSpeed;
    public List<GameObject> WayPoints;
    float timer = 0;
    int currentWayPoint = 0;
    int wayIndex;
    bool move,onTouch;
    bool touchStartedonPlayer;
    Touch touch;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody    = GetComponent<Rigidbody>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        wayIndex = 1;
        move = false;
        touchStartedonPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && !onTouch){
            lineRenderer.enabled = true;
            touchStartedonPlayer = true;
            lineRenderer.positionCount = 1;
            lineRenderer.SetPosition(0, transform.position);
            onTouch = true;
        }
        else if(Input.touchCount <= 0 && onTouch){
            onTouch = false;
            move = true;
            wayIndex = 0;
        }

        timer += Time.deltaTime;
        if(Input.touchCount > 0 && timer > TimeForNextRay && touchStartedonPlayer){
            touch = Input.GetTouch(0);
            Vector3 WorldfromMousepos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 100));
            Vector3 direction = WorldfromMousepos - Camera.main.transform.position;
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.transform.position,direction,out hit, 100f))
            {
                Debug.DrawLine(Camera.main.transform.position, direction, Color.red, 1f);
                GameObject newWayPoint = new GameObject("WayPoint");
                newWayPoint.transform.position = new Vector3(hit.point.x,hit.point.y,transform.position.z);
                WayPoints.Add(newWayPoint);
                lineRenderer.positionCount = wayIndex + 1;
                lineRenderer.SetPosition(wayIndex, newWayPoint.transform.position);
                timer = 0;
                wayIndex++;
            }
        }

        movementOperations();
    }

    void movementOperations(){
        if(move){
            transform.position = Vector3.MoveTowards(transform.position,WayPoints[wayIndex].transform.position,moveSpeed*Time.deltaTime);
            if(transform.position == WayPoints[wayIndex].transform.position){
                wayIndex++;
            }
        }
    }
}
