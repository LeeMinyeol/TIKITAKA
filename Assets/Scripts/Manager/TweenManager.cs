using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using DG.Tweening;
using System;

[Serializable]
public class TweenManager : MonoBehaviour
{
    [Header("StartScene UI")]
    [SerializeField] private GameObject[] titleImg;
    [SerializeField] private GameObject player1Img;
    [SerializeField] private GameObject player2Img;
    [SerializeField] private GameObject fragmentsImg;
    [SerializeField] private GameObject shockwaveImg;
    [SerializeField] private GameObject ballImg;
    [SerializeField] private GameObject startTxtImg;
    [SerializeField] private GameObject backgroundImg;


    private void Start()
    {
        ResetTransform();
        Debug.Log("����");
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            Debug.Log("�ڷ�ƾ ����");
            StartCoroutine(PopUpStart());    
        }
    }

    IEnumerator PopUpStart()
    {
        Debug.Log("�ڷ�ƾ ����");
        if (titleImg.Length < 1) yield return null;

        for(int i = 0; i < titleImg.Length; i++)
        {
            titleImg[i].SetActive(true);
            titleImg[i].transform.DOScale(Vector3.one, 0.5f);
            Debug.Log("���Ҵ�");
            yield return new WaitForSeconds(0.5f);
        }
        Debug.Log("���Դ�");
        player1Img.SetActive(true); // ���İ� 255�� ����
        player2Img.SetActive(true);

        yield return new WaitForSeconds(0.3f);

        ballImg.SetActive(true);
        ballImg.transform.DOMoveX(0, 1f, false);

        yield return new WaitForSeconds(0.4f);
        player1Img.SetActive(false);
        fragmentsImg.SetActive(true);

        backgroundImg.transform.DOShakePosition(1f,15);
        shockwaveImg.SetActive(true);
        startTxtImg.SetActive(true);

    }
    void ResetTransform()
    {
        for (int i = 0; i < titleImg.Length; i++)
        {
            titleImg[i].transform.localScale *= 0.2f;
        }

        for(int i = 0; i < backgroundImg.transform.childCount; i++)
        {
            backgroundImg.transform.GetChild(i).gameObject.SetActive(false);
        }
        

    }


}
