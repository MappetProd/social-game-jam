using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using NavMeshPlus;
using UnityEngine.AI;

namespace PlayerScripts
{
    public class Lira : MonoBehaviour
    {
        [SerializeField] private Light2D _enemyLight;
        [SerializeField] private GameObject _lightPrefab;
        [SerializeField] private float _liraLightSpeed;
        [SerializeField] private Transform _liraLightDestination;

        private GameObject _currPathfindingLight;

        private AudioManager _audioManager;

        private void Awake()
        {
            _audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        }

        public void ActivatePathFinding()
        {
            _audioManager.PlaySFX(_audioManager.liraPath);
            _currPathfindingLight = Instantiate(_lightPrefab);
            _currPathfindingLight.transform.position = transform.position;

            NavMeshAgent agent = _currPathfindingLight.AddComponent<NavMeshAgent>();
            agent.updateRotation = false;
            agent.updateUpAxis = false;
            agent.speed = _liraLightSpeed;
            agent.SetDestination(_liraLightDestination.position);
        }

        private void Update()
        {
            if (_currPathfindingLight != null)
            {
                if (Vector2.Distance(_currPathfindingLight.transform.position, _liraLightDestination.position) < 1f)
                {
                    Destroy(_currPathfindingLight);
                    _currPathfindingLight = null;
                }
            }
        }

        public void Play()
        {
            StartCoroutine(EnemyLight());
        }

        private IEnumerator EnemyLight()
        {
            _audioManager.PlaySFX(_audioManager.liraReveal);
            _enemyLight.intensity = 1f;
            yield return new WaitForSeconds(3f);
            _enemyLight.intensity = 0f;
        }
    }
}