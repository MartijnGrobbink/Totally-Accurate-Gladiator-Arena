using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCamera : MonoBehaviour
{
    //camera and sectors
    public GameObject camera01;

    public GameObject sector1;
    public GameObject sector2;
    public GameObject sector3;
    public GameObject sector4;

    Dictionary<GameObject, int> SectorPoints = new Dictionary<GameObject, int>();

    public Transform Sec1Cam;
    public Transform Sec2Cam;
    public Transform Sec3Cam;
    public Transform Sec4Cam;
    public float t;
    public float speed;

    //sector array
    private GameObject[] sectors;

    //lista ou array com as varias posicoes de camera para os varios sectors

    // Start is called before the first frame update
    void Start()
    {
        //every2 seconds remove 1 points
        

    }

    // Update is called once per frame
    void Update()
    {
        //every 10 secs check change sector
        
        

    }

    public void AddPoints()
    {
        //if statue inside zone and being contested give sector 1 points + 1 point per second while being contested
        //if AI took a hit/damage give sector 1 point
    }

    public void moveCamera(Vector3 position)
    {
        Vector3 a = transform.position;
        Vector3 b = Sec1Cam.position;
        Vector3 c = Sec2Cam.position;
        transform.position = Vector3.MoveTowards(a, Vector3.Lerp(a, b, t), speed);


    }

    public void ChangeSector()
    {
        //check if there is a sector with higher points than the current one
        //if higher and only higher change current sector to that one
        //moveCamera to that sector coords
    }


}
