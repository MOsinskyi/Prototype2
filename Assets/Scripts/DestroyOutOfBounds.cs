using System;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private const float TopBound = 30f;
    private const float LowerBound = -10f;
    private const float SideBound = 25f;
 
    private Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (transform.position.z < LowerBound)
        {
            _player.TakeDamage();
            Destroy(gameObject);
        }

        if (transform.position.z > TopBound)
            Destroy(gameObject);
        
        if (transform.position.x is > SideBound or < -SideBound)
            Destroy(gameObject);
    }
}
