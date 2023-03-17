using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextWawe : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Button _nextWaweButton;

    private void OnEnable()
    {
        _spawner.AllEnemySpawned += OnAllEnemySpawned;
        _nextWaweButton.onClick.AddListener(OnNextWaweButtonClick);
    }

    private void OnDisable()
    {
        _spawner.AllEnemySpawned -= OnAllEnemySpawned;
        _nextWaweButton.onClick.RemoveListener(OnNextWaweButtonClick);
    }

    public void OnAllEnemySpawned()
    {
        _nextWaweButton.gameObject.SetActive(true);
    }

    public void OnNextWaweButtonClick()
    {
        _spawner.NextWawe();
        _nextWaweButton.gameObject.SetActive(false);
    }
}
