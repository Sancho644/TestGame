using Scripts.WayPoints;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts.Components
{
    public class PlayerMovingComponent : MonoBehaviour
    {
        [SerializeField] private TargetPointSettings[] _targetPoints;
        [SerializeField] private Transform _player;
        [SerializeField] private SpawnComponent _weapon;

        private NavMeshAgent _agent;
        private Animator _animator;
        private ReloadLevelComponent _reload;

        private int _currentPoint = 0;
        private bool _startGame = false;
        private bool _isFinish = false;
        private bool _canFire = false;

        private static readonly int IsRunning = Animator.StringToHash("isRunning");

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponentInChildren<Animator>();
            _reload = GetComponent<ReloadLevelComponent>();

            _agent.enabled = false;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _startGame = true;
                _agent.enabled = true;
                _agent.destination = _targetPoints[_currentPoint].transform.position;
            }

            if (!_startGame) return;
            if (Input.GetMouseButtonDown(0) && _canFire) _weapon.Spawn();

            var distance = Vector3.Distance(_player.position, _targetPoints[_currentPoint].transform.position);

            if (distance > 5)
            {
                _agent.enabled = true;
                _animator.SetBool(IsRunning, true);
            }

            if (distance < 1.5f)
            {
                _agent.enabled = false;
                _animator.SetBool(IsRunning, false);
                _canFire = true;
                if (_isFinish)
                    _reload.Reload();
            }
        }

        public void SetNextPoint()
        {
            _currentPoint += 1;
            _agent.enabled = true;
            _agent.destination = _targetPoints[_currentPoint].transform.position;
            CheckForNextPoint();
        }

        private void CheckForNextPoint()
        {
            var isItNull = _targetPoints[_currentPoint].Point.Count;
            if (isItNull == 0)
            {
                _isFinish = true;
            }
        }
    }
}