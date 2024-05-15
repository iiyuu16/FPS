using UnityEngine;

public class Target : MonoBehaviour
{
    public float health;
   
    public void TakeDamage(float amt)
    {
        health -= amt;
        Debug.Log("dmg recieved:" + health);
        if (health <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
