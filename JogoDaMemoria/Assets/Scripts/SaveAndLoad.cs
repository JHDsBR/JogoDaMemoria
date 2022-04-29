using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveAndLoad
{
        private static string saveGamePath = Application.persistentDataPath;

        public static void SaveGame(GameDataManager dataM)
        {
            // return;
            if(!Directory.Exists(saveGamePath))
            {
                Directory.CreateDirectory(saveGamePath);
                // Debug.LogWarning("O diretório '" + path +"' não existia, mas acabou de ser criado" );
            }
            string path = saveGamePath+"/SaveGame.data";
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = new FileStream(path, FileMode.Create);
            GameData data = new GameData(dataM);
            bf.Serialize(file, data);
            file.Close();
            Debug.Log("Salvamento feito em: " + path);
        }


        public static GameData LoadGame()
        {
            string path = saveGamePath+"/SaveGame.data";

            if (!File.Exists(path))
            {
                Debug.LogWarning("Salvamento não encontrando em: " + path);
                return default(GameData);
            }

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = new FileStream(path, FileMode.Open);
            GameData data = default(GameData);

            try
            {
                // file.Position = 0;
                data = bf.Deserialize(file) as GameData;

            }
            catch
            {
                Debug.LogWarning("Não foi possível carregar o salvamento, ele está corrompido");
            }

            file.Close();

            return data;

        }


}
