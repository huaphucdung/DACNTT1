using System;
using System.Collections.Generic;
using UnityEngine;

public class UIBasic : MonoBehaviour, IBaseUI, IUIBaseTransform
{
    protected Transform _transform;
    protected RectTransform _rectTransform;
    public Transform Transform { get
        {
            if (_transform == null)
            {
                _transform = transform;
            }
            return _transform;
        }
    }

    public RectTransform RectTransform { get
        {
            if (_rectTransform == null)
            {
                _rectTransform = GetComponent<RectTransform>();
            }
            return _rectTransform;
        }
    }

    protected bool _isInited;
    protected bool _isActive;
    public bool IsInited => _isInited;
    public bool IsActive => _isActive;

    protected IUIShowData _showData;
    protected IUIHideData _hideData;

    protected Dictionary<string, Action<object>> _actions = new Dictionary<string, Action<object>>();
    public virtual void Initialize()
    {
        _transform = transform;
        _rectTransform = GetComponent<RectTransform>();
        _isInited = true;
    }

    public virtual void SetDefault()
    {
    }

    public virtual void SetData(IUIData data = null)
    {
    }

    public virtual void UpdateEverySeconds(float timeUpdate)
    {
    }

    public virtual void Show(IUIShowData showData = null)
    {
        gameObject.SetActive(_isActive = true);
        _showData = showData;
        BeginShow();
    }

    public virtual void BeginShow()
    {
        ExecuteEvent(UI_EVENT_KEY.BEGIN_SHOW);
    }

    public virtual void OnShowComplete()
    {
        ExecuteEvent(UI_EVENT_KEY.SHOW_COMPLETE);
    }

    public void Hide(IUIHideData hideData = null)
    {
        _hideData = hideData;
        BeginHide();
    }


    public virtual void BeginHide()
    {
        ExecuteEvent(UI_EVENT_KEY.BEGIN_HIDE);
    }

    public virtual void OnHideComplete()
    {
        ExecuteEvent(UI_EVENT_KEY.HIDE_COMPLETE);
    }

    private void ExecuteEvent(string key, object obj = null)
    {
        if (_actions.ContainsKey(key))
        {
            _actions[key]?.Invoke(obj);
        }
    }

    public virtual void RegisterEvent(string key, Action<object> evt)
    {
    }

    public virtual void UnregisterEvent(string key, Action<object> evt)
    {
    }
}
