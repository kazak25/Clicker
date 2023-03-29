using UnityEngine;

[CreateAssetMenu(fileName = "business", menuName = "Businesses")]
public class BusinessConfig : ScriptableObject
{
    public ConfigBusinessModel[] ConfigBusinessModel => _configBusinessModels;
    
    [SerializeField] private ConfigBusinessModel[] _configBusinessModels;
    
}

