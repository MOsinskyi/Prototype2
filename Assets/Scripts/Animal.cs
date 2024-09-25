using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour
{
    [SerializeField] private Slider hungerBar;
    [SerializeField] private int hunger = 3;
    
    private int _currentHunger;

    private void Start()
    {
        hungerBar.maxValue = hunger;
    }

    public void Feed()
    {
        if (_currentHunger >= hunger) return;
        _currentHunger++;
        hungerBar.value = _currentHunger;
        if (_currentHunger >= hunger)
            Destroy(gameObject);
    }
}
