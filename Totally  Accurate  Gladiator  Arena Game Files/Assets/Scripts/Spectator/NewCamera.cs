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
    private List<Sector> sectorList = new List<Sector>();

    public Sector currentSector;
    
    public float t;
    public float speed;

    //--------------------------------------------------------------------------------------------------------------
    void Start()
    {
        sectorList.Add(sector1);
        sectorList.Add(sector2);
        sectorList.Add(sector3);
        sectorList.Add(sector4);

        //
        InvokeRepeating(nameof(IncreasePoints), 0f, 0.5f);

        //Start the function at xf seconds and repeat it every yf seconds (sector update)
        InvokeRepeating(nameof(ChangeSector), 10f, 5f);

        //every 2 seconds remove 1 point in each sector
        InvokeRepeating(nameof(DecreasePoints), 2f, 2f);

        //Cam_EventManager.current.onDamagedOnSector += sectorDamaged;
    }

    void Update()
    {
        // Lerp from the current position of the camera to the sector which has the highest number of points
        if (currentSector && currentSector.getSectorCamera())
        {
            Vector3 a = transform.position;
            Vector3 b = currentSector.getSectorCamera().transform.position;   
            // * Time.deltaTime keeps the speed steady across all computers 
            transform.position = Vector3.MoveTowards(a, Vector3.Lerp(a, b, t), speed * Time.deltaTime);
        }
    }

    public void IncreasePoints()
    {
        //Debug.Log("\nSETOR1: [" + sector1.GetPoints() + "] SETOR2: [" + sector2.GetPoints()+ "] SETOR3: [" + sector3.GetPoints()+ "] SETOR4: " + sector4.GetPoints());

        if (sector1.triggered) {
            sector1.AddPoints(1);

            // if a statue is on this sector, add 2 points whilst it's inside the sector
            if (sector1.getColliderTag() == "Statue") {
                sector1.AddPoints(2);
            }

            // if an AI received damage while sector1 is triggered, add 1 point

            //if(sector1.getColliderTag() != "Statue" )
            //    sector1.AddPoints(1);
        }
        
        if (sector2.triggered) {
            sector2.AddPoints(1);

            // if a statue is on this sector, add 2 points whilst it's inside the sector
            if (sector2.getColliderTag() == "Statue") {
                sector2.AddPoints(2);
            }
        }

        if (sector3.triggered) {
            sector3.AddPoints(1);

            // if a statue is on this sector, add 2 points whilst it's inside the sector
            if (sector3.getColliderTag() == "Statue") {
                sector3.AddPoints(2);
            }
        }
        
        if (sector4.triggered) {
            sector4.AddPoints(1);

            // if a statue is on this sector, add 2 points whilst it's inside the sector
            if (sector4.getColliderTag() == "Statue") {
                sector4.AddPoints(2);
            }
        }

    }
    
    public void DecreasePoints() {
    // called every 2 seconds to remove 1 point of each sector
        for (int i = 0; i < 4; i++) {
            sectorList[i].AddPoints(-1);
        }
    }
   
    // --------------------------------------------------------------------------
    //check if there is a sector with higher points than the current one
    //if higher and only higher change current sector to that one
    public void ChangeSector()
    {
        var tempSector = CheckHigherPoints();
        if (tempSector != currentSector) currentSector = tempSector;
    }

    // Go through all 4 sectors and check which one has the highest number of points
    private Sector CheckHigherPoints()
    {
        var max = sector1.GetPoints();
        var index = 0;

        for(int i = 0; i < sectorList.Count; i++){
            if (sectorList[i].GetPoints() > max) {
                max = sectorList[i].GetPoints();
                index = i;
            }
        }

        return sectorList[index];
    }

}