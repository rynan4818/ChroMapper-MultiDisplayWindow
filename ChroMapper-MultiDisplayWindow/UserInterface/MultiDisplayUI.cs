using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ChroMapper_MultiDisplayWindow.Configuration;
using ChroMapper_MultiDisplayWindow.Component;

namespace ChroMapper_MultiDisplayWindow.UserInterface
{
    public class MultiDisplayUI
    {
        public GameObject _multiDisplayMenu;
        public Toggle _subWindow1;
        public Toggle _subWindow2;
        public Toggle _subWindow3;
        public TextMeshProUGUI _message;
        public const string deleteDisplayMessage = "Created displays cannot be deleted!";
        public const string noteEnoughDisplayMessage = "Not enough displays!";
        public void AddMenu(MapEditorUI mapEditorUI)
        {
            var parent = mapEditorUI.MainUIGroup[5];
            _multiDisplayMenu = new GameObject("Multi Display Window Menu");
            _multiDisplayMenu.transform.parent = parent.transform;

            //Multi Display Menu
            UI.AttachTransform(_multiDisplayMenu, 300, 240, 0.95f, 0.95f, 0, 0, 1, 1);

            Image imageSetting = _multiDisplayMenu.AddComponent<Image>();
            imageSetting.sprite = PersistentUI.Instance.Sprites.Background;
            imageSetting.type = Image.Type.Sliced;
            imageSetting.color = new Color(0.24f, 0.24f, 0.24f);

            UI.MoveTransform(UI.AddLabel(_multiDisplayMenu.transform, "Multi Display Window", "Multi Display Window").Item1, 200, 24, 0.5f, 1, 0, -15);

            UI.MoveTransform(UI.AddLabel(_multiDisplayMenu.transform, "Display Counts", $"Display Counts = {Display.displays.Length}").Item1, 200, 24, 0.5f, 1, 0, -35);

            var messageText = UI.AddLabel(_multiDisplayMenu.transform, "Message", "");
            UI.MoveTransform(messageText.Item1, 300, 24, 0.5f, 1, 0, -155);
            _message = messageText.Item2;
            _message.fontSize = 20;

            if (Display.displays.Length > 1)
            {
                var subWindow1Check = UI.AddCheckbox(_multiDisplayMenu.transform, "Sub Window 1", "Sub Window 1", Options.Instance.subWindow1, (check) =>
                {
                    _message.text = "";
                    if (MultiDisplayController.activeWindow > 1)
                    {
                        _subWindow1.isOn = true;
                        _message.text = deleteDisplayMessage;
                        return;
                    }
                    if (!check)
                    {
                        if (_subWindow2 != null)
                            _subWindow2.isOn = false;
                        if (_subWindow3 != null)
                            _subWindow3.isOn = false;
                    }
                    Options.Instance.subWindow1 = check;
                });
                UI.MoveTransform(subWindow1Check.Item3.transform, 30, 25, 0, 1, 30, -65);
                UI.MoveTransform(subWindow1Check.Item1, 160, 16, 0, 1, 115, -60);
                _subWindow1 = subWindow1Check.Item3;

                var uiHiden1Check = UI.AddCheckbox(_multiDisplayMenu.transform, "UI Hidden 1", "UI Hidden", Options.Instance.uiHidden1, (check) =>
                {
                    Options.Instance.uiHidden1 = check;
                    Plugin.multiDisplayController.SetCamUI(1, check);
                });
                UI.MoveTransform(uiHiden1Check.Item3.transform, 30, 25, 0, 1, 30, -85);
                UI.MoveTransform(uiHiden1Check.Item1, 160, 16, 0, 1, 115, -80);

                var fov1Input = UI.AddTextInput(_multiDisplayMenu.transform, "FOV 1", "FOV", Options.Instance.subCamera1FOV.ToString(), (value) =>
                {
                    float res;
                    if (float.TryParse(value, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture.NumberFormat, out res))
                    {
                        Options.Instance.subCamera1FOV = res;
                        Plugin.multiDisplayController.SetCamFov(1, res);
                    }
                });
                UI.MoveTransform(fov1Input.Item1, 60, 16, 0, 1, 15, -100);
                UI.MoveTransform(fov1Input.Item3.transform, 30, 20, 0.1f, 1, 35, -100);

                var mainCopy1Button = UI.AddButton(_multiDisplayMenu.transform, "Main Cam Copy 1", "Main Cam Copy", () =>
                {
                    if (Plugin.multiDisplayController.SetMainCamPos(1))
                        _message.text = "Sub Camera 1 Copy!";
                    else
                        _message.text = "";
                });
                UI.MoveTransform(mainCopy1Button.transform, 70, 25, 0, 1, 50, -125);

                if (Display.displays.Length > 2)
                {
                    var subWindowCheck2 = UI.AddCheckbox(_multiDisplayMenu.transform, "Sub Window 2", "Sub Window 2", Options.Instance.subWindow2, (check) =>
                    {
                        _message.text = "";
                        if (MultiDisplayController.activeWindow > 2)
                        {
                            _subWindow2.isOn = true;
                            _message.text = deleteDisplayMessage;
                            return;
                        }
                        if (check)
                            _subWindow1.isOn = true;
                        if (!check && _subWindow3 != null)
                            _subWindow3.isOn = false;
                        Options.Instance.subWindow2 = check;
                    });
                    UI.MoveTransform(subWindowCheck2.Item3.transform, 30, 25, 0, 1, 120, -65);
                    UI.MoveTransform(subWindowCheck2.Item1, 160, 16, 0, 1, 205, -60);
                    _subWindow2 = subWindowCheck2.Item3;

                    var uiHiden2Check = UI.AddCheckbox(_multiDisplayMenu.transform, "UI Hidden 2", "UI Hidden", Options.Instance.uiHidden2, (check) =>
                    {
                        Options.Instance.uiHidden2 = check;
                        Plugin.multiDisplayController.SetCamUI(2, check);
                    });
                    UI.MoveTransform(uiHiden2Check.Item3.transform, 30, 25, 0, 1, 120, -85);
                    UI.MoveTransform(uiHiden2Check.Item1, 160, 16, 0, 1, 205, -80);

                    var fov2Input = UI.AddTextInput(_multiDisplayMenu.transform, "FOV 2", "FOV", Options.Instance.subCamera2FOV.ToString(), (value) =>
                    {
                        float res;
                        if (float.TryParse(value, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture.NumberFormat, out res))
                        {
                            Options.Instance.subCamera2FOV = res;
                            Plugin.multiDisplayController.SetCamFov(2, res);
                        }
                    });
                    UI.MoveTransform(fov2Input.Item1, 60, 16, 0, 1, 105, -100);
                    UI.MoveTransform(fov2Input.Item3.transform, 30, 20, 0.1f, 1, 125, -100);

                    var mainCopy2Button = UI.AddButton(_multiDisplayMenu.transform, "Main Cam Copy 2", "Main Cam Copy", () =>
                    {
                        if (Plugin.multiDisplayController.SetMainCamPos(2))
                            _message.text = "Sub Camera 2 Copy!";
                        else
                            _message.text = "";
                    });
                    UI.MoveTransform(mainCopy2Button.transform, 70, 25, 0, 1, 140, -125);
                }

                if (Display.displays.Length > 3)
                {
                    var subWindowCheck3 = UI.AddCheckbox(_multiDisplayMenu.transform, "Sub Window 3", "Sub Window 3", Options.Instance.subWindow3, (check) =>
                    {
                        _message.text = "";
                        if (MultiDisplayController.activeWindow > 3)
                        {
                            _subWindow3.isOn = true;
                            _message.text = deleteDisplayMessage;
                            return;
                        }
                        if (check)
                        {
                            _subWindow1.isOn = true;
                            _subWindow2.isOn = true;
                        }
                        Options.Instance.subWindow3 = check;
                    });
                    UI.MoveTransform(subWindowCheck3.Item3.transform, 30, 25, 0, 1, 220, -65);
                    UI.MoveTransform(subWindowCheck3.Item1, 160, 16, 0, 1, 305, -60);
                    _subWindow3 = subWindowCheck3.Item3;

                    var uiHiden3Check = UI.AddCheckbox(_multiDisplayMenu.transform, "UI Hidden 3", "UI Hidden", Options.Instance.uiHidden3, (check) =>
                    {
                        Options.Instance.uiHidden3 = check;
                        Plugin.multiDisplayController.SetCamUI(3, check);
                    });
                    UI.MoveTransform(uiHiden3Check.Item3.transform, 30, 25, 0, 1, 220, -85);
                    UI.MoveTransform(uiHiden3Check.Item1, 160, 16, 0, 1, 305, -80);

                    var fov3Input = UI.AddTextInput(_multiDisplayMenu.transform, "FOV 3", "FOV", Options.Instance.subCamera3FOV.ToString(), (value) =>
                    {
                        float res;
                        if (float.TryParse(value, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture.NumberFormat, out res))
                        {
                            Options.Instance.subCamera3FOV = res;
                            Plugin.multiDisplayController.SetCamFov(3, res);
                        }
                    });
                    UI.MoveTransform(fov3Input.Item1, 60, 16, 0, 1, 205, -100);
                    UI.MoveTransform(fov3Input.Item3.transform, 30, 20, 0.1f, 1, 225, -100);

                    var mainCopy3Button = UI.AddButton(_multiDisplayMenu.transform, "Main Cam Copy 3", "Main Cam Copy", () =>
                    {
                        if (Plugin.multiDisplayController.SetMainCamPos(3))
                            _message.text = "Sub Camera 3 Copy!";
                        else
                            _message.text = "";
                    });
                    UI.MoveTransform(mainCopy3Button.transform, 70, 25, 0, 1, 240, -125);
                }

                var createButton = UI.AddButton(_multiDisplayMenu.transform, "Create Window", "Create Window", () =>
                {
                    Plugin.multiDisplayController.CreateDisplay();
                    if (MultiDisplayController.createDisplayActive)
                        _message.text = "Window Create!";
                    else
                        _message.text = "";
                });
                UI.MoveTransform(createButton.transform, 70, 25, 0, 1, 50, -185);

                var saveLayoutButton = UI.AddButton(_multiDisplayMenu.transform, "Save Layout", "Save Window Layout", () =>
                {
                    if(Plugin.multiDisplayController.SaveWindowLayout())
                        _message.text = "Save Window Layout!";
                    else
                        _message.text = "";
                });
                UI.MoveTransform(saveLayoutButton.transform, 70, 25, 0, 1, 140, -185);

                var resetLayoutButton = UI.AddButton(_multiDisplayMenu.transform, "Reset Layout", "Reset Window Layout", () =>
                {
                    if(Plugin.multiDisplayController.ResetWindowLayout())
                        _message.text = "Reset Layout!";
                    else
                        _message.text = "";
                });
                UI.MoveTransform(resetLayoutButton.transform, 70, 25, 0, 1, 240, -185);

                var resetCamButton = UI.AddButton(_multiDisplayMenu.transform, "Reset Cam Pos", "Reset Cam Pos", () =>
                {
                    Plugin.multiDisplayController.ResetCamPos(1);
                    Plugin.multiDisplayController.ResetCamPos(2);
                    Plugin.multiDisplayController.ResetCamPos(3);
                    _message.text = "Reset Camera Position!";
                });
                UI.MoveTransform(resetCamButton.transform, 70, 25, 0, 1, 50, -215);

                var saveButton = UI.AddButton(_multiDisplayMenu.transform, "Save Cam Pos", "Save Cam Pos", () =>
                {
                    if(Plugin.multiDisplayController.SaveCamPostion())
                        _message.text = "Save Camera Position!";
                    else
                        _message.text = "";
                });
                UI.MoveTransform(saveButton.transform, 70, 25, 0, 1, 140, -215);
            }
            else
            {
                _message.text = "Not multi-display!";
            }

            var closeButton = UI.AddButton(_multiDisplayMenu.transform, "Close", "Close", () =>
            {
                _message.text = "";
                _multiDisplayMenu.SetActive(false);
            });
            UI.MoveTransform(closeButton.transform, 70, 25, 0, 1, 240, -215);

            _multiDisplayMenu.SetActive(false);

            UI._extensionBtn.Click = () =>
            {
                _multiDisplayMenu.SetActive(!_multiDisplayMenu.activeSelf);
            };
        }
    }
}
