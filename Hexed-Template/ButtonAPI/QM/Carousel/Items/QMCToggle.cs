
using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using VRC.Localization;



using WorldAPI.ButtonAPI.Controls;
using WorldAPI;
using Object = UnityEngine.Object;
using WorldAPI.ButtonAPI.Groups;
using WorldAPI.ButtonAPI.QM.Controls;
using VRC.UI.Element;
using VRC.UI.Elements.Tooltips;


namespace WorldAPI.ButtonAPI.QM.Carousel.Items
{
    public class QMCToggle : QMCControl
    {
        public System.Action<bool> ListenerC { get; set; }
        public ToggleSwitch toggleSwitch { get; set; }
        private bool shouldInvoke = true;

        private static Vector3 onPos = new Vector3(93, 0, 0), offPos = new Vector3(30, 0, 0);
        public QMCToggle(Transform parent, string text, System.Action<bool> stateChange, string tooltip = "", bool defaultState = false, bool separator = false)
        {
            if (!APIBase.IsReady())
                throw new NullReferenceException("Object Search has FAILED!");

            (transform = (gameObject = Object.Instantiate(APIBase.QMCarouselToggleTemplate, parent)).transform).name = text;

            Text = (TMProCompnt = transform.Find("LeftItemContainer/Title").GetComponent<TextMeshProUGUI>()).text = text;
            TMProCompnt.richText = true;

            (ToggleToolTip = gameObject.GetComponent<UiToggleTooltip>())._localizableString = tooltip.ReturnLocalizableString();

            if (separator != false)
                AddSeparator(parent);
            (toggleSwitch = transform.Find("RightItemContainer/Cell_MM_OnOffSwitch").GetComponent<ToggleSwitch>()).Method_Public_Void_Boolean_0(defaultState);

            (Handle = toggleSwitch._handle).transform.localPosition = defaultState ? onPos : offPos;

            (ToggleCompnt = gameObject.GetComponent<Toggle>()).onValueChanged = new Toggle.ToggleEvent();
            ToggleCompnt.isOn = defaultState;
            ListenerC = stateChange;
            ToggleCompnt.onValueChanged.AddListener(new System.Action<bool>((val) => {
                if (shouldInvoke)
                    APIBase.SafelyInvolk(val, ListenerC, text);
                APIBase.Events.onQMCToggleValChange.Invoke(this, val);
                toggleSwitch.Method_Public_Void_Boolean_0(val);
                Handle.localPosition = val ? onPos : offPos;
            }));
            gameObject.GetComponent<SettingComponent>().enabled = false;

        }
        public QMCToggle(QMCGroup group, string text, System.Action<bool> stateChange, string tooltip = "", bool defaultState = false, bool separator = false)
            : this(group.GetTransform().Find("QM_Settings_Panel/VerticalLayoutGroup").transform, text, stateChange, tooltip, defaultState, separator) { }
        public QMCToggle(CollapsibleButtonGroup buttonGroup, string text, string tooltip, System.Action<bool> stateChange, bool defaultState = false, bool separator = false)
            : this(buttonGroup.QMCParent, text, stateChange, tooltip, defaultState, separator) { }
    }

}
