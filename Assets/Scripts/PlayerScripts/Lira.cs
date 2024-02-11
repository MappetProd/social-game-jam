using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace PlayerScripts
{
    public class Lira : MonoBehaviour
    {
        [SerializeField] private Light2D _enemyLight;
    
        public void Play()
        {
            StartCoroutine(EnemyLight());
        }

        private IEnumerator EnemyLight()
        {
            _enemyLight.intensity = 1f;
            yield return new WaitForSeconds(3f);
            _enemyLight.intensity = 0f;
        }
    }
}