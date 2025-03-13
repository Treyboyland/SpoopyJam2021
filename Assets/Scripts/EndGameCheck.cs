using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameCheck : MonoBehaviour
{
    [SerializeField]
    PlayerUpgradeSO nuke;

    [SerializeField]
    string endGameSceneName;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerGameStats.Instance.InGameStats.GetCountOfUpgradeType(null, nuke) > 0)
        {
            SceneManager.LoadScene(endGameSceneName);
        }
    }
}
