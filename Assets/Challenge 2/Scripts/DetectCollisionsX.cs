using UnityEngine;

namespace Challenge_2.Scripts
{
    public class DetectCollisionsX : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
        }
    }
}
