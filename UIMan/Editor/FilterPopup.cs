﻿using System;
using UnityEditor;
using UnityEngine;

namespace UnuGames
{
    public class FilterPopup : EditorWindow
    {
        private static string[] mItems;

        private static Action<string> OnSelected { get; set; }

        private const int MEMBER_HEIGHT = 37;
        private static Rect inspectorRect;
        private static Vector2 inspectorPos;
        private static Vector2 scrollPosition;
        private static UISearchField searchField;
        private static ListView listView;

        /// <summary>
        /// Show window as dropdown popup
        /// </summary>
        private static void Popup()
        {
            var fp = ScriptableObject.CreateInstance(typeof(FilterPopup)) as FilterPopup;

            var minHeight = mItems.Length * MEMBER_HEIGHT + MEMBER_HEIGHT * 2;
            var bestHeight = (int)(Screen.currentResolution.height / 2.5f);
            if (minHeight > bestHeight)
                minHeight = bestHeight;

            inspectorPos = GUIUtility.GUIToScreenPoint(new Vector2(inspectorRect.x, inspectorRect.y));
            fp.ShowAsDropDown(new Rect(inspectorPos, inspectorRect.size), new Vector2(inspectorRect.width, minHeight));
        }

        /// <summary>
        /// Browse for field/property
        /// </summary>
        /// <param name="binderEditor"></param>
        /// <param name="field"></param>
        public static void Browse(string[] items, Action<string> onSelected)
        {
            searchField = new UISearchField(Filter, null, null);
            OnSelected = onSelected;
            mItems = items;

            if (items != null && items.Length > 0)
                Popup();
        }

        private void OnGUI()
        {
            if (Event.current.keyCode == KeyCode.Escape)
                Close();

            if (mItems == null)
                return;

            if (listView == null)
                listView = new ListView();

            //Search field
            searchField.Draw();
            listView.SetData(mItems, true, OnSelected, searchField.KeyWord, this);
            listView.Draw();
        }

        /// <summary>
        /// Set the window's rectangle
        /// </summary>
        /// <param name="rect"></param>
        public static void SetPopupRect(Rect rect)
        {
            inspectorRect = rect;
        }

        public static void SetShowPosition()
        {
            SetPopupRect(new Rect(GUILayoutUtility.GetLastRect().x, Event.current.mousePosition.y, GUILayoutUtility.GetLastRect().width, 10));
        }

        /// <summary>
        /// Filter items by keyword
        /// </summary>
        /// <param name="keyWord"></param>
        private static void Filter(string keyWord)
        {
        }

        new public static void Close()
        {
            if (listView != null && listView.Window != null)
                listView.Window.Close();
        }
    }
}