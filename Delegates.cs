using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delegates : MonoBehaviour
{
    public delegate void TestDelegates();
    private TestDelegates testDeleateFunction;
    private void Start()
    {
        testDeleateFunction = MyTestDelegateFunction;
        testDeleateFunction();
    }
    //   public delegate void TestDelegates();�� �Ű������� ���� ���� ������ 
    private void MyTestDelegateFunction()
    {
        Debug.Log("MyTestDelegateFuction");
    }
}
