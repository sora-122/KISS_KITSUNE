"""
Project: KISS_KITSUNE
Module: OSC Sender Test
Description: UnityへのOSC疎通確認用スクリプト。ランダムなfloat値を送信する。
"""
import argparse
import random
import time
from pythonosc import udp_client

def run_sender(ip="127.0.0.1", port=3333):
    client = udp_client.SimpleUDPClient(ip, port)
    address = "/kiss_kitsune/test/value"

    print(f"Start sending OSC to {ip}:{port} (Address: {address})")
    print("Press Ctrl+C to stop.")

    try:
        while True:
            value = random.random() # 0.0 - 1.0
            client.send_message(address, value)
            print(f"Sent: {value:.4f}")
            time.sleep(1.0)
    except KeyboardInterrupt:
        print("\nStopped.")

if __name__ == "__main__":
    run_sender()