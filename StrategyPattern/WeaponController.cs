using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GunWeapon myWeapon; //������ ����, ��ũ��Ʈ
    GunWeapon lastWeapon; //��������

    public Transform tip; //�ѱ��� ��ġ 
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

        //�Ѿ��� ��� ���� �Ͽ��� ���, �⺻ ������ ����
        if(myWeapon.data.maxBullet ==0)
        {
            myWeapon = GetComponent<DeafaltGun>();
        }
    }
}
