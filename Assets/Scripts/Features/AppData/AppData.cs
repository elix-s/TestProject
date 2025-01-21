using System;
using UnityEngine;

public class AppData 
{
    public int StartingNumber { get; set; }
    public string Message { get; set; }
    public Sprite ButtonSprite { get; set; }
    
    [Serializable]
    public class Settings { public int startingNumber; }

    [Serializable]
    public class Greeting { public string message; }
}
