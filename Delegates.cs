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
    //   public delegate void TestDelegates();에 매개변수가 따로 없기 때문에 
    private void MyTestDelegateFunction()
    {
        Debug.Log("MyTestDelegateFuction");
    }
}
