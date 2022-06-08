using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_EventManager : MonoBehaviour
{
   public static Cam_EventManager current;

   private void Awake ()
   {
       current = this;
   }

   public event Action<string> onDamagedOnSector;

   public void DamagedOnSector(string whichSector)
   {
       if (onDamagedOnSector != null)
        {
            onDamagedOnSector(whichSector);
        }
   }

}
