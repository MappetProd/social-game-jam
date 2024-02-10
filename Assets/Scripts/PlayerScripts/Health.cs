using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float _health = 100;
    public bool isDead = false;

    public void TakeHit(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Death();
            // todo gameover gui
        }
    }

    private void Death()
    {
        Destroy(gameObject);
        // todo turn off controls
        // todo animation of death
        isDead = true;
    }

    private void Respawn()
    {
        _health = 100;
        isDead = false;
    }
}
