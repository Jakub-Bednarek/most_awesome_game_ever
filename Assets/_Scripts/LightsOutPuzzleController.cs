using UnityEngine;
using UnityEngine.UI;

namespace _Scripts
{
    public class LightsOutPuzzleController : MonoBehaviour, IInteractable
    {
        public Color defaultColor = Color.white;
        public Color actionColor = Color.black;
        public bool isFinished = false;

        // ReSharper disable Unity.PerformanceAnalysis
        public void Interact(FPSController player)
        {
            if (!isFinished)
                foreach (Transform row in gameObject.transform.root)
                foreach (Transform element in row)
                    if (gameObject.transform == element.Find("Capsule"))
                    {
                        var rowCount = row.GetSiblingIndex();
                        var elementCount = element.GetSiblingIndex();
                        ColorChange(element);

                        if (elementCount != 0) ColorChange(row.GetChild(elementCount - 1));

                        if (elementCount != 4) ColorChange(row.GetChild(elementCount + 1));

                        if (rowCount != 0)
                            ColorChange(gameObject.transform.root.GetChild(rowCount - 1).GetChild(elementCount));

                        if (rowCount != 4)
                            ColorChange(gameObject.transform.root.GetChild(rowCount + 1).GetChild(elementCount));
                    }

            // 	bool exitLoop = false;
            // 	foreach (Transform row in transform)
            // 	   {
            // 	    foreach (Transform element in row)
            // 	    {
            // 			if (element.Find("Capsule").GetComponent<Renderer>().material.color == defaultColor)
            // 			{
            // 				exitLoop = true;
            // 				isFinished = false;
            // 				break;
            // 			}
            // 	
            // 			isFinished = true;
            // 	    }
            // 	
            // 	    if (exitLoop)
            // 	    {
            // 		    break;
            // 	    }
            // 	   }
            // 	  }
            // 	  else
            // 	  {
            // 	   doorObject.isLocked = false;
            // 	  }
            // }

            void ColorChange(Transform element)
            {
                var elementRenderer = element.Find("Capsule").GetComponent<Renderer>();
                elementRenderer.material.color =
                    elementRenderer.material.color == defaultColor ? actionColor : defaultColor;
            }
        }
    }
}