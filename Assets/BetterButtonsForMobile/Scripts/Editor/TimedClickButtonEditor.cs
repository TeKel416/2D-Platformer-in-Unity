using UnityEngine;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace BetterButtonsEditor
{
    [CustomEditor(typeof(TimedClickButton))]
    public class TimedClickButtonEditor : ButtonEditor
    {
        [MenuItem("GameObject/UI/Timed Click Button", false, 1000)]
        static void Create()
        {
            GameObject go = new GameObject("Timed Click Button");
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

            var button = go.AddComponent<TimedClickButton>();

            GameObject imageGO = new GameObject("Image");
            var imageRectTransform = imageGO.AddComponent<RectTransform>();
            imageRectTransform.anchorMin = new Vector2(0, 0);
            imageRectTransform.anchorMax = new Vector2(1, 1);
            imageRectTransform.pivot = new Vector2(0.5f, 0.5f);
            imageRectTransform.parent = go.transform;
            imageRectTransform.sizeDelta = Vector2.zero;
            imageRectTransform.anchoredPosition = Vector2.zero;
            image = imageGO.AddComponent<Image>();
            button.fillImage = image;
            image.sprite = Resources.Load<Sprite>("Square");
            image.color = new Color32(255, 70, 70, 150);
            image.type = Image.Type.Filled;
            image.fillAmount = 0;
            image.fillMethod = Image.FillMethod.Horizontal;

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

        [MenuItem("GameObject/UI/Timed Click Button - TMPro", false, 1000)]
        static void CreateWithTMPro()
        {
            GameObject go = new GameObject("Timed Click Button");
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

            var button = go.AddComponent<TimedClickButton>();

            GameObject imageGO = new GameObject("Image");
            var imageRectTransform = imageGO.AddComponent<RectTransform>();
            imageRectTransform.anchorMin = new Vector2(0, 0);
            imageRectTransform.anchorMax = new Vector2(1, 1);
            imageRectTransform.pivot = new Vector2(0.5f, 0.5f);
            imageRectTransform.parent = go.transform;
            imageRectTransform.sizeDelta = Vector2.zero;
            imageRectTransform.anchoredPosition = Vector2.zero;
            image = imageGO.AddComponent<Image>();
            button.fillImage = image;
            image.sprite = Resources.Load<Sprite>("Square");
            image.color = new Color32(255, 70, 70, 150);
            image.type = Image.Type.Filled;
            image.fillAmount = 0;
            image.fillMethod = Image.FillMethod.Horizontal;

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

        private SerializedProperty imageProperty;
        private SerializedProperty floatProperty;
        private SerializedProperty eventProperty;

        protected override void OnEnable()
        {
            imageProperty = serializedObject.FindProperty("fillImage");
            floatProperty = serializedObject.FindProperty("requiredHoldTime");
            eventProperty = serializedObject.FindProperty("onClickTimeFinished");
            base.OnEnable();
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.PropertyField(imageProperty, new GUIContent("Fill Image"));
            EditorGUILayout.PropertyField(floatProperty, new GUIContent("Required Hold Time"));
            serializedObject.ApplyModifiedProperties();
            base.OnInspectorGUI();
            EditorGUILayout.PropertyField(eventProperty, new GUIContent("On Click Time Finished"));
            serializedObject.ApplyModifiedProperties();
        }
    }
}
