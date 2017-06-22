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
        for (int i = 0; i < 10000; i++)
        {
            RxDispatcher.Instance.Enqueue(() =>
                {
                    //TextFieldToUpdate.text = "Running item " + i.ToString();
                }
            );
        }
    }

    private void LongOperation(string delayText)
    {
        System.Threading.Thread.Sleep(3000); // main thread blocker
        // Update UI - proves we work on the main thread
        TextFieldToUpdate.text = delayText + " blocking work complete. " + System.DateTime.Now.ToString();
    }
}
