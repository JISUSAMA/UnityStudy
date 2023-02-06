using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//무기 클래스가 가지고 있는 공통 변수
public struct Data
{
    public float delayTime;
    public int maxBullet;
    public string info;
    public string soundEffect;
    public GameObject bullet;
}
// 각 무기마다 스크립트를 만들어줄 것임
//상속해주기 위해서 abstract로 추상 클래스로 만들어줌
public abstract class GunWeapon : MonoBehaviour
{
    public Data data;
    bool shootAble = true;
    float restTime = 0;
    public abstract void InitSetting(UnityEngine.UI.Text text);
    //abstract 에서는 구현이 불가능 하다. 그래서 virtual로 형식 변경해주어야함
    public abstract void Using();
    //총을 쏘는 방식은 구현방법이 동일 하기 때문에 부모에서 공통스크립트를 구현해준다.
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
