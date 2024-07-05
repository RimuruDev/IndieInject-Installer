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
        private const string PackageUrl = "https://github.com/RimuruDev/IndieInject/archive/refs/heads/main.zip";
        private const string DocsUrl = "https://github.com/RimuruDev/IndieInject/blob/main/README.md";
        private const string DownloadPath = "Assets/Plugins/IndieInject.zip";
        private const string ExtractPath = "Assets/Plugins";
        private const string ExtractedFolderPath = "Assets/Plugins/IndieInject-main";
        private const string FinalFolderPath = "Assets/Plugins/IndieInject";
        private Texture2D backgroundTexture;

        [InitializeOnLoadMethod]
        private static void Init()
        {
            if (!Directory.Exists(FinalFolderPath))
            {
                ShowWindow();
            }
        }

        private void OnEnable()
        {
            backgroundTexture = Resources.Load<Texture2D>("_Background");
        }

        [MenuItem("IndieInject/IndieInject Package Installer")]
        public static void ShowWindow()
        {
            const float width = 400f;
            const float height = 266f;

            var window = CreateInstance<IndieInjectInstaller>();
            window.titleContent = new GUIContent("IndieInject Installer");
            window.position = new Rect(Screen.width / 2, Screen.height / 2, width, height);
            window.maxSize = new Vector2(width, height);
            window.minSize = window.maxSize;
            window.ShowUtility();
        }

        private void OnGUI()
        {
            if (backgroundTexture != null)
            {
                GUI.DrawTexture(new Rect(0, 0, position.width, position.height), backgroundTexture,
                    ScaleMode.StretchToFill);
            }

            GUILayout.Space(20);

            var welcomeStyle = new GUIStyle(GUI.skin.label)
            {
                fontSize = 24,
                alignment = TextAnchor.MiddleCenter
            };
            GUILayout.Label("Welcome", welcomeStyle);

            var titleStyle = new GUIStyle(GUI.skin.label)
            {
                fontSize = 18,
                alignment = TextAnchor.MiddleCenter
            };

            GUILayout.Label("IndieInject", titleStyle);

            GUILayout.Space(20);

            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();

            var buttonStyle = new GUIStyle(GUI.skin.button)
            {
                fontSize = 12
            };

            if (GUILayout.Button("Install", buttonStyle, GUILayout.Width(100), GUILayout.Height(40)))
            {
                InstallIndieInject();
            }

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

            GUILayout.Space(10);

            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();

            if (GUILayout.Button("Docs", buttonStyle, GUILayout.Width(100), GUILayout.Height(40)))
            {
                Application.OpenURL(DocsUrl);
            }

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        }

        private static void InstallIndieInject()
        {
            if (!Directory.Exists(ExtractPath))
            {
                Directory.CreateDirectory(ExtractPath);
            }

            using (var client = new WebClient())
            {
                client.DownloadFile(PackageUrl, DownloadPath);
            }

            System.IO.Compression.ZipFile.ExtractToDirectory(DownloadPath, ExtractPath);

            File.Delete(DownloadPath);

            if (Directory.Exists(ExtractedFolderPath))
            {
                if (Directory.Exists(FinalFolderPath))
                {
                    Directory.Delete(FinalFolderPath, true);
                }

                Directory.Move(ExtractedFolderPath, FinalFolderPath);
            }

            AssetDatabase.Refresh();
            EditorUtility.DisplayDialog("Success", "IndieInject has been installed successfully!", "OK");
        }
    }
}