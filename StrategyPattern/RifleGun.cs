using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//라이플건 관련 스크립트 
public class RifleGun : GunWeapon
{
    //Defalt Gun 과 동일하게 구현
    public override void InitSetting(UnityEngine.UI.Text text)
    {
        data.delayTime =0.5f;
        data.maxBullet = 20;
        data.info = "현재 무기 : 돌격 소총";
        data.soundEffect = "탕!";
        data.bullet = Resources.Load<GameObject>("RifleBullet"); //돌격 소총 총알 이미지 
    }

    public override void Using()
    {
        throw new System.NotImplementedException();
    }

    public override void Using_virtural(Transform tip, TextMesh sound, Transform player)
    {
        base.Using_virtural(tip, sound, player);
        //기본 권총 일 때의 이동방식
        player.transform.position += new Vector3(Input.GetAxis("Vertical"), 0, 0) * 10 * Time.deltaTime;
    }

}
