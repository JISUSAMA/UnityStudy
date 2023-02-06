using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�÷��̾ �־�ΰ� WeaponController���� �����
public class DeafaltGun : GunWeapon
{
    //GunWeapon���� ���� �Լ� Ŭ����
    public override void InitSetting(UnityEngine.UI.Text text)
    {
        data.delayTime = 1;
        data.maxBullet =-1;
        data.info = "���� ���� : �⺻ ����";
        data.soundEffect ="����!";
        data.bullet = Resources.Load<GameObject>("DefaultBullet");
    }

    public override void Using()
    {
    }

    //�ѽ�� ����
    public override void Using_virtural(Transform tip, TextMesh sound , Transform player)
    {
        base.Using_virtural(tip, sound, player);
        //�⺻ ���� �� ���� �̵����
        player.transform.position += new Vector3(Input.GetAxis("Horiaontal"), 0, 0) * 10 * Time.deltaTime; 
    }
}
