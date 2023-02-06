using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� Ŭ������ ������ �ִ� ���� ����
public struct Data
{
    public float delayTime;
    public int maxBullet;
    public string info;
    public string soundEffect;
    public GameObject bullet;
}
// �� ���⸶�� ��ũ��Ʈ�� ������� ����
//������ֱ� ���ؼ� abstract�� �߻� Ŭ������ �������
public abstract class GunWeapon : MonoBehaviour
{
    public Data data;
    bool shootAble = true;
    float restTime = 0;
    public abstract void InitSetting(UnityEngine.UI.Text text);
    //abstract ������ ������ �Ұ��� �ϴ�. �׷��� virtual�� ���� �������־����
    public abstract void Using();
    //���� ��� ����� ��������� ���� �ϱ� ������ �θ𿡼� ���뽺ũ��Ʈ�� �������ش�.
    public virtual void Using_virtural(Transform tip, TextMesh sound , Transform player)
    {   
        if(Input.GetKey(KeyCode.Space) && shootAble)
        {
            var bull = Instantiate(data.bullet);
            bull.transform.position = tip.position;

            var effect = Instantiate(sound);
            effect.transform.position = tip.position + new Vector3(0, 1f, 0);
            effect.text = data.soundEffect;
            shootAble = false;

            data.maxBullet--;
        }
        if(shootAble  == false)
        {
            restTime += Time.deltaTime;
            if(restTime >= data.delayTime)
            {
                shootAble = true;
                restTime = 0f;
            }
        }
    }
}
