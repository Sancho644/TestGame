using Scripts.ObjectPool;
using UnityEngine;

namespace Scripts.Particles
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private Transform _shootPosition;

        public void CreateBullet(Vector3 direction)
        {
            var projectile = Pool.Instance.Get(_prefab, _shootPosition.position);
            ProjectilePosition(projectile);
            projectile.GetComponent<Projectile>().Project(direction);
        }

        private void ProjectilePosition(GameObject projectile)
        {
            projectile.transform.position = _shootPosition.position;
        }
    }
}