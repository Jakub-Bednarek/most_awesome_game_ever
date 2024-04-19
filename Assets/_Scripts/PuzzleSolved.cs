using UnityEngine;
using TMPro;

namespace _Scripts
{
    public class PuzzleSolved : MonoBehaviour
    {
        public bool isFinished = false;
        public Door doorObject;
        public Canvas canvas;
        
        void Update()
        {
            if (!isFinished)
            {
                foreach (Transform row in transform)
                {
                    foreach (Transform element in row)
                    {
                        Transform elementCapsule = element.Find("Capsule");
                        if (elementCapsule.GetComponent<Renderer>().material.color == elementCapsule.GetComponent<LightsOutPuzzleController>().defaultColor)
                        {
          				    isFinished = false;
          				    break;
                        }

                        isFinished = true;
                    }
                    if (!isFinished)
                        break;
                }

                if (isFinished)
                {
                    foreach (Transform row in transform)
                        foreach (Transform element in row)
                            element.Find("Capsule").gameObject.GetComponent<LightsOutPuzzleController>().isFinished = true;
                    
                    doorObject.isLocked = false;
                    canvas.gameObject.SetActive(true);
                    canvas.transform.Find("TextMain").GetComponent<TextMeshProUGUI>().text = "Udało się";
                    canvas.transform.Find("TextSub").GetComponent<TextMeshProUGUI>().text = "Drzwi otwarte";
                }
            }
                
        		// bool exitLoop = false;
          //   	foreach (Transform row in transform)
          //   	   {
          //   	    foreach (Transform element in row)
          //   	    {
          //   			if (element.Find("Capsule").GetComponent<Renderer>().material.color == defaultColor)
          //   			{
          //   				exitLoop = true;
          //   				isFinished = false;
          //   				break;
          //   			}
          //   	
          //   			isFinished = true;
          //   	    }
          //   	
          //   	    if (exitLoop)
          //   	    {
          //   		    break;
          //   	  }
          //   	  else
          //   	  {
          //   	   doorObject.isLocked = false;
          //   	  }
            }
        }
    }

