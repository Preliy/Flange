using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Preliy.Flange.Editor
{
    public class UrdfImporterWindow : EditorWindow
    {
        private const string PREFS_OBJECT = "URDF_IMPORTER";
        private const string PREFS_KEY_PATH_URDF = PREFS_OBJECT + "_PATH_URDF";
        
        private const string UXML = "UXML/URDFImporter";
        
        private Button _buttonImport;
        private Button _buttonSelectUrdf;
        private TextField _pathUrdf;
        
        [MenuItem("Flange/URDF Importer")]
        public static void ShowWindow()
        {
            var window = GetWindow(typeof(UrdfImporterWindow));
            window.titleContent = new GUIContent("URDF Importer");
        }

        public void CreateGUI()
        {
            Resources.Load<VisualTreeAsset>(UXML).CloneTree(rootVisualElement);
            
            _buttonImport = rootVisualElement.Q<Button>("import");
            _buttonSelectUrdf = rootVisualElement.Q<Button>("selectUrdf");
            _pathUrdf = rootVisualElement.Q<TextField>("pathUrdf");
            
            _buttonImport.clicked += Import;
            _buttonSelectUrdf.clicked += SelectUrdf;
            
            _pathUrdf.SetValueWithoutNotify(PlayerPrefs.GetString(PREFS_KEY_PATH_URDF));
        }
        

        private void OnDisable()
        {
            PlayerPrefs.SetString(PREFS_KEY_PATH_URDF, _pathUrdf.value);
        }
        
        private void Import()
        {
            try
            {
                if (!File.Exists(_pathUrdf.value))
                {
                    throw new FileNotFoundException("URDF import failed. Urdf file is not found.");
                }
            }
            catch (Exception exception)
            {
                Debug.LogError(exception);
            }
        }
        
        private void SelectUrdf()
        {
            var path = EditorUtility.OpenFilePanel("Select URDF File", PlayerPrefs.GetString(PREFS_KEY_PATH_URDF), "urdf");
            if (!string.IsNullOrEmpty(path))
            {
                _pathUrdf.SetValueWithoutNotify(path);
                PlayerPrefs.SetString(PREFS_KEY_PATH_URDF, path);
            }
        }
    }
}
