using System;

public class HealthSystem : MonoBehaviour
{
    public event EventHandler OnHealthChanged;

    private int health;
    private int healthMax;

    private int damaged = 0;

    public HealthSystem(int healthMax)
    {
        this.healthMax = healthMax;
        health = healthMax;
    }

    public int GetHealth() {
        return health;
    }

    public float GetHealthPercent()
    {
        return (float)health / healthMax;
    }

    //-----------------------For the Camera-----------------------------------
    public int getDamaged()
    {
        return damaged;
    }

    //------------------------------------------------------------------------

    public void Damage(int damageAmount)
    {
        health -= damageAmount;
        if (health < 0) health = 0;
        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);

        // to track the number of times an AI received damage on a certain sector 
        damaged++;
    }

    public void Heal(int healAmount)
    {
        health += healAmount;
        if (health > healthMax) health = healthMax;
        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    }
}
