using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    [SerializeField] private Text pressText;
    [SerializeField] private float fadingInterval;
    private float elapsedTime;
    private bool isFadeIn = false;

    private void Update()
    {
        elapsedTime += Time.deltaTime; // 한 프레임에서 다음 프레임으로 넘어갈 때까지 걸리는 시간
        if (isFadeIn)
        {
            float alpha = Mathf.Lerp(0.0f, 1.0f, elapsedTime / fadingInterval);
            SetTextAlpha(alpha);

            if (elapsedTime > fadingInterval)
            {
                isFadeIn = false;
                elapsedTime = 0.0f;
            }

        }

        else 
        {
            float alpha= Mathf.Lerp(1.0f, 0.0f, elapsedTime / fadingInterval);
            SetTextAlpha(alpha);

            if (elapsedTime > fadingInterval)
            {
                isFadeIn=true;
                elapsedTime = 0.0f;
            }

        }



    }

    private void SetTextAlpha(float alpha)
    {
        Color color = pressText.color;
        color.a = alpha;
        pressText.color= color;
    }

    public void LoadMaininMenu()
    {
        SceneManager.LoadScene("Main");
    }


}
