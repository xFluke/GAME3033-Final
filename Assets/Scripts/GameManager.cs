using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    int numberOfCustomersServedToWin;

    int numberOfCustomersServed = 0;

    [SerializeField]
    GameObject gameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<CustomerManager>().onFoodDeliverySuccess.AddListener(CheckForWinCondition);    
    }

    void CheckForWinCondition() {
        numberOfCustomersServed++;

        if (numberOfCustomersServed >= numberOfCustomersServedToWin) {
            Time.timeScale = 0;
            gameOverCanvas.SetActive(true);
        }
    }
}
