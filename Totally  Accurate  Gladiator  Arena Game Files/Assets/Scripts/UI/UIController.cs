using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject UILeftSidePointsSection;
    public GameObject UITopMiddleSection;
    public GameObject UIRightSideSection;

    void Start()
    {
        UILeftSidePointsSection.SetActive(false);
        UITopMiddleSection.SetActive(false);
        UIRightSideSection.SetActive(false);
    }

    
    void Update()
    {
        
    }
}
