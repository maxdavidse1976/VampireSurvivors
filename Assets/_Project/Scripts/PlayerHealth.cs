using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;
    
    [SerializeField] float _currentHealth;
    [SerializeField] float _maxHealth;

    [SerializeField] Slider _healthSlider;
    void Awake()
    {
        Instance = this;
        _currentHealth = _maxHealth;
        _healthSlider.maxValue = _maxHealth;
        _healthSlider.value = _currentHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }

        _healthSlider.value = _currentHealth;
    }
}
