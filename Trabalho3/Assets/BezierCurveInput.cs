using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class BezierCurveInput : MonoBehaviour
{

    public List<BezierCurve> bc = new List<BezierCurve>();
    public InputField curvePicker;
    public int N=0;
    public int OldN = 0;
    public bool updated = false;

    private void SetN(string txt)
    {
        OldN = N>=0 ? N : 0;
        N = Convert.ToInt32(txt);
        Debug.Log(N);
        updated = true;
    }
    private void RemoveCurve()
    {
        var comps = gameObject.GetComponents(typeof(BezierCurve));
        Destroy(comps[comps.Length - 1]);
        bc.RemoveAt(bc.Count - 1);
    }
    private void AddCurve(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
    {
        var helper = gameObject.AddComponent<BezierCurve>();
        helper.SetPoints(a, b, c, d);
        bc.Add(helper);
    }
    //Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<InputField>();
        gameObject.GetComponent<InputField>().onEndEdit.AddListener(SetN);
        
    }

    //// Update is called once per frame
    void Update()
    {
        var diff = N - OldN;
        // generate random coordinates to feed new curves with
        var a = new Vector3(UnityEngine.Random.Range(bc.Count, bc.Count+1), UnityEngine.Random.Range(bc.Count, bc.Count+1), UnityEngine.Random.Range(bc.Count, bc.Count+1));
        var b = new Vector3(UnityEngine.Random.Range(bc.Count, bc.Count+1), UnityEngine.Random.Range(bc.Count, bc.Count+1), UnityEngine.Random.Range(bc.Count, bc.Count+1));
        var c = new Vector3(UnityEngine.Random.Range(bc.Count, bc.Count+1), UnityEngine.Random.Range(bc.Count, bc.Count+1), UnityEngine.Random.Range(bc.Count, bc.Count+1));
        var d = new Vector3(UnityEngine.Random.Range(bc.Count, bc.Count+1), UnityEngine.Random.Range(bc.Count, bc.Count+1), UnityEngine.Random.Range(bc.Count, bc.Count+1));
        if (updated)
        {
            // Empty list
            if (bc.Count == 0)
            {
                if (diff > 0)
                {

                    for (int i = 0; i < diff; i++)
                    {
                        AddCurve(a, b, c, d);
                        a = new Vector3(UnityEngine.Random.Range(bc.Count, bc.Count + 1), UnityEngine.Random.Range(bc.Count, bc.Count + 1), UnityEngine.Random.Range(bc.Count, bc.Count + 1));
                        b = new Vector3(UnityEngine.Random.Range(bc.Count, bc.Count + 1), UnityEngine.Random.Range(bc.Count, bc.Count + 1), UnityEngine.Random.Range(bc.Count, bc.Count + 1));
                        c = new Vector3(UnityEngine.Random.Range(bc.Count, bc.Count + 1), UnityEngine.Random.Range(bc.Count, bc.Count + 1), UnityEngine.Random.Range(bc.Count, bc.Count + 1));
                        d = new Vector3(UnityEngine.Random.Range(bc.Count, bc.Count + 1), UnityEngine.Random.Range(bc.Count, bc.Count + 1), UnityEngine.Random.Range(bc.Count, bc.Count + 1));
                    }

                    // else - do nothing
                }
            }
            // List has 1 Curve
            else
            {
                if (diff > 0)
                {
                    //add the remaining points?
                    for (int i = 0; i < diff; i++)
                    {
                        AddCurve(a, b, c, d);
                        a = new Vector3(UnityEngine.Random.Range(bc.Count, bc.Count + 1), UnityEngine.Random.Range(bc.Count, bc.Count + 1), UnityEngine.Random.Range(bc.Count, bc.Count + 1));
                        b = new Vector3(UnityEngine.Random.Range(bc.Count, bc.Count + 1), UnityEngine.Random.Range(bc.Count, bc.Count + 1), UnityEngine.Random.Range(bc.Count, bc.Count + 1));
                        c = new Vector3(UnityEngine.Random.Range(bc.Count, bc.Count + 1), UnityEngine.Random.Range(bc.Count, bc.Count + 1), UnityEngine.Random.Range(bc.Count, bc.Count + 1));
                        d = new Vector3(UnityEngine.Random.Range(bc.Count, bc.Count + 1), UnityEngine.Random.Range(bc.Count, bc.Count + 1), UnityEngine.Random.Range(bc.Count, bc.Count + 1));
                    }
                }

                if (diff < 0)
                {
                    //remove the extra points
                    for (int i = diff; i < 0 && bc.Count != 0; i++)
                    {
                        RemoveCurve();
                    }
                }
            }
        }
        if (bc.Count > 1)
        {
            // joins points
            for (int j = bc.Count - 1; j > 0; j--)
            {
                var last = bc[j].GetLastPoint();
                bc[j - 1].SetPoints(last, bc[j - 1].points[1], bc[j - 1].points[2], bc[j - 1].points[3]);
            }
        }
        // prevents over-generation of curves
        updated = false;
        
    }
}
