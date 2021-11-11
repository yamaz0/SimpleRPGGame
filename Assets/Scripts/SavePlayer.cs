using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SavePlayer
{
    public static void PlayerSerialize(Player player)
    {
        FileStream file = new FileStream("PlayerAttributes.dat", FileMode.Create);

        BinaryFormatter formatter = new BinaryFormatter();
        try
        {
            formatter.Serialize(file, player.Character);
            formatter.Serialize(file, player.Inventory);
        }
        catch (SerializationException e)
        {
            Debug.LogError("Failed to serialize. Reason: " + e.Message);
            throw;
        }
        finally
        {
            file.Close();
        }
    }

    public static void PlayerDeserialize(Player player)
    {
        FileStream fs = new FileStream("PlayerAttributes.dat", FileMode.Open);

        try
        {
            BinaryFormatter formatter = new BinaryFormatter();

            player.Character = formatter.Deserialize(fs) as Character;
            player.Inventory = formatter.Deserialize(fs) as Inventory;
        }
        catch (SerializationException e)
        {
            Debug.LogError("Failed to deserialize. Reason: " + e.Message);
            throw;
        }
        finally
        {
            fs.Close();
        }
    }
}