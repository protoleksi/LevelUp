using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterClickHandler : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private ClickerController _clickerController;

    private void Awake()
    {
        if (_clickerController == null)
            _clickerController = FindFirstObjectByType<ClickerController>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_clickerController != null)
            _clickerController.AddCoinsFromClick();
    }
}