using Scripts.ObjectPool;
using System.Collections;
using UnityEngine;

namespace Scripts.Particles
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _lifeTime = 3f;

        private Vector3 _direction;
        private Transform _transform;
        private PoolItem _poolItem;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _poolItem = GetComponent<PoolItem>();
        }

        private void OnEnable()
        {
            _direction = _transform.position;
            StartCoroutine(BulletLifeTime());
        }

        private void FixedUpdate()
        {
            float maxDistance = _speed * Time.deltaTime;
            _transform.position = Vector3.MoveTowards(_transform.position, _direction, maxDistance);
        }

        private IEnumerator BulletLifeTime()
        {
            yield return new WaitForSeconds(_lifeTime);
            BulletDeactivate();
        }

        private void BulletDeactivate()
        {
            _poolItem.Relese();
        }

        public void SetDirection(Vector3 direction)
        {
            _direction = direction;
        }

        private void OnDisable()
        {
            StopCoroutine(BulletLifeTime());
        }
    }
}