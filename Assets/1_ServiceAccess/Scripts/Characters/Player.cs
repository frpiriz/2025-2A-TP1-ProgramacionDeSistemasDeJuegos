using UnityEngine;

namespace Excercise1
{
    public class Player : Character
    {
        [SerializeField] private float frequency = 1;
        [SerializeField] private float amplitude = 1;

        private void Reset()
            => id = nameof(Player);

        private void Update()
        {
            transform.position = new Vector3(Mathf.Cos(Time.time * frequency) * amplitude,
                                             Mathf.Sin(Time.time * frequency) * amplitude,
                                             transform.position.z);
        }

        private void Awake()
        {
            ServiceLocator.RegistrerCharacter(this);

        }
    }
}
