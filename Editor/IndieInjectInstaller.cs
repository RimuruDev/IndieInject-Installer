// **************************************************************** //
//
//   Copyright (c) RimuruDev. All rights reserved.
//   Contact me: 
//          - Gmail:    rimuru.dev@gmail.com
//          - LinkedIn: https://www.linkedin.com/in/rimuru/
//          - GitHub:   https://github.com/RimuruDev
//
// **************************************************************** //

using System.IO;
using System.Net;
using UnityEditor;
using UnityEngine;

namespace IndieInject.Editor.Installer
{
    public sealed class IndieInjectInstaller : EditorWindow
    {
        [MenuItem("IndieInject/IndieInject Package Installer")]
        public static void ShowWindow() => GetWindow<IndieInjectInstaller>("IndieInject Installer");

        private void OnGUI()
        {
            GUILayout.Label("Welcome to IndieInject Installer", EditorStyles.boldLabel);

            if (GUILayout.Button("Install IndieInject"))
                InstallIndieInject();
        }

        private static void InstallIndieInject()
        {
            const string url = "https://github.com/RimuruDev/IndieInject/archive/refs/heads/main.zip";
            var downloadPath = Path.Combine(Application.dataPath, "Plugins", "IndieInject.zip");
            var extractPath = Path.Combine(Application.dataPath, "Plugins");

            if (!Directory.Exists(extractPath))
            {
                Directory.CreateDirectory(extractPath);
            }

            using (var client = new WebClient())
            {
                client.DownloadFile(url, downloadPath);
            }

            System.IO.Compression.ZipFile.ExtractToDirectory(downloadPath, extractPath);
            File.Delete(downloadPath);

            AssetDatabase.Refresh();
            EditorUtility.DisplayDialog("Success", "IndieInject has been installed successfully!", "OK");
        }
    }
}