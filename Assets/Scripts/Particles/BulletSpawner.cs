using Scripts.ObjectPool;
using UnityEngine;

namespace Scripts.Particles
{
    public class BulletSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private Transform _shootPosition;

        public void CreateBullet(Vector3 direction)
        {
            var projectile = Pool.Instance.Get(_prefab, _shootPosition.position);
            projectile.GetComponent<Projectile>().SetDirection(direction);
        }
    }
}