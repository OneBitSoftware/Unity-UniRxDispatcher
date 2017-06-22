using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class PerformWork : MonoBehaviour
{
    public Text TextFieldToUpdate;


    public void DoSingleItemWork_Click()
    {
        RxDispatcher.Instance.Enqueue(() =>
        {
            LongOperation("3000ms");
        });
    }

    public void DoMultipleItemsWork_Click()
    {
        RxDispatcher.Instance.Enqueue(() => 
            LongOperation("3000ms")
         );

        RxDispatcher.Instance.Enqueue(() => 
            LongOperation("6000ms")
        );

        RxDispatcher.Instance.Enqueue(() => 
            LongOperation("9000ms")
        );
    }

    public void DoBulkWork_Click()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < 1000000; i++)
        {
            RxDispatcher.Instance.Enqueue(() =>
                {
                    if (TextFieldToUpdate != null)
                        TextFieldToUpdate.text = i.ToString() + " item took " + sw.ElapsedMilliseconds.ToString();
                }
            );
        }

        //sw.Stop(); leave it to be killed
    }

    private void LongOperation(string delayText)
    {
        System.Threading.Thread.Sleep(3000); // main thread blocker
        // Update UI - proves we work on the main thread
        TextFieldToUpdate.text = delayText + " blocking work complete. " + System.DateTime.Now.ToString();
    }
}
