using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Profit profit;
    [SerializeField] private BalanceView _balanceView;
    [SerializeField] private ConfigSystem _configSystem;
    [SerializeField] private BusinesSpawner _businesSpawner;
    
    private ISaveFileSystem _saveFileSystem;
    private ILoadFileSystem _loadFileSystem;
    private IDeleteFileSystem _deleteFileSystem;

    private void Awake()
    {
        InitializeSystems();
        StartGame();
    }

    private void Start()
    {
        _balanceView.Initialize(profit);
    }

    private void StartGame()
    {
        BusinessModel[] _businessModels;
        var data = _loadFileSystem.Load();
        if (data == null)
        {
            _configSystem.CreateBusinessModels();
            _businessModels = _configSystem.GetBuisnessModels();
        }
        else
        {
            _businessModels = data.BusinessModels;
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
        var balance = profit.GetBalance();
        var saveData = new SaveData(balance,businesModels);
        
        _saveFileSystem.Save(saveData);
    }

    private void NewGame( )
    {
        _deleteFileSystem.Delete();
        _businesSpawner.DeleteComtrollers();
        StartGame();
    }
    
}