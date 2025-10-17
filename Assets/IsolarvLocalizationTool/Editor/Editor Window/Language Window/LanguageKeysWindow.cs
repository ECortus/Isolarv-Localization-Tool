using System;
using System.Collections.Generic;
using System.Linq;
using IsolarvLocalizationTool.Runtime;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace IsolarvLocalizationTool.Editor
{
    public class LanguageKeysWindow : EditorWindow
    {
        private LanguageKeyCollection _languageKeyCollection;

        private GroupBox _contentBox;
        
        private ListView _languageListView;
        private VisualTreeAsset _listViewItemTemplate;

        private List<LanguageKey> _keysSet;
        
        [MenuItem("Tools/Isolarv/Localization Tool/All windows", false, 25)]
        public static void ShowAllWindows()
        {
            ShowWindow();
            
            LocalizationKeysWindow.OpenWindow(typeof(LanguageKeysWindow));
            TranslateTablesWindow.OpenWindow(typeof(LanguageKeysWindow));
            
            LanguageKeysWindow wnd = GetWindow<LanguageKeysWindow>("Languages");
            wnd.Focus();
        }
        
        [MenuItem("Tools/Isolarv/Localization Tool/Languages", false, 55)]
        public static void ShowWindow()
        {
            LanguageKeysWindow wnd = OpenWindow();
            
            var size = new Vector2(800, 400);
            wnd.minSize = size;

            wnd.Show();
        }

        public static LanguageKeysWindow OpenWindow(params Type[] desiredDockNextTo)
        {
            LanguageKeysWindow wnd = GetWindow<LanguageKeysWindow>("Languages", desiredDockNextTo);
            wnd.titleContent = EditorUtils.GetWindowTitle("Languages");

            return wnd;
        }

        public void CreateGUI()
        {
            _languageKeyCollection = AssetDatabase.LoadAssetAtPath<LanguageKeyCollection>(
                $"{EditorUtils.PACKAGE_BASE_PATH}/Data/Language Key Collection.asset");
            
            VisualElement root = rootVisualElement;

            UpdateKeysSet();

            var visualTree =
                AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(
                    $"{EditorUtils.PACKAGE_EDITOR_PATH}/Editor Window/Language Window/LanguageKeysWindow.uxml");
            
            VisualElement labelFromUxml = visualTree.Instantiate();
            root.Add(labelFromUxml);

            // AddNewLanguageGUI();
            CreateListViewGUI();
            CreateContentBox();
            
            _contentBox.Add(new AddNewLanguage());
        }

        void UpdateKeysSet()
        {
            _keysSet = _languageKeyCollection.GetKeys();
        }

        void AddNewLanguageGUI()
        {
            var addLanguageButton = rootVisualElement.Q<Button>("add-language-button");
            addLanguageButton.clicked += SwitchToCreateNewLanguageView;
        }
        
        void SwitchToCreateNewLanguageView()
        {
            _languageListView.ClearSelection();
            
            _contentBox.Clear();
            _contentBox.Add(new AddNewLanguage());
        }

        void CreateListViewGUI()
        {
            _languageListView = rootVisualElement.Q<ListView>("language-list-view");
            
            _listViewItemTemplate = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(
                $"{EditorUtils.PACKAGE_EDITOR_PATH}/Editor Window/Language Window/LanguageListViewItem.uxml");
            
            _languageListView.itemsSource = _keysSet;
            _languageListView.selectionType = SelectionType.Single;
            _languageListView.selectionChanged += ListViewSelectionChanged;
            _languageListView.showBoundCollectionSize = true;
            _languageListView.makeItem = () => _listViewItemTemplate.Instantiate();
            _languageListView.bindItem = BindListViewItem;
#if UNITY_2021_3_OR_NEWER
            _languageListView.virtualizationMethod = CollectionVirtualizationMethod.DynamicHeight;
#endif
        }   
        
        void CreateContentBox()
        {
            _contentBox = rootVisualElement.Q<GroupBox>("content-box");
        }
        
        private static int _lastSelectedIndex = -1;
        
        private void ListViewSelectionChanged(IEnumerable<object> objects)
        {
            if (objects == null || !objects.Any()) return;
            if (_lastSelectedIndex == _languageListView.selectedIndex) return;
            
            _lastSelectedIndex = _languageListView.selectedIndex;

            var key = _keysSet[_lastSelectedIndex];
            OnLanguageSelected(key);
        }

        void OnLanguageSelected(LanguageKey key)
        {
            _contentBox.Clear();
        }
        
        private void BindListViewItem(VisualElement listItem, int i)
        {
            var key = _keysSet[i];
            if (key == null) return;
            
            var mainAbilityBox = listItem.GetFirstOfType<VisualElement>();
            listItem.userData = i.ToString();
            
            var nameLabel = mainAbilityBox.Q<Label>("Language-Label");
            nameLabel.text = key.name;

            var abilityImage =  mainAbilityBox.Q<UxmlImage>("Language-Image");
            abilityImage.image = key.icon.texture;
        }
    }
}
