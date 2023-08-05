using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceablePiece : MonoBehaviour
{
    [SerializeField] private float separationForce;
    [SerializeField] private List<FixedJoint> joint;
    [SerializeField] private List<Rigidbody> pieces;
    private ScoreManager scoreManager;
    private bool sliced;

    void Start()
    {
        pieces.ForEach(p => p.constraints  = RigidbodyConstraints.FreezeAll);
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void Slice()
    {
        if(sliced) return;

        joint.ForEach(x => Destroy(x));
        scoreManager.RaiseScore(1);

        foreach (var piece in pieces)
        {
            var direction = piece.transform.localPosition.normalized;
            piece.constraints = RigidbodyConstraints.None;
            piece.AddForce(direction * separationForce, ForceMode.Impulse);
        }

        sliced = true;
    }
}
