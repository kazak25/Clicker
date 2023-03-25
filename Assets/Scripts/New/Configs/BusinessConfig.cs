using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "business", menuName = "Businesses")]
public class BusinessConfig : ScriptableObject
{
    public BusinessModel[] BuisnessModels => _businessModel;

    [SerializeField] private BusinessModel[] _businessModel;
    
}

