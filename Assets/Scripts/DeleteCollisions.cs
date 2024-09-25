using UnityEngine;

public class DeleteCollisions : MonoBehaviour
{
    private Player _player;
    
    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _player.IncreaseScore();
        if (other.TryGetComponent(out Animal animal))
            animal.Feed();
        Destroy(gameObject);
    }
}
