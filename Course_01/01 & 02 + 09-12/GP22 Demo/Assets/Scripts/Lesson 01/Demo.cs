using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{
    string[] myString = { "Hello World", "Hello", "World" };
    List<int> myList = new List<int>();
    int myInt = 1;

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
