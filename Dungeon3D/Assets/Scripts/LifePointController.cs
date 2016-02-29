using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifePointController : MonoBehaviour {

    private int lifePoints = 0;
    public Text lpText;
    public int LifePoints
    {
        get
        {
            return lifePoints;
        }
        set
        {
            lifePoints = value;
            if (lifePoints < 0)
                lifePoints = 0;
            UpdateView();
        }
    }

    void UpdateView()
    {
        lpText.text = lifePoints.ToString();
    }

    void Awake()
    {
        LifePoints = PlayerPrefs.GetInt("LPs");
    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("LPs", lifePoints);
    }
}
