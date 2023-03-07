using UnityEngine;
using UnityEngine.Events;

namespace Scripts.Components
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private UnityEvent _onDie;

        public void ModifyHealth(int healthDelta)
        {
            _health += healthDelta;

            if (_health <= 0)
            {
                _onDie?.Invoke();
            }
        }
    }
}