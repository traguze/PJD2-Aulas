using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectRef
{
    public string Name;
    public TransformRef Transform;
    public GameObjectRef[] Children;

    static public GameObjectRef FromObject(GameObject go)
    {
        var gor = new GameObjectRef()
        {
            Name = go.name,
            Transform = TransformRef.FromObject(go.transform),
        };

        return gor;
    }
}

public class TransformRef
{
    public float[] Position;
    public float[] Rotation;
    public float[] Scale;

    public static TransformRef FromObject(Transform tf)
    {
        var tfr = new TransformRef()
        {
            Position = tf.position.ToFloatArray(),
            Rotation = tf.rotation.eulerAngles.ToFloatArray(),
            Scale = tf.localScale.ToFloatArray(),
        };
        return tfr;
    }
}

