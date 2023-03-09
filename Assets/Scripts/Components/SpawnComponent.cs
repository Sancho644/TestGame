using Scripts.Particles;
using UnityEngine;

namespace Scripts.Components
{
    public class SpawnComponent : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private BulletSpawner _prefab;

        [ContextMenu("Spawn")]
        public void Spawn()
        {
            SpawnInstance();
        }

        private void SpawnInstance()
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                _prefab.CreateBullet(new Vector3(hit.point.x, hit.point.y + 0.1f, hit.point.z));
            }
        }
    }
}