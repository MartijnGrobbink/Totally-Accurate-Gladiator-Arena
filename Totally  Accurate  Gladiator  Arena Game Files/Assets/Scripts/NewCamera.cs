using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NewCamera : MonoBehaviour
{
    public GameObject camera01;

    public Sector sector1;
    public Sector sector2;
    public Sector sector3;
    public Sector sector4;
    public Sector currentSector;
    
    public GameObject cubo;

    private StatueManager statues;

    Dictionary<Sector, int> SectorPoints = new Dictionary<Sector, int>();

    public Transform currSecCam;
    public Transform Sec1Cam;
    public Transform Sec2Cam;
    public Transform Sec3Cam;
    public Transform Sec4Cam;
    public Transform targetCam;
    public float t;
    public float speed;
    public bool changedSec = false;

    //--------------------------------------------------------------------------
    void Start()
    {
        //every2 seconds remove 1 points
        //check higer point sector 10 sec
        SectorPoints[sector1] = 0;
        SectorPoints[sector2] = 0;
        SectorPoints[sector3] = 0;
        SectorPoints[sector4] = 0;

        InvokeRepeating(nameof(ChangeSector), 1f, 3f);
    }

    void Update()
    {
        UpdatePoints();

        if (changedSec)
        {
            Vector3 a = currSecCam.transform.position;
            Vector3 b = targetCam.position;
            //Vector3 c = Sec2Cam.position;

            transform.position = Vector3.MoveTowards(a, Vector3.Lerp(a, b, t), speed);

            Debug.Log("Before " + currSecCam.position + " " + targetCam.position + " " + transform.position);

            currSecCam = targetCam;

            Debug.Log("After " + currSecCam.position + " " + targetCam.position + " " + transform.position);
            //Vector3 a = transform.position;
            //Vector3 b = Sec2Cam.position;
            //transform.position = Vector3.MoveTowards(a, Vector3.Lerp(a, b, t), speed);
            changedSec = false;
        }


    }

    //--------------------------------------------------------------------------
    public void UpdatePoints()
    {
        if(sector1.triggered)
        {
            sector1.AddPoints(1);
        }
        if (sector2.triggered)
        {
            sector2.AddPoints(1);
        }
        if (sector3.triggered)
        {
            sector3.AddPoints(1);
        }
        if (sector4.triggered)
        {
            sector4.AddPoints(1);
        }

        //if (statues.getBeingContested())
        //{

        //}

        //if statue inside zone and being contested give sector 1 points + 1 point per second while being contested
        //if AI took a hit/damage give sector 1 point
    }

   
    //--------------------------------------------------------------------------
    public void moveCamera(Transform cam)
    {
        Vector3 a = currSecCam.transform.position;
        Vector3 b = cam.position;
        //Vector3 c = Sec2Cam.position;
        transform.position = Vector3.MoveTowards(a, Vector3.Lerp(a, b, t), speed);

        Debug.Log("Before " + currSecCam.position + " " + cam.position + " " + transform.position);

        currSecCam = cam;

        Debug.Log("After " + currSecCam.position + " " + cam.position + " " + transform.position);

    }

    //--------------------------------------------------------------------------
    public void ChangeSector()
    {
        var keyOfMaxValue = SectorPoints.Aggregate((x, y) => (x.Value > y.Value) ? x : y).Key; 

        if (keyOfMaxValue.transform.position != currentSector.transform.position)
        {

            if (keyOfMaxValue.transform.position == sector1.transform.position)
            {
                //moveCamera(Sec1Cam);
                targetCam = Sec1Cam;

                
            }
            else if (keyOfMaxValue.transform.position == sector2.transform.position)
            {
                //moveCamera(Sec2Cam);
                targetCam = Sec2Cam;
            }
            else if (keyOfMaxValue.transform.position == sector3.transform.position)
            {
                //moveCamera(Sec3Cam);
                targetCam = Sec3Cam;
            }
            else if (keyOfMaxValue.transform.position == sector4.transform.position)
            {
                //moveCamera(Sec4Cam);
                targetCam = Sec4Cam;
            }

            currentSector = keyOfMaxValue;
            changedSec = true;

            Debug.Log("current " + currentSector.name + " " + currentSector.transform.position);
            Debug.Log("Max " + keyOfMaxValue.name + " " + keyOfMaxValue.transform.position + " " + SectorPoints[keyOfMaxValue]);

        }

        //check if there is a sector with higher points than the current one

        //if higher and only higher change current sector to that one

        //moveCamera()
    }

    private Sector CheckHigherPoints()
    {
        int[] points = new int[] { sector1.GetPoints(), sector2.GetPoints(), sector3.GetPoints(), sector4.GetPoints() };
        int max = points.Max();
        if (max == 0)
            return sector1;
        if (max == 1)
            return sector2;
        if (max == 2)
            return sector3;
        if (max == 3)
            return sector4;

    }


}