using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//플레이어에 넣어두고 WeaponController에서 사용함
public class DeafaltGun : GunWeapon
{
    //GunWeapon에서 만든 함수 클래스
    public override void InitSetting(UnityEngine.UI.Text text)
    {
        data.delayTime = 1;
        data.maxBullet =-1;
        data.info = "현재 무기 : 기본 권총";
        data.soundEffect ="빵야!";
        data.bullet = Resources.Load<GameObject>("DefaultBullet");
    }

    public override void Using()
    {
    }

    //총쏘기 구현
    public override void Using_virtural(Transform tip, TextMesh sound , Transform player)
    {
        base.Using_virtural(tip, sound, player);
        //기본 권총 일 때의 이동방식
        player.transform.position += new Vector3(Input.GetAxis("Horiaontal"), 0, 0) * 10 * Time.deltaTime; 
    }
}
