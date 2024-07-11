using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    [SerializeField] private Text pressText; //유니티 내에서 수정할 수 있게 함, PressText 컴포넌트
    [SerializeField] private float fadingInterval; // 깜박거릴 시간 간격
    private float elapsedTime; // 진행 시간
    private bool isFadeIn = false; // FadeIn 중인지?

    private void Update()
    {
        elapsedTime += Time.deltaTime; // 한 프레임에서 다음 프레임으로 넘어갈 때까지 걸리는 시간 /  진행시간 = 진행시간+프레임 넘어가는 시간
        if (isFadeIn)
        {
            float alpha = Mathf.Lerp(0.0f, 1.0f, elapsedTime / fadingInterval); //elapsedTime 점점 늘어나지만 fadingInterval 보다 커질 수 없음, alpha=투명도(1)
            SetTextAlpha(alpha);

            if (elapsedTime > fadingInterval)
            {
                isFadeIn = false;
                elapsedTime = 0.0f; //진행시간 초기화 시키기
            }

        }

        else 
        {
            float alpha= Mathf.Lerp(1.0f, 0.0f, elapsedTime / fadingInterval); // 투명 -> 불투명 과정
            SetTextAlpha(alpha);

            if (elapsedTime > fadingInterval)
            {
                isFadeIn=true;
                elapsedTime = 0.0f;
            }

        }



    }

    //Text의 투명도를 변경해주는 Method, method = 객체의 동작이나 기능을 정의한 함수 (맴버함수)
    private void SetTextAlpha(float alpha)
    {
        Color color = pressText.color;
        color.a = alpha;
        pressText.color= color;
    }

    public void LoadMaininMenu() // 메인화면 로드하는 method
    {
        SceneManager.LoadScene("Main");
    }


}
