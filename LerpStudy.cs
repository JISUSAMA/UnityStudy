using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpStudy : MonoBehaviour
{
    public Transform startPosition; //시작점
    public Transform endPosition; //끝점

    float lerpT = 0.5f; //진행될 총 시간
    float currentT = 0f;
    //사람들이 기본적으로 사용하는 Lerp 방식
    private void Start()
    {
        //현재의 위치를 StartPosition 에 넣어줌
        this.transform.position = startPosition.position;
    }
    private void Update()
    {
        //시작 좌표가 고정 좌표가 아니기 때문에 매번 달라질 수 있다
        this.transform.position = Vector3.Lerp(this.transform.position, endPosition.position, 10 * Time.deltaTime);

        //진행될 총 시간을 수정할 필요 없이 lerpT 변수의 값만 수정해도 원하는 초만큼 이동 하게 만들 수 있음
        //고정 좌표를 넣어줌, 시작의 좌표가 매번 달라지는 불필요한 작업을 줄일 수있다.
        currentT += Time.deltaTime;
        if (currentT >= lerpT) //최대 0.5까지 증가함
        {
            currentT = lerpT;
        }
        //currentT/lerpT를 하면 0~1까지 서서히 증가 함
        this.transform.position = Vector3.Lerp(startPosition.position, endPosition.position, currentT / lerpT);
    }
}
