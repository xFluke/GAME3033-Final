using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerDetection : MonoBehaviour
{
    [SerializeField] GameObject myObject;
    [SerializeField] bool hasAnimation;


    private void Awake() {
        myObject = transform.parent.gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            if (myObject.CompareTag("Appliance") && hasAnimation) {
                myObject.GetComponent<Animator>().SetBool("Open", true);
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            if (myObject.CompareTag("Appliance") && hasAnimation) {
                myObject.GetComponent<Animator>().SetBool("Open", false);
            }
        }
    }
}
