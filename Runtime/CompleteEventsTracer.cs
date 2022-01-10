using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace Kogane.CompleteEventsTracer
{
    /// <summary>
    /// Complete Events を計測するクラス
    /// </summary>
    public sealed class CompleteEventsTracer
    {
        private readonly List<TraceEventScope> m_list = new();

        /// <summary>
        /// 計測を開始します
        /// </summary>
        /// <param name="name">トレースビューワに表示されるイベント名</param>
        /// <param name="category">イベントのカテゴリ</param>
        /// <param name="processId">このイベントを出力したプロセスのプロセス ID</param>
        /// <param name="threadId">このイベントを出力したスレッドのスレッド ID</param>
        /// <returns>イベントのスコープを管理するインスタンス</returns>
        [MustUseReturnValue]
        public TraceEventScope Start
        (
            string name,
            string category  = "",
            long   processId = 0,
            long   threadId  = 0
        )
        {
            var scope = new TraceEventScope
            (
                name: name,
                category: category,
                processId: processId,
                threadId: threadId
            );

            m_list.Add( scope );

            return scope;
        }

        /// <summary>
        /// 計測結果を JSON 文字列に変換して返します
        /// </summary>
        /// <param name="prettyPrint">フォーマットする場合 true</param>
        /// <returns>計測結果を表す JSON 文字列</returns>
        [MustUseReturnValue]
        public string ToJson( bool prettyPrint = false )
        {
            var traceEvents = m_list
                    .Select( x => x.CreateTraceEvent() )
                    .ToArray()
                ;

            var jsonObject = new JsonCompleteEvents( traceEvents );
            var json       = JsonUtility.ToJson( jsonObject, prettyPrint );

            return json;
        }
    }
}