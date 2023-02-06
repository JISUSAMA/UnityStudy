using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachineGun : GunWeapon
{
    public override void InitSetting(Text text)
    {
        data.delayTime = 0.1f;
        data.maxBullet = 40;
        data.info = "현재 무기 : 기관총";
        data.soundEffect = "두두두두!";
        data.bullet = Resources.Load<GameObject>("MachineGunBullet"); //돌격 소총 총알 이미지 
    }

    public override void Using()
    {
        throw new System.NotImplementedException();
    }
    public override void Using_virtural(Transform tip, TextMesh sound, Transform player)
    {
        base.Using_virtural(tip, sound, player);
        player.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
    }
}
