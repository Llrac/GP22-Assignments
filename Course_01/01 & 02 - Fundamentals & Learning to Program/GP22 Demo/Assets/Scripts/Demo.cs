using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{
    //bool myBool = true;
    string[] myString = { "Hello World", "Hello", "World" };
    //string[][] myString = new string[10, 10, 10];
    List<int> myList = new List<int>();
    int myInt = 1;
    //float myFloat = 1f;

    // Start is called before the first frame update
    void Start()
    {
        myInt = RandomNumber();

        PrintHelloWorld(myInt);
    }

    void PrintHelloWorld(int value)
    {
        Debug.Log("Hello World" + value);
    }

    int RandomNumber()
    {
        return Random.Range(0, 5);
    }
}
