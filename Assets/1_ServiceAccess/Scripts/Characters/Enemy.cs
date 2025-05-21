using System;
using UnityEngine;

namespace Excercise1
{
    public class Enemy : Character
    {
        [SerializeField] private float speed = 5;
        [SerializeField] private string playerId = "Player";
        private ICharacter _player;
        private string _logTag;
        private Transform target;



        private void Start()
        {
            var character = ServiceLocator.GetCharacter();
            if(character != null )
            {
                target= character.transform;

            }
        }

      
        private void Reset()
            => id = nameof(Enemy);

        private void Awake()
            => _logTag = $"{name}({nameof(Enemy).Colored("#555555")}):";

        protected override void OnEnable()
        {
            base.OnEnable();
            //TODO: Get the reference to the player.
            if (_player == null)
                Debug.LogError($"{_logTag} Player not found!");
        }

        private void Update()
        {

            if(target != null)
            {
                transform.position=Vector3.MoveTowards(transform.position, target.position,speed * Time.deltaTime);
            }
            if (_player == null)
                return;
            var direction = _player.transform.position - transform.position;
            transform.position += direction.normalized * (speed * Time.deltaTime);
        }
    }
}
