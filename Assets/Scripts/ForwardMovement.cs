using UnityEngine;

public class ForwardMovement : MonoBehaviour
{
    [SerializeField] private float speed = 40f;
    
    private void Update()
    {
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
    }
}
