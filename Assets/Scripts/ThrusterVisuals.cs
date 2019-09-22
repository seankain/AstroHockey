using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterVisuals : MonoBehaviour
{

    public GameObject ThrusterPrefab;

    public void ToggleThruster(bool isOn)
    {
        if (isOn && !ThrusterPrefab.activeSelf) { ThrusterPrefab.SetActive(true); }
        else { ThrusterPrefab.SetActive(false); }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
