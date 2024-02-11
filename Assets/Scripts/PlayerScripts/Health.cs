using PlayerScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private UIManager _uiManager;

    [SerializeField]
    private float _maxHealth = 100;

    [SerializeField]
    private Transform startLevelPosition;

    private float _health = 100;
    public bool isDead = false;

    private PlayerMovement _movement;
    

    private void Start()
    {
        _movement = GetComponent<PlayerMovement>();
    }

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
        _movement.disableControls();
        _uiManager.gameOverFrame.SetActive(true);
        // todo animation of death

        isDead = true;
    }

    public void Respawn()
    {
        transform.position = startLevelPosition.position;
        _movement.enableControls();
        _uiManager.gameOverFrame.SetActive(false);

        _health = _maxHealth;
        isDead = false;
    }
}
