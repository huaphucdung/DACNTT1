using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "UIReferenceSO", menuName = "UI/SO/UIReference")]
public class UIReferenceSO : ScriptableObject
{
    [field: SerializeField] public List<UIReference> UIReferencesList { get; private set; }

    public UIReference GetUIReference(string Key)
    {
        foreach(UIReference reference in UIReferencesList)
        {
            if(reference.Key.Equals(Key))
            {
                return reference;
            }
        }
        return null;
    }
}

[Serializable]
public class UIReference
{
    [field: SerializeField] public string Key { get; private set; }
    [field: SerializeField] public bool IsSingle { get; private set; } = true;
    [field: SerializeField] public AssetReference UIAsset { get; private set; }
}