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

        private void Awake()
        {
            _transform = GetComponent<Transform>();
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

        private void OnTriggerEnter(Collider other)
        {
            BulletDeactivate();
        }

        private void OnCollisionEnter(Collision collision)
        {
            BulletDeactivate();
        }

        private void BulletDeactivate()
        {
            gameObject.SetActive(false);
        }

        public void Project(Vector3 direction)
        {
            _direction = direction;
        }

        private void OnDisable()
        {
            StopCoroutine(BulletLifeTime());
        }
    }
}