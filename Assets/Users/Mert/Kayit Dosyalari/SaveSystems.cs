using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystems
{
    public static void SavePlayer(PlayerMovementDeneme player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.zero";

        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerDatas data = new PlayerDatas(player);
    }
}
