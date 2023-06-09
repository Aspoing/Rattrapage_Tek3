using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent InteractAction;

    void Update() {
        if (isInRange) {
            if (Input.GetKeyDown(interactKey)) {
                InteractAction.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            isInRange = true;
            other.gameObject.GetComponent<PlayerController>().notifyPlayer();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            isInRange = false;
            other.gameObject.GetComponent<PlayerController>().denotifyPlayer();
        }
    }
}
