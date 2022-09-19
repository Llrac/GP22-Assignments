using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessingAssignment : ProcessingLite.GP21
{
    [SerializeField] string lettersInRowOne;
    [SerializeField] string lettersInRowTwo;
    [SerializeField] string lettersInRowThree;
    [SerializeField] string lettersInRowFour;
    Vector2 position;

    private void Update()
    {
        UpdateLetters();
    }

    public void UpdateLetters()
    {
        Background(0);
        lettersInRowOne = lettersInRowOne.ToUpper();
        char[] charsOne = lettersInRowOne.ToCharArray();
        lettersInRowTwo = lettersInRowTwo.ToUpper();
        char[] charsTwo = lettersInRowTwo.ToCharArray();
        lettersInRowThree = lettersInRowThree.ToUpper();
        char[] charsThree = lettersInRowThree.ToCharArray();
        lettersInRowFour = lettersInRowFour.ToUpper();
        char[] charsFour = lettersInRowFour.ToCharArray();
        position = new Vector2(Width/2 + 1 - charsOne.Length, 7.5f);
        for (int letterID = 0; letterID < charsOne.Length; letterID++)
        {
            WriteLetter(charsOne[letterID]);
            position.x += 2;
        }
        position = new Vector2(Width / 2 + 1 - charsTwo.Length, 5.25f);
        for (int letterID = 0; letterID < charsTwo.Length; letterID++)
        {
            WriteLetter(charsTwo[letterID]);
            position.x += 2;
        }
        position = new Vector2(Width / 2 + 1 - charsThree.Length, 3f);
        for (int letterID = 0; letterID < charsThree.Length; letterID++)
        {
            WriteLetter(charsThree[letterID]);
            position.x += 2;
        }
        position = new Vector2(Width / 2 + 1 - charsFour.Length, 0.75f);
        for (int letterID = 0; letterID < charsFour.Length; letterID++)
        {
            WriteLetter(charsFour[letterID]);
            position.x += 2;
        }
    }

    void WriteLetter(char letter)
    {
        if (letter == 'A')
        {
            Stroke(50, 50, 200);
            Line(position.x - 0.5f, position.y, position.x, position.y + 2);
            Line(position.x, position.y + 2, position.x + 0.5f, position.y);
            Line(position.x - 0.25f, position.y + 1f, position.x + 0.25f, position.y + 1f);
        }
        if (letter == 'C')
        {
            Stroke(200, 50, 200);
            Line(position.x + 0.5f, position.y + 2, position.x, position.y + 2);
            Line(position.x, position.y + 2, position.x - 0.5f, position.y + 1.5f);
            Line(position.x - 0.5f, position.y + 1.5f, position.x - 0.5f, position.y + 0.5f);
            Line(position.x - 0.5f, position.y + 0.5f, position.x, position.y);
            Line(position.x, position.y, position.x + 0.5f, position.y);
        }
        if (letter == 'E')
        {
            Stroke(50, 200, 50);
            Line(position.x - 0.5f, position.y, position.x - 0.5f, position.y + 2);
            Line(position.x - 0.5f, position.y + 2, position.x + 0.5f, position.y + 2);
            Line(position.x - 0.5f, position.y + 1, position.x + 0.5f, position.y + 1);
            Line(position.x - 0.5f, position.y, position.x + 0.5f, position.y);
        }
        if (letter == 'K')
        {
            Stroke(50, 255, 255);
            Line(position.x - 0.5f, position.y, position.x - 0.5f, position.y + 2);
            Line(position.x - 0.5f, position.y + 1, position.x + 0.5f, position.y + 2);
            Line(position.x, position.y + 1.5f, position.x + 0.5f, position.y);
        }
        if (letter == 'L')
        {
            Stroke(255, 255, 50);
            Line(position.x - 0.5f, position.y, position.x - 0.5f, position.y + 2);
            Line(position.x - 0.5f, position.y, position.x + 0.5f, position.y);
        }
        if (letter == 'R')
        {
            Stroke(255, 0, 0);
            Line(position.x - 0.5f, position.y, position.x - 0.5f, position.y + 2);
            Line(position.x - 0.5f, position.y + 2, position.x + 0.25f, position.y + 2);
            Line(position.x + 0.25f, position.y + 2, position.x + 0.5f, position.y + 1.75f);
            Line(position.x + 0.5f, position.y + 1.75f, position.x + 0.5f, position.y + 1.25f);
            Line(position.x + 0.5f, position.y + 1.25f, position.x + 0.25f, position.y + 1);
            Line(position.x + 0.25f, position.y + 1f, position.x + 0.5f, position.y + 0.75f);
            Line(position.x + 0.25f, position.y + 1f, position.x - 0.5f, position.y + 1);
            Line(position.x + 0.5f, position.y + 0.75f, position.x + 0.5f, position.y);
        }
        if (letter == 'Y')
        {
            Stroke(100, 200, 200);
            Line(position.x - 0.5f, position.y, position.x + 0.5f, position.y + 2);
            Line(position.x - 0.5f, position.y + 2, position.x, position.y + 1);
        }
    }
}
