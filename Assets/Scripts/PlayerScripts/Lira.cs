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

        private GameObject _currentPathfindingLight;
        private AudioManager _audioManager;
        private bool _isPathFindingAvailable = true;
        private bool _isEnemyLightAvailable = true;

        private void Awake()
        {
            _audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        }

        public void ActivatePathFinding()
        {
            if (!_isPathFindingAvailable) return;
            StartCoroutine(PathFindingCooldown());
            _audioManager.PlaySFX(_audioManager.liraPath);
            _currentPathfindingLight = Instantiate(_lightPrefab);
            _currentPathfindingLight.transform.position = transform.position;

            NavMeshAgent agent = _currentPathfindingLight.AddComponent<NavMeshAgent>();
            agent.updateRotation = false;
            agent.updateUpAxis = false;
            agent.speed = _liraLightSpeed;
            agent.SetDestination(_liraLightDestination.position);
        }

        private void Update()
        {
            if (_currentPathfindingLight != null)
            {
                if (Vector2.Distance(_currentPathfindingLight.transform.position, _liraLightDestination.position) < 1f)
                {
                    Destroy(_currentPathfindingLight);
                    _currentPathfindingLight = null;
                }
            }
        }

        public void Play()
        {
            StartCoroutine(EnemyLight());
        }

        private IEnumerator EnemyLight()
        {
            _isEnemyLightAvailable = false;
            _audioManager.PlaySFX(_audioManager.liraReveal);
            _enemyLight.intensity = 1f;
            yield return new WaitForSeconds(3f);
            _enemyLight.intensity = 0f;
            _isEnemyLightAvailable = true;
        }

        private IEnumerator PathFindingCooldown()
        {
            _isPathFindingAvailable = false;
            print(_isPathFindingAvailable);
            yield return new WaitForSeconds(2f);
            _isPathFindingAvailable = true;
        }
    }
}