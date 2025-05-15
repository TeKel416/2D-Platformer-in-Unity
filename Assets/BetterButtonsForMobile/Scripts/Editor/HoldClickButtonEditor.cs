using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEditor.UI;
using UnityEngine.EventSystems;

namespace BetterButtonsEditor
{
    [CustomEditor(typeof(HoldClickButton))]
    public class HoldClickButtonEditor : ButtonEditor
    {
        [MenuItem("GameObject/UI/Hold Click Button", false, 1000)]
        static void Create()
        {
            GameObject go = new GameObject("Hold Click Button");
            Selection.activeGameObject = go;
            var rectTransform = go.AddComponent<RectTransform>();
            var canvas = FindObjectOfType<Canvas>();
            if (canvas != null)
            {
                rectTransform.parent = canvas.transform;
            }
            else
            {
                GameObject canvasGO = new GameObject("Canvas");
                GameObject eventSystemGO = new GameObject("EventSystem");
                eventSystemGO.AddComponent<EventSystem>();
                eventSystemGO.AddComponent<StandaloneInputModule>();
                canvas = canvasGO.AddComponent<Canvas>();
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                canvasGO.AddComponent<CanvasScaler>();
                canvasGO.AddComponent<GraphicRaycaster>();

                rectTransform.parent = canvasGO.transform;
            }


            rectTransform.localScale = new Vector3(1, 1, 1);
            rectTransform.anchoredPosition = Vector3.zero;
            rectTransform.sizeDelta = new Vector2(160, 30);

            // Image and Button components
            var image = go.AddComponent<Image>();
            image.sprite = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");
            image.raycastTarget = true;
            image.maskable = true;
            image.type = Image.Type.Sliced;

            var button = go.AddComponent<HoldClickButton>();

            GameObject textGO = new GameObject("Text");
            var textRectTransform = textGO.AddComponent<RectTransform>();
            textRectTransform.anchorMin = new Vector2(0, 0);
            textRectTransform.anchorMax = new Vector2(1, 1);
            textRectTransform.pivot = new Vector2(0.5f, 0.5f);
            textRectTransform.parent = go.transform;
            textRectTransform.sizeDelta = Vector2.zero;
            textRectTransform.anchoredPosition = Vector2.zero;
            textRectTransform.localScale = new Vector3(1, 1, 1);

            var text = textGO.AddComponent<Text>();
            text.text = "New Text";
            text.fontSize = 24;
            text.color = Color.black;
            text.alignment = TextAnchor.MiddleCenter;

        }

        [MenuItem("GameObject/UI/Hold Click Button - TMPro", false, 1000)]
        static void CreateWithTMPro()
        {
            GameObject go = new GameObject("Hold Click Button");
            Selection.activeGameObject = go;
            var rectTransform = go.AddComponent<RectTransform>();
            var canvas = FindObjectOfType<Canvas>();
            if (canvas != null)
            {
                rectTransform.parent = canvas.transform;
            }
            else
            {
                GameObject canvasGO = new GameObject("Canvas");
                GameObject eventSystemGO = new GameObject("EventSystem");
                eventSystemGO.AddComponent<EventSystem>();
                eventSystemGO.AddComponent<StandaloneInputModule>();
                canvas = canvasGO.AddComponent<Canvas>();
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                canvasGO.AddComponent<CanvasScaler>();
                canvasGO.AddComponent<GraphicRaycaster>();

                rectTransform.parent = canvasGO.transform;
            }


            rectTransform.localScale = new Vector3(1, 1, 1);
            rectTransform.anchoredPosition = Vector3.zero;
            rectTransform.sizeDelta = new Vector2(160, 30);

            // Image and Button components
            var image = go.AddComponent<Image>();
            image.sprite = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");
            image.raycastTarget = true;
            image.maskable = true;
            image.type = Image.Type.Sliced;

            var button = go.AddComponent<HoldClickButton>();

            GameObject textGO = new GameObject("Text (TMP)");
            var textRectTransform = textGO.AddComponent<RectTransform>();
            textRectTransform.anchorMin = new Vector2(0, 0);
            textRectTransform.anchorMax = new Vector2(1, 1);
            textRectTransform.pivot = new Vector2(0.5f, 0.5f);
            textRectTransform.parent = go.transform;
            textRectTransform.sizeDelta = Vector2.zero;
            textRectTransform.anchoredPosition = Vector2.zero;
            textRectTransform.localScale = new Vector3(1, 1, 1);

            var text = textGO.AddComponent<TMPro.TextMeshProUGUI>();
            text.text = "New Text";
            text.fontSize = 24;
            text.color = Color.black;
            text.alignment = TMPro.TextAlignmentOptions.Center;
        }

        private SerializedProperty eventProperty;


        protected override void OnEnable()
        {
            eventProperty = serializedObject.FindProperty("onHoldClick");
            base.OnEnable();
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.PropertyField(eventProperty, new GUIContent("On Hold Click"));
            serializedObject.ApplyModifiedProperties();
        }
    }
}
