using System;
using Unity.VisualScripting;
using UnityEngine;

namespace PlayerScripts
{
    public class PlayerMovement : MonoBehaviour
    {
        private Collider2D _collider;
        private Rigidbody2D _rb;

        [SerializeField] private float _speed;
        private float _dirX;
        private float _dirY;

        private void Start()
        {

            _collider = GetComponent<Collider2D>();
            _rb = GetComponent<Rigidbody2D>();
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
            _rb.bodyType = RigidbodyType2D.Static;
            _collider.enabled = false;
        }

        public void enableControls()
        {
            _rb.bodyType = RigidbodyType2D.Dynamic;
            _collider.enabled = true;
        }
    }
}