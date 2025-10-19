using System;
using IsolarvLocalizationTool.Runtime;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace IsolarvLocalizationTool.Editor
{
    public class TranslateTablesWindow : EditorWindow
    {
        static LocalizationKeyCollection _selectedCollection;

        ScrollView _tableView;
        
        [MenuItem("Tools/Isolarv/Localization Tool/Tables", false, 65)]
        public static void ShowWindow()
        {
            EditorWindowUtils.ShowWindow<TranslateTablesWindow>("Tables");
        }
        
        public static void OpenWindow(params Type[] desiredDockNextTo)
        {
            EditorWindowUtils.OpenWindow<TranslateTablesWindow>("Tables", desiredDockNextTo);
        }

        public void CreateGUI()
        {
            VisualElement root = rootVisualElement;

            var visualTree =
                AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(
                    $"{EditorUtils.PACKAGE_EDITOR_PATH}/Editor Window/Tables Window/TranslateTablesWindow.uxml");
            
            VisualElement labelFromUxml = visualTree.Instantiate();
            root.Add(labelFromUxml);
            
            _tableView = rootVisualElement.Q<ScrollView>("table-view");

            CreateCollectionSelectField();
            CreateTableView();
        }

        void CreateCollectionSelectField()
        {
            var objectField = new ObjectField();
            objectField.objectType = typeof(LocalizationKeyCollection);
            
            if (_selectedCollection != null)
            {
                objectField.value = _selectedCollection;
            }
            
            objectField.RegisterValueChangedCallback((loc) =>
            {
                _selectedCollection = loc.newValue as LocalizationKeyCollection;
                UpdateTableView();
            });
            
            var keysField = rootVisualElement.Q<GroupBox>("keys-field");
            keysField.Add(objectField);
        }
        
        void UpdateTableView()
        {
            _tableView.Clear();
            CreateTableView();
        }

        void CreateTableView()
        {
            var emptyTemplate = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(
                $"{EditorUtils.PACKAGE_EDITOR_PATH}/Editor Window/Tables Window/TableEmptyItem.uxml");

            string emptyLabel = "";
            bool isEmpty = false;
            
            if (_selectedCollection == null)
            {
                emptyLabel = "No collection selected.";
                isEmpty = true;
            }
            else if (_selectedCollection.keysCount == 0)
            {
                emptyLabel = "No keys in collection.";
                isEmpty = true;
            }
            
            if (isEmpty)
            {
                var emptyItem = emptyTemplate.Instantiate();
                emptyItem.Q<Label>("empty-label").text = emptyLabel;
                
                _tableView.Add(emptyItem);
                return;
            }
        }
    }
}
