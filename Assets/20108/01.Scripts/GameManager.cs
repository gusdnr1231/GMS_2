using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

	[SerializeField]
	private PoolingListSO _poolingList;

	private Transform playerTrm;
    public Transform PlayerTrm
    {
        get
        {
            if(playerTrm == null)
            {
				playerTrm = GameObject.FindGameObjectWithTag("Player").transform;
			}
			return playerTrm;
		}
    }

	private void Awake()
	{
		if (Instance != null)
		{
			Debug.LogError("Mutipple GameManager");
		}
		Instance = this;

		CreatePool();
	}

	private void CreatePool()
	{
		PoolManager.Instance = new PoolManager(transform);
		_poolingList.Pairs.ForEach(pair =>
		{
			PoolManager.Instance.CreatePool(pair.Prefab, pair.Count);
		});
	}
}
