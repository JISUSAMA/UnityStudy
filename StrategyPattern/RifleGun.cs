using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�����ð� ���� ��ũ��Ʈ 
public class RifleGun : GunWeapon
{
    //Defalt Gun �� �����ϰ� ����
    public override void InitSetting(UnityEngine.UI.Text text)
    {
        data.delayTime =0.5f;
        data.maxBullet = 20;
        data.info = "���� ���� : ���� ����";
        data.soundEffect = "��!";
        data.bullet = Resources.Load<GameObject>("RifleBullet"); //���� ���� �Ѿ� �̹��� 
    }

    public override void Using()
    {
        throw new System.NotImplementedException();
    }

    public override void Using_virtural(Transform tip, TextMesh sound, Transform player)
    {
        base.Using_virtural(tip, sound, player);
        //�⺻ ���� �� ���� �̵����
        player.transform.position += new Vector3(Input.GetAxis("Vertical"), 0, 0) * 10 * Time.deltaTime;
    }

}
