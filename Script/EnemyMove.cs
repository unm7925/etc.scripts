using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMove : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>(); // 적군 경로
    [SerializeField] [Range(0f, 5f)] float speed = 1f;

    Enemy enemy;
    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        
        StartCoroutine(FollowPath());
    }

     void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    void FindPath()
    {
        path.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Follow");

        foreach(Transform child in parent.transform)
        {
            WayPoint waypoint = child.GetComponent<WayPoint>();
            if(waypoint != null)
            {
                path.Add(waypoint);
            }
            
        }    
    }
    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }
    void finishPath()
    {
        enemy.StealMoney();
        gameObject.SetActive(false);
    }
    IEnumerator FollowPath()
    {
        foreach(WayPoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        finishPath();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
