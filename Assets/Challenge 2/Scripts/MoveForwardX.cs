using UnityEngine;

namespace Challenge_2.Scripts
{
    public class MoveForwardX : MonoBehaviour
    {
        public float speed;
        
        private void Update()
        {
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        }
    }
}
