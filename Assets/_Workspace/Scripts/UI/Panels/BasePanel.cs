using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public abstract class BasePanel : MonoBehaviour
{
    [SerializeField]
    protected List<BasePanel> _internalPanels;

    [SerializeField]
    protected List<BaseButton> _internalButtons;

    protected GameObject _gameObject;

    protected void Awake()
    {
        _gameObject = gameObject;
    }

    public T GetInternalButton<T>() where T : BaseButton
    {
        if (_internalButtons != null && _internalButtons.Count > 0)
        {
            return (T)_internalButtons.FirstOrDefault(s => s is T);
        }
        else
        {
            Debug.LogWarning("Internal Button is empty");

            return null;
        }
    }

    public T GetInternalPanel<T>() where T : BasePanel
    {
        if (_internalPanels != null && _internalPanels.Count > 0)
        {
            return (T)_internalPanels.FirstOrDefault(s => s is T);
        }
        else
        {
            Debug.LogWarning("Internal Panels is empty");

            return null;
        }
    }

    public void ShowInternalPanel<T>() where T : BasePanel
    {
        foreach (var panel in _internalPanels)
            panel.Hide();

        GetInternalPanel<T>().Show();
    }

    public void Hide()
    {
        if (_gameObject == null)
            _gameObject = gameObject;

        _gameObject.SetActive(false);
    }

    public void Show()
    {
        if (_gameObject == null)
            _gameObject = gameObject;

        _gameObject.SetActive(true);
    }
}
