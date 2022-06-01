# ChroMapper-MultiDisplayWindow

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
    - Resets the camera position in the subwindow to the saved state.
- Save Cam Pos
    - 現在のサブウィンドウのカメラ位置を保存します。
    - Saves the camera position in the current subwindow
- Close
    - 設定パネルを閉じます。
    - Close the settings panel.


一度作成したウィンドウはUnityの仕様でChroMapperを終了するまで閉じることができません。

動作不良を起こすため[ChroMapper-CameraMovement](https://github.com/rynan4818/ChroMapper-CameraMovement)のマルチウィンドウ機能と同時使用しないでください。

Once a window is created, it cannot be closed until ChroMapper is closed due to Unity specifications.

Do not use simultaneously with the multi-window function of [ChroMapper-CameraMovement](https://github.com/rynan4818/ChroMapper-CameraMovement) as it may cause malfunction.
