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
    private DontDestory _dontDestory;
    private void Start()
    {
        _processManager = GameObject.FindWithTag("ProcessManager").GetComponent<ProcessManager>();
        _dontDestory = GameObject.FindWithTag("DontDestory").GetComponent<DontDestory>();
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
            NPCConversation curConversation = null;
            if (_dontDestory.GetTimes() ==  0)
            {
                curConversation = chefConversation;
            } else if (_dontDestory.GetTimes() == 1)
            {
                curConversation = GameObject.Find("SecondConversation").GetComponent<NPCConversation>();
            }
            
            if (curConversation != null)
            {
                _processManager.ShutGameDown();
                ConversationManager.Instance.StartConversation(curConversation);
            }
        }
    }

    IEnumerator closeFigurineTitle()
    {
        yield return new WaitForSeconds(2);
        FigurineTitle.gameObject.SetActive(false);
    }
}
