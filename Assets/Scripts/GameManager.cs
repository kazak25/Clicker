using System;
using System.Collections.Generic;
using Configs;
using GameView;
using Models;
using Systems;
using UnityEngine;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TotalBalanceController totalBalanceController;
   // [SerializeField] private BalanceView _balanceView;
    [SerializeField] private ConfigSystem _configSystem;
    [SerializeField] private BusinessSystem businessSystem;

    private SaveSystem _json;

    private void Awake()
    {
        _json = new SaveSystem();
        StartGame();
    }

    private void Start()
    {
        //_balanceView.Initialize(totalBalanceController);
    }

    private void StartGame()
    {
        BusinessModel[] _businessModels;
        var data = _json.Load();
        if (data == null)
        {
            Debug.Log("IF");
            Debug.Log(totalBalanceController.GetBalance());
            _configSystem.CreateBusinessModels();
            _businessModels = _configSystem.GetBuisnessModels();
        }
        else
        {
            Debug.Log("ELSE");
            _businessModels = data.BusinessModels;
            Debug.Log(data.Balance);

            totalBalanceController.Initialize(data.Balance);
        }

        businessSystem.SpawnBusiness(_businessModels);
    }

    public void SaveGame()
    {
        var businesModels = _configSystem.GetBuisnessModels();

        var balance = totalBalanceController.GetBalance();
        var saveData = new SaveData(balance, businesModels);

        _json.Save(saveData);


        EditorApplication.isPlaying = false;
    }

    public void NewGame()
    {
        _json.Delete();
        businessSystem.DeleteControllers();
        EditorApplication.isPlaying = false;
        // StartGame();
    }
}