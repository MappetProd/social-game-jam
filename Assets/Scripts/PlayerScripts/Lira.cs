using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace PlayerScripts
{
    public class Lira : MonoBehaviour
    {
        [SerializeField] private Light2D _enemyLight;
        [SerializeField] private float _lightIntensity;
        [SerializeField] private float _enemyLightCooldown;
        private bool _isAbilityReady = true;
        
        public void Play()
        {
            if (!_isAbilityReady) return;
            
            Invoke(nameof(ReloadAbility), _enemyLightCooldown);
            StartCoroutine(EnemyLight());
            _isAbilityReady = false;
        }

        private IEnumerator EnemyLight()
        {
            _enemyLight.intensity = _lightIntensity;
            yield return new WaitForSeconds(3f);
            _enemyLight.intensity = 0f;
        }

        private void ReloadAbility()
        {
            _isAbilityReady = true;
        }
    }
} 