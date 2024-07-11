using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    [SerializeField] private Text pressText; //����Ƽ ������ ������ �� �ְ� ��, PressText ������Ʈ
    [SerializeField] private float fadingInterval; // ���ڰŸ� �ð� ����
    private float elapsedTime; // ���� �ð�
    private bool isFadeIn = false; // FadeIn ������?

    private void Update()
    {
        elapsedTime += Time.deltaTime; // �� �����ӿ��� ���� ���������� �Ѿ ������ �ɸ��� �ð� /  ����ð� = ����ð�+������ �Ѿ�� �ð�
        if (isFadeIn)
        {
            float alpha = Mathf.Lerp(0.0f, 1.0f, elapsedTime / fadingInterval); //elapsedTime ���� �þ���� fadingInterval ���� Ŀ�� �� ����, alpha=����(1)
            SetTextAlpha(alpha);

            if (elapsedTime > fadingInterval)
            {
                isFadeIn = false;
                elapsedTime = 0.0f; //����ð� �ʱ�ȭ ��Ű��
            }

        }

        else 
        {
            float alpha= Mathf.Lerp(1.0f, 0.0f, elapsedTime / fadingInterval); // ���� -> ������ ����
            SetTextAlpha(alpha);

            if (elapsedTime > fadingInterval)
            {
                isFadeIn=true;
                elapsedTime = 0.0f;
            }

        }



    }

    //Text�� ������ �������ִ� Method, method = ��ü�� �����̳� ����� ������ �Լ� (�ɹ��Լ�)
    private void SetTextAlpha(float alpha)
    {
        Color color = pressText.color;
        color.a = alpha;
        pressText.color= color;
    }

    public void LoadMaininMenu() // ����ȭ�� �ε��ϴ� method
    {
        SceneManager.LoadScene("Main");
    }


}
