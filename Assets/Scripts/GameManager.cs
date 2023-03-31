using System;
using System.Collections.Generic;
using Systems;
using UnityEngine;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ProfitSystem profitSystem;
    [SerializeField] private BalanceView _balanceView;
    [SerializeField] private ConfigSystem _configSystem;
    [SerializeField] private BusinesSpawner _businesSpawner;
    
    private ISaveFileSystem _saveFileSystem;
    private ILoadFileSystem _loadFileSystem;
    private IDeleteFileSystem _deleteFileSystem;

    private JsonFileSystem _json;

    private void Awake()
    {
        InitializeSystems();
        _json = new JsonFileSystem();
        StartGame();
    }

    private void Start()
    {
        _balanceView.Initialize(profitSystem);
    }

    private void StartGame()
    {
        BusinessModel[] _businessModels;
        var data = _json.Load();
        if (data == null)
        {
             Debug.Log("IF");
             Debug.Log(profitSystem.GetBalance());
             _configSystem.CreateBusinessModels();
            _businessModels = _configSystem.GetBuisnessModels();
        }
        else
        {
            Debug.Log("ELSE");
            _businessModels = data.BusinessModels;
            Debug.Log(data.Balance);
            
            profitSystem.Initialize(data.Balance);
        }
        
        _businesSpawner.SpawnBusiness(_businessModels);
    }

    private void InitializeSystems()
    {
        _saveFileSystem = new JsonFileSystem();
        _loadFileSystem = new JsonFileSystem();
        _deleteFileSystem = new JsonFileSystem();
    }

    public void SaveGame()
    {
        var businesModels = _configSystem.GetBuisnessModels();
        
        var balance = profitSystem.GetBalance();
        var saveData = new SaveData(balance,businesModels);
        
        _json.Save(saveData);
       
        
        EditorApplication.isPlaying = false;
        
    }
 
    public void NewGame()
    {
        _deleteFileSystem.Delete();
        _businesSpawner.DeleteControllers();
        EditorApplication.isPlaying = false;
       // StartGame();
    }
    
}