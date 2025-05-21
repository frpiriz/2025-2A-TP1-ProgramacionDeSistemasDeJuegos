using UnityEngine;

namespace Excercise1
{
    public static class ServiceLocator
    {
        private static Player player;
        private static ICharacter character;

        public static void RegistrerCharacter(ICharacter characterInstance)
        {
            character = characterInstance;


        }

    public static ICharacter GetCharacter()
        {
            if(character == null)
            {
                Debug.Log("No se ha registrado el jugador en el Service Locator.");
            }
            return character;
        }
        
    }
}
