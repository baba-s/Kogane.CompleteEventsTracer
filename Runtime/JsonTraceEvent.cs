using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Kogane.CompleteEventsTracer
{
    // https://docs.google.com/document/d/1CvAClvFfyA5R-PhYUmn5OOQtYMH4h6I0nSsKchNAySU/preview
    [Serializable]
    [SuppressMessage( "ReSharper", "InconsistentNaming" )]
    [SuppressMessage( "ReSharper", "NotAccessedField.Local" )]
    internal sealed class JsonTraceEvent
    {
        // トレースビューワに表示されるイベント名
        [SerializeField] private string name;

        // イベントのカテゴリ
        // これはイベントのカテゴリをカンマで区切ったリストです
        // カテゴリは、トレースビューワのUIでイベントを非表示にするために使用することができます
        [SerializeField] private string cat;

        // イベントタイプ
        // 出力されるイベントの種類に応じて変化する1文字です
        [SerializeField] private string ph;

        // イベントのトレースクロックのタイムスタンプ
        // タイムスタンプはマイクロ秒の粒度で提供されます
        [SerializeField] private long ts;

        // イベントのトレースクロックの継続時間
        // タイムスタンプはマイクロ秒の粒度で提供されます
        [SerializeField] private double dur;

        // オプション
        // イベントのスレッドクロックのタイムスタンプ
        // タイムスタンプはマイクロ秒単位で提供されます
        [SerializeField] private long tts;

        // このイベントを出力したプロセスのプロセス ID
        [SerializeField] private long pid;

        // このイベントを出力したスレッドのスレッド ID
        [SerializeField] private long tid;

        public JsonTraceEvent
        (
            string name,
            string cat,
            string ph,
            long   ts,
            double dur,
            long   tts,
            long   pid,
            long   tid
        )
        {
            this.name = name;
            this.cat  = cat;
            this.ph   = ph;
            this.ts   = ts;
            this.tts  = tts;
            this.pid  = pid;
            this.tid  = tid;
            this.dur  = dur;
        }
    }
}