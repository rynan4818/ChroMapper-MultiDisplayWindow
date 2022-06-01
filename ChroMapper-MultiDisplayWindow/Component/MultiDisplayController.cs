using UnityEngine;
using System;
using System.Collections;
using ChroMapper_MultiDisplayWindow.Controller;
using ChroMapper_MultiDisplayWindow.Configuration;

namespace ChroMapper_MultiDisplayWindow.Component
{
    public class MultiDisplayController : MonoBehaviour
    {
        public static (bool, IntPtr, int, int, string)[] windowInfos = new (bool, IntPtr, int, int, string)[4];
        public static bool createDisplayActive = false;
        public const string subWindow1Name = "Sub Window 1";
        public const string subWindow2Name = "Sub Window 2";
        public const string subWindow3Name = "Sub Window 3";
        public const string defaultWindowName = "Unity Secondary Display";
        public static int activeWindowNumber;
        public static DefaultCameraController defaultCameraController;
        public static ActionMapsController actionMapsController;
        public static Camera[] subCamera = new Camera[3];
        public static int activeCameraCount;
        public static GameObject mapEditorCamera;

        public void CreateDisplay()
        {
            if (Display.displays.Length <= 1)
                return;
            if (Plugin.activeWindow >= 4)
                return;
            if (createDisplayActive)
                return;
            if (Options.Instance.subWindow1 || Options.Instance.subWindow2 || Options.Instance.subWindow3)
                StartCoroutine("DelayWindow");
        }
        private IEnumerator DelayWindow()
        {
            createDisplayActive = true;
            var mainPosSize = WindowController.getWindowPosSize(Application.productName);
            var beforeActiveWindow = Plugin.activeWindow;
            if (!Display.displays[1].active && Options.Instance.subWindow1)
            {
                Debug.Log("Sub Display 1 Active");
                Display.displays[1].Activate();
                yield return new WaitForSeconds(Options.Instance.multiDislayCreateDelay);
                if (Options.Instance.subDisplay1Width == 0)
                    windowInfos[1] = WindowController.windowReplace(defaultWindowName, subWindow1Name, mainPosSize.Item1 + 100, mainPosSize.Item2 + 100, 0.5, false);
                else
                    windowInfos[1] = WindowController.windowReplace(defaultWindowName, subWindow1Name, (int)Options.Instance.subDisplay1PosX, (int)Options.Instance.subDisplay1PosY, (int)Options.Instance.subDisplay1Width, (int)Options.Instance.subDisplay1Height, false);
                yield return new WaitForSeconds(Options.Instance.multiDislayCreateDelay);
                Plugin.activeWindow = 2;
            }
            if (Display.displays.Length > 2 && !Display.displays[2].active && Options.Instance.subWindow1 && Options.Instance.subWindow2)
            {
                Debug.Log("Sub Display 2 Active");
                Display.displays[2].Activate();
                yield return new WaitForSeconds(Options.Instance.multiDislayCreateDelay);
                if (Options.Instance.subDisplay2Width == 0)
                    windowInfos[2] = WindowController.windowReplace(defaultWindowName, subWindow2Name, mainPosSize.Item1 + 100, mainPosSize.Item2 + 200, 0.5, false);
                else
                    windowInfos[2] = WindowController.windowReplace(defaultWindowName, subWindow2Name, (int)Options.Instance.subDisplay2PosX, (int)Options.Instance.subDisplay2PosY, (int)Options.Instance.subDisplay2Width, (int)Options.Instance.subDisplay2Height, false);
                yield return new WaitForSeconds(Options.Instance.multiDislayCreateDelay);
                Plugin.activeWindow = 3;
            }
            if (Display.displays.Length > 3 && !Display.displays[3].active && Options.Instance.subWindow1 && Options.Instance.subWindow2 && Options.Instance.subWindow3)
            {
                Debug.Log("Sub Display 3 Active");
                Display.displays[3].Activate();
                yield return new WaitForSeconds(Options.Instance.multiDislayCreateDelay);
                if (Options.Instance.subDisplay3Width == 0)
                    windowInfos[3] = WindowController.windowReplace(defaultWindowName, subWindow3Name, mainPosSize.Item1 + 100, mainPosSize.Item2 + 300, 0.5, false);
                else
                    windowInfos[3] = WindowController.windowReplace(defaultWindowName, subWindow3Name, (int)Options.Instance.subDisplay3PosX, (int)Options.Instance.subDisplay3PosY, (int)Options.Instance.subDisplay3Width, (int)Options.Instance.subDisplay3Height, false);
                yield return new WaitForSeconds(Options.Instance.multiDislayCreateDelay);
                Plugin.activeWindow = 4;
            }
            if (beforeActiveWindow != Plugin.activeWindow)
            {
                if (Options.Instance.mainDisplayWidth == 0)
                    windowInfos[0] = WindowController.windowReplace(Application.productName, null, mainPosSize.Item1, mainPosSize.Item2, mainPosSize.Item3, mainPosSize.Item4, false, 1);
                else
                    windowInfos[0] = WindowController.windowReplace(Application.productName, null, (int)Options.Instance.mainDisplayPosX, (int)Options.Instance.mainDisplayPosY, (int)Options.Instance.mainDisplayWidth, (int)Options.Instance.mainDisplayHeight, false, 1);
                yield return new WaitForSeconds(Options.Instance.multiDislayCreateDelay);
            }
            createDisplayActive = false;
            SetTargetDisplay();
        }
        public void SetTargetDisplay()
        {
            if (Plugin.activeWindow - 1 > activeCameraCount && activeCameraCount == 0)
            {
                Debug.Log("Sub Camera 1 Active");
                defaultCameraController = this.gameObject.AddComponent<DefaultCameraController>();
                subCamera[0] = new GameObject("Sub Camera 1").AddComponent<Camera>();
                subCamera[0].clearFlags = CameraClearFlags.SolidColor;
                subCamera[0].backgroundColor = new Color(0, 0, 0, 255);
                defaultCameraController.targetCamera[1] = subCamera[0];
                subCamera[0].targetDisplay = 1;
                ResetCamPos(1);
                SetCamUI(1, Options.Instance.uiHidden1);
                SetCamFov(1, Options.Instance.subCamera1FOV);
                actionMapsController = this.gameObject.AddComponent<ActionMapsController>();  //マルチディスプレイを有効にするまでactionMapsControllerはアクティブにしない
                activeCameraCount = 1;
            }
            if (Plugin.activeWindow - 1 > activeCameraCount && activeCameraCount == 1)
            {
                Debug.Log("Sub Camera 2 Active");
                subCamera[1] = new GameObject("Sub Camera 2").AddComponent<Camera>();
                subCamera[1].clearFlags = CameraClearFlags.SolidColor;
                subCamera[1].backgroundColor = new Color(0, 0, 0, 255);
                defaultCameraController.targetCamera[2] = subCamera[1];
                subCamera[1].targetDisplay = 2;
                ResetCamPos(2);
                SetCamUI(2, Options.Instance.uiHidden2);
                SetCamFov(2, Options.Instance.subCamera2FOV);
                activeCameraCount = 2;
            }
            if (Plugin.activeWindow - 1 > activeCameraCount && activeCameraCount == 1)
            {
                Debug.Log("Sub Camera 3 Active");
                subCamera[2] = new GameObject("Sub Camera 3").AddComponent<Camera>();
                subCamera[2].clearFlags = CameraClearFlags.SolidColor;
                subCamera[2].backgroundColor = new Color(0, 0, 0, 255);
                defaultCameraController.targetCamera[3] = subCamera[2];
                subCamera[2].targetDisplay = 3;
                ResetCamPos(3);
                SetCamUI(3, Options.Instance.uiHidden3);
                SetCamFov(3, Options.Instance.subCamera3FOV);
                activeCameraCount = 3;
            }
        }
        public void SaveWindowLayout()
        {
            if (Plugin.activeWindow < 2)
                return;
            var mainDisplay = WindowController.getWindowPosSize(Application.productName);
            Options.Instance.mainDisplayPosX = mainDisplay.Item1;
            Options.Instance.mainDisplayPosY = mainDisplay.Item2;
            Options.Instance.mainDisplayWidth = mainDisplay.Item3;
            Options.Instance.mainDisplayHeight = mainDisplay.Item4;
            var subDisplay1 = WindowController.getWindowPosSize(windowInfos[1].Item2);
            Options.Instance.subDisplay1PosX = subDisplay1.Item1;
            Options.Instance.subDisplay1PosY = subDisplay1.Item2;
            Options.Instance.subDisplay1Width = subDisplay1.Item3;
            Options.Instance.subDisplay1Height = subDisplay1.Item4;
            if (Plugin.activeWindow == 3)
            {
                var subDisplay2 = WindowController.getWindowPosSize(windowInfos[2].Item2);
                Options.Instance.subDisplay2PosX = subDisplay2.Item1;
                Options.Instance.subDisplay2PosY = subDisplay2.Item2;
                Options.Instance.subDisplay2Width = subDisplay2.Item3;
                Options.Instance.subDisplay2Height = subDisplay2.Item4;
            }
            if (Plugin.activeWindow == 4)
            {
                var subDisplay3 = WindowController.getWindowPosSize(windowInfos[3].Item2);
                Options.Instance.subDisplay3PosX = subDisplay3.Item1;
                Options.Instance.subDisplay3PosY = subDisplay3.Item2;
                Options.Instance.subDisplay3Width = subDisplay3.Item3;
                Options.Instance.subDisplay3Height = subDisplay3.Item4;
            }
            Options.Instance.SettingSave();
        }
        public void SaveCamPostion()
        {
            if (Plugin.activeWindow < 2)
                return;
            if (subCamera[0] != null)
            {
                Options.Instance.subCamera1PosX = subCamera[0].transform.position.x;
                Options.Instance.subCamera1PosY = subCamera[0].transform.position.y;
                Options.Instance.subCamera1PosZ = subCamera[0].transform.position.z;
                Options.Instance.subCamera1RotX = subCamera[0].transform.eulerAngles.x;
                Options.Instance.subCamera1RotY = subCamera[0].transform.eulerAngles.y;
                Options.Instance.subCamera1RotZ = subCamera[0].transform.eulerAngles.z;
                Options.Instance.subCamera1FOV = subCamera[0].fieldOfView;
            }
            if (subCamera[1] != null)
            {
                Options.Instance.subCamera2PosX = subCamera[1].transform.position.x;
                Options.Instance.subCamera2PosY = subCamera[1].transform.position.y;
                Options.Instance.subCamera2PosZ = subCamera[1].transform.position.z;
                Options.Instance.subCamera2RotX = subCamera[1].transform.eulerAngles.x;
                Options.Instance.subCamera2RotY = subCamera[1].transform.eulerAngles.y;
                Options.Instance.subCamera2RotZ = subCamera[1].transform.eulerAngles.z;
                Options.Instance.subCamera2FOV = subCamera[1].fieldOfView;
            }
            if (subCamera[2] != null)
            {
                Options.Instance.subCamera3PosX = subCamera[2].transform.position.x;
                Options.Instance.subCamera3PosY = subCamera[2].transform.position.y;
                Options.Instance.subCamera3PosZ = subCamera[2].transform.position.z;
                Options.Instance.subCamera3RotX = subCamera[2].transform.eulerAngles.x;
                Options.Instance.subCamera3RotY = subCamera[2].transform.eulerAngles.y;
                Options.Instance.subCamera3RotZ = subCamera[2].transform.eulerAngles.z;
                Options.Instance.subCamera3FOV = subCamera[2].fieldOfView;
            }
            Options.Instance.SettingSave();
        }

