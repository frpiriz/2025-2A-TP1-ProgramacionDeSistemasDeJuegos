using System.Collections;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor.Graphs;
using UnityEngine;

namespace Gameplay
{
    [RequireComponent(typeof(Rigidbody))]
    public class Character : MonoBehaviour
    {
        [SerializeField] private float acceleration = 10;
        [SerializeField] private float speed = 3;
        [SerializeField] private float jumpForce = 10;
        [SerializeField] private float Run = 6;


        private Vector3 _direction = Vector3.zero;
        private Rigidbody _rigidbody;

        private StateCharacter _currentState;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            TransitionToState(new StateIdle(this));
        }

        private void Update() => _currentState?.Update();
        private void FixedUpdate()
        {
            _currentState?.FixedUpdate();

            var scaledDirection = _direction * acceleration;
            if (_rigidbody.linearVelocity.IgnoreY().magnitude < speed)
                _rigidbody.AddForce(scaledDirection, ForceMode.Force);
        }

        public void SetDirection(Vector3 direction) => _direction = direction;

        public IEnumerator Jump()
        {
            yield return new WaitForFixedUpdate();
            _rigidbody.linearVelocity = new Vector3(_rigidbody.linearVelocity.x, 0, _rigidbody.linearVelocity.z);
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        public bool IsGrounded()
        {
            return Physics.Raycast(transform.position, Vector3.down, 1.1f); // Ajusta el valor si es necesario
        }

        public void TransitionToState(StateCharacter newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }
    }
}
