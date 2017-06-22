using UnityEngine;
using UnityEngine.UI;

public class FrameCounter : MonoBehaviour {
    public Text TextFieldToUpdate;
	
	void Update () {

        if (TextFieldToUpdate != null)
            TextFieldToUpdate.text = Time.frameCount.ToString();	
	}
}
