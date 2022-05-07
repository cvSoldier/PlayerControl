using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DialogueEditor;

public class CollisionNpc : MonoBehaviour
{
    public TextMeshProUGUI FigurineTitle;
    public NPCConversation chefConversation;
    
    private ProcessManager _processManager;
    private void Start()
    {
        _processManager = GameObject.FindWithTag("ProcessManager").GetComponent<ProcessManager>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name != "Player") return;

        if (gameObject.name == "Figurine")
        {
            FigurineTitle.gameObject.SetActive(true);
            StartCoroutine("closeFigurineTitle");
        }

        if (gameObject.name == "Chef")
        {
            _processManager.ShutGameDown();
            ConversationManager.Instance.StartConversation(chefConversation);
        }
    }

    IEnumerator closeFigurineTitle()
    {
        yield return new WaitForSeconds(2);
        FigurineTitle.gameObject.SetActive(false);
    }
}
