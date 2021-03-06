vmon   - Visualizer for URG-X Series        Version 2008/04/16

----------------------------------------
ソース構成及びライセンス

 glt:
      GLT OpenGL C++ toolkit (http://www.nigels.com/glt/)
      LGPL

 freeglut-2.4.0:
      The Free OpenGL Utility Toolkit (http://freeglut.sourceforge.net/)
      X-Consortium license.

 src:
      本体ソース


----------------------------------------
動作確認環境
 OS:      Windows XP SP2, Windows Vista SP1
 センサ:  URG-04LX, TOP-URG, Rapid-URG, Hi-URG, Rapid-URG

----------------------------------------
起動方法

 実行ファイル vmon を起動します。コマンドラインオプションはありません。
 起動後にポップアップメニューからセンサを接続したポートを選択してください。
 Linux 版では
  /dev/ttyS0
  /dev/ttyS1
  /dev/usb/tts/0
  /dev/usb/tts/1
 が、メニューにあります。Windows版では同様に COM1〜COM16までがメニューに
 あります。

 これらとは別のポートを使用する場合は、環境変数 URG_PORT か、RSX_PORTに
 ポート名を設定しておくと、そのポートもメニューに追加されます。

----------------------------------------
キー操作

 "q", ESC
    終了します。

 "r"
    ビューを初期状態にリセットします。

 "," "."
    ビューを45度回転します。

 "a","z"
    ビューをY軸周りに10度回転します。

 "x","c"
    ビューをX軸周りに10度回転します。
    
 "g" "b"
    ビューを上下に移動します

 "n" "m"
    ビューを左右に移動します

 TAB
    フルスクリーン表示とウィンドウ表示を切り替えます。

 "f"
    センサデータの表示方向(時計回り/反時計回り)を反転します。

 "1"〜"6","0"
    配色を変更します。
    1: デフォルトの配色。計測エラーは表示しない
    2: 背景色を白にした配色。計測エラーは塗りつぶして表現
    3: 緑を基調にした配色。計測エラーは塗りつぶして表現
    4: 青を基調にした配色。計測エラーは塗りつぶして表現
    5: 過去の距離データを点で表現する。計測エラーは塗りつぶして表現
    6: 半透明を使わない配色

    9: 全ての距離データを点で表現する。計測エラーは表示しない
    0: 9と同じだが、計測エラー領域は塗りつぶして表現。 

 "p"
    センサへのアクセスを一時停止、もしくは既に一時停止していた場合再開します。

 "o"
    表示する過去データ数を1減らします。デフォルトは10です。

 "O"
    表示する過去データ数を1に設定します
    
 "i"
    表示する過去データ数を1増やします(最大 30)

 "i"
    表示する過去データ数を30に設定します

 "u"
    表示する過去データ数を10に設定します。

 "s"
    表示されているデータをファイルに保存します。
    カレントディレクトリに
      "保存日時 保存時刻"
    というディレクトリを作成し、その中に
      "計測日時 計測時刻.csv"
    というファイル名の CSV ファイルを作成します。複数の過去データを表
    示している場合、全ての過去データが保存対象となります。

    記録内容は、
     [センサ出力値],[方位(rad)],[座標変換後のX(mm)],[座標変換後のY(mm)]
    の4つです。


 "l"
    レーザ出力許可/禁止 コマンドを発行します。

----------------------------------------
マウス操作

 マウス左ドラッグ
    ビューを回転します。

 マウス中ドラッグ
    ビューを移動します。

 マウス右クリック
    ポップアップメニュー

 マウスホイール
    ビューを拡大/縮小します。

 SHIFT+マウス左ドラッグ
    ビューを拡大/縮小します。

 CTRL+マウス左ドラッグ
    ビューを移動します。

----------------------------------------
ポップアップメニュー

 SensorParameters
  センサへ制御コマンドを発行します。
 
  - Reset
   未実装

  - Toggle Laser
   レーザ出力をトグルします。 "l" キーと同じです。

  - Point cluster
   - 1Pt〜4Pt
   計測結果のまとめ送り指示の設定を変更します。1Ptで全データ取得。2Pt 
   で隣り合う2点のうち近い方のみ取得します。3Pt, 4Pt は同様に3点、4点
   のうち近い方のみ取得します。デフォルトは 1Ptで、全データを取得しま
   す。

  Reset speed to ...

   通信速度設定。500000bpsはLinuxで対応する一部のハードウェアでのみ動作します。

   注意: PC側が対応できるかどうかにかかわらず、センサには通信速度変更
         コマンドを送るため、PC側が対応できない場合は以後通信不能とな
         ってしまいます。

 ViewControl
  表示変更

  - Pause/Resume
   センサへのアクセスを一時停止/再開します。"p"キーと同じです。

  - Reset view
   左ドラッグ、中ドラッグ、ホイール、","キー、"."キー等で変更した表示
   をデフォルトに戻します。ただし、"f"キーで変更したデータの表示順には
   影響しません。


 DisplayOpenGL Settting
  OpenGLの設定変更

  - Enable Alpha Blending
   過去データの表示を半透明にします。

  - Disable Alpha Blending
   過去データの表示に半透明を使いません。

  - Set view update rate to ...
   表示の更新頻度を秒間 それぞれ 5回, 10回, 30回, 50回 に変更します。
   センサへのアクセス頻度には影響しません。デフォルトは30回です。

 Quit 
  終了。"q" キーと同じ。
----------------------------------------
Tips

 *表示が遅い

  OpenGLのハードウェア支援のないビデオカードを使用する場合遅くなりがち
  です。まずは、Alpha Blending を禁止(Popup - DisplayOpenGL Setting -
  Disable Alpha Blending) してみてください。また、過去データの表示数を
  減らして("o"キー)みてください。

  それでも遅い場合はWindow表示にし、Windowのサイズを小さくリサイズして
  みてください。また、表示の更新頻度を下げると効果があるかもしれません。


 *通信が遅い

  USB接続で使用すると秒間10回全計測点が取得できます。また、Linuxで、ハー
  ドウェアが対応している場合 500kbs で通信するとやはり秒間10回全計測点
  が取得できます。

  115Kbps の場合、2点まとめ送り(SensorParameters - Point Cluster - 2Pt)
  にすると秒間10回の計測結果が取得できます。
----------------------------------------
