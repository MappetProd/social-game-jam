using System;
using Unity.VisualScripting;
using UnityEngine;

namespace PlayerScripts
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private float _dirX;
        private float _dirY;
        private Collider2D _collider;
        private Rigidbody2D _rb;
        private Lira _lira;
        
        private void Start()
        {
            _collider = GetComponent<Collider2D>();
            _rb = GetComponent<Rigidbody2D>();
            _lira = GetComponentInChildren<Lira>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
                _lira.Play();
        }
        
        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            _dirX = Input.GetAxis("Horizontal");
            _dirY = Input.GetAxis("Vertical");
            transform.Translate((Vector3.right * _dirX + Vector3.up * _dirY) * (_speed*Time.deltaTime));
        }

        public void disableControls()
        {
            gameObject.layer = 0;
            this.enabled = false;
            _rb.velocity = Vector3.zero;
        }

        public void enableControls()
        {
            gameObject.layer = 6;
            this.enabled = true;
        }
    }
}