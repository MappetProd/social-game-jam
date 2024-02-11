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
    }
}