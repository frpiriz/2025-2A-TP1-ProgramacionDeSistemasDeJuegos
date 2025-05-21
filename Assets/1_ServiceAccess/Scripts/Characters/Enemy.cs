using UnityEngine;

namespace Excercise1
{
    public class Enemy : Character
    {
        [SerializeField] private float speed = 5;
        private Transform target;
        private string _logTag;

        private void Reset()
            => id = nameof(Enemy);

        private void Awake()
            => _logTag = $"{name}({nameof(Enemy).Colored("#555555")}):";

        private void OnEnable()
        {
            var character = ServiceLocator.GetCharacter();
            if (character != null)
            {
                target = character.transform;
            }
            else
            {
                Debug.LogError($"{_logTag} Player not found!");
            }
        }

        private void Update()
        {
            if (target != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
        }
    }
}
