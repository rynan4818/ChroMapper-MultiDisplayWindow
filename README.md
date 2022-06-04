# ChroMapper-MultiDisplayWindow

カメラスクリプト作成ツールの[CameraMovement](https://github.com/rynan4818/ChroMapper-CameraMovement)にあるマルチディスプレイウィンドウ機能を、作譜用に別のプラグインにしました。

The multi-display window feature in the [CameraMovement](https://github.com/rynan4818/ChroMapper-CameraMovement) camera scripting tool has been made into a separate plug-in for mapping.

![image](https://user-images.githubusercontent.com/14249877/171408555-26aa9a59-d6be-4c33-91fb-fcdeea42f00d.png)

BeatSaberの作譜ツールの[ChroMapper](https://github.com/Caeden117/ChroMapper)で、マルチディスプレイ環境の時にマルチウィンドウで複数カメラで表示するプラグインです。

PCのディスプレイの数が2個以上のときに使用可能です。

メインウィンドウも含めてディスプレイの台数までウィンドウ表示できます。

4台以上のディスプレイ環境のときに、メイン画面以外に最大3個のサブウィンドウが表示可能です。

※本プラグインはWindowsでのみ動作可能です。(マルチディスプレイをウィンドウ表示するためにWindows APIを使用しています)

------------

This is a plug-in for [ChroMapper](https://github.com/Caeden117/ChroMapper), BeatSaber's mapping tool, to display multiple cameras in multiple windows in a multi-display environment.

Available when the number of PC displays is two or more.

Up to the number of displays, including the main window, can be windowed.

Up to three sub-windows can be displayed in addition to the main screen when four or more displays are used.

※This plug-in can only work on Windows. (Windows API is used to window multi-displays)
# インストール方法 (How to Install)

1. [リリースページ](https://github.com/rynan4818/ChroMapper-MultiDisplayWindow/releases)から、最新のプラグインのzipファイルをダウンロードして下さい。

    Download the latest plug-in zip file from the [release page](https://github.com/rynan4818/ChroMapper-MultiDisplayWindow/releases).

2. ダウンロードしたzipファイルを解凍してChroMapperのインストールフォルダにある`Plugins`フォルダに`ChroMapper-MultiDisplayWindow.dll`をコピーします。

    Unzip the downloaded zip file and copy `ChroMapper-MultiDisplayWindow.dll` to the `Plugins` folder in the ChroMapper installation folder.

# 使用方法 (Usage)

譜面を読み込んでエディタ画面を出して下さい。**Tabキー**を押すと右側にアイコンパネルが出ますので、オレンジ色のウィンドウアイコンを押すと下の設定パネルが開きます。

Load the map and bring up the editor screen. Press the **Tab key** to bring up the icon panel on the right side, then press the orange window icon to open the settings panel below.

![image](https://user-images.githubusercontent.com/14249877/171408730-aba1e9c1-d737-42e9-92a3-1890a3ffddf1.png)

- Display Counts = *
    - 現在のPCのディスプレイ数です。2以上で本プラグインを利用できます。4以上だと最大3個のウィンドウを作成できます。
    - The current number of displays on your PC. 2 or more allows you to use this plug-in. 4 or more allows you to create up to 3 windows.
- Sub Window 1～3
    - 表示するサブウィンドウの個数を選択します。
    - Select the number of sub-windows to display.
- UI Hidden
    - チェックすると、そのウィンドウでマッピング用のグリッド表示が消えます。
    - When checked, the grid display for mapping disappears in that window.
- FOV
    - カメラのFOVです。
    - Camera FOV.
- Main Cam Copy
    - 現在のメインウィンドウのカメラ位置をコピーします。
    - Copies the camera position in the current main window.
- Create Window
    - 現在の設定でマルチディスプレイ機能を有効にします。
    - Enable the multi-display feature in the current configuration.
- Save Window Layout
    - 現在のウィンドウレイアウトを保存し、次回Create Windowした時に再現します。
    - The current window layout is saved and reproduced the next time Create Window is used.
- Reset Window Layout
    - ウィンドウレイアウトをリセットします。
    - Resets the window layout.
- Reset Cam Pos
    - サブウィンドウのカメラ位置を保存した状態にリセットします。
    - Resets the camera position in the sub-window to the saved state.
- Save Cam Pos
    - 現在のサブウィンドウのカメラ位置を保存します。
    - Saves the camera position in the current subwindow
- Close
    - 設定パネルを閉じます。
    - Close the settings panel.

サブウィンドウを選択中は、カメラの移動操作は選択しているウィンドウが対象になります。

一度作成したサブウィンドウはUnityの仕様でChroMapperを終了するまで閉じることができません。

サブウィンドウはモニタのアスペクト比に依存するため、サイズ変更はアスペクト比固定になっています。

マルチディスプレイモード時にメインウィンドウのサイズを変更すると、画面が崩れることがありますがウィンドウをドラッグで移動すると直ります。

動作不良を起こすため[ChroMapper-CameraMovement](https://github.com/rynan4818/ChroMapper-CameraMovement)のマルチウィンドウ機能と同時使用しないでください。

----

While a sub-window is selected, the camera movement operation targets the selected window.

Once a sub-window is created, it cannot be closed until ChroMapper is closed due to Unity specifications.

Since the sub-window depends on the aspect ratio of the monitor, resizing is fixed to the aspect ratio.

If the main window is resized in multi-display mode, the screen may collapse, but this can be fixed by dragging the window.

Do not use simultaneously with the multi-window function of [ChroMapper-CameraMovement](https://github.com/rynan4818/ChroMapper-CameraMovement) as it may cause malfunction.

## 設定ファイルについて (About the configuration file)
設定ファイルはChroMapperの設定ファイルと同じフォルダ`ユーザ設定フォルダ(Users)\ユーザ名\AppData\LocalLow\BinaryElement\ChroMapper`の`MultiDisplayWindow.json`に保存されます。

The configuration file is saved in `MultiDisplayWindow.json` in the same folder as ChroMapper's configuration file `User Settings Folder(Users)\User Name\AppData\LocalLow\BinaryElement\ChroMapper`.

プラグインのUIで設定できない項目の説明は以下です。

The following is a description of the items that cannot be set in the plugin UI.

| 設定項目 (Setting Item) | デフォルト値 (Default Value) | 説明 (Description) |
|:---|:---|:---|
| multiDislayCreateDelay | 0.1 | マルチディスプレイ作成時のディレイ時間(秒)。作成時に異常動作する場合は値を増やして下さい<br>Delay time (seconds) when creating a multi-display. Increase the value if abnormal operation occurs during creation. |
| defaultCameraActiveKeyBinding | ＜Mouse＞/rightButton | サブウィンドウ用カメラ移動の有効キーバインドです<br>Enabled key bindings for camera movement for subwindows. |
| defaultCameraElevatePositiveKeyBinding | ＜Keyboard＞/space | サブウィンドウ用カメラ移動の上移動キーバインドです<br>Up movement key bindings for camera movement for sub-windows. |
| defaultCameraElevateNegativeKeyBinding | ＜Keyboard＞/ctrl | サブウィンドウ用カメラ移動の下移動キーバインドです<br>Down movement key bindings for camera movement for sub-windows. |
| defaultCameraMoveUpKeyBinding | ＜Keyboard＞/w | サブウィンドウ用カメラ移動の前移動キーバインドです<br>Forward movement key bindings for camera movement for sub-windows. |
| defaultCameraMoveLeftKeyBinding | ＜Keyboard＞/a | サブウィンドウ用カメラ移動の左移動キーバインドです<br>Left movement key bindings for camera movement for sub-windows.|
| defaultCameraMoveDownKeyBinding | ＜Keyboard＞/s | サブウィンドウ用カメラ移動の後移動キーバインドです<br>Backward movement key bindings for camera movement for sub-windows. |
| defaultCameraMoveRightKeyBinding | ＜Keyboard＞/d | サブウィンドウ用カメラ移動の右移動キーバインドです<br>Right movement key bindings for camera movement for sub-windows. |

キーバインドはUnityのInputSystem形式で設定してください。<Br>
Key bindings should be set in Unity's InputSystem format.
