using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    int numberOfCustomersServedToWin;

    int numberOfCustomersServed = 0;

    [SerializeField]
    int numberOfCustomersFailedToLose;

    int numberOfCustomersFailed = 0;

    [SerializeField]
    GameObject gameOverCanvas;

    [SerializeField]
    Text gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<CustomerManager>().onFoodDeliverySuccess.AddListener(CheckForWinCondition);
        FindObjectOfType<CustomerManager>().onFoodDeliveryFail.AddListener(CheckForLossCondition);
    }

    void CheckForWinCondition() {
        numberOfCustomersServed++;

        if (numberOfCustomersServed >= numberOfCustomersServedToWin) {
            Time.timeScale = 0;
            gameOverCanvas.SetActive(true);
            gameOverText.text = "Congraulations! You won!";
        }
    }

    void CheckForLossCondition() {
        numberOfCustomersFailed++;

        if (numberOfCustomersFailed >= numberOfCustomersFailedToLose) {
            Time.timeScale = 0;
            gameOverCanvas.SetActive(true);
            gameOverText.text = "Oops! You lost!";
        }
    }
}
