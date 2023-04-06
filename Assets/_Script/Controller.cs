using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePoint
{
    public Vector3 pos;
    public float time;
    public int id;
}

public class Controller : MonoBehaviour
{

    [SerializeField] LineRenderer line;
    List<LinePoint> linePoints = new List<LinePoint>();


    Vector2 curMousePos = Vector2.zero;
    Vector2 prevMousePos = Vector2.zero;

    bool mouseIsPressed = false;

    bool isBubbleClick = false;


    void Update()
    {
        if (mouseIsPressed)
        {
            LinePoint lineP = new LinePoint();
            lineP.pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lineP.pos = new Vector3(lineP.pos.x, lineP.pos.y, 0.0f);
            lineP.time = 0.1f;
            linePoints.Add(lineP);
            line.positionCount++;
            line.SetPosition(line.positionCount - 1, lineP.pos);

            for (int i = 0; i < linePoints.Count; i++)
            {
                linePoints[i].time -= Time.deltaTime;
                if (linePoints[i].time <= 0.0f)
                {
                    linePoints.Remove(linePoints[i]);
                    line.positionCount--;
                    Vector3[] lpointsPos = new Vector3[linePoints.Count];
                    for (int j = 0; j < linePoints.Count; j++)
                    {
                        lpointsPos[j] = linePoints[j].pos;
                    }
                    line.SetPositions(lpointsPos);
                    i--;
                }
            }
        }

        if (Input.GetMouseButton(0) && !isBubbleClick)
        {
            MousePressed();
        }
        if (Input.GetMouseButtonUp(0))
        {
            MouseReleased();
        }
    }

    //Mouse left click is pressed
    void MousePressed()
    {
        curMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D[] hits;
        if (mouseIsPressed) //If isn't first frame of pressed
        {
            hits = Physics2D.RaycastAll(curMousePos, prevMousePos - curMousePos, (prevMousePos - curMousePos).magnitude);
        }
        else //If is first frame of pressed
        {
            hits = Physics2D.RaycastAll(curMousePos, Vector2.zero);
        }

        prevMousePos = curMousePos;
        mouseIsPressed = true;
    }

    //Mouse left click is released
    void MouseReleased()
    {
        mouseIsPressed = false;
        linePoints.Clear();
        line.positionCount = 0;
    }
}
