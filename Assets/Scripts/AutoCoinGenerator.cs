using UnityEngine;

public class AutoCoinGenerator : MonoBehaviour
{
    [SerializeField] private ClickerController _clickerController;
    [SerializeField] private float _tickInterval = 1f;

    private float _timer = 0f;

    private void Awake()
    {
        if (_clickerController == null)
            _clickerController = FindFirstObjectByType<ClickerController>();
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _tickInterval)
        {
            _clickerController?.AddCoinsPerSecond();
            _timer = 0f;
        }
    }
}