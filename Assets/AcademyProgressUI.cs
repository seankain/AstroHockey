using MLAgents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcademyProgressUI : MonoBehaviour
{
    public Text EpisodeCountText;
    public Academy TrainingAcademy;
    public float UpdateInterval = 3;
    private float elapsed = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= UpdateInterval)
        {
            EpisodeCountText.text = $"Episode: {TrainingAcademy.GetEpisodeCount()}";
            elapsed = 0;
        }
    }
}
