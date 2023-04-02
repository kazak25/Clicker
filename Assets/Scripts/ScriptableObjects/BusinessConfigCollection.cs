using Configs;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "business", menuName = "Businesses")]
    public class BusinessConfigCollection : ScriptableObject
    {
        public ConfigBusinessModel[] ConfigBusinessModel => _configBusinessModels;
    
        [SerializeField] private ConfigBusinessModel[] _configBusinessModels;
    
    }
}

