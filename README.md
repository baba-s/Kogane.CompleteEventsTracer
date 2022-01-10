# Kogane Complete Events Tracer

計測した処理時間を Chrome でプロファイリングできるようにするパッケージ

## 使用例

```cs
using System.IO;
using System.Threading.Tasks;
using Kogane.CompleteEventsTracer;
using UnityEngine;

public sealed class Example : MonoBehaviour
{
    private async void Start()
    {
        Debug.Log( "開始" );

        var tracer = new CompleteEventsTracer();

        async Task Process( string name, float duration )
        {
            using ( tracer.Start( name ) )
            {
                await Task.Delay( ( int ) ( duration * 1000 ) );
            }
        }

        await Process( "A", 0.1f );
        await Process( "B", 0.2f );
        await Process( "C", 0.3f );

        await Task.WhenAll
        (
            Process( "D", 0.3f ),
            Process( "E", 0.2f ),
            Process( "F", 0.1f )
        );

        await Process( "G", 0.1f );

        var json = tracer.ToJson();

        await File.WriteAllTextAsync( "result.json", json );

        Debug.Log( "完了" );
    }
}
```

たとえば上記のように CompleteEventsTracer クラスを使用して処理時間を計測し、  
その結果を JSON で result.json に出力します  

![](https://user-images.githubusercontent.com/6134875/148707198-525b10de-1ca7-4a62-8e96-c6cce0c0420d.png)

Chrome のアドレスバーに `chrome://tracing` と入力して  
表示されたページで「Load」を押して出力した result.json を選択します  

![](https://user-images.githubusercontent.com/6134875/148707199-c561a391-22ec-46b3-b93f-62e580bb9ba6.png)

これで計測した処理時間を Chrome 上でプロファイリングできます  