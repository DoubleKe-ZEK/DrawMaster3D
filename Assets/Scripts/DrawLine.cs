using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{

    public GameObject linePrefab;
    public GameObject currentLine;

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider2d;
    public List<Vector2> pointsList;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            CreateLine();
        }

        if(Input.GetMouseButton(0))
        {
            Vector2 fingerPoints = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector2.Distance(fingerPoints, pointsList[pointsList.Count - 1]) > 0.1f)
            {
                UpdateLine(fingerPoints);
                if (!soundmanager.instance._As.isPlaying)
                {
                    soundmanager.instance.playmysound(soundmanager.instance.draw);
                    soundmanager.instance._As.loop = true;
                }               
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            GameManager.instance.ClearPointsCounter();
            soundmanager.instance._As.loop = false;
            soundmanager.instance._As.Stop();
            Destroy(currentLine.gameObject);
        }
    }

    void CreateLine()
    {
        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        edgeCollider2d = currentLine.GetComponent<EdgeCollider2D>();
        pointsList.Clear();
        pointsList.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        pointsList.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        lineRenderer.SetPosition(0, pointsList[0]);
        lineRenderer.SetPosition(1, pointsList[1]);
        edgeCollider2d.points = pointsList.ToArray();
    }


    void UpdateLine(Vector2 newPoints)
    {
        pointsList.Add(newPoints);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(pointsList.Count - 1, newPoints);
        edgeCollider2d.points = pointsList.ToArray();
    }
}








