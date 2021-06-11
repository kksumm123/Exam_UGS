using MyGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hamster.ZG.Type
{
    [Type(typeof(bool), new string[] { "Bool", "bool" })]
    public class Bool : IType
    {
        public object DefaultValue => false;
        public object Read(string value)
        {
            bool f = false;
            var b = bool.TryParse(value, out f);
            if (b == false)
            {
                return DefaultValue;
            }
            return f;
        }
        public string Write(object value)
        {
            return value.ToString();
        }
    }
}

public class DataLoadTest : MonoBehaviour
{
    void Start()
    {
        //Fist time must be need call load();
        //UnityGoogleSheet.Load<Data>();  // or call MyGame.Data.Load(); it's same!
        Data.Load();

        //List
        foreach (var value in Data.DataList)
        {
            Debug.Log(value.Name + "," + value.Power + "," + value.Desc);
        }

        //Map (Dictionary)
        var dataFromMap = Data.DataMap["¾ÆÀú¾¾"];
        Debug.Log("dataFromMap : " + dataFromMap.Name + ", " + dataFromMap.Power + "," + dataFromMap.Desc);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Data.LoadFromGoogle((list, map) =>
            {
                foreach (var data in list) // loop received gamedata
                {
                    Debug.Log(data.Name);
                }
            }, false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Data.LoadFromGoogle((list, map) =>
            {
                foreach (var data in list) // loop received gamedata
                {
                    Debug.Log(data.Name);
                }
            }, true);
        }
    }
}
