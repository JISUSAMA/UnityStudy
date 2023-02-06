using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpStudy : MonoBehaviour
{
    public Transform startPosition; //������
    public Transform endPosition; //����

    float lerpT = 0.5f; //����� �� �ð�
    float currentT = 0f;
    //������� �⺻������ ����ϴ� Lerp ���
    private void Start()
    {
        //������ ��ġ�� StartPosition �� �־���
        this.transform.position = startPosition.position;
    }
    private void Update()
    {
        //���� ��ǥ�� ���� ��ǥ�� �ƴϱ� ������ �Ź� �޶��� �� �ִ�
        this.transform.position = Vector3.Lerp(this.transform.position, endPosition.position, 10 * Time.deltaTime);

        //����� �� �ð��� ������ �ʿ� ���� lerpT ������ ���� �����ص� ���ϴ� �ʸ�ŭ �̵� �ϰ� ���� �� ����
        //���� ��ǥ�� �־���, ������ ��ǥ�� �Ź� �޶����� ���ʿ��� �۾��� ���� ���ִ�.
        currentT += Time.deltaTime;
        if (currentT >= lerpT) //�ִ� 0.5���� ������
        {
            currentT = lerpT;
        }
        //currentT/lerpT�� �ϸ� 0~1���� ������ ���� ��
        this.transform.position = Vector3.Lerp(startPosition.position, endPosition.position, currentT / lerpT);
    }
}