        public void ResetWindowLayout()
        {
            Options.Instance.mainDisplayPosX = 0;
            Options.Instance.mainDisplayPosY = 0;
            Options.Instance.mainDisplayWidth = 0;
            Options.Instance.mainDisplayHeight = 0;
            Options.Instance.subDisplay1PosX = 0;
            Options.Instance.subDisplay1PosY = 0;
            Options.Instance.subDisplay1Width = 0;
            Options.Instance.subDisplay1Height = 0;
            Options.Instance.subDisplay2PosX = 0;
            Options.Instance.subDisplay2PosY = 0;
            Options.Instance.subDisplay2Width = 0;
            Options.Instance.subDisplay2Height = 0;
            Options.Instance.subDisplay3PosX = 0;
            Options.Instance.subDisplay3PosY = 0;
            Options.Instance.subDisplay3Width = 0;
            Options.Instance.subDisplay3Height = 0;
            if (Plugin.activeWindow < 2)
                return;
            var mainPosSize = WindowController.getWindowPosSize(Application.productName);
            WindowController.windowReplace(windowInfos[0].Item2, null, mainPosSize.Item1, mainPosSize.Item2, mainPosSize.Item3, mainPosSize.Item4, false);
            WindowController.windowReplace(windowInfos[1].Item2, null, mainPosSize.Item1 + 100, mainPosSize.Item2 + 100, (int)(windowInfos[1].Item3 * 0.5), (int)(windowInfos[1].Item4 * 0.5), false);
            if (Plugin.activeWindow == 3)
                WindowController.windowReplace(windowInfos[2].Item2, null, mainPosSize.Item1 + 100, mainPosSize.Item2 + 200, (int)(windowInfos[2].Item3 * 0.5), (int)(windowInfos[2].Item4 * 0.5), false);
            if (Plugin.activeWindow == 4)
                WindowController.windowReplace(windowInfos[3].Item2, null, mainPosSize.Item1 + 100, mainPosSize.Item2 + 300, (int)(windowInfos[2].Item3 * 0.5), (int)(windowInfos[2].Item4 * 0.5), false);
        }
        public bool SetMainCamPos(int camNum)
        {
            if (subCamera[camNum - 1] == null)
                return false;
            subCamera[camNum - 1].transform.SetPositionAndRotation(mapEditorCamera.transform.position, mapEditorCamera.transform.rotation);
            return true;
        }
        public void SetCamFov(int camNum, float fov)
        {
            if (subCamera[camNum - 1] == null)
                return;
            subCamera[camNum - 1].fieldOfView = fov;
        }
        public void SetCamUI(int camNum, bool hidden)
        {
            if (subCamera[camNum - 1] == null)
                return;
            if (hidden)
                subCamera[camNum - 1].cullingMask &= ~(1 << 11);
            else
                subCamera[camNum - 1].cullingMask |= 1 << 11;
        }
        public void ResetCamPos(int camNum)
        {
            if (subCamera[camNum - 1] == null)
                return;
            var pos = new Vector3(Options.Instance.subCamera1PosX, Options.Instance.subCamera1PosY, Options.Instance.subCamera1PosZ);
            var rot = Quaternion.Euler(new Vector3(Options.Instance.subCamera1RotX, Options.Instance.subCamera1RotY, Options.Instance.subCamera1RotZ));
            if (camNum == 2)
            {
                pos = new Vector3(Options.Instance.subCamera2PosX, Options.Instance.subCamera2PosY, Options.Instance.subCamera2PosZ);
                rot = Quaternion.Euler(new Vector3(Options.Instance.subCamera2RotX, Options.Instance.subCamera2RotY, Options.Instance.subCamera2RotZ));
            }
            if (camNum == 3)
            {
                pos = new Vector3(Options.Instance.subCamera3PosX, Options.Instance.subCamera3PosY, Options.Instance.subCamera3PosZ);
                rot = Quaternion.Euler(new Vector3(Options.Instance.subCamera3RotX, Options.Instance.subCamera3RotY, Options.Instance.subCamera3RotZ));
            }
            subCamera[camNum - 1].transform.SetPositionAndRotation(pos, rot);
        }
        public void Start()
        {
            activeWindowNumber = -1;
            activeCameraCount = 0;
            subCamera[0] = null;
            subCamera[1] = null;
            subCamera[2] = null;
            mapEditorCamera = GameObject.Find("MapEditor Camera");
            SetTargetDisplay();
        }
        public void Update()
        {
            if (Plugin.activeWindow == 1)
            {
                activeWindowNumber = 0;
                return;
            }
            var window = WindowController.getForegroundWindowHandle();
            activeWindowNumber = -1;
            for (int i = 0; i < Plugin.activeWindow; i++)
            {
                if (windowInfos[i].Item2 == window)
                {
                    activeWindowNumber = i;
                    if (i > 0)
                        WindowController.windowAspectResize(windowInfos[i]);
                    break;
                }
            }
        }
    }
}
