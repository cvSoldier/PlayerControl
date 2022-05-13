using System.Collections;
using System.Collections.Generic;
using DialogueEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProcessManager : MonoBehaviour
{
    private bool gameover = false;

    private PlayerController _playerController;
    private SpriteRenderer _chefSpriteRenderer;
    // start时isActive = false，不能用Find获取到
    [SerializeField] private GameObject _bloodParticle;
    private BgmFade _bgmFade;
    public NPCConversation Conversation;
    [SerializeField] private GameObject gameUI;
    private DontDestory _dontDestory;

    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        _bgmFade = GameObject.FindWithTag("MainCamera").GetComponent<BgmFade>();
        _chefSpriteRenderer = GameObject.Find("Chef").GetComponent<SpriteRenderer>();
        _dontDestory = GameObject.FindWithTag("DontDestory").GetComponent<DontDestory>();
    }


    // duck走位，bgm淡出
    public void Step1()
    {
        _playerController.GameoverSlowMove();
        _bgmFade.beginFadeBgm();
        StartCoroutine("waitStartConversation");
    }

    IEnumerator waitStartConversation()
    {
        yield return new WaitForSeconds(1.5f);
        _chefSpriteRenderer.flipX = true;
        ConversationManager.Instance.StartConversation(Conversation);
    }

    // duck 叫 + 飙血, 镜头变黑缩紧。
    public void Step2()
    {
        _playerController.DuckCall();
        _bloodParticle.gameObject.SetActive(true);
        gameUI.gameObject.SetActive(true);
    }
    public void ShutGameDown()
    {
        gameover = true;
        _playerController.StopMoving();
    }

    public bool isGameover()
    {
        return gameover;
    }
    public void RestartGame()
    {
        _dontDestory.TimesPlusPlus();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
