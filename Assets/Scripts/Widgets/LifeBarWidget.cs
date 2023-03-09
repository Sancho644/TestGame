using Scripts.Components;
using UnityEngine;

namespace Scripts.Widgets
{
    public class LifeBarWidget : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private RectTransform _lifeBarScale;
        [SerializeField] private ProgressBarWidget _lifeBar;
        [SerializeField] private HealthComponent _hp;

        private int _maxHp;

        private void Start()
        {
            if (_hp == null)
            {
                _hp = GetComponentInParent<HealthComponent>();
            }

            _maxHp = _hp.Health;

            _hp._onDie.AddListener(OnDie);
            _hp._onChange.AddListener(OnHpChanged);
        }

        private void Update()
        {
            var scale = _target.lossyScale;

            if (scale.x == -1) _lifeBarScale.localScale = new Vector3(-1f, 1f, 1f);
            else _lifeBarScale.localScale = new Vector3(1f, 1f, 1f);
        }

        private void OnDie()
        {
            Destroy(gameObject);
        }

        private void OnHpChanged(int hp)
        {
            var progress = (float)hp / _maxHp;
            _lifeBar.SetProgress(progress);
        }

        private void OnDestroy()
        {
            _hp._onDie.RemoveListener(OnDie);
            _hp._onChange.RemoveListener(OnHpChanged);
        }
    }
}