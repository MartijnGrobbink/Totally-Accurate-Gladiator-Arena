using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    private HealthSystem healthSystem;
    public void setup(HealthSystem healthSystem)
    {
        this.healthSystem = healthSystem;

        healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;
    }
    private void HealthSystem_OnHealthChanged( object sender, System.EventArgs e)
    {
        transform.Find("bar").localScale = new Vector3(healthSystem.GetHealthPercent(), 1);
    }

    private void update()
    {
        //transform.find("bar").localScale = new Vector3(healthSystem.GetHealthPercent(), 1);
    }
}
