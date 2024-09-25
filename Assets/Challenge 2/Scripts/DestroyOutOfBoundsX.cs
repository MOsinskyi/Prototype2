using UnityEngine;

namespace Challenge_2.Scripts
{
    public class DestroyOutOfBoundsX : MonoBehaviour
    {
        private const float LeftLimit = -30;
        private const float BottomLimit = -5;
        
        private void Update()
        {
            if (transform.position.x < LeftLimit)
            {
                Destroy(gameObject);
            } 
            else if (transform.position.y < BottomLimit)
            {
                Debug.Log("Game Over!");
                Destroy(gameObject);
            }

        }
    }
}
