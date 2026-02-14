"""
Project: KISS KITSUNE
Module: OSC Trigger Sender
Description: ターミナルのフォーカスが外れていても、特定のキーでUnityへ信号を送信する。
"""
from pythonosc import udp_client
from pynput import keyboard

# OSC 設定
IP = "127.0.0.1"
PORT = 3333
ADDRESS = "/kiss_kitsune/trigger/color_change"
client = udp_client.SimpleUDPClient(IP, PORT)

print(f"Global Hotkey Active. Press [F9] to trigger. (Press [ESC] to exit)")

def on_press(key):
    try:
        # F9 キーが押されたら送信
        if key == keyboard.Key.f9:
            client.send_message(ADDRESS, 1.0)
            print(">>> OSC Trigger Sent (F9)")
    except AttributeError:
        pass

def on_release(key):
    # ESC キーでスクリプト終了
    if key == keyboard.Key.esc:
        return False

# リスナーの開始
with keyboard.Listener(on_press=on_press, on_release=on_release) as listener:
    listener.join()