using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GunWeapon myWeapon; //무기의 종류, 스크립트
    GunWeapon lastWeapon; //이전무기

    public Transform tip; //총구의 위치 
    public TextMesh sound;

    public UnityEngine.UI.Text info;

    private void Start()
    {
        lastWeapon = myWeapon; 
        myWeapon.InitSetting(info);

    }
    private void Update()
    {
        if (lastWeapon != myWeapon)
        {
            lastWeapon = myWeapon;
            myWeapon.InitSetting(info);
        }
        myWeapon.Using_virtural(tip, sound, this.gameObject.transform);

        //총알을 모두 소진 하였을 경우, 기본 총으로 변경
        if(myWeapon.data.maxBullet ==0)
        {
            myWeapon = GetComponent<DeafaltGun>();
        }
    }
}
