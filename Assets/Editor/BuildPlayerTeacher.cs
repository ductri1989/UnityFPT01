using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Build.Reporting;
using System;

public class BuildPlayerTeacher : MonoBehaviour
{
    public static void XuatFile(){
        string[] scenes = new[] { "Assets/SC_Move/Scene_MoveObject.unity"
            , "Assets/SC_Rotate/Scene_RotateObject.unity"
            , "Assets/SC_Teacher/Scene_Teacher.unity"
            , "Assets/SC_Student01_NguyenVanA/Scene_LV1.unity"
        };

        //string path = System.IO.Directory.GetCurrentDirectory();
        //path = commandLineOption[CommandType.path.ToKey()];
        //string _versionName = commandLineOption[CommandType.versionName.ToKey()];
        //int _versionCode = -1;
        //int.TryParse(commandLineOption[CommandType.versionCode.ToKey()], out _versionCode);

        int version = DateTime.Today.Year*10000 + DateTime.Today.Month*100 + DateTime.Today.Day;

        PlayerSettings.companyName = "AiO JSC";
        PlayerSettings.productName = "AiOOnline";
        PlayerSettings.bundleVersion = version + "";
        PlayerSettings.Android.bundleVersionCode = version;

        PlayerSettings.Android.keystoreName = "/workspace/Unity/Keystore/bth.bigxu.online.keystore";
        PlayerSettings.Android.keystorePass = "Password";
        PlayerSettings.Android.keyaliasName = "bigxu_studio";
        PlayerSettings.Android.keyaliasPass = "Password";
        PlayerSettings.SetScriptingBackend(BuildTargetGroup.Android, ScriptingImplementation.IL2CPP);
        PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, "");
        //PlayerSettings.Android.targetArchitectures = AndroidArchitecture.All;
        PlayerSettings.Android.targetArchitectures = AndroidArchitecture.ARM64 | AndroidArchitecture.ARMv7;
        BuildPipeline.BuildPlayer(scenes, "" + version + ".apk", BuildTarget.Android, BuildOptions.None);



        //PlayerSettings.companyName = "AiO JSC";
        //PlayerSettings.productName = "AiOOnline";
        //PlayerSettings.bundleVersion = version + "";
        //PlayerSettings.iOS.buildNumber = version + "";

        //PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.iOS, "bth.bigxu.boardgame");
        //PlayerSettings.SetScriptingBackend(BuildTargetGroup.iOS, ScriptingImplementation.IL2CPP);
        //PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS, "");
        //EditorUserBuildSettings.iOSXcodeBuildConfig = XcodeBuildConfig.Release;
        //PlayerSettings.iOS.targetDevice = iOSTargetDevice.iPhoneAndiPad;
        ////https://docs.unity3d.com/ScriptReference/PlayerSettings.SetArchitecture.html
        ////Sets an integer value associated with the architecture of a BuildTargetPlatformGroup. 0 - None, 1 - ARM64, 2 - Universal.
        //PlayerSettings.SetArchitecture(BuildTargetGroup.iOS, 2);
        //BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, "/Users/multimediajscbth/Desktop/BigxuIOS_v" + version, BuildTarget.iOS, BuildOptions.None);
    }
}
