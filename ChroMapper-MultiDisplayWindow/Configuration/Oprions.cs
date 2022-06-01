using System;
using System.Reflection;
using System.IO;
using UnityEngine;
using SimpleJSON;

namespace ChroMapper_MultiDisplayWindow.Configuration
{
    public class Options
    {
        private static Options instance;
        public static readonly string settingJsonFile = Application.persistentDataPath + "/MultiDisplayWindow.json";

        public bool subWindow1 = false;
        public bool subWindow2 = false;
        public bool subWindow3 = false;
        public bool uiHidden1 = false;
        public bool uiHidden2 = false;
        public bool uiHidden3 = false;
        public float multiDislayCreateDelay = 0.1f;
        public int mainDisplayPosX = 0;
        public int mainDisplayPosY = 0;
        public int mainDisplayWidth = 0;
        public int mainDisplayHeight = 0;
        public int subDisplay1PosX = 0;
        public int subDisplay1PosY = 0;
        public int subDisplay1Width = 0;
        public int subDisplay1Height = 0;
        public float subCamera1PosX = 0;
        public float subCamera1PosY = 0;
        public float subCamera1PosZ = 0;
        public float subCamera1RotX = 0;
        public float subCamera1RotY = 0;
        public float subCamera1RotZ = 0;
        public float subCamera1FOV = 60;
        public int subDisplay2PosX = 0;
        public int subDisplay2PosY = 0;
        public int subDisplay2Width = 0;
        public int subDisplay2Height = 0;
        public float subCamera2PosX = 0;
        public float subCamera2PosY = 0;
        public float subCamera2PosZ = 0;
        public float subCamera2RotX = 0;
        public float subCamera2RotY = 0;
        public float subCamera2RotZ = 0;
        public float subCamera2FOV = 60;
        public int subDisplay3PosX = 0;
        public int subDisplay3PosY = 0;
        public int subDisplay3Width = 0;
        public int subDisplay3Height = 0;
        public float subCamera3PosX = 0;
        public float subCamera3PosY = 0;
        public float subCamera3PosZ = 0;
        public float subCamera3RotX = 0;
        public float subCamera3RotY = 0;
        public float subCamera3RotZ = 0;
        public float subCamera3FOV = 60;
        public string defaultCameraActiveKeyBinding = "<Mouse>/rightButton";
        public string defaultCameraElevatePositiveKeyBinding = "<Keyboard>/space";
        public string defaultCameraElevateNegativeKeyBinding = "<Keyboard>/ctrl";
        public string defaultCameraMoveUpKeyBinding = "<Keyboard>/w";
        public string defaultCameraMoveLeftKeyBinding = "<Keyboard>/a";
        public string defaultCameraMoveDownKeyBinding = "<Keyboard>/s";
        public string defaultCameraMoveRightKeyBinding = "<Keyboard>/d";

        public static Options Instance
        {
            get
            {
                if (instance is null)
                    instance = SettingLoad();
                return instance;
            }
        }

        public static Options SettingLoad()
        {
            var options = new Options();
            if (!File.Exists(settingJsonFile))
                return options;
            var members = options.GetType().GetMembers(BindingFlags.Instance | BindingFlags.Public);
            using (var jsonReader = new StreamReader(settingJsonFile))
            {
                var optionsNode = JSON.Parse(jsonReader.ReadToEnd());
                foreach (var member in members)
                {
                    try
                    {
                        if (!(member is FieldInfo field))
                            continue;
                        var optionValue = optionsNode[field.Name];
                        if (optionValue != null)
                            field.SetValue(options, Convert.ChangeType(optionValue.Value, field.FieldType));
                    }
                    catch (Exception e)
                    {
                        Debug.LogError($"Optiong {member.Name} member to load ERROR!.\n{e}");
                        options = new Options();
                    }
                }
            }
            return options;
        }
        public void SettingSave()
        {
            var optionsNode = new JSONObject();
            var members = this.GetType().GetMembers(BindingFlags.Instance | BindingFlags.Public);
            foreach (var member in members)
            {
                if (!(member is FieldInfo field))
                    continue;
                optionsNode[field.Name] = field.GetValue(this).ToString();
            }
            using (var jsonWriter = new StreamWriter(settingJsonFile, false))
                jsonWriter.Write(optionsNode.ToString(2));
        }

    }
}
