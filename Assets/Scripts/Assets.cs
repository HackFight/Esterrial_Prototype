using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assets : MonoBehaviour
{
    public static Assets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Transform itemWorldPrefab;
    public Transform tileWorldPrefab;
}
