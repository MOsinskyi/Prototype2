using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject mobileControls;
    
    [Header("PROJECTILE")]
    [SerializeField] private GameObject foodPrefab;
    
    [Header("PROPERTIES")]
    [SerializeField] private float speed = 10f;
    
    [Header("RESTRICTIONS")]
    [SerializeField] private float clampX = 10f;
    [SerializeField] private float clampZ = 15f;

    private Player _main;

    private FixedJoystick _joystick;
    
    private float _horizontalInput;
    private float _verticalInput;

    private void Start()
    {
        _joystick = FindObjectOfType<FixedJoystick>();
        _main = GetComponent<Player>();
    }

    private void Update()
    {
        if (_main.GameOverStatus) return;
        
        var clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -clampX, clampX);
        clampedPosition.z = Mathf.Clamp(clampedPosition.z, -clampZ, clampZ);
        transform.position = clampedPosition;
  
        if (Application.platform == RuntimePlatform.Android)
        {
            mobileControls.SetActive(true);
            transform.Translate(Vector3.forward * (_joystick.Vertical * Time.deltaTime * speed));
            transform.Translate(Vector3.right * (_joystick.Horizontal * Time.deltaTime * speed));
        }
        else
        {
            mobileControls.SetActive(false);
            _horizontalInput = Input.GetAxis("Horizontal");
            _verticalInput = Input.GetAxis("Vertical");
        
            transform.Translate(Vector3.forward * (_verticalInput * Time.deltaTime * speed));
            transform.Translate(Vector3.right * (_horizontalInput * Time.deltaTime * speed));
        
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Fire();
            }
        }

    }

    public void Fire()
    {
        Instantiate(foodPrefab, transform.position, foodPrefab.transform.rotation);
    }
    public float GetClampX() => clampX;
    
    public float GetClampZ() => clampZ;
}
